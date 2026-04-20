namespace wumgr
{
    partial class WuMgr
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WuMgr));
            toolTip = new System.Windows.Forms.ToolTip(components);
            chkAutoRun = new System.Windows.Forms.CheckBox();
            updateView = new ListViewExtended();
            columnHeader1 = new System.Windows.Forms.ColumnHeader();
            columnHeader2 = new System.Windows.Forms.ColumnHeader();
            columnHeader3 = new System.Windows.Forms.ColumnHeader();
            columnHeader4 = new System.Windows.Forms.ColumnHeader();
            columnHeader5 = new System.Windows.Forms.ColumnHeader();
            columnHeader6 = new System.Windows.Forms.ColumnHeader();
            notifyIcon = new System.Windows.Forms.NotifyIcon(components);
            panelList = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            chkAll = new System.Windows.Forms.CheckBox();
            chkGrupe = new System.Windows.Forms.CheckBox();
            lblSupport = new System.Windows.Forms.LinkLabel();
            dlColorMode = new System.Windows.Forms.ComboBox();
            logBox = new System.Windows.Forms.RichTextBox();
            tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            lblSearch = new System.Windows.Forms.Label();
            txtFilter = new System.Windows.Forms.TextBox();
            btnSearchOff = new System.Windows.Forms.Button();
            tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            btnSearch = new System.Windows.Forms.Button();
            btnDownload = new System.Windows.Forms.Button();
            btnInstall = new System.Windows.Forms.Button();
            btnUnInstall = new System.Windows.Forms.Button();
            btnHide = new System.Windows.Forms.Button();
            btnGetLink = new System.Windows.Forms.Button();
            tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            btnCancel = new System.Windows.Forms.Button();
            progTotal = new System.Windows.Forms.ProgressBar();
            btnHistory = new System.Windows.Forms.CheckBox();
            btnHidden = new System.Windows.Forms.CheckBox();
            btnInstalled = new System.Windows.Forms.CheckBox();
            btnWinUpd = new System.Windows.Forms.CheckBox();
            lblStatus = new System.Windows.Forms.Label();
            tabs = new System.Windows.Forms.TabControl();
            tabOptions = new System.Windows.Forms.TabPage();
            gbStartup = new System.Windows.Forms.GroupBox();
            lblScheduleOn = new System.Windows.Forms.Label();
            dlScheduleDay = new System.Windows.Forms.ComboBox();
            dlScheduleHour = new System.Windows.Forms.ComboBox();
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
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            panelList.SuspendLayout();
            tableLayoutPanel7.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            tabs.SuspendLayout();
            tabOptions.SuspendLayout();
            gbStartup.SuspendLayout();
            tabAU.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // chkAutoRun
            // 
            chkAutoRun.AutoSize = true;
            chkAutoRun.Location = new System.Drawing.Point(4, 18);
            chkAutoRun.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkAutoRun.Name = "chkAutoRun";
            chkAutoRun.Size = new System.Drawing.Size(127, 19);
            chkAutoRun.TabIndex = 0;
            chkAutoRun.Text = "Run in background";
            chkAutoRun.ThreeState = true;
            toolTip.SetToolTip(chkAutoRun, "Auto Start with Windows");
            chkAutoRun.UseVisualStyleBackColor = false;
            chkAutoRun.CheckedChanged += chkAutoRun_CheckedChanged;
            // 
            // updateView
            // 
            updateView.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            updateView.CheckBoxes = true;
            updateView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6 });
            updateView.Location = new System.Drawing.Point(4, 26);
            updateView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            updateView.Name = "updateView";
            updateView.ShowItemToolTips = true;
            updateView.Size = new System.Drawing.Size(570, 346);
            updateView.TabIndex = 2;
            toolTip.SetToolTip(updateView, "Press Ctrl+F to filter updates");
            updateView.UseCompatibleStateImageBehavior = false;
            updateView.View = System.Windows.Forms.View.Details;
            updateView.ColumnClick += updateView_ColumnClick;
            updateView.ItemChecked += updateView_ItemChecked;
            updateView.SelectedIndexChanged += updateView_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Title";
            columnHeader1.Width = 260;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Category";
            columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "KB Article";
            columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Date";
            columnHeader4.Width = 70;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Size";
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "State";
            columnHeader6.Width = 80;
            // 
            // notifyIcon
            // 
            notifyIcon.Icon = (System.Drawing.Icon)resources.GetObject("notifyIcon.Icon");
            notifyIcon.Text = "notifyIcon1";
            notifyIcon.BalloonTipClicked += notifyIcon_BalloonTipClicked;
            notifyIcon.MouseClick += notifyIcon_MouseClick;
            // 
            // panelList
            // 
            panelList.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelList.ColumnCount = 1;
            panelList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelList.Controls.Add(tableLayoutPanel7, 0, 0);
            panelList.Controls.Add(updateView, 0, 1);
            panelList.Controls.Add(logBox, 0, 3);
            panelList.Controls.Add(tableLayoutPanel3, 0, 2);
            panelList.Location = new System.Drawing.Point(219, 0);
            panelList.Margin = new System.Windows.Forms.Padding(0);
            panelList.Name = "panelList";
            panelList.RowCount = 4;
            panelList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            panelList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            panelList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 115F));
            panelList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            panelList.Size = new System.Drawing.Size(578, 519);
            panelList.TabIndex = 1;
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tableLayoutPanel7.ColumnCount = 5;
            tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel7.Controls.Add(chkAll, 0, 0);
            tableLayoutPanel7.Controls.Add(chkGrupe, 1, 0);
            tableLayoutPanel7.Controls.Add(lblSupport, 4, 0);
            tableLayoutPanel7.Controls.Add(dlColorMode, 2, 0);
            tableLayoutPanel7.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 1;
            tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel7.Size = new System.Drawing.Size(578, 23);
            tableLayoutPanel7.TabIndex = 5;
            // 
            // chkAll
            // 
            chkAll.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            chkAll.AutoSize = true;
            chkAll.Location = new System.Drawing.Point(4, 3);
            chkAll.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkAll.Name = "chkAll";
            chkAll.Size = new System.Drawing.Size(74, 21);
            chkAll.TabIndex = 2;
            chkAll.Text = "Select All";
            chkAll.UseVisualStyleBackColor = false;
            chkAll.CheckedChanged += chkAll_CheckedChanged;
            // 
            // chkGrupe
            // 
            chkGrupe.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            chkGrupe.AutoSize = true;
            chkGrupe.Location = new System.Drawing.Point(86, 3);
            chkGrupe.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkGrupe.Name = "chkGrupe";
            chkGrupe.Size = new System.Drawing.Size(105, 21);
            chkGrupe.TabIndex = 1;
            chkGrupe.Text = "Group Updates";
            chkGrupe.UseVisualStyleBackColor = false;
            chkGrupe.CheckedChanged += chkGrupe_CheckedChanged;
            // 
            // lblSupport
            // 
            lblSupport.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lblSupport.AutoSize = true;
            lblSupport.DisabledLinkColor = System.Drawing.SystemColors.GrayText;
            lblSupport.ForeColor = System.Drawing.SystemColors.ControlText;
            lblSupport.LinkColor = System.Drawing.SystemColors.HotTrack;
            lblSupport.Location = new System.Drawing.Point(501, 6);
            lblSupport.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblSupport.Name = "lblSupport";
            lblSupport.Size = new System.Drawing.Size(73, 15);
            lblSupport.TabIndex = 0;
            lblSupport.TabStop = true;
            lblSupport.Text = "Support URL";
            lblSupport.Visible = false;
            lblSupport.VisitedLinkColor = System.Drawing.Color.Magenta;
            lblSupport.LinkClicked += lblSupport_LinkClicked;
            // 
            // dlColorMode
            // 
            dlColorMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            dlColorMode.Font = new System.Drawing.Font("Segoe UI", 8F);
            dlColorMode.FormattingEnabled = true;
            dlColorMode.Items.AddRange(new object[] { "System default", "Light (classic)", "Dark" });
            dlColorMode.Location = new System.Drawing.Point(199, 3);
            dlColorMode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dlColorMode.Name = "dlColorMode";
            dlColorMode.Size = new System.Drawing.Size(128, 21);
            dlColorMode.TabIndex = 11;
            dlColorMode.SelectedIndexChanged += dlColorMode_SelectedIndexChanged;
            // 
            // logBox
            // 
            logBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            logBox.Location = new System.Drawing.Point(4, 407);
            logBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            logBox.Name = "logBox";
            logBox.ReadOnly = true;
            logBox.Size = new System.Drawing.Size(570, 109);
            logBox.TabIndex = 4;
            logBox.Text = "";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tableLayoutPanel3.AutoSize = true;
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            tableLayoutPanel3.Controls.Add(lblSearch, 0, 0);
            tableLayoutPanel3.Controls.Add(txtFilter, 1, 0);
            tableLayoutPanel3.Controls.Add(btnSearchOff, 2, 0);
            tableLayoutPanel3.Location = new System.Drawing.Point(0, 375);
            tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanel3.Size = new System.Drawing.Size(578, 29);
            tableLayoutPanel3.TabIndex = 6;
            // 
            // lblSearch
            // 
            lblSearch.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lblSearch.AutoSize = true;
            lblSearch.Location = new System.Drawing.Point(4, 7);
            lblSearch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new System.Drawing.Size(109, 15);
            lblSearch.TabIndex = 2;
            lblSearch.Text = "Search Filter:";
            // 
            // txtFilter
            // 
            txtFilter.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtFilter.Location = new System.Drawing.Point(121, 3);
            txtFilter.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtFilter.Name = "txtFilter";
            txtFilter.Size = new System.Drawing.Size(424, 23);
            txtFilter.TabIndex = 1;
            txtFilter.TextChanged += txtFilter_TextChanged;
            // 
            // btnSearchOff
            // 
            btnSearchOff.Location = new System.Drawing.Point(553, 3);
            btnSearchOff.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnSearchOff.Name = "btnSearchOff";
            btnSearchOff.Size = new System.Drawing.Size(21, 22);
            btnSearchOff.TabIndex = 0;
            btnSearchOff.Text = "X";
            btnSearchOff.UseVisualStyleBackColor = false;
            btnSearchOff.Click += btnSearchOff_Click;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(tableLayoutPanel4, 0, 0);
            tableLayoutPanel2.Controls.Add(tabs, 0, 1);
            tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel2.Size = new System.Drawing.Size(219, 519);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel4.Controls.Add(flowLayoutPanel1, 0, 4);
            tableLayoutPanel4.Controls.Add(tableLayoutPanel5, 0, 5);
            tableLayoutPanel4.Controls.Add(btnHistory, 0, 3);
            tableLayoutPanel4.Controls.Add(btnHidden, 0, 2);
            tableLayoutPanel4.Controls.Add(btnInstalled, 0, 1);
            tableLayoutPanel4.Controls.Add(btnWinUpd, 0, 0);
            tableLayoutPanel4.Controls.Add(lblStatus, 0, 6);
            tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 7;
            tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanel4.Size = new System.Drawing.Size(217, 242);
            tableLayoutPanel4.TabIndex = 0;
            tableLayoutPanel4.Paint += tableLayoutPanel4_Paint;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnSearch);
            flowLayoutPanel1.Controls.Add(btnDownload);
            flowLayoutPanel1.Controls.Add(btnInstall);
            flowLayoutPanel1.Controls.Add(btnUnInstall);
            flowLayoutPanel1.Controls.Add(btnHide);
            flowLayoutPanel1.Controls.Add(btnGetLink);
            flowLayoutPanel1.Location = new System.Drawing.Point(4, 143);
            flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(209, 37);
            flowLayoutPanel1.TabIndex = 4;
            flowLayoutPanel1.WrapContents = false;
            // 
            // btnSearch
            // 
            btnSearch.Location = new System.Drawing.Point(0, 0);
            btnSearch.Margin = new System.Windows.Forms.Padding(0);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(35, 35);
            btnSearch.TabIndex = 0;
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnDownload
            // 
            btnDownload.Location = new System.Drawing.Point(35, 0);
            btnDownload.Margin = new System.Windows.Forms.Padding(0);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new System.Drawing.Size(35, 35);
            btnDownload.TabIndex = 1;
            btnDownload.UseVisualStyleBackColor = false;
            btnDownload.Click += btnDownload_Click;
            // 
            // btnInstall
            // 
            btnInstall.Location = new System.Drawing.Point(70, 0);
            btnInstall.Margin = new System.Windows.Forms.Padding(0);
            btnInstall.Name = "btnInstall";
            btnInstall.Size = new System.Drawing.Size(35, 35);
            btnInstall.TabIndex = 2;
            btnInstall.UseVisualStyleBackColor = false;
            btnInstall.Click += btnInstall_Click;
            // 
            // btnUnInstall
            // 
            btnUnInstall.Location = new System.Drawing.Point(105, 0);
            btnUnInstall.Margin = new System.Windows.Forms.Padding(0);
            btnUnInstall.Name = "btnUnInstall";
            btnUnInstall.Size = new System.Drawing.Size(35, 35);
            btnUnInstall.TabIndex = 3;
            btnUnInstall.UseVisualStyleBackColor = false;
            btnUnInstall.Click += btnUnInstall_Click;
            // 
            // btnHide
            // 
            btnHide.Location = new System.Drawing.Point(140, 0);
            btnHide.Margin = new System.Windows.Forms.Padding(0);
            btnHide.Name = "btnHide";
            btnHide.Size = new System.Drawing.Size(35, 35);
            btnHide.TabIndex = 4;
            btnHide.UseVisualStyleBackColor = false;
            btnHide.Click += btnHide_Click;
            // 
            // btnGetLink
            // 
            btnGetLink.Location = new System.Drawing.Point(175, 0);
            btnGetLink.Margin = new System.Windows.Forms.Padding(0);
            btnGetLink.Name = "btnGetLink";
            btnGetLink.Size = new System.Drawing.Size(35, 35);
            btnGetLink.TabIndex = 5;
            btnGetLink.UseVisualStyleBackColor = false;
            btnGetLink.Click += btnGetLink_Click;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tableLayoutPanel5.ColumnCount = 2;
            tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            tableLayoutPanel5.Controls.Add(btnCancel, 1, 0);
            tableLayoutPanel5.Controls.Add(progTotal, 0, 0);
            tableLayoutPanel5.Location = new System.Drawing.Point(4, 186);
            tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            tableLayoutPanel5.Size = new System.Drawing.Size(209, 32);
            tableLayoutPanel5.TabIndex = 5;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btnCancel.Location = new System.Drawing.Point(175, 0);
            btnCancel.Margin = new System.Windows.Forms.Padding(0);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(34, 33);
            btnCancel.TabIndex = 0;
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // progTotal
            // 
            progTotal.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            progTotal.Location = new System.Drawing.Point(4, 3);
            progTotal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            progTotal.Name = "progTotal";
            progTotal.Size = new System.Drawing.Size(167, 27);
            progTotal.TabIndex = 1;
            // 
            // btnHistory
            // 
            btnHistory.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btnHistory.Appearance = System.Windows.Forms.Appearance.Button;
            btnHistory.AutoSize = true;
            btnHistory.Location = new System.Drawing.Point(4, 108);
            btnHistory.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnHistory.Name = "btnHistory";
            btnHistory.Size = new System.Drawing.Size(209, 25);
            btnHistory.TabIndex = 6;
            btnHistory.Text = "Update History";
            btnHistory.UseVisualStyleBackColor = false;
            btnHistory.CheckedChanged += btnHistory_CheckedChanged;
            // 
            // btnHidden
            // 
            btnHidden.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btnHidden.Appearance = System.Windows.Forms.Appearance.Button;
            btnHidden.AutoSize = true;
            btnHidden.Location = new System.Drawing.Point(4, 73);
            btnHidden.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnHidden.Name = "btnHidden";
            btnHidden.Size = new System.Drawing.Size(209, 25);
            btnHidden.TabIndex = 7;
            btnHidden.Text = "Hidden Updates";
            btnHidden.UseVisualStyleBackColor = false;
            btnHidden.CheckedChanged += btnHidden_CheckedChanged;
            // 
            // btnInstalled
            // 
            btnInstalled.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btnInstalled.Appearance = System.Windows.Forms.Appearance.Button;
            btnInstalled.AutoSize = true;
            btnInstalled.Location = new System.Drawing.Point(4, 38);
            btnInstalled.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnInstalled.Name = "btnInstalled";
            btnInstalled.Size = new System.Drawing.Size(209, 25);
            btnInstalled.TabIndex = 8;
            btnInstalled.Text = "Installed Updates";
            btnInstalled.UseVisualStyleBackColor = false;
            btnInstalled.CheckedChanged += btnInstalled_CheckedChanged;
            // 
            // btnWinUpd
            // 
            btnWinUpd.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btnWinUpd.Appearance = System.Windows.Forms.Appearance.Button;
            btnWinUpd.AutoSize = true;
            btnWinUpd.Location = new System.Drawing.Point(4, 3);
            btnWinUpd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnWinUpd.Name = "btnWinUpd";
            btnWinUpd.Size = new System.Drawing.Size(209, 25);
            btnWinUpd.TabIndex = 0;
            btnWinUpd.Text = "Windows Updates";
            btnWinUpd.UseVisualStyleBackColor = false;
            btnWinUpd.CheckedChanged += btnWinUpd_CheckedChanged;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lblStatus.AutoSize = true;
            lblStatus.Location = new System.Drawing.Point(4, 225);
            lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new System.Drawing.Size(209, 15);
            lblStatus.TabIndex = 9;
            // 
            // tabs
            // 
            tabs.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tabs.Controls.Add(tabOptions);
            tabs.Controls.Add(tabAU);
            tabs.Location = new System.Drawing.Point(4, 245);
            tabs.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabs.Name = "tabs";
            tabs.SelectedIndex = 0;
            tabs.Size = new System.Drawing.Size(211, 340);
            tabs.TabIndex = 1;
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
            tabOptions.Size = new System.Drawing.Size(203, 312);
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
            gbStartup.Location = new System.Drawing.Point(1, 127);
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
            lblScheduleOn.Location = new System.Drawing.Point(89, 95);
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
            // chkNoUAC
            // 
            chkNoUAC.AutoSize = true;
            chkNoUAC.Location = new System.Drawing.Point(4, 40);
            chkNoUAC.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkNoUAC.Name = "chkNoUAC";
            chkNoUAC.Size = new System.Drawing.Size(174, 19);
            chkNoUAC.TabIndex = 1;
            chkNoUAC.Text = "Always run as Administrator";
            chkNoUAC.UseVisualStyleBackColor = false;
            chkNoUAC.CheckedChanged += chkNoUAC_CheckedChanged;
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
            dlAutoCheck.SelectedIndexChanged += dlAutoCheck_SelectedIndexChanged;
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
            dlSource.SelectedIndexChanged += dlSource_SelectedIndexChanged;
            // 
            // chkOffline
            // 
            chkOffline.AutoSize = true;
            chkOffline.Checked = true;
            chkOffline.CheckState = System.Windows.Forms.CheckState.Checked;
            chkOffline.Location = new System.Drawing.Point(5, 33);
            chkOffline.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkOffline.Name = "chkOffline";
            chkOffline.Size = new System.Drawing.Size(96, 19);
            chkOffline.TabIndex = 1;
            chkOffline.Text = "Offline Mode";
            chkOffline.UseVisualStyleBackColor = false;
            chkOffline.CheckedChanged += chkOffline_CheckedChanged;
            // 
            // chkMsUpd
            // 
            chkMsUpd.AutoSize = true;
            chkMsUpd.Location = new System.Drawing.Point(5, 107);
            chkMsUpd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkMsUpd.Name = "chkMsUpd";
            chkMsUpd.Size = new System.Drawing.Size(163, 19);
            chkMsUpd.TabIndex = 0;
            chkMsUpd.Text = "Register Microsoft Update";
            chkMsUpd.UseVisualStyleBackColor = false;
            chkMsUpd.CheckedChanged += chkMsUpd_CheckedChanged;
            // 
            // chkOld
            // 
            chkOld.AutoSize = true;
            chkOld.Location = new System.Drawing.Point(5, 89);
            chkOld.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkOld.Name = "chkOld";
            chkOld.Size = new System.Drawing.Size(128, 19);
            chkOld.TabIndex = 2;
            chkOld.Text = "Include superseded";
            chkOld.UseVisualStyleBackColor = false;
            chkOld.CheckedChanged += chkOld_CheckedChanged;
            // 
            // chkManual
            // 
            chkManual.AutoSize = true;
            chkManual.Location = new System.Drawing.Point(5, 70);
            chkManual.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkManual.Name = "chkManual";
            chkManual.Size = new System.Drawing.Size(165, 19);
            chkManual.TabIndex = 0;
            chkManual.Text = "'Manual' Download/Install";
            chkManual.UseVisualStyleBackColor = false;
            chkManual.CheckedChanged += chkManual_CheckedChanged;
            // 
            // chkDownload
            // 
            chkDownload.AutoSize = true;
            chkDownload.Checked = true;
            chkDownload.CheckState = System.Windows.Forms.CheckState.Checked;
            chkDownload.Location = new System.Drawing.Point(5, 52);
            chkDownload.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkDownload.Name = "chkDownload";
            chkDownload.Size = new System.Drawing.Size(155, 19);
            chkDownload.TabIndex = 3;
            chkDownload.Text = "Download wsusscn2.cab";
            chkDownload.UseVisualStyleBackColor = false;
            chkDownload.CheckedChanged += chkDownload_CheckedChanged;
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
            tabAU.Size = new System.Drawing.Size(203, 312);
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
            chkDrivers.Location = new System.Drawing.Point(5, 215);
            chkDrivers.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkDrivers.Name = "chkDrivers";
            chkDrivers.Size = new System.Drawing.Size(104, 19);
            chkDrivers.TabIndex = 7;
            chkDrivers.Text = "Include Drivers";
            chkDrivers.ThreeState = true;
            chkDrivers.UseVisualStyleBackColor = false;
            chkDrivers.CheckStateChanged += chkDrivers_CheckStateChanged;
            // 
            // chkStore
            // 
            chkStore.AutoSize = true;
            chkStore.Location = new System.Drawing.Point(5, 196);
            chkStore.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkStore.Name = "chkStore";
            chkStore.Size = new System.Drawing.Size(164, 19);
            chkStore.TabIndex = 21;
            chkStore.Text = "Disable Store Auto Update";
            chkStore.UseVisualStyleBackColor = false;
            chkStore.CheckedChanged += chkStore_CheckedChanged;
            // 
            // chkHideWU
            // 
            chkHideWU.AutoSize = true;
            chkHideWU.Location = new System.Drawing.Point(5, 178);
            chkHideWU.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkHideWU.Name = "chkHideWU";
            chkHideWU.Size = new System.Drawing.Size(147, 19);
            chkHideWU.TabIndex = 1;
            chkHideWU.Text = "Hide WU Settings Page";
            chkHideWU.UseVisualStyleBackColor = false;
            chkHideWU.CheckedChanged += chkHideWU_CheckedChanged;
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
            chkDisableAU.CheckedChanged += chkDisableAU_CheckedChanged;
            // 
            // radDefault
            // 
            radDefault.AutoSize = true;
            radDefault.Location = new System.Drawing.Point(5, 150);
            radDefault.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            radDefault.Name = "radDefault";
            radDefault.Size = new System.Drawing.Size(170, 19);
            radDefault.TabIndex = 19;
            radDefault.TabStop = true;
            radDefault.Text = "Automatic Update (default)";
            radDefault.UseVisualStyleBackColor = false;
            radDefault.CheckedChanged += radGPO_CheckedChanged;
            // 
            // radSchedule
            // 
            radSchedule.AutoSize = true;
            radSchedule.Location = new System.Drawing.Point(5, 105);
            radSchedule.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            radSchedule.Name = "radSchedule";
            radSchedule.Size = new System.Drawing.Size(144, 19);
            radSchedule.TabIndex = 18;
            radSchedule.TabStop = true;
            radSchedule.Text = "Scheduled & Installation";
            radSchedule.UseVisualStyleBackColor = false;
            radSchedule.CheckedChanged += radGPO_CheckedChanged;
            // 
            // radDownload
            // 
            radDownload.AutoSize = true;
            radDownload.Location = new System.Drawing.Point(5, 84);
            radDownload.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            radDownload.Name = "radDownload";
            radDownload.Size = new System.Drawing.Size(107, 19);
            radDownload.TabIndex = 17;
            radDownload.TabStop = true;
            radDownload.Text = "Download Only";
            radDownload.UseVisualStyleBackColor = false;
            radDownload.CheckedChanged += radGPO_CheckedChanged;
            // 
            // chkBlockMS
            // 
            chkBlockMS.AutoSize = true;
            chkBlockMS.Location = new System.Drawing.Point(5, 5);
            chkBlockMS.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkBlockMS.Name = "chkBlockMS";
            chkBlockMS.Size = new System.Drawing.Size(170, 19);
            chkBlockMS.TabIndex = 4;
            chkBlockMS.Text = "Block Access to WU Servers";
            chkBlockMS.UseVisualStyleBackColor = false;
            chkBlockMS.CheckedChanged += chkBlockMS_CheckedChanged;
            // 
            // radNotify
            // 
            radNotify.AutoSize = true;
            radNotify.Location = new System.Drawing.Point(5, 63);
            radNotify.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            radNotify.Name = "radNotify";
            radNotify.Size = new System.Drawing.Size(116, 19);
            radNotify.TabIndex = 16;
            radNotify.TabStop = true;
            radNotify.Text = "Notification Only";
            radNotify.UseVisualStyleBackColor = false;
            radNotify.CheckedChanged += radGPO_CheckedChanged;
            // 
            // radDisable
            // 
            radDisable.AutoSize = true;
            radDisable.Location = new System.Drawing.Point(5, 25);
            radDisable.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            radDisable.Name = "radDisable";
            radDisable.Size = new System.Drawing.Size(163, 19);
            radDisable.TabIndex = 15;
            radDisable.TabStop = true;
            radDisable.Text = "Disable Automatic Update";
            radDisable.UseVisualStyleBackColor = false;
            radDisable.CheckedChanged += radGPO_CheckedChanged;
            // 
            // dlShDay
            // 
            dlShDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            dlShDay.Enabled = false;
            dlShDay.FormattingEnabled = true;
            dlShDay.Items.AddRange(new object[] { "Daily", "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" });
            dlShDay.Location = new System.Drawing.Point(21, 125);
            dlShDay.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dlShDay.Name = "dlShDay";
            dlShDay.Size = new System.Drawing.Size(104, 23);
            dlShDay.TabIndex = 5;
            dlShDay.SelectedIndexChanged += dlShDay_SelectedIndexChanged;
            // 
            // dlShTime
            // 
            dlShTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            dlShTime.Enabled = false;
            dlShTime.FormattingEnabled = true;
            dlShTime.Items.AddRange(new object[] { "00:00", "01:00", "02:00", "03:00", "04:00", "05:00", "06:00", "07:00", "08:00", "09:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00", "19:00", "20:00", "21:00", "22:00", "23:00" });
            dlShTime.Location = new System.Drawing.Point(133, 125);
            dlShTime.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dlShTime.Name = "dlShTime";
            dlShTime.Size = new System.Drawing.Size(63, 23);
            dlShTime.TabIndex = 6;
            dlShTime.SelectedIndexChanged += dlShTime_SelectedIndexChanged;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(panelList, 1, 0);
            tableLayoutPanel1.Location = new System.Drawing.Point(1, 2);
            tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new System.Drawing.Size(797, 519);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // WuMgr
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(799, 524);
            Controls.Add(tableLayoutPanel1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MinimumSize = new System.Drawing.Size(814, 554);
            Name = "WuMgr";
            Text = "Update Manager for Windows";
            FormClosing += WuMgr_FormClosing;
            Load += WuMgr_Load;
            panelList.ResumeLayout(false);
            panelList.PerformLayout();
            tableLayoutPanel7.ResumeLayout(false);
            tableLayoutPanel7.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tabs.ResumeLayout(false);
            tabOptions.ResumeLayout(false);
            tabOptions.PerformLayout();
            gbStartup.ResumeLayout(false);
            gbStartup.PerformLayout();
            tabAU.ResumeLayout(false);
            tabAU.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.TableLayoutPanel panelList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.Button btnUnInstall;
        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.Button btnGetLink;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ProgressBar progTotal;
        private System.Windows.Forms.CheckBox btnHistory;
        private System.Windows.Forms.CheckBox btnHidden;
        private System.Windows.Forms.CheckBox btnInstalled;
        private System.Windows.Forms.CheckBox btnWinUpd;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.CheckBox chkBlockMS;
        private System.Windows.Forms.CheckBox chkDrivers;
        private System.Windows.Forms.ComboBox dlShTime;
        private System.Windows.Forms.ComboBox dlShDay;
        private System.Windows.Forms.CheckBox chkNoUAC;
        private System.Windows.Forms.CheckBox chkMsUpd;
        private System.Windows.Forms.CheckBox chkOld;
        private System.Windows.Forms.ComboBox dlSource;
        private System.Windows.Forms.CheckBox chkOffline;
        private System.Windows.Forms.CheckBox chkDownload;
        private System.Windows.Forms.CheckBox chkManual;
        private System.Windows.Forms.ComboBox dlColorMode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RichTextBox logBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.LinkLabel lblSupport;
        private System.Windows.Forms.CheckBox chkHideWU;
        private ListViewExtended updateView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabOptions;
        private System.Windows.Forms.ComboBox dlAutoCheck;
        private System.Windows.Forms.CheckBox chkAutoRun;
        private System.Windows.Forms.TabPage tabAU;
        private System.Windows.Forms.CheckBox chkStore;
        private System.Windows.Forms.CheckBox chkDisableAU;
        private System.Windows.Forms.RadioButton radDefault;
        private System.Windows.Forms.RadioButton radSchedule;
        private System.Windows.Forms.RadioButton radDownload;
        private System.Windows.Forms.RadioButton radNotify;
        private System.Windows.Forms.RadioButton radDisable;
        private System.Windows.Forms.GroupBox gbStartup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btnSearchOff;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.CheckBox chkGrupe;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.ComboBox dlScheduleHour;
        private System.Windows.Forms.ComboBox dlScheduleDay;
        private System.Windows.Forms.Label lblScheduleOn;
    }
}

