namespace ClientModSyncGUI {
    partial class FrmMain {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.GroupSync = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnSelectProgram = new System.Windows.Forms.Button();
            this.TxtCommand = new System.Windows.Forms.TextBox();
            this.LblAfterSync = new System.Windows.Forms.Label();
            this.ComboAction = new System.Windows.Forms.ComboBox();
            this.ChkAutoSyncMod = new System.Windows.Forms.CheckBox();
            this.TxtServerName = new System.Windows.Forms.TextBox();
            this.LblServerName = new System.Windows.Forms.Label();
            this.BtnSync = new System.Windows.Forms.Button();
            this.BtnResetConfig = new System.Windows.Forms.Button();
            this.GroupConfig = new System.Windows.Forms.GroupBox();
            this.ChkAutoUpdate = new System.Windows.Forms.CheckBox();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.BtnSaveConfig = new System.Windows.Forms.Button();
            this.Progress = new System.Windows.Forms.ProgressBar();
            this.TxtLog = new System.Windows.Forms.TextBox();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.GroupSync.SuspendLayout();
            this.GroupConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupSync
            // 
            this.GroupSync.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupSync.Controls.Add(this.label1);
            this.GroupSync.Controls.Add(this.BtnSelectProgram);
            this.GroupSync.Controls.Add(this.TxtCommand);
            this.GroupSync.Controls.Add(this.LblAfterSync);
            this.GroupSync.Controls.Add(this.ComboAction);
            this.GroupSync.Controls.Add(this.ChkAutoSyncMod);
            this.GroupSync.Controls.Add(this.TxtServerName);
            this.GroupSync.Controls.Add(this.LblServerName);
            this.GroupSync.Controls.Add(this.BtnSync);
            this.GroupSync.Location = new System.Drawing.Point(12, 12);
            this.GroupSync.MinimumSize = new System.Drawing.Size(0, 100);
            this.GroupSync.Name = "GroupSync";
            this.GroupSync.Size = new System.Drawing.Size(544, 170);
            this.GroupSync.TabIndex = 5;
            this.GroupSync.TabStop = false;
            this.GroupSync.Text = "同步设置";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "同步后要执行的程序";
            // 
            // BtnSelectProgram
            // 
            this.BtnSelectProgram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSelectProgram.Location = new System.Drawing.Point(463, 135);
            this.BtnSelectProgram.Name = "BtnSelectProgram";
            this.BtnSelectProgram.Size = new System.Drawing.Size(75, 29);
            this.BtnSelectProgram.TabIndex = 12;
            this.BtnSelectProgram.Text = "选择程序";
            this.BtnSelectProgram.UseVisualStyleBackColor = true;
            this.BtnSelectProgram.Click += new System.EventHandler(this.BtnSelectProgram_Click);
            // 
            // TxtCommand
            // 
            this.TxtCommand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtCommand.Location = new System.Drawing.Point(128, 138);
            this.TxtCommand.Name = "TxtCommand";
            this.TxtCommand.Size = new System.Drawing.Size(326, 23);
            this.TxtCommand.TabIndex = 11;
            this.TxtCommand.TextChanged += new System.EventHandler(this.TxtCommand_TextChanged);
            // 
            // LblAfterSync
            // 
            this.LblAfterSync.AutoSize = true;
            this.LblAfterSync.Location = new System.Drawing.Point(6, 98);
            this.LblAfterSync.Name = "LblAfterSync";
            this.LblAfterSync.Size = new System.Drawing.Size(68, 17);
            this.LblAfterSync.TabIndex = 10;
            this.LblAfterSync.Text = "同步完成后";
            // 
            // ComboAction
            // 
            this.ComboAction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboAction.FormattingEnabled = true;
            this.ComboAction.Items.AddRange(new object[] {
            "退出程序",
            "待命",
            "执行程序",
            "执行程序并退出"});
            this.ComboAction.Location = new System.Drawing.Point(80, 95);
            this.ComboAction.Name = "ComboAction";
            this.ComboAction.Size = new System.Drawing.Size(254, 25);
            this.ComboAction.TabIndex = 9;
            this.ComboAction.SelectedIndexChanged += new System.EventHandler(this.ComboAction_SelectedIndexChanged);
            // 
            // ChkAutoSyncMod
            // 
            this.ChkAutoSyncMod.AutoSize = true;
            this.ChkAutoSyncMod.Location = new System.Drawing.Point(6, 68);
            this.ChkAutoSyncMod.Name = "ChkAutoSyncMod";
            this.ChkAutoSyncMod.Size = new System.Drawing.Size(162, 21);
            this.ChkAutoSyncMod.TabIndex = 8;
            this.ChkAutoSyncMod.Text = "程序启动后自动同步mod";
            this.ChkAutoSyncMod.UseVisualStyleBackColor = true;
            this.ChkAutoSyncMod.CheckedChanged += new System.EventHandler(this.ChkAutoSyncMod_CheckedChanged);
            // 
            // TxtServerName
            // 
            this.TxtServerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtServerName.Location = new System.Drawing.Point(6, 39);
            this.TxtServerName.Name = "TxtServerName";
            this.TxtServerName.Size = new System.Drawing.Size(532, 23);
            this.TxtServerName.TabIndex = 7;
            this.TxtServerName.TextChanged += new System.EventHandler(this.TxtServerName_TextChanged);
            // 
            // LblServerName
            // 
            this.LblServerName.AutoSize = true;
            this.LblServerName.Location = new System.Drawing.Point(6, 19);
            this.LblServerName.Name = "LblServerName";
            this.LblServerName.Size = new System.Drawing.Size(68, 17);
            this.LblServerName.TabIndex = 6;
            this.LblServerName.Text = "服务器名称";
            // 
            // BtnSync
            // 
            this.BtnSync.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSync.Font = new System.Drawing.Font("Microsoft YaHei UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSync.Location = new System.Drawing.Point(340, 68);
            this.BtnSync.Name = "BtnSync";
            this.BtnSync.Size = new System.Drawing.Size(198, 53);
            this.BtnSync.TabIndex = 5;
            this.BtnSync.Text = "同步Mod";
            this.BtnSync.UseVisualStyleBackColor = true;
            this.BtnSync.Click += new System.EventHandler(this.BtnSync_Click);
            // 
            // BtnResetConfig
            // 
            this.BtnResetConfig.Location = new System.Drawing.Point(107, 27);
            this.BtnResetConfig.Name = "BtnResetConfig";
            this.BtnResetConfig.Size = new System.Drawing.Size(95, 33);
            this.BtnResetConfig.TabIndex = 9;
            this.BtnResetConfig.Text = "重置配置文件";
            this.BtnResetConfig.UseVisualStyleBackColor = true;
            this.BtnResetConfig.Click += new System.EventHandler(this.BtnResetConfig_Click);
            // 
            // GroupConfig
            // 
            this.GroupConfig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupConfig.Controls.Add(this.ChkAutoUpdate);
            this.GroupConfig.Controls.Add(this.BtnUpdate);
            this.GroupConfig.Controls.Add(this.BtnSaveConfig);
            this.GroupConfig.Controls.Add(this.BtnResetConfig);
            this.GroupConfig.Location = new System.Drawing.Point(12, 373);
            this.GroupConfig.Name = "GroupConfig";
            this.GroupConfig.Size = new System.Drawing.Size(544, 67);
            this.GroupConfig.TabIndex = 10;
            this.GroupConfig.TabStop = false;
            this.GroupConfig.Text = "设置";
            // 
            // ChkAutoUpdate
            // 
            this.ChkAutoUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ChkAutoUpdate.AutoSize = true;
            this.ChkAutoUpdate.Location = new System.Drawing.Point(382, 34);
            this.ChkAutoUpdate.Name = "ChkAutoUpdate";
            this.ChkAutoUpdate.Size = new System.Drawing.Size(75, 21);
            this.ChkAutoUpdate.TabIndex = 12;
            this.ChkAutoUpdate.Text = "自动更新";
            this.ChkAutoUpdate.UseVisualStyleBackColor = true;
            this.ChkAutoUpdate.CheckedChanged += new System.EventHandler(this.ChkAutoUpdate_CheckedChanged);
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnUpdate.Location = new System.Drawing.Point(463, 28);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(68, 31);
            this.BtnUpdate.TabIndex = 11;
            this.BtnUpdate.Text = "检查更新";
            this.BtnUpdate.UseVisualStyleBackColor = true;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // BtnSaveConfig
            // 
            this.BtnSaveConfig.Location = new System.Drawing.Point(6, 27);
            this.BtnSaveConfig.Name = "BtnSaveConfig";
            this.BtnSaveConfig.Size = new System.Drawing.Size(95, 33);
            this.BtnSaveConfig.TabIndex = 10;
            this.BtnSaveConfig.Text = "保存当前设置";
            this.BtnSaveConfig.UseVisualStyleBackColor = true;
            this.BtnSaveConfig.Click += new System.EventHandler(this.BtnSaveConfig_Click);
            // 
            // Progress
            // 
            this.Progress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Progress.Location = new System.Drawing.Point(12, 347);
            this.Progress.Name = "Progress";
            this.Progress.Size = new System.Drawing.Size(544, 20);
            this.Progress.TabIndex = 11;
            // 
            // TxtLog
            // 
            this.TxtLog.AcceptsReturn = true;
            this.TxtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtLog.Location = new System.Drawing.Point(12, 188);
            this.TxtLog.Multiline = true;
            this.TxtLog.Name = "TxtLog";
            this.TxtLog.ReadOnly = true;
            this.TxtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtLog.Size = new System.Drawing.Size(544, 153);
            this.TxtLog.TabIndex = 12;
            this.TxtLog.WordWrap = false;
            this.TxtLog.TextChanged += new System.EventHandler(this.TxtLog_TextChanged);
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.Filter = "可执行程序|*.exe|cmd脚本|*.cmd,*.bat|所有文件|*.*";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 452);
            this.Controls.Add(this.TxtLog);
            this.Controls.Add(this.Progress);
            this.Controls.Add(this.GroupConfig);
            this.Controls.Add(this.GroupSync);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(415, 415);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MinecraftModSync";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.GroupSync.ResumeLayout(false);
            this.GroupSync.PerformLayout();
            this.GroupConfig.ResumeLayout(false);
            this.GroupConfig.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox GroupSync;
        private CheckBox ChkAutoSyncMod;
        private TextBox TxtServerName;
        private Label LblServerName;
        private Button BtnSync;
        private Button BtnResetConfig;
        private GroupBox GroupConfig;
        private Button BtnSaveConfig;
        private Button BtnUpdate;
        private CheckBox ChkAutoUpdate;
        private ComboBox ComboAction;
        private Label LblAfterSync;
        private ProgressBar Progress;
        private TextBox TxtLog;
        private TextBox TxtCommand;
        private OpenFileDialog OpenFileDialog;
        private Label label1;
        private Button BtnSelectProgram;
    }
}