namespace HospitalRegisterSoftware.Forms
{
    partial class AuthCodeForm
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
            this.tbAuthCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.pbAuthCode = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbAuthCode)).BeginInit();
            this.SuspendLayout();
            // 
            // tbAuthCode
            // 
            this.tbAuthCode.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tbAuthCode.Border.Class = "TextBoxBorder";
            this.tbAuthCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbAuthCode.DisabledBackColor = System.Drawing.Color.White;
            this.tbAuthCode.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbAuthCode.ForeColor = System.Drawing.Color.Black;
            this.tbAuthCode.Location = new System.Drawing.Point(197, 40);
            this.tbAuthCode.Name = "tbAuthCode";
            this.tbAuthCode.PreventEnterBeep = true;
            this.tbAuthCode.Size = new System.Drawing.Size(100, 21);
            this.tbAuthCode.TabIndex = 5;
            this.tbAuthCode.WatermarkText = "请输入验证码";
            this.tbAuthCode.TextChanged += new System.EventHandler(this.tbAuthCode_TextChanged);
            // 
            // pbAuthCode
            // 
            this.pbAuthCode.BackColor = System.Drawing.Color.White;
            this.pbAuthCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbAuthCode.ForeColor = System.Drawing.Color.Black;
            this.pbAuthCode.Location = new System.Drawing.Point(33, 11);
            this.pbAuthCode.Name = "pbAuthCode";
            this.pbAuthCode.Size = new System.Drawing.Size(144, 50);
            this.pbAuthCode.TabIndex = 4;
            this.pbAuthCode.TabStop = false;
            this.pbAuthCode.Click += new System.EventHandler(this.pbAuthCode_Click);
            // 
            // AuthCodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 69);
            this.Controls.Add(this.tbAuthCode);
            this.Controls.Add(this.pbAuthCode);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AuthCodeForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "验证码";
            ((System.ComponentModel.ISupportInitialize)(this.pbAuthCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX tbAuthCode;
        private System.Windows.Forms.PictureBox pbAuthCode;
    }
}