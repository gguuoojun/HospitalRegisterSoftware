using DevComponents.DotNetBar.Metro;
using HospitalRegisterSoftware.Register;
using HospitalRegisterSoftware.Register.Model;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Utility;

namespace HospitalRegisterSoftware.Forms
{
    public partial class AuthCodeForm : MetroForm
    {
        private RegisterHelper m_register = null;
        private OrderManager m_orderManager = null;  //平台预约订单管理类
        private string m_userName;
        private string m_userPwd;

        private Image m_imageAuthCode = null;
        private WaitingForm m_frmWaiting = new WaitingForm();

        public AuthCodeForm(RegisterHelper register, OrderManager orderManager, string userName, string userPwd)
        {
            InitializeComponent();
            m_register = register;
            m_orderManager = orderManager;
            m_userName = userName;
            m_userPwd = userPwd;
        }

        protected override void OnLoad(EventArgs e)
        {
            UpdateAuthCode("获取验证码中...");
        }

        private void tbAuthCode_TextChanged(object sender, EventArgs e)
        {
            if (tbAuthCode.Text.Length == 4)
            {
                bool bIsSuccess = false;
                m_frmWaiting.OnDoWork = (s, we) =>
                {
                    bIsSuccess = m_register.Login(m_userName, m_userPwd, tbAuthCode.Text);
                    if(bIsSuccess)
                    {
                        m_orderManager.User = m_register.GetUserInfo();
                    }
                };
                m_frmWaiting.MsgWait = "正在登录中...";
                m_frmWaiting.ShowDialog();

                if (bIsSuccess)
                {
                    DialogResult = DialogResult.Yes;
                }
                else if(m_register.GetLastError().Contains("验证码"))
                {
                    MessageBoxExS.ShowError(m_register.GetLastError());
                    UpdateAuthCode("重新获取验证码中...");
                    return;
                }
                else
                {
                    MessageBoxExS.ShowError(m_register.GetLastError());
                }
                Close();
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            m_frmWaiting.Close();
        }

        private void pbAuthCode_Click(object sender, EventArgs e)
        {
            UpdateAuthCode("获取验证码中...");
        }

        private void UpdateAuthCode(string tipMsg)
        {
             m_frmWaiting.OnDoWork = (s, we) =>
            {
                m_imageAuthCode = m_register.GetLoginAuthCode();
            };

            m_frmWaiting.MsgWait = tipMsg;
            m_frmWaiting.ShowDialog();
            tbAuthCode.Text = string.Empty;
            pbAuthCode.Image = m_imageAuthCode;
            if (m_imageAuthCode == null)
            {
                MessageBoxExS.ShowError(m_register.GetLastError());
            }                     
        }
    }
}
