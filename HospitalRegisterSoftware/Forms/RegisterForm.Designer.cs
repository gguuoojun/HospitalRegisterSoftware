namespace HospitalRegisterSoftware.Forms
{
    partial class RegisterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            this.metroStatusBar1 = new DevComponents.DotNetBar.Metro.MetroStatusBar();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.lbItemTime = new DevComponents.DotNetBar.LabelItem();
            this.lbItemSpanTime = new DevComponents.DotNetBar.LabelItem();
            this.btnCheckUpgrate = new DevComponents.DotNetBar.ButtonItem();
            this.btnItemDonate = new DevComponents.DotNetBar.ButtonItem();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.registerControl1 = new HospitalRegisterSoftware.UserControls.RegisterControl();
            this.SuspendLayout();
            // 
            // metroStatusBar1
            // 
            this.metroStatusBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            // 
            // 
            // 
            this.metroStatusBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroStatusBar1.ContainerControlProcessDialogKey = true;
            this.metroStatusBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.metroStatusBar1.DragDropSupport = true;
            this.metroStatusBar1.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroStatusBar1.ForeColor = System.Drawing.Color.Black;
            this.metroStatusBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem1,
            this.lbItemTime,
            this.lbItemSpanTime,
            this.btnCheckUpgrate,
            this.btnItemDonate});
            this.metroStatusBar1.Location = new System.Drawing.Point(0, 493);
            this.metroStatusBar1.Margin = new System.Windows.Forms.Padding(0);
            this.metroStatusBar1.Name = "metroStatusBar1";
            this.metroStatusBar1.Size = new System.Drawing.Size(1026, 32);
            this.metroStatusBar1.TabIndex = 2;
            this.metroStatusBar1.Text = "metroStatusBar1";
            // 
            // labelItem1
            // 
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.Text = "北京时间:";
            // 
            // lbItemTime
            // 
            this.lbItemTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbItemTime.Name = "lbItemTime";
            this.lbItemTime.Text = "网络连接失败";
            this.lbItemTime.Click += new System.EventHandler(this.lbItemTime_Click);
            // 
            // lbItemSpanTime
            // 
            this.lbItemSpanTime.Name = "lbItemSpanTime";
            // 
            // btnCheckUpgrate
            // 
            this.btnCheckUpgrate.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueWithBackground;
            this.btnCheckUpgrate.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.btnCheckUpgrate.Name = "btnCheckUpgrate";
            this.btnCheckUpgrate.Text = "检查更新";
            this.btnCheckUpgrate.Visible = false;
            // 
            // btnItemDonate
            // 
            this.btnItemDonate.CanCustomize = false;
            this.btnItemDonate.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueWithBackground;
            this.btnItemDonate.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.btnItemDonate.Name = "btnItemDonate";
            this.btnItemDonate.Text = "捐助软件";
            this.btnItemDonate.Click += new System.EventHandler(this.btnItemDonate_Click);
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2013;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242))))), System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(143))))));
            // 
            // registerControl1
            // 
            this.registerControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.registerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.registerControl1.ForeColor = System.Drawing.Color.Black;
            this.registerControl1.Location = new System.Drawing.Point(0, 0);
            this.registerControl1.Margin = new System.Windows.Forms.Padding(0);
            this.registerControl1.Name = "registerControl1";
            this.registerControl1.Size = new System.Drawing.Size(1026, 493);
            this.registerControl1.TabIndex = 3;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 525);
            this.Controls.Add(this.registerControl1);
            this.Controls.Add(this.metroStatusBar1);
            this.DoubleBuffered = true;
            this.HelpButtonText = "关于";
            this.HelpButtonVisible = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RegisterForm";
            this.SettingsButtonText = "注销";
            this.SettingsButtonVisible = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "预约挂号辅助软件";
            this.SettingsButtonClick += new System.EventHandler(this.RegisterForm_SettingsButtonClick);
            this.HelpButtonClick += new System.EventHandler(this.RegisterForm_HelpButtonClick);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Metro.MetroStatusBar metroStatusBar1;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private DevComponents.DotNetBar.LabelItem lbItemTime;
        private DevComponents.DotNetBar.ButtonItem btnItemDonate;
        private DevComponents.DotNetBar.LabelItem lbItemSpanTime;
        private UserControls.RegisterControl registerControl1;
        private DevComponents.DotNetBar.ButtonItem btnCheckUpgrate;
    }
}