using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro;
using HospitalRegisterSoftware.Register;
using HospitalRegisterSoftware.Register.Model;
using System.Drawing;
using System.Windows.Forms;

namespace HospitalRegisterSoftware.Forms
{
    public partial class OrderForm : MetroForm
    {
        private RegisterHelper m_register = null;
        private OrderManager m_orderManager = null;
        private WaitingForm m_frmWaiting = new WaitingForm();

        private bool bIsCheckOrderSuccess = true;          //选择定单是否成功

        private Image m_imageAuthCode = null;               //临时存储验证码

        public OrderForm(RegisterHelper register, OrderManager orderManager)
        {
            InitializeComponent();

            m_register = register;
            m_orderManager = orderManager;
        }

        private void OrderForm_Load(object sender, System.EventArgs e)
        {
            lbDoctorName.Text = m_orderManager.Doctor.Name;
            lbHospital.Text = m_orderManager.Doctor.HospitalName + "  " + m_orderManager.Doctor.Department;
            lbUserName.Text = m_orderManager.User.Name;
            lbPhone.Text = m_orderManager.User.PhoneNumber;
            lbCardId.Text = m_orderManager.User.CardId;
            lbVisitTime.Text = m_orderManager.RegisterDate;
            lbFee.Text = "<font color=\"OrangeRed\">" + m_orderManager.RegisterFee + "</font>";
            foreach (OrderInfo order in m_orderManager.OrderInfos)
            {
                ListBoxItem listBoxItem = new ListBoxItem();
                listBoxItem.Text = string.Format("序号:{0}  时间:{1}", order.OrderId, order.OrderTime);
                listBoxItem.Tag = order;
                this.lbxRegTime.Items.Add(listBoxItem);
            }

            if (lbxRegTime.Items.Count > 0)
            {
                lbxRegTime.SelectedIndex = 0;
            }
        }

        private void lbxRegTime_SelectedIndexChanged(object sender, System.EventArgs e)
        {               
            if (!CheckOrderInfo())
            {
                return;
            }

            lbMessage.Text = string.Empty;         
            RefreshAuthCode("选择的预约信息验证通过,正在获取验证码中...");
        }

        private void pbAuthCode_Click(object sender, System.EventArgs e)
        {
            if (lbxRegTime.SelectedIndex < 0)
            {
                lbMessage.Text = "请选择具体时间后再点击刷新验证码";
                return;
            }

            lbMessage.Text = string.Empty;
            if (!bIsCheckOrderSuccess)
            {
                if (!CheckOrderInfo())
                {
                    return;
                }
            }

            RefreshAuthCode("正在获取验证码中...");
        }

        private bool CheckOrderInfo()
        {
            m_orderManager.SelectOrderInfo(this.lbxRegTime.SelectedIndex);
            m_frmWaiting.OnDoWork = (s, we) =>
            {
                bIsCheckOrderSuccess = m_register.CheckOrderInfo(m_orderManager.GetCheckOderPostData());
            };
            m_frmWaiting.MsgWait = "选择的预约信息验证中...";
            m_frmWaiting.ShowDialog();

            if (!bIsCheckOrderSuccess)
            {
                lbMessage.Text = "选择的预约信息验证失败,请点击验证码图片刷新";
            }
            return bIsCheckOrderSuccess;
        }

        private void RefreshAuthCode(string tipMsg)
        {
            m_frmWaiting.OnDoWork = (s, we) =>
            {
                m_imageAuthCode = m_register.GetOrderCode(m_orderManager.GetOrderAuthCodeData());
            };

            m_frmWaiting.MsgWait = tipMsg;
            m_frmWaiting.ShowDialog();

            tbOrderAuthCode.Text = string.Empty;
            pbAuthCode.Image = m_imageAuthCode;
            if (m_imageAuthCode == null)
            {
                //验证码获取失败了
                lbMessage.Text = m_register.GetLastError();
            }          
        }

        private void tbOrderAuthCode_TextChanged(object sender, System.EventArgs e)
        {
            if (this.tbOrderAuthCode.Text.Length == 5)
            {
                RegisterSuccessInfo successInfo = new RegisterSuccessInfo();

                this.lbMessage.Text = string.Empty;
                this.lbMessage.Text = "提交中...";

                bool bIsSuccess = false;
                m_frmWaiting.MsgWait = "已提交预约数据，正在等待服务端的响应...";
                m_frmWaiting.OnDoWork = (s, we) =>
                {
                    bIsSuccess = m_register.SaveOrderInfo(tbOrderAuthCode.Text, ref successInfo);
                };
                m_frmWaiting.ShowDialog();

                if (!bIsSuccess)
                {
                    lbMessage.Text = m_register.GetLastError();
                    tbOrderAuthCode.Text = string.Empty;

                    RefreshAuthCode("预约数据提交失败，正在重新获取验证码...");
                    return;
                }

                Hide();
                SuccessForm successForm = new SuccessForm(successInfo);
                successForm.ShowDialog();
                successForm.Dispose();
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
