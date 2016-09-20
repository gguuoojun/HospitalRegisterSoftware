namespace HospitalRegisterSoftware.Forms
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.cbPlatform = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.btnLogin = new DevComponents.DotNetBar.ButtonX();
            this.btnRegisterUser = new DevComponents.DotNetBar.ButtonX();
            this.tbUserPwd = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lbRegisterUrl = new DevComponents.DotNetBar.LabelX();
            this.cbkRememberPwd = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cbkAutoLogin = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.cbUserName = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.SuspendLayout();
            // 
            // cbPlatform
            // 
            this.cbPlatform.DisplayMember = "Text";
            this.cbPlatform.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbPlatform.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPlatform.ForeColor = System.Drawing.Color.Black;
            this.cbPlatform.FormattingEnabled = true;
            this.cbPlatform.ItemHeight = 15;
            this.cbPlatform.Location = new System.Drawing.Point(76, 23);
            this.cbPlatform.Name = "cbPlatform";
            this.cbPlatform.Size = new System.Drawing.Size(252, 21);
            this.cbPlatform.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbPlatform.TabIndex = 0;
            this.cbPlatform.SelectedIndexChanged += new System.EventHandler(this.cbPlatform_SelectedIndexChanged);
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.ForeColor = System.Drawing.Color.Black;
            this.labelX1.Location = new System.Drawing.Point(16, 21);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(58, 23);
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "预约平台";
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.ForeColor = System.Drawing.Color.Black;
            this.labelX2.Location = new System.Drawing.Point(15, 54);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(59, 23);
            this.labelX2.TabIndex = 3;
            this.labelX2.Text = "平台网址";
            // 
            // btnLogin
            // 
            this.btnLogin.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLogin.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnLogin.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLogin.Location = new System.Drawing.Point(86, 201);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "登录";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnRegisterUser
            // 
            this.btnRegisterUser.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRegisterUser.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnRegisterUser.Location = new System.Drawing.Point(201, 201);
            this.btnRegisterUser.Name = "btnRegisterUser";
            this.btnRegisterUser.Size = new System.Drawing.Size(75, 23);
            this.btnRegisterUser.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnRegisterUser.TabIndex = 5;
            this.btnRegisterUser.Text = "注册";
            this.btnRegisterUser.Click += new System.EventHandler(this.btnRegisterUser_Click);
            // 
            // tbUserPwd
            // 
            // 
            // 
            // 
            this.tbUserPwd.Border.Class = "TextBoxBorder";
            this.tbUserPwd.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbUserPwd.DisabledBackColor = System.Drawing.Color.White;
            this.tbUserPwd.Location = new System.Drawing.Point(76, 129);
            this.tbUserPwd.Name = "tbUserPwd";
            this.tbUserPwd.PasswordChar = '*';
            this.tbUserPwd.PreventEnterBeep = true;
            this.tbUserPwd.Size = new System.Drawing.Size(252, 21);
            this.tbUserPwd.TabIndex = 6;
            // 
            // lbRegisterUrl
            // 
            this.lbRegisterUrl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            // 
            // 
            // 
            this.lbRegisterUrl.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbRegisterUrl.ForeColor = System.Drawing.Color.Black;
            this.lbRegisterUrl.Location = new System.Drawing.Point(75, 54);
            this.lbRegisterUrl.Name = "lbRegisterUrl";
            this.lbRegisterUrl.Size = new System.Drawing.Size(253, 23);
            this.lbRegisterUrl.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lbRegisterUrl.TabIndex = 8;
            // 
            // cbkRememberPwd
            // 
            this.cbkRememberPwd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            // 
            // 
            // 
            this.cbkRememberPwd.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbkRememberPwd.ForeColor = System.Drawing.Color.Black;
            this.cbkRememberPwd.Location = new System.Drawing.Point(89, 164);
            this.cbkRememberPwd.Name = "cbkRememberPwd";
            this.cbkRememberPwd.Size = new System.Drawing.Size(100, 23);
            this.cbkRememberPwd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbkRememberPwd.TabIndex = 9;
            this.cbkRememberPwd.Text = "记住密码";
            this.cbkRememberPwd.CheckedChanged += new System.EventHandler(this.cbkRememberPwd_CheckedChanged);
            // 
            // cbkAutoLogin
            // 
            this.cbkAutoLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            // 
            // 
            // 
            this.cbkAutoLogin.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbkAutoLogin.ForeColor = System.Drawing.Color.Black;
            this.cbkAutoLogin.Location = new System.Drawing.Point(213, 164);
            this.cbkAutoLogin.Name = "cbkAutoLogin";
            this.cbkAutoLogin.Size = new System.Drawing.Size(75, 23);
            this.cbkAutoLogin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbkAutoLogin.TabIndex = 10;
            this.cbkAutoLogin.Text = "自动登录";
            this.cbkAutoLogin.Visible = false;
            this.cbkAutoLogin.CheckedChanged += new System.EventHandler(this.cbkAutoLogin_CheckedChanged);
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.ForeColor = System.Drawing.Color.Black;
            this.labelX4.Location = new System.Drawing.Point(22, 90);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(52, 23);
            this.labelX4.TabIndex = 11;
            this.labelX4.Text = "用户名";
            // 
            // labelX5
            // 
            this.labelX5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.ForeColor = System.Drawing.Color.Black;
            this.labelX5.Location = new System.Drawing.Point(33, 129);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(41, 23);
            this.labelX5.TabIndex = 12;
            this.labelX5.Text = "密码";
            // 
            // cbUserName
            // 
            this.cbUserName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbUserName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbUserName.DisplayMember = "Text";
            this.cbUserName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbUserName.ForeColor = System.Drawing.Color.Black;
            this.cbUserName.FormattingEnabled = true;
            this.cbUserName.ItemHeight = 15;
            this.cbUserName.Location = new System.Drawing.Point(75, 90);
            this.cbUserName.MaxDropDownItems = 20;
            this.cbUserName.Name = "cbUserName";
            this.cbUserName.Size = new System.Drawing.Size(253, 21);
            this.cbUserName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbUserName.TabIndex = 13;
            this.cbUserName.SelectedIndexChanged += new System.EventHandler(this.cbUserName_SelectedIndexChanged);
            this.cbUserName.TextChanged += new System.EventHandler(this.cbUserName_TextChanged);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 237);
            this.Controls.Add(this.cbUserName);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.cbkAutoLogin);
            this.Controls.Add(this.cbkRememberPwd);
            this.Controls.Add(this.lbRegisterUrl);
            this.Controls.Add(this.tbUserPwd);
            this.Controls.Add(this.btnRegisterUser);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.cbPlatform);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbPlatform;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.ButtonX btnLogin;
        private DevComponents.DotNetBar.ButtonX btnRegisterUser;
        private DevComponents.DotNetBar.Controls.TextBoxX tbUserPwd;
        private DevComponents.DotNetBar.LabelX lbRegisterUrl;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbkRememberPwd;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbkAutoLogin;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbUserName;
    }
}