using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskScheduler;
using System.Collections.Specialized;
using System.Collections.Concurrent;
using System.Security;
using System.Security.Permissions;
using System.Security.AccessControl;

namespace wumgr
{
    static class Program
    {
        public static string[] args = null;
        public static bool mConsole = false;
        public static string mVersion = "0.0";
        public static string mName = "Update Manager for Windows";
        private static string nTaskName = "WuMgrNoUAC";
        public static string appPath = "";
        public static string wrkPath = "";
        public static WuAgent Agent = null;
        public static PipeIPC ipc = null;

        private static string GetINIPath() { return wrkPath + @"\wumgr.ini"; }
        public static string GetToolsPath() { return appPath + @"\Tools"; }
        

        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Program.args = args;

            mConsole = WinConsole.Initialize(TestArg("-console"));

            if (TestArg("-help") || TestArg("/?"))
            {
                ShowHelp();
                return;
            }

            if (TestArg("-dbg_wait"))
                MessageBox.Show("Waiting for debugger. (press ok when attached)");

            Console.WriteLine("Starting...");

            appPath = Path.GetDirectoryName(Application.ExecutablePath);
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            mVersion = fvi.FileMajorPart + "." + fvi.FileMinorPart;
            if (fvi.FileBuildPart != 0)
                mVersion += (char)('a' + (fvi.FileBuildPart - 1));

            wrkPath = appPath;

            Translate.Load(IniReadValue("Options", "Lang", ""));

            AppLog Log = new AppLog();
            AppLog.Line("{0}, Version v{1} by David Xanatos", mName, mVersion);
            AppLog.Line("This Tool is Open Source under the GNU General Public License, Version 3\r\n");

            ipc = new PipeIPC("wumgr_pipe");

            var client = ipc.Connect(100);
            if (client != null)
            {
                AppLog.Line("Application is already running.");
                client.Send("show");
                string ret = client.Read(1000);
                if(!ret.Equals("ok", StringComparison.CurrentCultureIgnoreCase))
                    MessageBox.Show(Translate.fmt("msg_running"));
                return;
            }

            if (!MiscFunc.IsAdministrator() && !MiscFunc.IsDebugging())
            {
                Console.WriteLine("Trying to get admin privileges...");

                if (SkipUacRun())
                {
                    Application.Exit();
                    return;
                }

                if (!MiscFunc.IsRunningAsUwp())
                {
                    Console.WriteLine("Trying to start with 'runas'...");
                    // Restart program and run as admin
                    var exeName = Process.GetCurrentProcess().MainModule.FileName;
                    string arguments = "\"" + string.Join("\" \"", args) + "\"";
                    ProcessStartInfo startInfo = new ProcessStartInfo(exeName, arguments);
                    startInfo.UseShellExecute = true;
                    startInfo.Verb = "runas";
                    try
                    {
                        Process.Start(startInfo);
                        Application.Exit();
                        return;
                    }
                    catch
                    {
                        //MessageBox.Show(Translate.fmt("msg_admin_req", mName), mName);
                        AppLog.Line("Administrator privileges are required in order to install updates.");
                    }
                }
            }

            if (!FileOps.TestWrite(GetINIPath()))
            {
                Console.WriteLine("Can't write to default working directory.");

                string downloadFolder = KnownFolders.GetPath(KnownFolder.Downloads);
                if (downloadFolder == null)
                    downloadFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";

                wrkPath = downloadFolder + @"\WuMgr";
                try
                {
                    if (!Directory.Exists(wrkPath))
                        Directory.CreateDirectory(wrkPath);
                }
                catch
                {
                    MessageBox.Show(Translate.fmt("msg_ro_wrk_dir", wrkPath), mName);
                }
            }

            /*switch(FileOps.TestFileAdminSec(mINIPath))
            {
                case 0:
                    AppLog.Line("Warning wumgr.ini was writable by non administrative users, it was renamed to wumgr.ini.old and replaced with a empty one.\r\n");
                    if (!FileOps.MoveFile(mINIPath, mINIPath + ".old", true))
                        return;
                    goto case 2;
                case 2: // file missing, create
                    FileOps.SetFileAdminSec(mINIPath);
                    break;
                case 1: // every thign's fine ini file is only writable by admins
                    break;
            }*/

            AppLog.Line("Working Directory: {0}", wrkPath);

            LoadSettings();

            Agent = new WuAgent();

            ExecOnStart();

            Agent.Init();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string colorMode = Settings.ColorMode;
            if (colorMode.Equals("dark", StringComparison.OrdinalIgnoreCase))
                Application.SetColorMode(SystemColorMode.Dark);
            else if (colorMode.Equals("classic", StringComparison.OrdinalIgnoreCase))
                Application.SetColorMode(SystemColorMode.Classic);
            else
                Application.SetColorMode(SystemColorMode.System);

            Application.Run(new WuMgr());

            Agent.UnInit();

            ExecOnClose();

            Environment.Exit(0);
        }

        static private void ExecOnStart()
        {
            string ToolsINI = GetToolsPath() +@"\Tools.ini";

            if (MiscFunc.parseInt(IniReadValue("OnStart", "EnableWuAuServ", "0", ToolsINI)) != 0)
                Agent.EnableWuAuServ(true);

            string OnStart = IniReadValue("OnStart", "Exec", "", ToolsINI);
            if (OnStart.Length > 0)
                DoExec(PrepExec(OnStart, MiscFunc.parseInt(IniReadValue("OnStart", "Silent", "1", ToolsINI)) != 0), true);
        }

        static private void ExecOnClose()
        {
            string ToolsINI = GetToolsPath() + @"\Tools.ini";

            string OnClose = IniReadValue("OnClose", "Exec", "", ToolsINI);
            if (OnClose.Length > 0)
                DoExec(PrepExec(OnClose, MiscFunc.parseInt(IniReadValue("OnClose", "Silent", "1", ToolsINI)) != 0), true);

            if (MiscFunc.parseInt(IniReadValue("OnClose", "DisableWuAuServ", "0", ToolsINI)) != 0)
                Agent.EnableWuAuServ(false);

        }

        static public ProcessStartInfo PrepExec(string command, bool silent = true)
        {
            int pos = -1;
            if (command.Length > 0 && command.Substring(0, 1) == "\"")
            {
                command = command.Remove(0, 1).Trim();
                pos = command.IndexOf("\"");
            }
            else
                pos = command.IndexOf(" ");

            string exec;
            string arguments = "";
            if (pos != -1)
            {
                exec = command.Substring(0, pos);
                arguments = command.Substring(pos + 1).Trim();
            }
            else
                exec = command;

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = exec;
            startInfo.Arguments = arguments;
            if (silent)
            {
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardError = true;
                startInfo.UseShellExecute = false;
                startInfo.CreateNoWindow = true;
            }
            return startInfo;
        }

        static public bool DoExec(ProcessStartInfo startInfo, bool wait = false)
        {
            try
            {
                using Process proc = new Process();
                proc.StartInfo = startInfo;
                proc.EnableRaisingEvents = true;
                proc.Start();
                if (wait)
                    proc.WaitForExit();
            }
            catch
            {
                return false;
            }
            return true;

        }

        // ── Typed application settings ────────────────────────────────────────────

        public class AppSettings
        {
            // General
            public string ColorMode       { get; set; } = "system";
            public int    AutoUpdate      { get; set; } = 0;
            public bool   Offline         { get; set; } = false;
            public bool   Download        { get; set; } = true;
            public bool   Manual          { get; set; } = false;
            public int    IdleDelay       { get; set; } = 20;
            public string Lang            { get; set; } = "";
            public bool   LoadLists       { get; set; } = false;
            public string OfflineCab      { get; set; } = "";
            public bool   Refresh         { get; set; } = false;
            public bool   IncludeOld      { get; set; } = false;
            public bool   GroupUpdates    { get; set; } = true;
            public string Source          { get; set; } = "Windows Update";
            public string LastCheck       { get; set; } = "";

            // Auto-check schedule
            public int  ScheduleHour      { get; set; } = 12;
            public int  ScheduleWeekDay   { get; set; } = 1;
            public int  ScheduleMonthDay  { get; set; } = 1;

            // WiFi
            public bool   WifiAutoConnect    { get; set; } = false;
            public bool   WifiAutoDisconnect { get; set; } = true;
            public string WifiProfile        { get; set; } = "";
        }

        public static AppSettings Settings { get; private set; } = new AppSettings();

        private static readonly System.Text.Json.JsonSerializerOptions sJsonOpts =
            new System.Text.Json.JsonSerializerOptions { WriteIndented = true };

        private static string GetJsonSettingsPath() => Path.Combine(wrkPath, "wumgr.json");

        public static void LoadSettings()
        {
            string path = GetJsonSettingsPath();
            if (System.IO.File.Exists(path))
            {
                try
                {
                    Settings = System.Text.Json.JsonSerializer.Deserialize<AppSettings>(
                        System.IO.File.ReadAllText(path)) ?? new AppSettings();
                    return;
                }
                catch (Exception e) { AppLog.Line("Failed to load settings: {0}", e.Message); }
            }
            MigrateSettingsFromIni();
        }

        public static void SaveSettings()
        {
            try
            {
                Directory.CreateDirectory(wrkPath);
                System.IO.File.WriteAllText(GetJsonSettingsPath(),
                    System.Text.Json.JsonSerializer.Serialize(Settings, sJsonOpts));
            }
            catch (Exception e) { AppLog.Line("Failed to save settings: {0}", e.Message); }
        }

        private static void MigrateSettingsFromIni()
        {
            if (!System.IO.File.Exists(GetINIPath())) return;
            AppLog.Line("Migrating settings from wumgr.ini to wumgr.json");
            Settings = new AppSettings();
            string r(string k, string d = "") => IniReadValue("Options", k, d);
            Settings.ColorMode          = r("ColorMode", "system");
            Settings.AutoUpdate         = MiscFunc.parseInt(r("AutoUpdate", "0"));
            Settings.Offline            = r("Offline", "0") != "0";
            Settings.Download           = r("Download", "1") != "0";
            Settings.Manual             = r("Manual", "0")  != "0";
            Settings.IdleDelay          = MiscFunc.parseInt(r("IdleDelay", "20"));
            Settings.Lang               = r("Lang", "");
            Settings.LoadLists          = r("LoadLists", "0") != "0";
            Settings.OfflineCab         = r("OfflineCab", "");
            Settings.Refresh            = r("Refresh", "0") != "0";
            Settings.IncludeOld         = r("IncludeOld", "0") != "0";
            Settings.GroupUpdates       = r("GroupUpdates", "1") != "0";
            Settings.Source             = r("Source", "Windows Update");
            Settings.LastCheck          = r("LastCheck", "");
            Settings.ScheduleHour       = MiscFunc.parseInt(r("AutoCheckHour", "12"));
            Settings.ScheduleWeekDay    = MiscFunc.parseInt(r("AutoCheckWeekDay", "1"));
            Settings.ScheduleMonthDay   = MiscFunc.parseInt(r("AutoCheckMonthDay", "1"));
            Settings.WifiAutoConnect    = IniReadValue("WiFi", "AutoConnect",    "0") != "0";
            Settings.WifiAutoDisconnect = IniReadValue("WiFi", "AutoDisconnect", "1") != "0";
            Settings.WifiProfile        = IniReadValue("WiFi", "Profile", "");
            SaveSettings();
        }

        // ── Legacy INI P/Invoke (kept for external files: Tools.ini, translations, KB lists) ──

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        public static void IniWriteValue(string Section, string Key, string Value, string INIPath = null)
        {
            WritePrivateProfileString(Section, Key, Value, INIPath != null ? INIPath : GetINIPath());
        }

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, [In, Out] char[] retVal, int size, string filePath);
        public static string IniReadValue(string Section, string Key, string Default = "", string INIPath = null)
        {
            char[] chars = new char[8193];
            int size = GetPrivateProfileString(Section, Key, Default, chars, 8193, INIPath != null ? INIPath : GetINIPath());
            return new String(chars, 0, size);
        }

        public static string[] IniEnumSections(string INIPath = null)
        {
            char[] chars = new char[8193];
            int size = GetPrivateProfileString(null, null, null, chars, 8193, INIPath != null ? INIPath : GetINIPath());
            return new String(chars, 0, size).Split('\0');
        }

        private static string[] IniEnumKeys(string section, string INIPath = null)
        {
            char[] chars = new char[8193];
            int size = GetPrivateProfileString(section, null, null, chars, 8193, INIPath ?? GetINIPath());
            return new String(chars, 0, size).Split('\0').Where(s => s.Length > 0).ToArray();
        }

        public static bool TestArg(string name)
        {
            for (int i = 0; i < Program.args.Length; i++)
            {
                if (Program.args[i].Equals(name, StringComparison.CurrentCultureIgnoreCase))
                    return true;
            }
            return false;
        }

        public static string GetArg(string name)
        {
            for (int i = 0; i < Program.args.Length; i++)
            {
                if (Program.args[i].Equals(name, StringComparison.CurrentCultureIgnoreCase))
                {
                    if (i + 1 >= Program.args.Length)
                        return "";
                    string temp = Program.args[i + 1];
                    if (temp.Length > 0 && temp[0] != '-')
                        return temp;
                    return "";
                }
            }
            return null;
        }

        public static void AutoStart(bool enable)
        {
            using var subKey = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            if (enable)
            {
                string value = "\"" + System.Reflection.Assembly.GetExecutingAssembly().Location + "\"" + " -tray";
                subKey.SetValue("wumgr", value);
            }
            else
                subKey.DeleteValue("wumgr", false);
        }

        public static bool IsAutoStart()
        {
            using var subKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", false);
            return (subKey != null && subKey.GetValue("wumgr") != null);
        }

        static public bool IsSkipUacRun()
        {
            try
            {
                TaskScheduler.TaskScheduler service = new TaskScheduler.TaskScheduler();
                service.Connect();
                ITaskFolder folder = service.GetFolder(@"\"); // root
                IRegisteredTask task = folder.GetTask(nTaskName);
                return task != null;
            }
            catch {}
            return false;
        }

        static public bool SkipUacEnable(bool is_enable)
        {
            try
            {
                TaskScheduler.TaskScheduler service = new TaskScheduler.TaskScheduler();
                service.Connect();
                ITaskFolder folder = service.GetFolder(@"\"); // root
                if (is_enable)
                {
                    string exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;

                    ITaskDefinition task = service.NewTask(0);
                    task.RegistrationInfo.Author = "WuMgr";
                    task.Principal.RunLevel = _TASK_RUNLEVEL.TASK_RUNLEVEL_HIGHEST;

                    task.Settings.AllowHardTerminate = false;
                    task.Settings.StartWhenAvailable = false;
                    task.Settings.DisallowStartIfOnBatteries = false;
                    task.Settings.StopIfGoingOnBatteries = false;
                    task.Settings.MultipleInstances = _TASK_INSTANCES_POLICY.TASK_INSTANCES_PARALLEL;
                    task.Settings.ExecutionTimeLimit = "PT0S";

                    IExecAction action = (IExecAction)task.Actions.Create(_TASK_ACTION_TYPE.TASK_ACTION_EXEC);
                    action.Path = exePath;
                    action.WorkingDirectory = appPath;
                    action.Arguments = "-NoUAC $(Arg0)";

                    IRegisteredTask registered_task = folder.RegisterTaskDefinition(nTaskName, task, (int)_TASK_CREATION.TASK_CREATE_OR_UPDATE, null, null, _TASK_LOGON_TYPE.TASK_LOGON_INTERACTIVE_TOKEN);

                    if(registered_task == null)
                        return false;

                    // Note: if we run as UWP we need to adjust the file permissions for this workaround to work
                    if (MiscFunc.IsRunningAsUwp())
                    {
                        if (!FileOps.TakeOwn(exePath))
                            return false;

                        FileInfo exeInfo = new FileInfo(exePath);
                        FileSecurity ac = exeInfo.GetAccessControl();
                        ac.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(FileOps.SID_Worls), FileSystemRights.ReadAndExecute, AccessControlType.Allow));
                        exeInfo.SetAccessControl(ac);
                    }
                }
                else
                    folder.DeleteTask(nTaskName, 0);
            }
            catch (Exception err)
            {
                AppLog.Line("Enable SkipUAC Error {0}", err.ToString());
                return false;
            }
            return true;
        }

        static public bool SkipUacRun()
        {
            bool silent = true;
            try
            {
                TaskScheduler.TaskScheduler service = new TaskScheduler.TaskScheduler();
                service.Connect();
                ITaskFolder folder = service.GetFolder(@"\"); // root
                IRegisteredTask task = folder.GetTask(nTaskName);

                silent = false;
                AppLog.Line("Trying to SkipUAC ...");

                IExecAction action = (IExecAction)task.Definition.Actions[1];
                if (action.Path.Equals(System.Reflection.Assembly.GetExecutingAssembly().Location, StringComparison.CurrentCultureIgnoreCase))
                {
                    string arguments = "\"" + string.Join("\" \"", args) + "\"";

                    IRunningTask running_Task = task.RunEx(arguments, (int)_TASK_RUN_FLAGS.TASK_RUN_NO_FLAGS, 0, null);

                    for (int i = 0; i < 5; i++)
                    {
                        Thread.Sleep(250);
                        running_Task.Refresh();
                        _TASK_STATE state = running_Task.State;
                        if (state == _TASK_STATE.TASK_STATE_RUNNING || state == _TASK_STATE.TASK_STATE_READY || state == _TASK_STATE.TASK_STATE_DISABLED)
                        {
                            if (state == _TASK_STATE.TASK_STATE_RUNNING || state == _TASK_STATE.TASK_STATE_READY)
                                return true;
                            break;
                        }
                    }
                }
            }
            catch (Exception err)
            {
                if(!silent)
                    AppLog.Line("SkipUAC Error {0}", err.ToString());
            }
            return false;
        }

        private static void ShowHelp()
        {
            string Message = "Available command line options\r\n";
            string[] Help = {"-tray\t\tStart in Tray",
                                    "-update\t\tSearch for updates on start",
                                    "-console\t\tshow console (for debugging)",
                                    "-help\t\tShow this help message" };
            if (!mConsole)
                MessageBox.Show(Message + string.Join("\r\n", Help));
            else
            {
                Console.WriteLine(Message);
                for (int j = 0; j < Help.Length; j++)
                    Console.WriteLine(" " + Help[j]);
            }
        }
    }
}
