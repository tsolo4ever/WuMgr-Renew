using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;


internal struct LASTINPUTINFO
{
    public uint cbSize;
    public uint dwTime;
}

class MiscFunc
{
    [DllImport("User32.dll", SetLastError = true)]
    private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

    public static uint GetIdleTime() // in seconds
    {
        LASTINPUTINFO lastInPut = new LASTINPUTINFO();
        lastInPut.cbSize = (uint)Marshal.SizeOf(lastInPut);
        if (!GetLastInputInfo(ref lastInPut))
            throw new Exception(Marshal.GetLastWin32Error().ToString());
        return ((uint)Environment.TickCount - lastInPut.dwTime) / 1000;
    }

    public static int parseInt(string str, int def = 0)
    {
        return int.TryParse(str, out int result) ? result : def;
    }

    static public Color? parseColor(string input)
    {
        ColorConverter c = new ColorConverter();
        if (Regex.IsMatch(input, "^(#[0-9A-Fa-f]{3})$|^(#[0-9A-Fa-f]{6})$"))
            return (Color)c.ConvertFromString(input);

        ColorConverter.StandardValuesCollection svc = (ColorConverter.StandardValuesCollection)c.GetStandardValues();
        foreach (Color o in svc)
        {
            if (o.Name.Equals(input, StringComparison.OrdinalIgnoreCase))
                return o;
        }
        return null;
    }

    public static bool IsAdministrator()
    {
        using WindowsIdentity identity = WindowsIdentity.GetCurrent();
        return new WindowsPrincipal(identity).IsInRole(WindowsBuiltInRole.Administrator);
    }

    [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
    static extern bool CheckRemoteDebuggerPresent(IntPtr hProcess, ref bool isDebuggerPresent);

    static public bool IsDebugging()
    {
        bool isDebuggerPresent = false;
        CheckRemoteDebuggerPresent(Process.GetCurrentProcess().Handle, ref isDebuggerPresent);
        return isDebuggerPresent;
    }

    const long APPMODEL_ERROR_NO_PACKAGE = 15700L;

    [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    static extern int GetCurrentPackageFullName(ref int packageFullNameLength, StringBuilder packageFullName);

    static public bool IsRunningAsUwp()
    {
        int length = 0;
        StringBuilder sb = new StringBuilder(0);
        GetCurrentPackageFullName(ref length, sb);
        sb = new StringBuilder(length);
        int result = GetCurrentPackageFullName(ref length, sb);
        return result != APPMODEL_ERROR_NO_PACKAGE;
    }
}
