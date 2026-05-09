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
            btn_settings = new System.Windows.Forms.Button();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            panelList.SuspendLayout();
            tableLayoutPanel7.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
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
            panelList.Controls.Add(logBox, 0, 3);
            panelList.Controls.Add(tableLayoutPanel3, 0, 2);
            panelList.Controls.Add(updateView, 0, 1);
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
            tableLayoutPanel2.Controls.Add(btn_settings, 0, 2);
            tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
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
            // btn_settings
            // 
            btn_settings.Location = new System.Drawing.Point(3, 492);
            btn_settings.Name = "btn_settings";
            btn_settings.Size = new System.Drawing.Size(213, 23);
            btn_settings.TabIndex = 1;
            btn_settings.Text = "Settings";
            btn_settings.UseVisualStyleBackColor = true;
            btn_settings.Click += btn_settings_Click;
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
        private System.Windows.Forms.ComboBox dlColorMode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RichTextBox logBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.LinkLabel lblSupport;
        private ListViewExtended updateView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btnSearchOff;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.CheckBox chkGrupe;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Button btn_settings;
    }
}

