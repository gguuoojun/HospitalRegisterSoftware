using DevComponents.DotNetBar.Metro;
using System;
using HospitalRegisterSoftware.Register.Model;

namespace HospitalRegisterSoftware.Forms
{
    public partial class SuccessForm : MetroForm
    {
        private RegisterSuccessInfo m_regSuccessInfo = null;
        public SuccessForm(RegisterSuccessInfo regSuccessInfo)
        {
            InitializeComponent();
            m_regSuccessInfo = regSuccessInfo;
        }

        protected override void OnLoad(EventArgs e)
        {
            lbPasswd.Text = "<font color=\"OrangeRed\">" + m_regSuccessInfo.Passwd + "</font>";
            lbPhone.Text = "<font color=\"OrangeRed\">" + m_regSuccessInfo.Phone + "</font>";
            lbVisitTime.Text = "<font color=\"LightSeaGreen\">" + m_regSuccessInfo.DiagnoseTime + "</font>";
            lbVisitNum.Text = "<font color=\"LightSeaGreen\">" + m_regSuccessInfo.DiagnoseNum + "</font>";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
