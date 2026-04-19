using System;
using System.IO;
using System.Net;
using System.Windows.Threading;


class HttpTask
{
    const int BUFFER_SIZE = 65536;
    private byte[] BufferRead;
    private HttpWebRequest request;
    private HttpWebResponse response;
    private Stream streamResponse;
    private Stream streamWriter;
    private Dispatcher mDispatcher;
    private string mUrl;
    private string mDlPath;
    private string mDlName;
    private long mLength = -1;
    private long mOffset = -1;
    private int mOldPercent = -1;
    private bool Canceled = false;
    private DateTime lastTime;
    private DateTime mStartTime;

    public string DlPath { get { return mDlPath; } }
    public string DlName { get { return mDlName; } }

    public HttpTask(string Url, string DlPath, string DlName = null, bool Update = false)
    {
        mUrl = Url;
        mDlPath = DlPath;
        mDlName = DlName;
        mDispatcher = Dispatcher.CurrentDispatcher;
    }

    public bool Start()
    {
        Canceled = false;
        try
        {
            if (!Uri.TryCreate(mUrl, UriKind.Absolute, out Uri uri) ||
                (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps))
            {
                AppLog.Line("Download rejected, invalid URL scheme: {0}", mUrl);
                return false;
            }
            request = (HttpWebRequest)WebRequest.Create(uri);
            BufferRead = new byte[BUFFER_SIZE];
            mOffset = 0;
            request.BeginGetResponse(new AsyncCallback(RespCallback), this);
            return true;
        }
        catch (Exception e)
        {
            AppLog.Line("Download start failed: {0}", e.Message);
        }
        return false;
    }

    public void Cancel()
    {
        Canceled = true;
        if (request != null)
            request.Abort();
    }

    private void Finish(int Success, int ErrCode, Exception Error = null)
    {
        if (response != null)
        {
            response.Close();
            if (streamResponse != null)
                streamResponse.Close();
            if (streamWriter != null)
                streamWriter.Close();
        }
        response = null;
        request = null;
        streamResponse = null;
        BufferRead = null;

        if (Success == 1)
        {
            try
            {
                File.Move(mDlPath + @"\" + mDlName + ".tmp", mDlPath + @"\" + mDlName, overwrite: true);
            }
            catch
            {
                AppLog.Line("Failed to rename download {0}", mDlPath + @"\" + mDlName + ".tmp");
                mDlName += ".tmp";
            }

            try { File.SetLastWriteTime(mDlPath + @"\" + mDlName, lastTime); } catch { }
        }
        else if (Success == 2)
        {
            AppLog.Line("File already downloaded {0}", mDlPath + @"\" + mDlName);
        }
        else
        {
            try { File.Delete(mDlPath + @"\" + mDlName + ".tmp"); } catch { }
            AppLog.Line("Failed to download file {0}", mDlPath + @"\" + mDlName);
        }

        Finished?.Invoke(this, new FinishedEventArgs(Success > 0 ? 0 : Canceled ? -1 : ErrCode, Error));
    }

    static public string GetNextTempFile(string path, string baseName)
    {
        for (int i = 0; i < 10000; i++)
        {
            if (!File.Exists(path + @"\" + baseName + "_" + i + ".tmp"))
                return baseName + "_" + i;
        }
        return baseName;
    }

    private static void RespCallback(IAsyncResult asynchronousResult)
    {
        int Success = 0;
        int ErrCode = 0;
        Exception Error = null;
        HttpTask task = (HttpTask)asynchronousResult.AsyncState;
        try
        {
            task.response = (HttpWebResponse)task.request.EndGetResponse(asynchronousResult);
            ErrCode = (int)task.response.StatusCode;

            string fileName = Path.GetFileName(task.response.ResponseUri.ToString());
            task.lastTime = DateTime.Now;

            foreach (string key in task.response.Headers.AllKeys)
            {
                if (key.Equals("Content-Length", StringComparison.CurrentCultureIgnoreCase))
                {
                    if (long.TryParse(task.response.Headers[key], out long len))
                        task.mLength = len;
                }
                else if (key.Equals("Content-Disposition", StringComparison.CurrentCultureIgnoreCase))
                {
                    string cd = task.response.Headers[key];
                    int idx = cd.IndexOf("filename=");
                    if (idx >= 0)
                        fileName = Path.GetFileName(cd.Substring(idx + 9).Replace("\"", ""));
                }
                else if (key.Equals("Last-Modified", StringComparison.CurrentCultureIgnoreCase))
                {
                    if (DateTime.TryParse(task.response.Headers[key], out DateTime dt))
                        task.lastTime = dt;
                }
            }

            if (task.mDlName == null)
                task.mDlName = fileName;

            FileInfo testInfo = new FileInfo(task.mDlPath + @"\" + task.mDlName);
            if (testInfo.Exists && testInfo.LastWriteTime == task.lastTime && testInfo.Length == task.mLength)
            {
                task.request.Abort();
                Success = 2;
            }
            else
            {
                if (!Directory.Exists(task.mDlPath))
                    Directory.CreateDirectory(task.mDlPath);
                if (task.mDlName.Length == 0 || task.mDlName[0] == '?')
                    task.mDlName = GetNextTempFile(task.mDlPath, "Download");

                FileInfo info = new FileInfo(task.mDlPath + @"\" + task.mDlName + ".tmp");
                if (info.Exists)
                    info.Delete();

                task.streamResponse = task.response.GetResponseStream();
                task.streamWriter = info.OpenWrite();
                task.mStartTime = DateTime.Now;

                task.streamResponse.BeginRead(task.BufferRead, 0, BUFFER_SIZE, new AsyncCallback(ReadCallBack), task);
                return;
            }
        }
        catch (WebException e)
        {
            if (e.Response != null)
            {
                string fileName = Path.GetFileName(e.Response.ResponseUri.AbsolutePath.ToString());
                if (task.mDlName == null)
                    task.mDlName = fileName;

                FileInfo testInfo = new FileInfo(task.mDlPath + @"\" + task.mDlName);
                if (testInfo.Exists)
                    Success = 2;
            }

            if (Success == 0)
            {
                ErrCode = -2;
                Error = e;
                AppLog.Line("Download error: {0} ({1})", e.Message, e.Status);
            }
        }
        catch (Exception e)
        {
            ErrCode = -2;
            Error = e;
            AppLog.Line("Download error: {0}", e.Message);
        }
        task.mDispatcher.Invoke(new Action(() => {
            task.Finish(Success, ErrCode, Error);
        }));
    }

    private static void ReadCallBack(IAsyncResult asyncResult)
    {
        int Success = 0;
        int ErrCode = 0;
        Exception Error = null;
        HttpTask task = (HttpTask)asyncResult.AsyncState;
        try
        {
            int read = task.streamResponse.EndRead(asyncResult);
            if (read > 0)
            {
                task.streamWriter.Write(task.BufferRead, 0, read);
                task.mOffset += read;

                int Percent = task.mLength > 0 ? (int)(100L * task.mOffset / task.mLength) : -1;
                if (Percent != task.mOldPercent)
                {
                    task.mOldPercent = Percent;
                    double elapsed = (DateTime.Now - task.mStartTime).TotalSeconds;
                    long speed = elapsed > 0.1 ? (long)(task.mOffset / elapsed) : 0;
                    task.mDispatcher.BeginInvoke(new Action(() => {
                        task.Progress?.Invoke(task, new ProgressEventArgs(Percent, speed));
                    }));
                }

                task.streamResponse.BeginRead(task.BufferRead, 0, BUFFER_SIZE, new AsyncCallback(ReadCallBack), task);
                return;
            }
            else
            {
                Success = 1;
            }
        }
        catch (Exception e)
        {
            ErrCode = -3;
            Error = e;
            AppLog.Line("Download read error: {0}", e.Message);
        }
        task.mDispatcher.Invoke(new Action(() => {
            task.Finish(Success, ErrCode, Error);
        }));
    }

    public class FinishedEventArgs : EventArgs
    {
        public FinishedEventArgs(int ErrCode = 0, Exception Error = null)
        {
            this.ErrCode = ErrCode;
            this.Error = Error;
        }
        public string GetError()
        {
            if (Error != null)
                return Error.ToString();
            switch (ErrCode)
            {
                case 0: return "Ok";
                case -1: return "Canceled";
                default: return ErrCode.ToString();
            }
        }
        public bool Success { get { return ErrCode == 0; } }
        public bool Cancelled { get { return ErrCode == -1; } }

        public int ErrCode = 0;
        public Exception Error = null;
    }
    public event EventHandler<FinishedEventArgs> Finished;

    public class ProgressEventArgs : EventArgs
    {
        public ProgressEventArgs(int Percent, long Speed = 0)
        {
            this.Percent = Percent;
            this.Speed = Speed;
        }
        public int Percent = 0;
        public long Speed = 0; // bytes per second
    }
    public event EventHandler<ProgressEventArgs> Progress;
}
