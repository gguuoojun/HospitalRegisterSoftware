namespace HospitalRegisterSoftware.Forms
{
    partial class OrderForm
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
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.lbMessage = new DevComponents.DotNetBar.LabelX();
            this.lbVisitTime = new DevComponents.DotNetBar.LabelX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.lbFee = new DevComponents.DotNetBar.LabelX();
            this.lbPhone = new DevComponents.DotNetBar.LabelX();
            this.lbxRegTime = new DevComponents.DotNetBar.ListBoxAdv();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.tbOrderAuthCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.pbAuthCode = new System.Windows.Forms.PictureBox();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.lbUserName = new DevComponents.DotNetBar.LabelX();
            this.lbHospital = new DevComponents.DotNetBar.LabelX();
            this.lbDoctorName = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.lbCardId = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.pbAuthCode)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX8
            // 
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(25, 136);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(280, 23);
            this.labelX8.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX8.TabIndex = 34;
            this.labelX8.Text = "<font color=\"Red\">（请在以下时间列表中选择后填写验证码）</font>";
            // 
            // lbMessage
            // 
            this.lbMessage.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lbMessage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbMessage.ForeColor = System.Drawing.Color.Black;
            this.lbMessage.Location = new System.Drawing.Point(340, 382);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(274, 35);
            this.lbMessage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lbMessage.TabIndex = 33;
            // 
            // lbVisitTime
            // 
            this.lbVisitTime.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lbVisitTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbVisitTime.ForeColor = System.Drawing.Color.Black;
            this.lbVisitTime.Location = new System.Drawing.Point(111, 111);
            this.lbVisitTime.Name = "lbVisitTime";
            this.lbVisitTime.Size = new System.Drawing.Size(194, 23);
            this.lbVisitTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lbVisitTime.TabIndex = 32;
            // 
            // labelX7
            // 
            this.labelX7.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.ForeColor = System.Drawing.Color.Black;
            this.labelX7.Location = new System.Drawing.Point(27, 112);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(84, 23);
            this.labelX7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX7.TabIndex = 31;
            this.labelX7.Text = "就诊时间：";
            // 
            // lbFee
            // 
            this.lbFee.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lbFee.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbFee.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbFee.ForeColor = System.Drawing.Color.Black;
            this.lbFee.Location = new System.Drawing.Point(382, 82);
            this.lbFee.Name = "lbFee";
            this.lbFee.Size = new System.Drawing.Size(127, 23);
            this.lbFee.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lbFee.TabIndex = 30;
            // 
            // lbPhone
            // 
            this.lbPhone.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lbPhone.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbPhone.ForeColor = System.Drawing.Color.Black;
            this.lbPhone.Location = new System.Drawing.Point(111, 83);
            this.lbPhone.Name = "lbPhone";
            this.lbPhone.Size = new System.Drawing.Size(127, 23);
            this.lbPhone.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lbPhone.TabIndex = 29;
            // 
            // lbxRegTime
            // 
            this.lbxRegTime.AutoScroll = true;
            this.lbxRegTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            // 
            // 
            // 
            this.lbxRegTime.BackgroundStyle.Class = "ListBoxAdv";
            this.lbxRegTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbxRegTime.ContainerControlProcessDialogKey = true;
            this.lbxRegTime.DragDropSupport = true;
            this.lbxRegTime.ForeColor = System.Drawing.Color.Black;
            this.lbxRegTime.Location = new System.Drawing.Point(24, 161);
            this.lbxRegTime.Name = "lbxRegTime";
            this.lbxRegTime.Size = new System.Drawing.Size(581, 200);
            this.lbxRegTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lbxRegTime.TabIndex = 28;
            this.lbxRegTime.Text = "listBoxAdv1";
            this.lbxRegTime.SelectedIndexChanged += new System.EventHandler(this.lbxRegTime_SelectedIndexChanged);
            // 
            // labelX5
            // 
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.ForeColor = System.Drawing.Color.Black;
            this.labelX5.Location = new System.Drawing.Point(315, 83);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(64, 23);
            this.labelX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX5.TabIndex = 27;
            this.labelX5.Text = "挂号费：";
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.ForeColor = System.Drawing.Color.Black;
            this.labelX4.Location = new System.Drawing.Point(27, 83);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(84, 23);
            this.labelX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX4.TabIndex = 26;
            this.labelX4.Text = "联系电话：";
            // 
            // tbOrderAuthCode
            // 
            this.tbOrderAuthCode.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tbOrderAuthCode.Border.Class = "TextBoxBorder";
            this.tbOrderAuthCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbOrderAuthCode.DisabledBackColor = System.Drawing.Color.White;
            this.tbOrderAuthCode.ForeColor = System.Drawing.Color.Black;
            this.tbOrderAuthCode.Location = new System.Drawing.Point(92, 389);
            this.tbOrderAuthCode.Name = "tbOrderAuthCode";
            this.tbOrderAuthCode.PreventEnterBeep = true;
            this.tbOrderAuthCode.Size = new System.Drawing.Size(93, 23);
            this.tbOrderAuthCode.TabIndex = 25;
            this.tbOrderAuthCode.TextChanged += new System.EventHandler(this.tbOrderAuthCode_TextChanged);
            // 
            // pbAuthCode
            // 
            this.pbAuthCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.pbAuthCode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbAuthCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbAuthCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbAuthCode.ForeColor = System.Drawing.Color.Black;
            this.pbAuthCode.Location = new System.Drawing.Point(191, 371);
            this.pbAuthCode.Name = "pbAuthCode";
            this.pbAuthCode.Size = new System.Drawing.Size(142, 53);
            this.pbAuthCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAuthCode.TabIndex = 24;
            this.pbAuthCode.TabStop = false;
            this.pbAuthCode.Click += new System.EventHandler(this.pbAuthCode_Click);
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.ForeColor = System.Drawing.Color.Black;
            this.labelX2.Location = new System.Drawing.Point(28, 390);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX2.TabIndex = 23;
            this.labelX2.Text = "验证码：";
            // 
            // lbUserName
            // 
            this.lbUserName.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lbUserName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbUserName.ForeColor = System.Drawing.Color.Black;
            this.lbUserName.Location = new System.Drawing.Point(111, 54);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(127, 23);
            this.lbUserName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lbUserName.TabIndex = 39;
            // 
            // lbHospital
            // 
            this.lbHospital.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lbHospital.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbHospital.ForeColor = System.Drawing.Color.Black;
            this.lbHospital.Location = new System.Drawing.Point(111, 24);
            this.lbHospital.Name = "lbHospital";
            this.lbHospital.Size = new System.Drawing.Size(464, 23);
            this.lbHospital.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lbHospital.TabIndex = 38;
            // 
            // lbDoctorName
            // 
            this.lbDoctorName.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lbDoctorName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbDoctorName.ForeColor = System.Drawing.Color.Black;
            this.lbDoctorName.Location = new System.Drawing.Point(111, -3);
            this.lbDoctorName.Name = "lbDoctorName";
            this.lbDoctorName.Size = new System.Drawing.Size(127, 23);
            this.lbDoctorName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lbDoctorName.TabIndex = 37;
            // 
            // labelX6
            // 
            this.labelX6.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.ForeColor = System.Drawing.Color.Black;
            this.labelX6.Location = new System.Drawing.Point(36, -3);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(75, 23);
            this.labelX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX6.TabIndex = 36;
            this.labelX6.Text = "预约医生：";
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.ForeColor = System.Drawing.Color.Black;
            this.labelX1.Location = new System.Drawing.Point(36, 52);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX1.TabIndex = 35;
            this.labelX1.Text = "就诊人：";
            // 
            // lbCardId
            // 
            this.lbCardId.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lbCardId.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbCardId.ForeColor = System.Drawing.Color.Black;
            this.lbCardId.Location = new System.Drawing.Point(382, 54);
            this.lbCardId.Name = "lbCardId";
            this.lbCardId.Size = new System.Drawing.Size(187, 23);
            this.lbCardId.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lbCardId.TabIndex = 41;
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.ForeColor = System.Drawing.Color.Black;
            this.labelX3.Location = new System.Drawing.Point(315, 54);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(64, 23);
            this.labelX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX3.TabIndex = 40;
            this.labelX3.Text = "证件号：";
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 429);
            this.Controls.Add(this.lbCardId);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.lbUserName);
            this.Controls.Add(this.lbHospital);
            this.Controls.Add(this.lbDoctorName);
            this.Controls.Add(this.labelX6);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.labelX8);
            this.Controls.Add(this.lbMessage);
            this.Controls.Add(this.lbVisitTime);
            this.Controls.Add(this.labelX7);
            this.Controls.Add(this.lbFee);
            this.Controls.Add(this.lbPhone);
            this.Controls.Add(this.lbxRegTime);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.tbOrderAuthCode);
            this.Controls.Add(this.pbAuthCode);
            this.Controls.Add(this.labelX2);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrderForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "订单信息";
            this.Load += new System.EventHandler(this.OrderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbAuthCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.LabelX lbMessage;
        private DevComponents.DotNetBar.LabelX lbVisitTime;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.LabelX lbFee;
        private DevComponents.DotNetBar.LabelX lbPhone;
        private DevComponents.DotNetBar.ListBoxAdv lbxRegTime;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX tbOrderAuthCode;
        private System.Windows.Forms.PictureBox pbAuthCode;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX lbUserName;
        private DevComponents.DotNetBar.LabelX lbHospital;
        private DevComponents.DotNetBar.LabelX lbDoctorName;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX lbCardId;
        private DevComponents.DotNetBar.LabelX labelX3;
    }
}