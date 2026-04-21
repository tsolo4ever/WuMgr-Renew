namespace wumgr
{
    partial class form_settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            WiFiTab = new System.Windows.Forms.TabControl();
            tabOptions = new System.Windows.Forms.TabPage();
            gbStartup = new System.Windows.Forms.GroupBox();
            lblScheduleOn = new System.Windows.Forms.Label();
            dlScheduleDay = new System.Windows.Forms.ComboBox();
            dlScheduleHour = new System.Windows.Forms.ComboBox();
            chkAutoRun = new System.Windows.Forms.CheckBox();
            chkNoUAC = new System.Windows.Forms.CheckBox();
            dlAutoCheck = new System.Windows.Forms.ComboBox();
            dlSource = new System.Windows.Forms.ComboBox();
            chkOffline = new System.Windows.Forms.CheckBox();
            chkMsUpd = new System.Windows.Forms.CheckBox();
            chkOld = new System.Windows.Forms.CheckBox();
            chkManual = new System.Windows.Forms.CheckBox();
            chkDownload = new System.Windows.Forms.CheckBox();
            tabAU = new System.Windows.Forms.TabPage();
            label1 = new System.Windows.Forms.Label();
            chkDrivers = new System.Windows.Forms.CheckBox();
            chkStore = new System.Windows.Forms.CheckBox();
            chkHideWU = new System.Windows.Forms.CheckBox();
            chkDisableAU = new System.Windows.Forms.CheckBox();
            radDefault = new System.Windows.Forms.RadioButton();
            radSchedule = new System.Windows.Forms.RadioButton();
            radDownload = new System.Windows.Forms.RadioButton();
            chkBlockMS = new System.Windows.Forms.CheckBox();
            radNotify = new System.Windows.Forms.RadioButton();
            radDisable = new System.Windows.Forms.RadioButton();
            dlShDay = new System.Windows.Forms.ComboBox();
            dlShTime = new System.Windows.Forms.ComboBox();
            tabWiFi = new System.Windows.Forms.TabPage();
            tabParanoid = new System.Windows.Forms.TabPage();
            tabWiFiconnectchk = new System.Windows.Forms.CheckBox();
            tabWiFiDisconnectchk = new System.Windows.Forms.CheckBox();
            tabWifiprofilecmb = new System.Windows.Forms.ComboBox();
            WiFiBox = new System.Windows.Forms.GroupBox();
            tabWiFitogglebtn = new System.Windows.Forms.Button();
            tabWiFiprofilelbl = new System.Windows.Forms.Label();
            tabWiFIrefreshbtn = new System.Windows.Forms.Button();
            tabWiFistatuslbl = new System.Windows.Forms.Label();
            WiFiTab.SuspendLayout();
            tabOptions.SuspendLayout();
            gbStartup.SuspendLayout();
            tabAU.SuspendLayout();
            tabWiFi.SuspendLayout();
            WiFiBox.SuspendLayout();
            SuspendLayout();
            // 
            // WiFiTab
            // 
            WiFiTab.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            WiFiTab.Controls.Add(tabOptions);
            WiFiTab.Controls.Add(tabAU);
            WiFiTab.Controls.Add(tabWiFi);
            WiFiTab.Controls.Add(tabParanoid);
            WiFiTab.Location = new System.Drawing.Point(1, 1);
            WiFiTab.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            WiFiTab.Name = "WiFiTab";
            WiFiTab.SelectedIndex = 0;
            WiFiTab.Size = new System.Drawing.Size(267, 290);
            WiFiTab.TabIndex = 2;
            // 
            // tabOptions
            // 
            tabOptions.Controls.Add(gbStartup);
            tabOptions.Controls.Add(dlSource);
            tabOptions.Controls.Add(chkOffline);
            tabOptions.Controls.Add(chkMsUpd);
            tabOptions.Controls.Add(chkOld);
            tabOptions.Controls.Add(chkManual);
            tabOptions.Controls.Add(chkDownload);
            tabOptions.Location = new System.Drawing.Point(4, 24);
            tabOptions.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabOptions.Name = "tabOptions";
            tabOptions.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabOptions.Size = new System.Drawing.Size(259, 262);
            tabOptions.TabIndex = 0;
            tabOptions.Text = "Options";
            // 
            // gbStartup
            // 
            gbStartup.Controls.Add(lblScheduleOn);
            gbStartup.Controls.Add(dlScheduleDay);
            gbStartup.Controls.Add(dlScheduleHour);
            gbStartup.Controls.Add(chkAutoRun);
            gbStartup.Controls.Add(chkNoUAC);
            gbStartup.Controls.Add(dlAutoCheck);
            gbStartup.Location = new System.Drawing.Point(9, 135);
            gbStartup.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbStartup.Name = "gbStartup";
            gbStartup.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbStartup.Size = new System.Drawing.Size(198, 122);
            gbStartup.TabIndex = 8;
            gbStartup.TabStop = false;
            gbStartup.Text = "Startup";
            // 
            // lblScheduleOn
            // 
            lblScheduleOn.AutoSize = true;
            lblScheduleOn.Location = new System.Drawing.Point(90, 95);
            lblScheduleOn.Name = "lblScheduleOn";
            lblScheduleOn.Size = new System.Drawing.Size(21, 15);
            lblScheduleOn.TabIndex = 6;
            lblScheduleOn.Text = "on";
            lblScheduleOn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblScheduleOn.Visible = false;
            // 
            // dlScheduleDay
            // 
            dlScheduleDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            dlScheduleDay.FormattingEnabled = true;
            dlScheduleDay.Location = new System.Drawing.Point(141, 92);
            dlScheduleDay.Name = "dlScheduleDay";
            dlScheduleDay.Size = new System.Drawing.Size(53, 23);
            dlScheduleDay.TabIndex = 4;
            dlScheduleDay.Visible = false;
            // 
            // dlScheduleHour
            // 
            dlScheduleHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            dlScheduleHour.FormattingEnabled = true;
            dlScheduleHour.Location = new System.Drawing.Point(4, 92);
            dlScheduleHour.Name = "dlScheduleHour";
            dlScheduleHour.Size = new System.Drawing.Size(53, 23);
            dlScheduleHour.TabIndex = 3;
            dlScheduleHour.Visible = false;
            // 
            // chkAutoRun
            // 
            chkAutoRun.AutoSize = true;
            chkAutoRun.Location = new System.Drawing.Point(5, 18);
            chkAutoRun.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkAutoRun.Name = "chkAutoRun";
            chkAutoRun.Size = new System.Drawing.Size(127, 19);
            chkAutoRun.TabIndex = 0;
            chkAutoRun.Text = "Run in background";
            chkAutoRun.ThreeState = true;
            chkAutoRun.UseVisualStyleBackColor = false;
            // 
            // chkNoUAC
            // 
            chkNoUAC.AutoSize = true;
            chkNoUAC.Location = new System.Drawing.Point(5, 40);
            chkNoUAC.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkNoUAC.Name = "chkNoUAC";
            chkNoUAC.Size = new System.Drawing.Size(174, 19);
            chkNoUAC.TabIndex = 1;
            chkNoUAC.Text = "Always run as Administrator";
            chkNoUAC.UseVisualStyleBackColor = false;
            // 
            // dlAutoCheck
            // 
            dlAutoCheck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            dlAutoCheck.Enabled = false;
            dlAutoCheck.FormattingEnabled = true;
            dlAutoCheck.Items.AddRange(new object[] { "No auto search for updates", "Search updates every day", "Search updates once a week", "Search updates every month" });
            dlAutoCheck.Location = new System.Drawing.Point(4, 63);
            dlAutoCheck.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dlAutoCheck.Name = "dlAutoCheck";
            dlAutoCheck.Size = new System.Drawing.Size(190, 23);
            dlAutoCheck.TabIndex = 2;
            // 
            // dlSource
            // 
            dlSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            dlSource.Enabled = false;
            dlSource.FormattingEnabled = true;
            dlSource.Location = new System.Drawing.Point(5, 6);
            dlSource.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dlSource.Name = "dlSource";
            dlSource.Size = new System.Drawing.Size(191, 23);
            dlSource.TabIndex = 0;
            // 
            // chkOffline
            // 
            chkOffline.AutoSize = true;
            chkOffline.Checked = true;
            chkOffline.CheckState = System.Windows.Forms.CheckState.Checked;
            chkOffline.Location = new System.Drawing.Point(9, 36);
            chkOffline.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkOffline.Name = "chkOffline";
            chkOffline.Size = new System.Drawing.Size(96, 19);
            chkOffline.TabIndex = 1;
            chkOffline.Text = "Offline Mode";
            chkOffline.UseVisualStyleBackColor = false;
            // 
            // chkMsUpd
            // 
            chkMsUpd.AutoSize = true;
            chkMsUpd.Location = new System.Drawing.Point(9, 110);
            chkMsUpd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkMsUpd.Name = "chkMsUpd";
            chkMsUpd.Size = new System.Drawing.Size(163, 19);
            chkMsUpd.TabIndex = 0;
            chkMsUpd.Text = "Register Microsoft Update";
            chkMsUpd.UseVisualStyleBackColor = false;
            // 
            // chkOld
            // 
            chkOld.AutoSize = true;
            chkOld.Location = new System.Drawing.Point(9, 92);
            chkOld.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkOld.Name = "chkOld";
            chkOld.Size = new System.Drawing.Size(128, 19);
            chkOld.TabIndex = 2;
            chkOld.Text = "Include superseded";
            chkOld.UseVisualStyleBackColor = false;
            // 
            // chkManual
            // 
            chkManual.AutoSize = true;
            chkManual.Location = new System.Drawing.Point(9, 73);
            chkManual.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkManual.Name = "chkManual";
            chkManual.Size = new System.Drawing.Size(165, 19);
            chkManual.TabIndex = 0;
            chkManual.Text = "'Manual' Download/Install";
            chkManual.UseVisualStyleBackColor = false;
            // 
            // chkDownload
            // 
            chkDownload.AutoSize = true;
            chkDownload.Checked = true;
            chkDownload.CheckState = System.Windows.Forms.CheckState.Checked;
            chkDownload.Location = new System.Drawing.Point(9, 55);
            chkDownload.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkDownload.Name = "chkDownload";
            chkDownload.Size = new System.Drawing.Size(155, 19);
            chkDownload.TabIndex = 3;
            chkDownload.Text = "Download wsusscn2.cab";
            chkDownload.UseVisualStyleBackColor = false;
            // 
            // tabAU
            // 
            tabAU.Controls.Add(label1);
            tabAU.Controls.Add(chkDrivers);
            tabAU.Controls.Add(chkStore);
            tabAU.Controls.Add(chkHideWU);
            tabAU.Controls.Add(chkDisableAU);
            tabAU.Controls.Add(radDefault);
            tabAU.Controls.Add(radSchedule);
            tabAU.Controls.Add(radDownload);
            tabAU.Controls.Add(chkBlockMS);
            tabAU.Controls.Add(radNotify);
            tabAU.Controls.Add(radDisable);
            tabAU.Controls.Add(dlShDay);
            tabAU.Controls.Add(dlShTime);
            tabAU.Location = new System.Drawing.Point(4, 24);
            tabAU.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabAU.Name = "tabAU";
            tabAU.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabAU.Size = new System.Drawing.Size(259, 262);
            tabAU.TabIndex = 1;
            tabAU.Text = "Auto Update";
            // 
            // label1
            // 
            label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            label1.Location = new System.Drawing.Point(0, 172);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(203, 2);
            label1.TabIndex = 22;
            // 
            // chkDrivers
            // 
            chkDrivers.AutoSize = true;
            chkDrivers.Location = new System.Drawing.Point(9, 218);
            chkDrivers.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkDrivers.Name = "chkDrivers";
            chkDrivers.Size = new System.Drawing.Size(104, 19);
            chkDrivers.TabIndex = 7;
            chkDrivers.Text = "Include Drivers";
            chkDrivers.ThreeState = true;
            chkDrivers.UseVisualStyleBackColor = false;
            // 
            // chkStore
            // 
            chkStore.AutoSize = true;
            chkStore.Location = new System.Drawing.Point(9, 199);
            chkStore.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkStore.Name = "chkStore";
            chkStore.Size = new System.Drawing.Size(164, 19);
            chkStore.TabIndex = 21;
            chkStore.Text = "Disable Store Auto Update";
            chkStore.UseVisualStyleBackColor = false;
            // 
            // chkHideWU
            // 
            chkHideWU.AutoSize = true;
            chkHideWU.Location = new System.Drawing.Point(9, 181);
            chkHideWU.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkHideWU.Name = "chkHideWU";
            chkHideWU.Size = new System.Drawing.Size(147, 19);
            chkHideWU.TabIndex = 1;
            chkHideWU.Text = "Hide WU Settings Page";
            chkHideWU.UseVisualStyleBackColor = false;
            // 
            // chkDisableAU
            // 
            chkDisableAU.Location = new System.Drawing.Point(19, 43);
            chkDisableAU.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkDisableAU.Name = "chkDisableAU";
            chkDisableAU.Size = new System.Drawing.Size(181, 24);
            chkDisableAU.TabIndex = 20;
            chkDisableAU.Text = "Disable Update Facilitators";
            chkDisableAU.UseVisualStyleBackColor = false;
            // 
            // radDefault
            // 
            radDefault.AutoSize = true;
            radDefault.Location = new System.Drawing.Point(9, 153);
            radDefault.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            radDefault.Name = "radDefault";
            radDefault.Size = new System.Drawing.Size(170, 19);
            radDefault.TabIndex = 19;
            radDefault.TabStop = true;
            radDefault.Text = "Automatic Update (default)";
            radDefault.UseVisualStyleBackColor = false;
            // 
            // radSchedule
            // 
            radSchedule.AutoSize = true;
            radSchedule.Location = new System.Drawing.Point(9, 108);
            radSchedule.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            radSchedule.Name = "radSchedule";
            radSchedule.Size = new System.Drawing.Size(144, 19);
            radSchedule.TabIndex = 18;
            radSchedule.TabStop = true;
            radSchedule.Text = "Scheduled & Installation";
            radSchedule.UseVisualStyleBackColor = false;
            // 
            // radDownload
            // 
            radDownload.AutoSize = true;
            radDownload.Location = new System.Drawing.Point(9, 87);
            radDownload.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            radDownload.Name = "radDownload";
            radDownload.Size = new System.Drawing.Size(107, 19);
            radDownload.TabIndex = 17;
            radDownload.TabStop = true;
            radDownload.Text = "Download Only";
            radDownload.UseVisualStyleBackColor = false;
            // 
            // chkBlockMS
            // 
            chkBlockMS.AutoSize = true;
            chkBlockMS.Location = new System.Drawing.Point(9, 8);
            chkBlockMS.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkBlockMS.Name = "chkBlockMS";
            chkBlockMS.Size = new System.Drawing.Size(170, 19);
            chkBlockMS.TabIndex = 4;
            chkBlockMS.Text = "Block Access to WU Servers";
            chkBlockMS.UseVisualStyleBackColor = false;
            // 
            // radNotify
            // 
            radNotify.AutoSize = true;
            radNotify.Location = new System.Drawing.Point(9, 66);
            radNotify.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            radNotify.Name = "radNotify";
            radNotify.Size = new System.Drawing.Size(116, 19);
            radNotify.TabIndex = 16;
            radNotify.TabStop = true;
            radNotify.Text = "Notification Only";
            radNotify.UseVisualStyleBackColor = false;
            // 
            // radDisable
            // 
            radDisable.AutoSize = true;
            radDisable.Location = new System.Drawing.Point(9, 28);
            radDisable.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            radDisable.Name = "radDisable";
            radDisable.Size = new System.Drawing.Size(163, 19);
            radDisable.TabIndex = 15;
            radDisable.TabStop = true;
            radDisable.Text = "Disable Automatic Update";
            radDisable.UseVisualStyleBackColor = false;
            // 
            // dlShDay
            // 
            dlShDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            dlShDay.Enabled = false;
            dlShDay.FormattingEnabled = true;
            dlShDay.Items.AddRange(new object[] { "Daily", "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" });
            dlShDay.Location = new System.Drawing.Point(9, 125);
            dlShDay.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dlShDay.Name = "dlShDay";
            dlShDay.Size = new System.Drawing.Size(104, 23);
            dlShDay.TabIndex = 5;
            // 
            // dlShTime
            // 
            dlShTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            dlShTime.Enabled = false;
            dlShTime.FormattingEnabled = true;
            dlShTime.Items.AddRange(new object[] { "00:00", "01:00", "02:00", "03:00", "04:00", "05:00", "06:00", "07:00", "08:00", "09:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00", "19:00", "20:00", "21:00", "22:00", "23:00" });
            dlShTime.Location = new System.Drawing.Point(121, 125);
            dlShTime.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dlShTime.Name = "dlShTime";
            dlShTime.Size = new System.Drawing.Size(63, 23);
            dlShTime.TabIndex = 6;
            // 
            // tabWiFi
            // 
            tabWiFi.BackColor = System.Drawing.SystemColors.Control;
            tabWiFi.Controls.Add(WiFiBox);
            tabWiFi.ForeColor = System.Drawing.SystemColors.ControlText;
            tabWiFi.Location = new System.Drawing.Point(4, 24);
            tabWiFi.Name = "tabWiFi";
            tabWiFi.Padding = new System.Windows.Forms.Padding(3);
            tabWiFi.Size = new System.Drawing.Size(259, 262);
            tabWiFi.TabIndex = 2;
            tabWiFi.Text = "WiFi";
            // 
            // tabParanoid
            // 
            tabParanoid.BackColor = System.Drawing.SystemColors.Control;
            tabParanoid.Location = new System.Drawing.Point(4, 24);
            tabParanoid.Name = "tabParanoid";
            tabParanoid.Padding = new System.Windows.Forms.Padding(3);
            tabParanoid.Size = new System.Drawing.Size(259, 252);
            tabParanoid.TabIndex = 3;
            tabParanoid.Text = "Paranoid";
            // 
            // tabWiFiconnectchk
            // 
            tabWiFiconnectchk.AutoSize = true;
            tabWiFiconnectchk.Location = new System.Drawing.Point(6, 73);
            tabWiFiconnectchk.Name = "tabWiFiconnectchk";
            tabWiFiconnectchk.Size = new System.Drawing.Size(200, 19);
            tabWiFiconnectchk.TabIndex = 0;
            tabWiFiconnectchk.Text = "Connect before check/download";
            tabWiFiconnectchk.UseVisualStyleBackColor = true;
            tabWiFiconnectchk.UseWaitCursor = true;
            // 
            // tabWiFiDisconnectchk
            // 
            tabWiFiDisconnectchk.AutoSize = true;
            tabWiFiDisconnectchk.Location = new System.Drawing.Point(6, 98);
            tabWiFiDisconnectchk.Name = "tabWiFiDisconnectchk";
            tabWiFiDisconnectchk.Size = new System.Drawing.Size(168, 19);
            tabWiFiDisconnectchk.TabIndex = 1;
            tabWiFiDisconnectchk.Text = "Disconnect after download";
            tabWiFiDisconnectchk.UseVisualStyleBackColor = true;
            tabWiFiDisconnectchk.UseWaitCursor = true;
            // 
            // tabWifiprofilecmb
            // 
            tabWifiprofilecmb.FormattingEnabled = true;
            tabWifiprofilecmb.Location = new System.Drawing.Point(6, 44);
            tabWifiprofilecmb.Name = "tabWifiprofilecmb";
            tabWifiprofilecmb.RightToLeft = System.Windows.Forms.RightToLeft.No;
            tabWifiprofilecmb.Size = new System.Drawing.Size(138, 23);
            tabWifiprofilecmb.TabIndex = 2;
            tabWifiprofilecmb.UseWaitCursor = true;
            tabWifiprofilecmb.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // WiFiBox
            // 
            WiFiBox.Controls.Add(tabWiFistatuslbl);
            WiFiBox.Controls.Add(tabWiFIrefreshbtn);
            WiFiBox.Controls.Add(tabWiFiprofilelbl);
            WiFiBox.Controls.Add(tabWiFitogglebtn);
            WiFiBox.Controls.Add(tabWifiprofilecmb);
            WiFiBox.Controls.Add(tabWiFiDisconnectchk);
            WiFiBox.Controls.Add(tabWiFiconnectchk);
            WiFiBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            WiFiBox.Location = new System.Drawing.Point(6, 7);
            WiFiBox.Name = "WiFiBox";
            WiFiBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            WiFiBox.Size = new System.Drawing.Size(247, 239);
            WiFiBox.TabIndex = 3;
            WiFiBox.TabStop = false;
            WiFiBox.Text = "WiFi for Updates";
            WiFiBox.UseWaitCursor = true;
            // 
            // tabWiFitogglebtn
            // 
            tabWiFitogglebtn.Location = new System.Drawing.Point(6, 123);
            tabWiFitogglebtn.Name = "tabWiFitogglebtn";
            tabWiFitogglebtn.Size = new System.Drawing.Size(142, 36);
            tabWiFitogglebtn.TabIndex = 3;
            tabWiFitogglebtn.UseVisualStyleBackColor = true;
            tabWiFitogglebtn.UseWaitCursor = true;
            // 
            // tabWiFiprofilelbl
            // 
            tabWiFiprofilelbl.AutoSize = true;
            tabWiFiprofilelbl.Location = new System.Drawing.Point(10, 28);
            tabWiFiprofilelbl.Name = "tabWiFiprofilelbl";
            tabWiFiprofilelbl.Size = new System.Drawing.Size(44, 15);
            tabWiFiprofilelbl.TabIndex = 4;
            tabWiFiprofilelbl.Text = "Profile:";
            // 
            // tabWiFIrefreshbtn
            // 
            tabWiFIrefreshbtn.Location = new System.Drawing.Point(146, 44);
            tabWiFIrefreshbtn.Name = "tabWiFIrefreshbtn";
            tabWiFIrefreshbtn.Size = new System.Drawing.Size(25, 23);
            tabWiFIrefreshbtn.TabIndex = 5;
            tabWiFIrefreshbtn.UseVisualStyleBackColor = true;
            // 
            // tabWiFistatuslbl
            // 
            tabWiFistatuslbl.AutoSize = true;
            tabWiFistatuslbl.Location = new System.Drawing.Point(6, 162);
            tabWiFistatuslbl.Name = "tabWiFistatuslbl";
            tabWiFistatuslbl.Size = new System.Drawing.Size(38, 15);
            tabWiFistatuslbl.TabIndex = 7;
            tabWiFistatuslbl.Text = "label3";
            // 
            // form_settings
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new System.Drawing.Size(267, 293);
            Controls.Add(WiFiTab);
            Name = "form_settings";
            Text = "Settings";
            WiFiTab.ResumeLayout(false);
            tabOptions.ResumeLayout(false);
            tabOptions.PerformLayout();
            gbStartup.ResumeLayout(false);
            gbStartup.PerformLayout();
            tabAU.ResumeLayout(false);
            tabAU.PerformLayout();
            tabWiFi.ResumeLayout(false);
            WiFiBox.ResumeLayout(false);
            WiFiBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl WiFiTab;
        private System.Windows.Forms.TabPage tabOptions;
        private System.Windows.Forms.GroupBox gbStartup;
        private System.Windows.Forms.Label lblScheduleOn;
        private System.Windows.Forms.ComboBox dlScheduleDay;
        private System.Windows.Forms.ComboBox dlScheduleHour;
        private System.Windows.Forms.CheckBox chkAutoRun;
        private System.Windows.Forms.CheckBox chkNoUAC;
        private System.Windows.Forms.ComboBox dlAutoCheck;
        private System.Windows.Forms.ComboBox dlSource;
        private System.Windows.Forms.CheckBox chkOffline;
        private System.Windows.Forms.CheckBox chkMsUpd;
        private System.Windows.Forms.CheckBox chkOld;
        private System.Windows.Forms.CheckBox chkManual;
        private System.Windows.Forms.CheckBox chkDownload;
        private System.Windows.Forms.TabPage tabAU;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkDrivers;
        private System.Windows.Forms.CheckBox chkStore;
        private System.Windows.Forms.CheckBox chkHideWU;
        private System.Windows.Forms.CheckBox chkDisableAU;
        private System.Windows.Forms.RadioButton radDefault;
        private System.Windows.Forms.RadioButton radSchedule;
        private System.Windows.Forms.RadioButton radDownload;
        private System.Windows.Forms.CheckBox chkBlockMS;
        private System.Windows.Forms.RadioButton radNotify;
        private System.Windows.Forms.RadioButton radDisable;
        private System.Windows.Forms.ComboBox dlShDay;
        private System.Windows.Forms.ComboBox dlShTime;
        private System.Windows.Forms.TabPage tabWiFi;
        private System.Windows.Forms.TabPage tabParanoid;
        private System.Windows.Forms.GroupBox WiFiBox;
        private System.Windows.Forms.ComboBox tabWifiprofilecmb;
        private System.Windows.Forms.CheckBox tabWiFiDisconnectchk;
        private System.Windows.Forms.CheckBox tabWiFiconnectchk;
        private System.Windows.Forms.Button tabWiFitogglebtn;
        private System.Windows.Forms.Button tabWiFIrefreshbtn;
        private System.Windows.Forms.Label tabWiFiprofilelbl;
        private System.Windows.Forms.Label tabWiFistatuslbl;
    }
}