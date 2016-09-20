using DevComponents.DotNetBar.Metro;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace HospitalRegisterSoftware.Forms
{
    public partial class WaitingForm : MetroForm
    {
        public delegate void DoWorkHandler(object sender, DoWorkEventArgs e);
        public DoWorkHandler OnDoWork;

        private string m_msgWait = "努力加载中...";

        public WaitingForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 显示的等待信息
        /// </summary>
        public string MsgWait
        {
            get { return m_msgWait; }
            set { m_msgWait = value; }
        }

        private void WatingForm_Paint(object sender, PaintEventArgs e)
        {
            Rectangle r = e.ClipRectangle;
            r.Inflate(-1, -1);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            ControlPaint.DrawBorder3D(e.Graphics, r, Border3DStyle.RaisedInner);
            e.Graphics.DrawString(m_msgWait, new Font("Arial", 9, FontStyle.Regular), SystemBrushes.WindowText, r, sf);
        }

        protected override void OnShown(EventArgs e)
        {
            circularProgress1.IsRunning = true;
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (OnDoWork != null)
            {
                OnDoWork(sender, e);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            circularProgress1.IsRunning = false;
            DialogResult = DialogResult.OK;
        }
    }
}
