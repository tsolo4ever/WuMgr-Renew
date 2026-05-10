using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wumgr
{
    internal partial class form_settings : Form
    {
        private readonly WuAgent mAgent;
        private bool mSuspend;
        private GPO.Respect mGPORespect;
        private float mWinVersion;

        private static Program.AppSettings Cfg => Program.Settings;

        public form_settings(WuAgent agent)
        {
            InitializeComponent();
            mAgent = agent;
            this.Load += form_settings_Load;
        }

        private void form_settings_Load(object sender, EventArgs e)
        {
            mSuspend = true;

            // --- Options tab ---
            string savedSource = Cfg.Source;
            dlSource.Items.Clear();
            for (int i = 0; i < mAgent.mServiceList.Count; i++)
            {
                string svc = mAgent.mServiceList[i];
                dlSource.Items.Add(svc);
                if (svc.Equals(savedSource, StringComparison.CurrentCultureIgnoreCase))
                    dlSource.SelectedIndex = i;
            }
            if (dlSource.SelectedIndex < 0 && dlSource.Items.Count > 0)
                dlSource.SelectedIndex = 0;

            chkOffline.Checked = Cfg.Offline;
            chkDownload.Checked = Cfg.Download;
            chkDownload.Enabled = chkOffline.Checked;
            dlSource.Enabled = !chkOffline.Checked;
            chkManual.Checked = Cfg.Manual;
            chkOld.Checked = Cfg.IncludeOld;

            chkMsUpd.Checked = mAgent.IsActive() && mAgent.TestService(WuAgent.MsUpdGUID);
            if (!MiscFunc.IsAdministrator())
                chkMsUpd.Enabled = false;

            chkAutoRun.Checked = Program.IsAutoStart();
            chkNoUAC.Checked = Program.IsSkipUacRun();
            chkNoUAC.Enabled = MiscFunc.IsAdministrator();
            chkNoUAC.Visible = chkNoUAC.Enabled || chkNoUAC.Checked || !MiscFunc.IsRunningAsUwp();

            try { dlAutoCheck.SelectedIndex = Cfg.AutoUpdate; } catch { dlAutoCheck.SelectedIndex = 0; }
            dlAutoCheck.Enabled = chkAutoRun.Checked;

            BuildScheduleControls();

            // --- AU tab ---
            mGPORespect = GPO.GetRespect();
            mWinVersion = GPO.GetWinVersion();

            if (mWinVersion < 10)
                chkHideWU.Enabled = false;
            chkHideWU.Checked = GPO.IsUpdatePageHidden();

            if (mGPORespect == GPO.Respect.Partial || mGPORespect == GPO.Respect.None)
                radSchedule.Enabled = radDownload.Enabled = radNotify.Enabled = false;

            if (mGPORespect == GPO.Respect.None)
                chkBlockMS.Enabled = false;
            chkBlockMS.CheckState = (CheckState)GPO.GetBlockMS();

            int day, time;
            switch (GPO.GetAU(out day, out time))
            {
                case GPO.AUOptions.Default: radDefault.Checked = true; break;
                case GPO.AUOptions.Disabled: radDisable.Checked = true; break;
                case GPO.AUOptions.Notification: radNotify.Checked = true; break;
                case GPO.AUOptions.Download: radDownload.Checked = true; break;
                case GPO.AUOptions.Scheduled: radSchedule.Checked = true; break;
            }
            try { dlShDay.SelectedIndex = day; dlShTime.SelectedIndex = time; } catch { }

            if (mWinVersion >= 10)
                chkDisableAU.Checked = GPO.GetDisableAU();

            if (mWinVersion < 6.2)
                chkStore.Enabled = false;
            chkStore.Checked = GPO.GetStoreAU();

            chkDrivers.CheckState = (CheckState)GPO.GetDriverAU();

            if (!MiscFunc.IsAdministrator() || MiscFunc.IsRunningAsUwp())
            {
                foreach (Control ctl in tabAU.Controls)
                    ctl.Enabled = false;
            }

            // --- WiFi tab ---
            tabWiFiconnectchk.Checked = Cfg.WifiAutoConnect;
            tabWiFiDisconnectchk.Checked = Cfg.WifiAutoDisconnect;
            RefreshWifiProfiles();

            mSuspend = false;
            UpdateGPORadioState();
            UpdateWifiStatus();

            // Wire event handlers after populating so they don't fire during init
            chkOffline.CheckedChanged += chkOffline_CheckedChanged;
            chkDownload.CheckedChanged += chkDownload_CheckedChanged;
            chkManual.CheckedChanged += chkManual_CheckedChanged;
            chkOld.CheckedChanged += chkOld_CheckedChanged;
            dlSource.SelectedIndexChanged += dlSource_SelectedIndexChanged;
            chkMsUpd.CheckedChanged += chkMsUpd_CheckedChanged;
            chkAutoRun.CheckedChanged += chkAutoRun_CheckedChanged;
            dlAutoCheck.SelectedIndexChanged += dlAutoCheck_SelectedIndexChanged;
            dlScheduleHour.SelectedIndexChanged += dlScheduleHour_SelectedIndexChanged;
            dlScheduleDay.SelectedIndexChanged += dlScheduleDay_SelectedIndexChanged;
            chkNoUAC.CheckedChanged += chkNoUAC_CheckedChanged;
            chkBlockMS.CheckedChanged += chkBlockMS_CheckedChanged;
            radDisable.CheckedChanged += radGPO_CheckedChanged;
            radNotify.CheckedChanged += radGPO_CheckedChanged;
            radDownload.CheckedChanged += radGPO_CheckedChanged;
            radSchedule.CheckedChanged += radGPO_CheckedChanged;
            radDefault.CheckedChanged += radGPO_CheckedChanged;
            dlShDay.SelectedIndexChanged += dlShDay_SelectedIndexChanged;
            dlShTime.SelectedIndexChanged += dlShTime_SelectedIndexChanged;
            chkDisableAU.CheckedChanged += chkDisableAU_CheckedChanged;
            chkHideWU.CheckedChanged += chkHideWU_CheckedChanged;
            chkStore.CheckedChanged += chkStore_CheckedChanged;
            chkDrivers.CheckStateChanged += chkDrivers_CheckStateChanged;
            tabWiFiconnectchk.CheckedChanged += tabWiFiconnectchk_CheckedChanged;
            tabWiFiDisconnectchk.CheckedChanged += tabWiFiDisconnectchk_CheckedChanged;
            tabWiFIrefreshbtn.Click += tabWiFIrefreshbtn_Click;
            tabWiFitogglebtn.Click += tabWiFitogglebtn_Click;
        }

        // ── Schedule helpers ──────────────────────────────────────────────────────

        private void BuildScheduleControls()
        {
            dlScheduleHour.Items.Clear();
            for (int h = 0; h < 24; h++)
                dlScheduleHour.Items.Add(h == 0 ? "12:00 AM" : h < 12 ? $"{h}:00 AM" : h == 12 ? "12:00 PM" : $"{h - 12}:00 PM");
            try { dlScheduleHour.SelectedIndex = Cfg.ScheduleHour; } catch { dlScheduleHour.SelectedIndex = 12; }
            UpdateScheduleVisibility();
        }

        private void UpdateScheduleVisibility()
        {
            int mode = dlAutoCheck.SelectedIndex;
            bool showHour = mode > 0;
            bool showDay = mode >= 2;

            dlScheduleHour.Visible = showHour;
            lblScheduleOn.Visible = showDay;
            dlScheduleDay.Visible = showDay;

            if (!showDay) return;

            dlScheduleDay.Items.Clear();
            if (mode == 2)
            {
                dlScheduleDay.Items.AddRange(new object[] { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" });
                dlScheduleDay.SelectedIndex = Math.Min(Math.Max(Cfg.ScheduleWeekDay, 0), 6);
            }
            else
            {
                for (int i = 1; i <= 28; i++) dlScheduleDay.Items.Add(i.ToString());
                dlScheduleDay.SelectedIndex = Math.Min(Math.Max(Cfg.ScheduleMonthDay, 0), 27);
            }
        }

        // ── Options tab ───────────────────────────────────────────────────────────

        private void chkOffline_CheckedChanged(object sender, EventArgs e)
        {
            dlSource.Enabled = !chkOffline.Checked;
            chkDownload.Enabled = chkOffline.Checked;
            Cfg.Offline = chkOffline.Checked;
            Program.SaveSettings();
        }

        private void chkDownload_CheckedChanged(object sender, EventArgs e)
        {
            Cfg.Download = chkDownload.Checked;
            Program.SaveSettings();
        }

        private void chkManual_CheckedChanged(object sender, EventArgs e)
        {
            Cfg.Manual = chkManual.Checked;
            Program.SaveSettings();
        }

        private void chkOld_CheckedChanged(object sender, EventArgs e)
        {
            Cfg.IncludeOld = chkOld.Checked;
            Program.SaveSettings();
        }

        private void dlSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cfg.Source = dlSource.Text;
            Program.SaveSettings();
        }

        private void chkMsUpd_CheckedChanged(object sender, EventArgs e)
        {
            if (mSuspend) return;
            string sel = dlSource.Text;
            mAgent.EnableService(WuAgent.MsUpdGUID, chkMsUpd.Checked);
            dlSource.Items.Clear();
            for (int i = 0; i < mAgent.mServiceList.Count; i++)
            {
                dlSource.Items.Add(mAgent.mServiceList[i]);
                if (mAgent.mServiceList[i].Equals(sel, StringComparison.CurrentCultureIgnoreCase))
                    dlSource.SelectedIndex = i;
            }
            if (dlSource.SelectedIndex < 0 && dlSource.Items.Count > 0)
                dlSource.SelectedIndex = 0;
        }

        private void chkAutoRun_CheckedChanged(object sender, EventArgs e)
        {
            dlAutoCheck.Enabled = chkAutoRun.Checked;
            if (mSuspend) return;
            if (chkAutoRun.CheckState == CheckState.Indeterminate) return;
            if (MiscFunc.IsRunningAsUwp())
            {
                if (chkAutoRun.CheckState == CheckState.Checked)
                {
                    mSuspend = true;
                    chkAutoRun.CheckState = CheckState.Indeterminate;
                    mSuspend = false;
                }
                return;
            }
            Program.AutoStart(chkAutoRun.Checked);
        }

        private void dlAutoCheck_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mSuspend) return;
            Cfg.AutoUpdate = dlAutoCheck.SelectedIndex;
            Program.SaveSettings();
            UpdateScheduleVisibility();
        }

        private void dlScheduleHour_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mSuspend) return;
            Cfg.ScheduleHour = dlScheduleHour.SelectedIndex;
            Program.SaveSettings();
        }

        private void dlScheduleDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mSuspend) return;
            if (dlAutoCheck.SelectedIndex == 2) Cfg.ScheduleWeekDay = dlScheduleDay.SelectedIndex;
            else Cfg.ScheduleMonthDay = dlScheduleDay.SelectedIndex;
            Program.SaveSettings();
        }

        private void chkNoUAC_CheckedChanged(object sender, EventArgs e)
        {
            if (mSuspend) return;
            Program.SkipUacEnable(chkNoUAC.Checked);
        }

        // ── AU tab ────────────────────────────────────────────────────────────────

        private void chkBlockMS_CheckedChanged(object sender, EventArgs e)
        {
            if (mSuspend) return;

            if (chkBlockMS.Checked)
            {
                var result = MessageBox.Show(
                    "Blocking access to Windows Update servers will prevent this app from checking for updates.\n\n" +
                    "Once enabled, disabling this option may require restarting the Windows Update service or rebooting before searches work again.\n\n" +
                    "Are you sure?",
                    Program.mName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                {
                    mSuspend = true;
                    chkBlockMS.Checked = false;
                    mSuspend = false;
                    return;
                }
            }

            if (radDisable.Checked && mGPORespect == GPO.Respect.Partial)
            {
                if (chkBlockMS.Checked)
                {
                    chkDisableAU.Enabled = true;
                }
                else
                {
                    if (!chkDisableAU.Checked)
                    {
                        switch (MessageBox.Show(Translate.fmt("msg_gpo"), Program.mName, MessageBoxButtons.YesNoCancel))
                        {
                            case DialogResult.Yes:
                                chkDisableAU.Checked = true;
                                break;
                            case DialogResult.No:
                                radDefault.Checked = true;
                                break;
                            case DialogResult.Cancel:
                                mSuspend = true;
                                chkBlockMS.Checked = true;
                                mSuspend = false;
                                return;
                        }
                    }
                    chkDisableAU.Enabled = false;
                }
            }

            GPO.BlockMS(chkBlockMS.Checked);
        }

        private void radGPO_CheckedChanged(object sender, EventArgs e)
        {
            UpdateGPORadioState();
            if (mSuspend) return;
            ApplyGPOAUSettings();
        }

        private void UpdateGPORadioState()
        {
            dlShDay.Enabled = dlShTime.Enabled = radSchedule.Checked;

            if (radDisable.Checked)
            {
                switch (mGPORespect)
                {
                    case GPO.Respect.Partial:
                        chkDisableAU.Enabled = chkBlockMS.Checked;
                        if (!chkBlockMS.Checked)
                        {
                            mSuspend = true;
                            chkDisableAU.Checked = true;
                            mSuspend = false;
                        }
                        break;
                    case GPO.Respect.None:
                        chkDisableAU.Enabled = false;
                        mSuspend = true;
                        chkDisableAU.Checked = true;
                        mSuspend = false;
                        break;
                    case GPO.Respect.Full:
                        chkDisableAU.Enabled = mWinVersion >= 10;
                        break;
                }
            }
            else
            {
                chkDisableAU.Enabled = false;
            }
        }

        private void ApplyGPOAUSettings()
        {
            if (radDisable.Checked)
            {
                if (chkDisableAU.Checked)
                {
                    bool test = GPO.GetDisableAU();
                    GPO.DisableAU(true);
                    if (!test) MessageBox.Show(Translate.fmt("msg_disable_au"));
                }
                GPO.ConfigAU(GPO.AUOptions.Disabled);
            }
            else
            {
                mSuspend = true;
                chkDisableAU.Checked = false;
                mSuspend = false;

                if (radNotify.Checked)
                    GPO.ConfigAU(GPO.AUOptions.Notification);
                else if (radDownload.Checked)
                    GPO.ConfigAU(GPO.AUOptions.Download);
                else if (radSchedule.Checked)
                    GPO.ConfigAU(GPO.AUOptions.Scheduled, dlShDay.SelectedIndex, dlShTime.SelectedIndex);
                else
                    GPO.ConfigAU(GPO.AUOptions.Default);
            }
        }

        private void dlShDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mSuspend) return;
            GPO.ConfigAU(GPO.AUOptions.Scheduled, dlShDay.SelectedIndex, dlShTime.SelectedIndex);
        }

        private void dlShTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mSuspend) return;
            GPO.ConfigAU(GPO.AUOptions.Scheduled, dlShDay.SelectedIndex, dlShTime.SelectedIndex);
        }

        private void chkDisableAU_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDisableAU.Checked)
            {
                chkHideWU.Checked = true;
                chkHideWU.Enabled = false;
            }
            else
            {
                chkHideWU.Enabled = true;
            }

            if (mSuspend) return;
            bool test = GPO.GetDisableAU();
            GPO.DisableAU(chkDisableAU.Checked);
            if (test != chkDisableAU.Checked)
                MessageBox.Show(Translate.fmt("msg_disable_au"));
        }

        private void chkHideWU_CheckedChanged(object sender, EventArgs e)
        {
            if (mSuspend) return;
            GPO.HideUpdatePage(chkHideWU.Checked);
        }

        private void chkStore_CheckedChanged(object sender, EventArgs e)
        {
            if (mSuspend) return;
            GPO.SetStoreAU(chkStore.Checked);
        }

        private void chkDrivers_CheckStateChanged(object sender, EventArgs e)
        {
            if (mSuspend) return;
            GPO.ConfigDriverAU((int)chkDrivers.CheckState);
        }

        // ── WiFi tab ──────────────────────────────────────────────────────────────

        private void tabWiFiconnectchk_CheckedChanged(object sender, EventArgs e)
        {
            Cfg.WifiAutoConnect = tabWiFiconnectchk.Checked;
            Program.SaveSettings();
        }

        private void tabWiFiDisconnectchk_CheckedChanged(object sender, EventArgs e)
        {
            Cfg.WifiAutoDisconnect = tabWiFiDisconnectchk.Checked;
            Program.SaveSettings();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabWifiprofilecmb.SelectedItem != null)
            {
                Cfg.WifiProfile = tabWifiprofilecmb.SelectedItem.ToString();
                Program.SaveSettings();
            }
        }

        private void tabWiFIrefreshbtn_Click(object sender, EventArgs e)
        {
            RefreshWifiProfiles();
        }

        private async void tabWiFitogglebtn_Click(object sender, EventArgs e)
        {
            try
            {
                tabWiFitogglebtn.Enabled = false;
                if (WifiManager.IsWifiConnected())
                {
                    await Task.Run(() => WifiManager.Disconnect());
                }
                else
                {
                    string profile = tabWifiprofilecmb.SelectedItem?.ToString();
                    if (!string.IsNullOrEmpty(profile))
                    {
                        tabWiFistatuslbl.Text = "Connecting...";
                        bool ok = await Task.Run(() => WifiManager.Connect(profile));
                        if (!IsDisposed && ok)
                            ok = await WifiManager.WaitForConnectionAsync();
                        if (!ok) AppLog.Line("WiFi: failed to connect to '{0}'", profile);
                    }
                }
                if (!IsDisposed)
                {
                    tabWiFitogglebtn.Enabled = true;
                    UpdateWifiStatus();
                }
            }
            catch (Exception ex)
            {
                AppLog.Line("WiFi button error: {0}", ex.Message);
                if (!IsDisposed)
                    tabWiFitogglebtn.Enabled = true;
            }
        }

        private void RefreshWifiProfiles()
        {
            string current = tabWifiprofilecmb.SelectedItem?.ToString() ?? Cfg.WifiProfile;
            tabWifiprofilecmb.Items.Clear();
            foreach (string p in WifiManager.GetSavedProfiles())
                tabWifiprofilecmb.Items.Add(p);
            if (current != null && tabWifiprofilecmb.Items.Contains(current))
                tabWifiprofilecmb.SelectedItem = current;
            else if (tabWifiprofilecmb.Items.Count > 0)
                tabWifiprofilecmb.SelectedIndex = 0;
        }

        private void UpdateWifiStatus()
        {
            bool connected = WifiManager.IsWifiConnected();
            tabWiFitogglebtn.Text = connected ? "Disconnect Now" : "Connect Now";
            tabWiFistatuslbl.Text = connected ? "WiFi: connected" : "WiFi: not connected";
        }

        private void ck1_paranoid_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
