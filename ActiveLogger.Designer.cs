namespace ActiveLogger
{
    partial class ActiveLogger
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActiveLogger));
            this.maxFileSizeText = new System.Windows.Forms.TextBox();
            this.maxLogFileSizeLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.maxErrorCountLabel = new System.Windows.Forms.Label();
            this.maxErrorCountText = new System.Windows.Forms.TextBox();
            this.tipBytesLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.jumpToWebLinkButton = new System.Windows.Forms.LinkLabel();
            this.serviceStatusGroupBox = new System.Windows.Forms.GroupBox();
            this.serviceStatusButton = new System.Windows.Forms.Button();
            this.serviceStatusPicture = new System.Windows.Forms.PictureBox();
            this.informationGroupBox = new System.Windows.Forms.GroupBox();
            this.versionInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.currentVersionStatus = new System.Windows.Forms.Label();
            this.currentVersionLabel = new System.Windows.Forms.Label();
            this.informationLabel = new System.Windows.Forms.Label();
            this.serviceStatusLabel = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.currentLanguageCombo = new System.Windows.Forms.ComboBox();
            this.hotKeysGroupBox = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ModifierList = new System.Windows.Forms.CheckedListBox();
            this.hidesActiveLoggerLabel = new System.Windows.Forms.Label();
            this.MainCombo = new System.Windows.Forms.ComboBox();
            this.generalGroupBox = new System.Windows.Forms.GroupBox();
            this.settingsDescTipLabel = new System.Windows.Forms.Label();
            this.settingsDescLabel = new System.Windows.Forms.Label();
            this.tipSecondsLabel = new System.Windows.Forms.Label();
            this.unpressedTimeThreshHoldText = new System.Windows.Forms.TextBox();
            this.timeThresholdLabel = new System.Windows.Forms.Label();
            this.adminPasswordLabel = new System.Windows.Forms.Label();
            this.adminPasswordText = new System.Windows.Forms.TextBox();
            this.setDefaultsButton = new System.Windows.Forms.Button();
            this.mainTab = new System.Windows.Forms.TabControl();
            this.serviceStatusTab = new System.Windows.Forms.TabPage();
            this.keyLogTab = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.clearKeyLogFileButton = new System.Windows.Forms.Button();
            this.keyLogText = new System.Windows.Forms.TextBox();
            this.keyLogSaveAsButton = new System.Windows.Forms.Button();
            this.errorLogTab = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.clearErrorLogFileButton = new System.Windows.Forms.Button();
            this.errorLogSaveAsButton = new System.Windows.Forms.Button();
            this.errorLogText = new System.Windows.Forms.TextBox();
            this.settingsTab = new System.Windows.Forms.TabPage();
            this.closeAppButton = new System.Windows.Forms.Button();
            this.activeLogContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activeLogNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.saveLogFileAs = new System.Windows.Forms.SaveFileDialog();
            this.groupBox2.SuspendLayout();
            this.serviceStatusGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.serviceStatusPicture)).BeginInit();
            this.versionInfoGroupBox.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.hotKeysGroupBox.SuspendLayout();
            this.generalGroupBox.SuspendLayout();
            this.mainTab.SuspendLayout();
            this.serviceStatusTab.SuspendLayout();
            this.keyLogTab.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.errorLogTab.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.settingsTab.SuspendLayout();
            this.activeLogContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // maxFileSizeText
            // 
            this.maxFileSizeText.AccessibleDescription = null;
            this.maxFileSizeText.AccessibleName = null;
            resources.ApplyResources(this.maxFileSizeText, "maxFileSizeText");
            this.maxFileSizeText.BackgroundImage = null;
            this.maxFileSizeText.Font = null;
            this.maxFileSizeText.Name = "maxFileSizeText";
            this.maxFileSizeText.Tag = "1";
            this.maxFileSizeText.MouseLeave += new System.EventHandler(this.settingsProperties_MouseLeave);
            this.maxFileSizeText.MouseMove += new System.Windows.Forms.MouseEventHandler(this.settingsProperties_MouseMove);
            this.maxFileSizeText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.isPressedKeyDigit);
            // 
            // maxLogFileSizeLabel
            // 
            this.maxLogFileSizeLabel.AccessibleDescription = null;
            this.maxLogFileSizeLabel.AccessibleName = null;
            resources.ApplyResources(this.maxLogFileSizeLabel, "maxLogFileSizeLabel");
            this.maxLogFileSizeLabel.Font = null;
            this.maxLogFileSizeLabel.Name = "maxLogFileSizeLabel";
            // 
            // okButton
            // 
            this.okButton.AccessibleDescription = null;
            this.okButton.AccessibleName = null;
            resources.ApplyResources(this.okButton, "okButton");
            this.okButton.BackgroundImage = null;
            this.okButton.Font = null;
            this.okButton.Name = "okButton";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.AccessibleDescription = null;
            this.cancelButton.AccessibleName = null;
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.BackgroundImage = null;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Font = null;
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // maxErrorCountLabel
            // 
            this.maxErrorCountLabel.AccessibleDescription = null;
            this.maxErrorCountLabel.AccessibleName = null;
            resources.ApplyResources(this.maxErrorCountLabel, "maxErrorCountLabel");
            this.maxErrorCountLabel.Font = null;
            this.maxErrorCountLabel.Name = "maxErrorCountLabel";
            // 
            // maxErrorCountText
            // 
            this.maxErrorCountText.AccessibleDescription = null;
            this.maxErrorCountText.AccessibleName = null;
            resources.ApplyResources(this.maxErrorCountText, "maxErrorCountText");
            this.maxErrorCountText.BackgroundImage = null;
            this.maxErrorCountText.Font = null;
            this.maxErrorCountText.Name = "maxErrorCountText";
            this.maxErrorCountText.Tag = "2";
            this.maxErrorCountText.MouseLeave += new System.EventHandler(this.settingsProperties_MouseLeave);
            this.maxErrorCountText.MouseMove += new System.Windows.Forms.MouseEventHandler(this.settingsProperties_MouseMove);
            this.maxErrorCountText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.isPressedKeyDigit);
            // 
            // tipBytesLabel
            // 
            this.tipBytesLabel.AccessibleDescription = null;
            this.tipBytesLabel.AccessibleName = null;
            resources.ApplyResources(this.tipBytesLabel, "tipBytesLabel");
            this.tipBytesLabel.Font = null;
            this.tipBytesLabel.Name = "tipBytesLabel";
            // 
            // groupBox2
            // 
            this.groupBox2.AccessibleDescription = null;
            this.groupBox2.AccessibleName = null;
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.BackgroundImage = null;
            this.groupBox2.Controls.Add(this.jumpToWebLinkButton);
            this.groupBox2.Controls.Add(this.serviceStatusGroupBox);
            this.groupBox2.Controls.Add(this.informationGroupBox);
            this.groupBox2.Controls.Add(this.versionInfoGroupBox);
            this.groupBox2.Controls.Add(this.informationLabel);
            this.groupBox2.Controls.Add(this.serviceStatusLabel);
            this.groupBox2.Font = null;
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // jumpToWebLinkButton
            // 
            this.jumpToWebLinkButton.AccessibleDescription = null;
            this.jumpToWebLinkButton.AccessibleName = null;
            resources.ApplyResources(this.jumpToWebLinkButton, "jumpToWebLinkButton");
            this.jumpToWebLinkButton.Font = null;
            this.jumpToWebLinkButton.Name = "jumpToWebLinkButton";
            this.jumpToWebLinkButton.TabStop = true;
            // 
            // serviceStatusGroupBox
            // 
            this.serviceStatusGroupBox.AccessibleDescription = null;
            this.serviceStatusGroupBox.AccessibleName = null;
            resources.ApplyResources(this.serviceStatusGroupBox, "serviceStatusGroupBox");
            this.serviceStatusGroupBox.BackgroundImage = null;
            this.serviceStatusGroupBox.Controls.Add(this.serviceStatusButton);
            this.serviceStatusGroupBox.Controls.Add(this.serviceStatusPicture);
            this.serviceStatusGroupBox.Font = null;
            this.serviceStatusGroupBox.Name = "serviceStatusGroupBox";
            this.serviceStatusGroupBox.TabStop = false;
            // 
            // serviceStatusButton
            // 
            this.serviceStatusButton.AccessibleDescription = null;
            this.serviceStatusButton.AccessibleName = null;
            resources.ApplyResources(this.serviceStatusButton, "serviceStatusButton");
            this.serviceStatusButton.BackgroundImage = null;
            this.serviceStatusButton.Font = null;
            this.serviceStatusButton.Name = "serviceStatusButton";
            this.serviceStatusButton.UseVisualStyleBackColor = true;
            this.serviceStatusButton.Click += new System.EventHandler(this.serviceStatusButton_Click);
            // 
            // serviceStatusPicture
            // 
            this.serviceStatusPicture.AccessibleDescription = null;
            this.serviceStatusPicture.AccessibleName = null;
            resources.ApplyResources(this.serviceStatusPicture, "serviceStatusPicture");
            this.serviceStatusPicture.BackgroundImage = global::ActiveLogger.Properties.Resources.stopped;
            this.serviceStatusPicture.Font = null;
            this.serviceStatusPicture.ImageLocation = null;
            this.serviceStatusPicture.Name = "serviceStatusPicture";
            this.serviceStatusPicture.TabStop = false;
            // 
            // informationGroupBox
            // 
            this.informationGroupBox.AccessibleDescription = null;
            this.informationGroupBox.AccessibleName = null;
            resources.ApplyResources(this.informationGroupBox, "informationGroupBox");
            this.informationGroupBox.BackgroundImage = null;
            this.informationGroupBox.Font = null;
            this.informationGroupBox.Name = "informationGroupBox";
            this.informationGroupBox.TabStop = false;
            // 
            // versionInfoGroupBox
            // 
            this.versionInfoGroupBox.AccessibleDescription = null;
            this.versionInfoGroupBox.AccessibleName = null;
            resources.ApplyResources(this.versionInfoGroupBox, "versionInfoGroupBox");
            this.versionInfoGroupBox.BackgroundImage = null;
            this.versionInfoGroupBox.Controls.Add(this.currentVersionStatus);
            this.versionInfoGroupBox.Controls.Add(this.currentVersionLabel);
            this.versionInfoGroupBox.Font = null;
            this.versionInfoGroupBox.Name = "versionInfoGroupBox";
            this.versionInfoGroupBox.TabStop = false;
            // 
            // currentVersionStatus
            // 
            this.currentVersionStatus.AccessibleDescription = null;
            this.currentVersionStatus.AccessibleName = null;
            resources.ApplyResources(this.currentVersionStatus, "currentVersionStatus");
            this.currentVersionStatus.Name = "currentVersionStatus";
            // 
            // currentVersionLabel
            // 
            this.currentVersionLabel.AccessibleDescription = null;
            this.currentVersionLabel.AccessibleName = null;
            resources.ApplyResources(this.currentVersionLabel, "currentVersionLabel");
            this.currentVersionLabel.Name = "currentVersionLabel";
            // 
            // informationLabel
            // 
            this.informationLabel.AccessibleDescription = null;
            this.informationLabel.AccessibleName = null;
            resources.ApplyResources(this.informationLabel, "informationLabel");
            this.informationLabel.Font = null;
            this.informationLabel.Name = "informationLabel";
            // 
            // serviceStatusLabel
            // 
            this.serviceStatusLabel.AccessibleDescription = null;
            this.serviceStatusLabel.AccessibleName = null;
            resources.ApplyResources(this.serviceStatusLabel, "serviceStatusLabel");
            this.serviceStatusLabel.Font = null;
            this.serviceStatusLabel.Name = "serviceStatusLabel";
            // 
            // groupBox3
            // 
            this.groupBox3.AccessibleDescription = null;
            this.groupBox3.AccessibleName = null;
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.BackgroundImage = null;
            this.groupBox3.Controls.Add(this.currentLanguageCombo);
            this.groupBox3.Controls.Add(this.hotKeysGroupBox);
            this.groupBox3.Controls.Add(this.generalGroupBox);
            this.groupBox3.Controls.Add(this.setDefaultsButton);
            this.groupBox3.Font = null;
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // currentLanguageCombo
            // 
            this.currentLanguageCombo.AccessibleDescription = null;
            this.currentLanguageCombo.AccessibleName = null;
            resources.ApplyResources(this.currentLanguageCombo, "currentLanguageCombo");
            this.currentLanguageCombo.BackgroundImage = null;
            this.currentLanguageCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.currentLanguageCombo.Font = null;
            this.currentLanguageCombo.FormattingEnabled = true;
            this.currentLanguageCombo.Items.AddRange(new object[] {
            resources.GetString("currentLanguageCombo.Items"),
            resources.GetString("currentLanguageCombo.Items1")});
            this.currentLanguageCombo.Name = "currentLanguageCombo";
            this.currentLanguageCombo.SelectedIndexChanged += new System.EventHandler(this.currentLanguageCombo_SelectedIndexChanged);
            // 
            // hotKeysGroupBox
            // 
            this.hotKeysGroupBox.AccessibleDescription = null;
            this.hotKeysGroupBox.AccessibleName = null;
            resources.ApplyResources(this.hotKeysGroupBox, "hotKeysGroupBox");
            this.hotKeysGroupBox.BackgroundImage = null;
            this.hotKeysGroupBox.Controls.Add(this.label9);
            this.hotKeysGroupBox.Controls.Add(this.ModifierList);
            this.hotKeysGroupBox.Controls.Add(this.hidesActiveLoggerLabel);
            this.hotKeysGroupBox.Controls.Add(this.MainCombo);
            this.hotKeysGroupBox.Font = null;
            this.hotKeysGroupBox.Name = "hotKeysGroupBox";
            this.hotKeysGroupBox.TabStop = false;
            // 
            // label9
            // 
            this.label9.AccessibleDescription = null;
            this.label9.AccessibleName = null;
            resources.ApplyResources(this.label9, "label9");
            this.label9.Font = null;
            this.label9.Name = "label9";
            // 
            // ModifierList
            // 
            this.ModifierList.AccessibleDescription = null;
            this.ModifierList.AccessibleName = null;
            resources.ApplyResources(this.ModifierList, "ModifierList");
            this.ModifierList.BackgroundImage = null;
            this.ModifierList.CheckOnClick = true;
            this.ModifierList.Font = null;
            this.ModifierList.Items.AddRange(new object[] {
            resources.GetString("ModifierList.Items"),
            resources.GetString("ModifierList.Items1"),
            resources.GetString("ModifierList.Items2"),
            resources.GetString("ModifierList.Items3")});
            this.ModifierList.Name = "ModifierList";
            // 
            // hidesActiveLoggerLabel
            // 
            this.hidesActiveLoggerLabel.AccessibleDescription = null;
            this.hidesActiveLoggerLabel.AccessibleName = null;
            resources.ApplyResources(this.hidesActiveLoggerLabel, "hidesActiveLoggerLabel");
            this.hidesActiveLoggerLabel.Font = null;
            this.hidesActiveLoggerLabel.Name = "hidesActiveLoggerLabel";
            // 
            // MainCombo
            // 
            this.MainCombo.AccessibleDescription = null;
            this.MainCombo.AccessibleName = null;
            resources.ApplyResources(this.MainCombo, "MainCombo");
            this.MainCombo.BackgroundImage = null;
            this.MainCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MainCombo.DropDownWidth = 40;
            this.MainCombo.Font = null;
            this.MainCombo.Name = "MainCombo";
            // 
            // generalGroupBox
            // 
            this.generalGroupBox.AccessibleDescription = null;
            this.generalGroupBox.AccessibleName = null;
            resources.ApplyResources(this.generalGroupBox, "generalGroupBox");
            this.generalGroupBox.BackgroundImage = null;
            this.generalGroupBox.Controls.Add(this.settingsDescTipLabel);
            this.generalGroupBox.Controls.Add(this.settingsDescLabel);
            this.generalGroupBox.Controls.Add(this.maxLogFileSizeLabel);
            this.generalGroupBox.Controls.Add(this.maxErrorCountLabel);
            this.generalGroupBox.Controls.Add(this.maxErrorCountText);
            this.generalGroupBox.Controls.Add(this.tipSecondsLabel);
            this.generalGroupBox.Controls.Add(this.tipBytesLabel);
            this.generalGroupBox.Controls.Add(this.unpressedTimeThreshHoldText);
            this.generalGroupBox.Controls.Add(this.maxFileSizeText);
            this.generalGroupBox.Controls.Add(this.timeThresholdLabel);
            this.generalGroupBox.Controls.Add(this.adminPasswordLabel);
            this.generalGroupBox.Controls.Add(this.adminPasswordText);
            this.generalGroupBox.Font = null;
            this.generalGroupBox.Name = "generalGroupBox";
            this.generalGroupBox.TabStop = false;
            // 
            // settingsDescTipLabel
            // 
            this.settingsDescTipLabel.AccessibleDescription = null;
            this.settingsDescTipLabel.AccessibleName = null;
            resources.ApplyResources(this.settingsDescTipLabel, "settingsDescTipLabel");
            this.settingsDescTipLabel.Font = null;
            this.settingsDescTipLabel.Name = "settingsDescTipLabel";
            // 
            // settingsDescLabel
            // 
            this.settingsDescLabel.AccessibleDescription = null;
            this.settingsDescLabel.AccessibleName = null;
            resources.ApplyResources(this.settingsDescLabel, "settingsDescLabel");
            this.settingsDescLabel.Name = "settingsDescLabel";
            // 
            // tipSecondsLabel
            // 
            this.tipSecondsLabel.AccessibleDescription = null;
            this.tipSecondsLabel.AccessibleName = null;
            resources.ApplyResources(this.tipSecondsLabel, "tipSecondsLabel");
            this.tipSecondsLabel.Font = null;
            this.tipSecondsLabel.Name = "tipSecondsLabel";
            // 
            // unpressedTimeThreshHoldText
            // 
            this.unpressedTimeThreshHoldText.AccessibleDescription = null;
            this.unpressedTimeThreshHoldText.AccessibleName = null;
            resources.ApplyResources(this.unpressedTimeThreshHoldText, "unpressedTimeThreshHoldText");
            this.unpressedTimeThreshHoldText.BackgroundImage = null;
            this.unpressedTimeThreshHoldText.Font = null;
            this.unpressedTimeThreshHoldText.Name = "unpressedTimeThreshHoldText";
            this.unpressedTimeThreshHoldText.Tag = "4";
            this.unpressedTimeThreshHoldText.MouseLeave += new System.EventHandler(this.settingsProperties_MouseLeave);
            this.unpressedTimeThreshHoldText.MouseMove += new System.Windows.Forms.MouseEventHandler(this.settingsProperties_MouseMove);
            this.unpressedTimeThreshHoldText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.isPressedKeyDigit);
            // 
            // timeThresholdLabel
            // 
            this.timeThresholdLabel.AccessibleDescription = null;
            this.timeThresholdLabel.AccessibleName = null;
            resources.ApplyResources(this.timeThresholdLabel, "timeThresholdLabel");
            this.timeThresholdLabel.Font = null;
            this.timeThresholdLabel.Name = "timeThresholdLabel";
            // 
            // adminPasswordLabel
            // 
            this.adminPasswordLabel.AccessibleDescription = null;
            this.adminPasswordLabel.AccessibleName = null;
            resources.ApplyResources(this.adminPasswordLabel, "adminPasswordLabel");
            this.adminPasswordLabel.Font = null;
            this.adminPasswordLabel.Name = "adminPasswordLabel";
            // 
            // adminPasswordText
            // 
            this.adminPasswordText.AccessibleDescription = null;
            this.adminPasswordText.AccessibleName = null;
            resources.ApplyResources(this.adminPasswordText, "adminPasswordText");
            this.adminPasswordText.BackgroundImage = null;
            this.adminPasswordText.Font = null;
            this.adminPasswordText.Name = "adminPasswordText";
            this.adminPasswordText.Tag = "3";
            this.adminPasswordText.MouseLeave += new System.EventHandler(this.settingsProperties_MouseLeave);
            this.adminPasswordText.MouseMove += new System.Windows.Forms.MouseEventHandler(this.settingsProperties_MouseMove);
            // 
            // setDefaultsButton
            // 
            this.setDefaultsButton.AccessibleDescription = null;
            this.setDefaultsButton.AccessibleName = null;
            resources.ApplyResources(this.setDefaultsButton, "setDefaultsButton");
            this.setDefaultsButton.BackgroundImage = null;
            this.setDefaultsButton.Font = null;
            this.setDefaultsButton.Name = "setDefaultsButton";
            this.setDefaultsButton.UseVisualStyleBackColor = true;
            this.setDefaultsButton.Click += new System.EventHandler(this.setDefaultsButton_Click);
            // 
            // mainTab
            // 
            this.mainTab.AccessibleDescription = null;
            this.mainTab.AccessibleName = null;
            resources.ApplyResources(this.mainTab, "mainTab");
            this.mainTab.BackgroundImage = null;
            this.mainTab.Controls.Add(this.serviceStatusTab);
            this.mainTab.Controls.Add(this.keyLogTab);
            this.mainTab.Controls.Add(this.errorLogTab);
            this.mainTab.Controls.Add(this.settingsTab);
            this.mainTab.Font = null;
            this.mainTab.Name = "mainTab";
            this.mainTab.SelectedIndex = 0;
            // 
            // serviceStatusTab
            // 
            this.serviceStatusTab.AccessibleDescription = null;
            this.serviceStatusTab.AccessibleName = null;
            resources.ApplyResources(this.serviceStatusTab, "serviceStatusTab");
            this.serviceStatusTab.BackgroundImage = null;
            this.serviceStatusTab.Controls.Add(this.groupBox2);
            this.serviceStatusTab.Font = null;
            this.serviceStatusTab.Name = "serviceStatusTab";
            this.serviceStatusTab.UseVisualStyleBackColor = true;
            // 
            // keyLogTab
            // 
            this.keyLogTab.AccessibleDescription = null;
            this.keyLogTab.AccessibleName = null;
            resources.ApplyResources(this.keyLogTab, "keyLogTab");
            this.keyLogTab.BackgroundImage = null;
            this.keyLogTab.Controls.Add(this.groupBox4);
            this.keyLogTab.Font = null;
            this.keyLogTab.Name = "keyLogTab";
            this.keyLogTab.UseVisualStyleBackColor = true;
            this.keyLogTab.Enter += new System.EventHandler(this.keyLogTab_Enter);
            // 
            // groupBox4
            // 
            this.groupBox4.AccessibleDescription = null;
            this.groupBox4.AccessibleName = null;
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.BackgroundImage = null;
            this.groupBox4.Controls.Add(this.clearKeyLogFileButton);
            this.groupBox4.Controls.Add(this.keyLogText);
            this.groupBox4.Controls.Add(this.keyLogSaveAsButton);
            this.groupBox4.Font = null;
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // clearKeyLogFileButton
            // 
            this.clearKeyLogFileButton.AccessibleDescription = null;
            this.clearKeyLogFileButton.AccessibleName = null;
            resources.ApplyResources(this.clearKeyLogFileButton, "clearKeyLogFileButton");
            this.clearKeyLogFileButton.BackgroundImage = null;
            this.clearKeyLogFileButton.Font = null;
            this.clearKeyLogFileButton.Name = "clearKeyLogFileButton";
            this.clearKeyLogFileButton.UseVisualStyleBackColor = true;
            this.clearKeyLogFileButton.Click += new System.EventHandler(this.clearKeyLogFileButton_Click);
            // 
            // keyLogText
            // 
            this.keyLogText.AcceptsReturn = true;
            this.keyLogText.AcceptsTab = true;
            this.keyLogText.AccessibleDescription = null;
            this.keyLogText.AccessibleName = null;
            resources.ApplyResources(this.keyLogText, "keyLogText");
            this.keyLogText.BackColor = System.Drawing.SystemColors.Info;
            this.keyLogText.BackgroundImage = null;
            this.keyLogText.Font = null;
            this.keyLogText.Name = "keyLogText";
            this.keyLogText.ReadOnly = true;
            // 
            // keyLogSaveAsButton
            // 
            this.keyLogSaveAsButton.AccessibleDescription = null;
            this.keyLogSaveAsButton.AccessibleName = null;
            resources.ApplyResources(this.keyLogSaveAsButton, "keyLogSaveAsButton");
            this.keyLogSaveAsButton.BackgroundImage = null;
            this.keyLogSaveAsButton.Font = null;
            this.keyLogSaveAsButton.Name = "keyLogSaveAsButton";
            this.keyLogSaveAsButton.UseVisualStyleBackColor = true;
            this.keyLogSaveAsButton.Click += new System.EventHandler(this.keyLogSaveAsButton_Click);
            // 
            // errorLogTab
            // 
            this.errorLogTab.AccessibleDescription = null;
            this.errorLogTab.AccessibleName = null;
            resources.ApplyResources(this.errorLogTab, "errorLogTab");
            this.errorLogTab.BackgroundImage = null;
            this.errorLogTab.Controls.Add(this.groupBox1);
            this.errorLogTab.Font = null;
            this.errorLogTab.Name = "errorLogTab";
            this.errorLogTab.UseVisualStyleBackColor = true;
            this.errorLogTab.Enter += new System.EventHandler(this.errorLogTab_Enter);
            // 
            // groupBox1
            // 
            this.groupBox1.AccessibleDescription = null;
            this.groupBox1.AccessibleName = null;
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.BackgroundImage = null;
            this.groupBox1.Controls.Add(this.clearErrorLogFileButton);
            this.groupBox1.Controls.Add(this.errorLogSaveAsButton);
            this.groupBox1.Controls.Add(this.errorLogText);
            this.groupBox1.Font = null;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // clearErrorLogFileButton
            // 
            this.clearErrorLogFileButton.AccessibleDescription = null;
            this.clearErrorLogFileButton.AccessibleName = null;
            resources.ApplyResources(this.clearErrorLogFileButton, "clearErrorLogFileButton");
            this.clearErrorLogFileButton.BackgroundImage = null;
            this.clearErrorLogFileButton.Font = null;
            this.clearErrorLogFileButton.Name = "clearErrorLogFileButton";
            this.clearErrorLogFileButton.UseVisualStyleBackColor = true;
            this.clearErrorLogFileButton.Click += new System.EventHandler(this.clearErrorLogFileButton_Click);
            // 
            // errorLogSaveAsButton
            // 
            this.errorLogSaveAsButton.AccessibleDescription = null;
            this.errorLogSaveAsButton.AccessibleName = null;
            resources.ApplyResources(this.errorLogSaveAsButton, "errorLogSaveAsButton");
            this.errorLogSaveAsButton.BackgroundImage = null;
            this.errorLogSaveAsButton.Font = null;
            this.errorLogSaveAsButton.Name = "errorLogSaveAsButton";
            this.errorLogSaveAsButton.UseVisualStyleBackColor = true;
            this.errorLogSaveAsButton.Click += new System.EventHandler(this.errorLogSaveAsButton_Click);
            // 
            // errorLogText
            // 
            this.errorLogText.AcceptsReturn = true;
            this.errorLogText.AcceptsTab = true;
            this.errorLogText.AccessibleDescription = null;
            this.errorLogText.AccessibleName = null;
            resources.ApplyResources(this.errorLogText, "errorLogText");
            this.errorLogText.BackColor = System.Drawing.SystemColors.Info;
            this.errorLogText.BackgroundImage = null;
            this.errorLogText.Font = null;
            this.errorLogText.Name = "errorLogText";
            this.errorLogText.ReadOnly = true;
            // 
            // settingsTab
            // 
            this.settingsTab.AccessibleDescription = null;
            this.settingsTab.AccessibleName = null;
            resources.ApplyResources(this.settingsTab, "settingsTab");
            this.settingsTab.BackgroundImage = null;
            this.settingsTab.Controls.Add(this.groupBox3);
            this.settingsTab.Font = null;
            this.settingsTab.Name = "settingsTab";
            this.settingsTab.UseVisualStyleBackColor = true;
            // 
            // closeAppButton
            // 
            this.closeAppButton.AccessibleDescription = null;
            this.closeAppButton.AccessibleName = null;
            resources.ApplyResources(this.closeAppButton, "closeAppButton");
            this.closeAppButton.BackgroundImage = null;
            this.closeAppButton.Font = null;
            this.closeAppButton.Name = "closeAppButton";
            this.closeAppButton.UseVisualStyleBackColor = true;
            this.closeAppButton.Click += new System.EventHandler(this.closeAppButton_Click);
            // 
            // activeLogContextMenu
            // 
            this.activeLogContextMenu.AccessibleDescription = null;
            this.activeLogContextMenu.AccessibleName = null;
            resources.ApplyResources(this.activeLogContextMenu, "activeLogContextMenu");
            this.activeLogContextMenu.BackgroundImage = null;
            this.activeLogContextMenu.Font = null;
            this.activeLogContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.activeLogContextMenu.Name = "activeLogCentextMenu";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.AccessibleDescription = null;
            this.settingsToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.settingsToolStripMenuItem, "settingsToolStripMenuItem");
            this.settingsToolStripMenuItem.BackgroundImage = null;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.AccessibleDescription = null;
            this.exitToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.BackgroundImage = null;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // activeLogNotifyIcon
            // 
            this.activeLogNotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            resources.ApplyResources(this.activeLogNotifyIcon, "activeLogNotifyIcon");
            this.activeLogNotifyIcon.ContextMenuStrip = this.activeLogContextMenu;
            // 
            // saveLogFileAs
            // 
            resources.ApplyResources(this.saveLogFileAs, "saveLogFileAs");
            // 
            // ActiveLogger
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.mainTab);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.closeAppButton);
            this.Controls.Add(this.cancelButton);
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ActiveLogger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ActiveLogger_FormClosing);
            this.Load += new System.EventHandler(this.ActiveLogger_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.serviceStatusGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.serviceStatusPicture)).EndInit();
            this.versionInfoGroupBox.ResumeLayout(false);
            this.versionInfoGroupBox.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.hotKeysGroupBox.ResumeLayout(false);
            this.hotKeysGroupBox.PerformLayout();
            this.generalGroupBox.ResumeLayout(false);
            this.generalGroupBox.PerformLayout();
            this.mainTab.ResumeLayout(false);
            this.serviceStatusTab.ResumeLayout(false);
            this.keyLogTab.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.errorLogTab.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.settingsTab.ResumeLayout(false);
            this.activeLogContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox maxFileSizeText;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label maxLogFileSizeLabel;
        private System.Windows.Forms.Label maxErrorCountLabel;
        private System.Windows.Forms.TextBox maxErrorCountText;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label tipBytesLabel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TabControl mainTab;
        private System.Windows.Forms.TabPage serviceStatusTab;
        private System.Windows.Forms.TabPage settingsTab;
        private System.Windows.Forms.Button closeAppButton;
        private System.Windows.Forms.PictureBox serviceStatusPicture;
        private System.Windows.Forms.Button serviceStatusButton;
        private System.Windows.Forms.Label serviceStatusLabel;
        private System.Windows.Forms.ContextMenuStrip activeLogContextMenu;
        private System.Windows.Forms.NotifyIcon activeLogNotifyIcon;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TextBox unpressedTimeThreshHoldText;
        private System.Windows.Forms.Label timeThresholdLabel;
        private System.Windows.Forms.TextBox adminPasswordText;
        private System.Windows.Forms.Label adminPasswordLabel;
        private System.Windows.Forms.Label tipSecondsLabel;
        private System.Windows.Forms.TabPage keyLogTab;
        private System.Windows.Forms.TabPage errorLogTab;
        private System.Windows.Forms.Button keyLogSaveAsButton;
        private System.Windows.Forms.TextBox keyLogText;
        private System.Windows.Forms.TextBox errorLogText;
        private System.Windows.Forms.Label informationLabel;
        private System.Windows.Forms.SaveFileDialog saveLogFileAs;
        private System.Windows.Forms.Button setDefaultsButton;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button errorLogSaveAsButton;
        private System.Windows.Forms.Button clearKeyLogFileButton;
        private System.Windows.Forms.Button clearErrorLogFileButton;
        private System.Windows.Forms.GroupBox hotKeysGroupBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckedListBox ModifierList;
        private System.Windows.Forms.Label hidesActiveLoggerLabel;
        private System.Windows.Forms.ComboBox MainCombo;
        private System.Windows.Forms.GroupBox generalGroupBox;
        private System.Windows.Forms.Label settingsDescLabel;
        private System.Windows.Forms.Label settingsDescTipLabel;
        private System.Windows.Forms.GroupBox versionInfoGroupBox;
        private System.Windows.Forms.Label currentVersionLabel;
        private System.Windows.Forms.GroupBox serviceStatusGroupBox;
        private System.Windows.Forms.GroupBox informationGroupBox;
        private System.Windows.Forms.Label currentVersionStatus;
        private System.Windows.Forms.LinkLabel jumpToWebLinkButton;
        private System.Windows.Forms.ComboBox currentLanguageCombo;
    }
}

