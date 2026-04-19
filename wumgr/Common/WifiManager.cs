using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace wumgr
{
    static class WifiManager
    {
        const int NETSH_TIMEOUT_MS = 15000;

        public static List<string> GetSavedProfiles()
        {
            var profiles = new List<string>();
            try
            {
                var psi = new ProcessStartInfo("netsh");
                psi.ArgumentList.Add("wlan");
                psi.ArgumentList.Add("show");
                psi.ArgumentList.Add("profiles");
                psi.RedirectStandardOutput = true;
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;
                using var proc = Process.Start(psi);
                if (proc == null)
                {
                    AppLog.Line("WifiManager: failed to launch netsh");
                    return profiles;
                }
                string output = proc.StandardOutput.ReadToEnd();
                if (!proc.WaitForExit(NETSH_TIMEOUT_MS))
                {
                    try { proc.Kill(); } catch { }
                    AppLog.Line("WifiManager: netsh show profiles timed out");
                    return profiles;
                }
                foreach (string line in output.Split('\n'))
                {
                    int idx = line.IndexOf(':');
                    if (idx < 0) continue;
                    string key = line.Substring(0, idx).Trim();
                    if (key.Equals("All User Profile", StringComparison.OrdinalIgnoreCase) ||
                        key.Equals("User Profile", StringComparison.OrdinalIgnoreCase))
                        profiles.Add(line.Substring(idx + 1).Trim().TrimEnd('\r'));
                }
            }
            catch (Exception e)
            {
                AppLog.Line("WifiManager: failed to enumerate profiles: {0}", e.Message);
            }
            return profiles;
        }

        public static bool Connect(string profileName)
        {
            try
            {
                var psi = new ProcessStartInfo("netsh");
                psi.ArgumentList.Add("wlan");
                psi.ArgumentList.Add("connect");
                psi.ArgumentList.Add("name=" + profileName);
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;
                psi.RedirectStandardOutput = true;
                using var proc = Process.Start(psi);
                if (proc == null)
                {
                    AppLog.Line("WifiManager: failed to launch netsh connect");
                    return false;
                }
                if (!proc.WaitForExit(NETSH_TIMEOUT_MS))
                {
                    try { proc.Kill(); } catch { }
                    AppLog.Line("WifiManager: netsh connect timed out");
                    return false;
                }
                return proc.ExitCode == 0;
            }
            catch (Exception e)
            {
                AppLog.Line("WifiManager: connect failed: {0}", e.Message);
                return false;
            }
        }

        public static bool Disconnect()
        {
            try
            {
                var psi = new ProcessStartInfo("netsh");
                psi.ArgumentList.Add("wlan");
                psi.ArgumentList.Add("disconnect");
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;
                psi.RedirectStandardOutput = true;
                using var proc = Process.Start(psi);
                if (proc == null)
                {
                    AppLog.Line("WifiManager: failed to launch netsh disconnect");
                    return false;
                }
                if (!proc.WaitForExit(NETSH_TIMEOUT_MS))
                {
                    try { proc.Kill(); } catch { }
                    AppLog.Line("WifiManager: netsh disconnect timed out");
                    return false;
                }
                return proc.ExitCode == 0;
            }
            catch (Exception e)
            {
                AppLog.Line("WifiManager: disconnect failed: {0}", e.Message);
                return false;
            }
        }

        public static bool IsWifiConnected()
        {
            try
            {
                foreach (var ni in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 &&
                        ni.OperationalStatus == OperationalStatus.Up)
                        return true;
                }
            }
            catch (Exception e)
            {
                AppLog.Line("WifiManager: status check failed: {0}", e.Message);
            }
            return false;
        }

        public static async Task<bool> WaitForConnectionAsync(int timeoutSeconds = 30)
        {
            var sw = System.Diagnostics.Stopwatch.StartNew();
            while (sw.Elapsed.TotalSeconds < timeoutSeconds)
            {
                if (IsWifiConnected())
                    return true;
                await Task.Delay(500);
            }
            return false;
        }
    }
}
