using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

class PipeIPC
{
    string mPipeName = null;

    internal class PipeTmpl<T> where T : PipeStream
    {
        protected T pipeStream = null;
        public event EventHandler<String> DataReceived;
        public event EventHandler<EventArgs> PipeClosed;

        public void Close()
        {
            pipeStream.Flush();
            pipeStream.WaitForPipeDrain();
            pipeStream.Close();
            pipeStream = null;
        }

        public bool IsConnected() { return pipeStream.IsConnected; }

        public Task Send(string str)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            byte[] data = BitConverter.GetBytes(bytes.Length);
            byte[] buff = data.Concat(bytes).ToArray();
            return pipeStream.WriteAsync(buff, 0, buff.Length);
        }

        protected void initAsyncReader()
        {
            RunAsyncByteReader((b) => { DataReceived?.Invoke(this, Encoding.UTF8.GetString(b).TrimEnd('\0')); });
        }

        protected void RunAsyncByteReader(Action<byte[]> asyncReader)
        {
            int len = sizeof(int);
            byte[] buff = new byte[len];

            pipeStream.ReadAsync(buff, 0, len).ContinueWith((ret) =>
            {
                if (ret.IsFaulted || ret.Result == 0)
                {
                    if (ret.IsFaulted) AppLog.Line("Pipe read error: {0}", ret.Exception?.GetBaseException().Message);
                    PipeClosed?.Invoke(this, EventArgs.Empty);
                    return;
                }

                len = BitConverter.ToInt32(buff, 0);
                buff = new byte[len];
                pipeStream.ReadAsync(buff, 0, len).ContinueWith((ret2) =>
                {
                    if (ret2.IsFaulted || ret2.Result == 0)
                    {
                        if (ret2.IsFaulted) AppLog.Line("Pipe read error: {0}", ret2.Exception?.GetBaseException().Message);
                        PipeClosed?.Invoke(this, EventArgs.Empty);
                        return;
                    }

                    asyncReader(buff);
                    RunAsyncByteReader(asyncReader);
                });
            });
        }

        public void Flush()
        {
            pipeStream.Flush();
        }
    }

    internal class PipeServer : PipeTmpl<NamedPipeServerStream>
    {
        public event EventHandler<EventArgs> Connected;

        public PipeServer(string pipeName)
        {
            PipeSecurity pipeSa = new PipeSecurity();
            // Allow only the current user — a non-elevated second instance runs as the same
            // user and can still connect, but other users on the machine cannot.
            SecurityIdentifier currentUser = WindowsIdentity.GetCurrent().User;
            pipeSa.SetAccessRule(new PipeAccessRule(currentUser, PipeAccessRights.ReadWrite, AccessControlType.Allow));
            int buffLen = 1029; // 4-byte length prefix + 1024 data + 1
            pipeStream = NamedPipeServerStreamAcl.Create(pipeName, PipeDirection.InOut, NamedPipeServerStream.MaxAllowedServerInstances, PipeTransmissionMode.Message, PipeOptions.Asynchronous, buffLen, buffLen, pipeSa);
            pipeStream.BeginWaitForConnection(new AsyncCallback(PipeConnected), null);
        }

        protected void PipeConnected(IAsyncResult asyncResult)
        {
            pipeStream.EndWaitForConnection(asyncResult);
            Connected?.Invoke(this, new EventArgs());
            initAsyncReader();
        }
    }

    internal class PipeClient : PipeTmpl<NamedPipeClientStream>
    {
        public PipeClient(string serverName, string pipeName)
        {
            pipeStream = new NamedPipeClientStream(serverName, pipeName, PipeDirection.InOut, PipeOptions.Asynchronous);
        }

        public bool Connect(int TimeOut = 10000)
        {
            try
            {
                pipeStream.Connect(TimeOut);
            }
            catch
            {
                return false;
            }

            DataReceived += (sndr, data) => {
                MessageQueue.Enqueue(data);
            };

            initAsyncReader();
            return true;
        }

        private ConcurrentQueue<string> MessageQueue = new ConcurrentQueue<string>();

        public string Read(int TimeOut = 10000)
        {
            while (MessageQueue.TryDequeue(out _)) { } // clear queue
            for (long ticksEnd = DateTime.Now.Ticks + TimeOut * 10000L; ticksEnd > DateTime.Now.Ticks;)
            {
                Application.DoEvents();
                if (!IsConnected() || !MessageQueue.IsEmpty)
                    break;
            }
            return Read();
        }

        public string Read()
        {
            var messages = new List<string>();
            while (MessageQueue.TryDequeue(out string msg))
                messages.Add(msg);
            return string.Join("\0", messages);
        }
    }

    private Dispatcher mDispatcher;
    private List<PipeServer> serverPipes;
    private List<PipeClient> clientPipes;

    public PipeIPC(string PipeName)
    {
        mDispatcher = Dispatcher.CurrentDispatcher;
        mPipeName = PipeName;
        serverPipes = new List<PipeServer>();
        clientPipes = new List<PipeClient>();
    }

    public delegate void DelegateMessage(PipeServer pipe, string data);
    public event DelegateMessage PipeMessage;

    public void Listen()
    {
        PipeServer serverPipe = new PipeServer(mPipeName);
        serverPipes.Add(serverPipe);

        serverPipe.DataReceived += (sndr, data) => {
            mDispatcher.BeginInvoke(new Action(() => {
                PipeMessage?.Invoke(serverPipe, data);
            }));
        };

        serverPipe.Connected += (sndr, args) => {
            mDispatcher.BeginInvoke(new Action(() => {
                Listen();
            }));
        };

        serverPipe.PipeClosed += (sndr, args) => {
            mDispatcher.BeginInvoke(new Action(() => {
                serverPipes.Remove(serverPipe);
            }));
        };
    }

    public PipeClient Connect(int TimeOut = 10000)
    {
        PipeClient clientPipe = new PipeClient(".", mPipeName);
        if (!clientPipe.Connect(TimeOut))
            return null;

        clientPipes.Add(clientPipe);

        clientPipe.PipeClosed += (sndr, args) => {
            mDispatcher.BeginInvoke(new Action(() => {
                clientPipes.Remove(clientPipe);
            }));
        };

        return clientPipe;
    }
}
