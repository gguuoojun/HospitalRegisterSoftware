using System;
using System.Collections.Generic;
using DevComponents.DotNetBar.Metro;
using HospitalRegisterSoftware.Plugins;
using HospitalRegisterSoftware.OrmLite.Model;
using HospitalRegisterSoftware.OrmLite.BLL;
using DevComponents.Editors;
using Utility;
using System.Reflection;
using HospitalRegisterSoftware.Register.Model;
using HospitalRegisterSoftware.Register;
using System.Windows.Forms;

namespace HospitalRegisterSoftware.Forms
{
    public partial class LoginForm : MetroForm
    {
        private PlatformBll m_bllPlatform = PlatformBll.Instance;
        private UserBll m_bllUser = UserBll.Instance;
        private List<Platform> m_listPlatform = null;

        private PluginManager m_pluginManager = new PluginManager();

        private RegisterHelper m_register = null;          //平台预约类
        private OrderManager m_orderManager = null;  //平台预约订单管理类

        private int m_nSelectedPlatformId = 0;   //当前选择的平台插件ID
        private User m_loginUser = null;         //登录的用户 

        public LoginForm()
        {
            InitializeComponent();           
        }

        public RegisterHelper RegisterHelper
        {
            get { return m_register; }
        }

        public OrderManager OrderManager
        {
            get { return m_orderManager; }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            m_pluginManager = new PluginManager();
            m_pluginManager.LoadPlugins();
           
            InitPlatform();
           
        }

        private void InitPlatform()
        {
            cbPlatform.Items.Clear();
            m_listPlatform = m_bllPlatform.GetModelList(new Platform(), null);
            if (m_listPlatform.Count == 0)
            {
                //数据库内容为空则无需登录
                cbPlatform.Enabled = false;
                tbUserPwd.Enabled = false;
                cbUserName.Enabled = false;
                btnLogin.Enabled = false;
                return;
            }

            foreach(Platform p in m_listPlatform)
            {
                ComboItem comboItem = new ComboItem();
                comboItem.Text = p.PlatformName;
                comboItem.Value = p;
                cbPlatform.Items.Add(comboItem);
            }

            m_loginUser = m_bllUser.GetLastLoginUser();
            List<User> allUsers = m_bllUser.GetModelList(new User(), null);
            //如果出现有用户但没有最近一次登录用户信息则默认使用第一个用户
            if (m_loginUser == null && allUsers.Count > 0)
            {
                m_loginUser = allUsers[0];
                m_loginUser.RecentLogin = true;
            }

            int index = 0;
            if(m_loginUser != null)
            {
                index = m_listPlatform.FindIndex((p) =>
                {
                    return p.Id == m_loginUser.PlatformId;
                });
            }

            cbPlatform.SelectedIndex = index;
            lbRegisterUrl.Text = m_listPlatform[index].PlatformUrl;
           
            if (m_loginUser != null)
            {
                SetUserUI(m_loginUser);               
            }           
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (cbUserName.Text.Length == 0)
            {
                MessageBoxExS.ShowError("用户名不能为空！");
                return;
            }
            if (tbUserPwd.Text.Length == 0)
            {
                MessageBoxExS.ShowError("密码不能为空！");
                return;
            }

            LoginPlatform();
        }

        private void LoginPlatform()
        {
            if (m_register == null)
            {
                Assembly assembly = m_pluginManager.GetAssembly(((Platform)(((ComboItem)cbPlatform.SelectedItem)).Value).AssemblyName);
                Type[] types = assembly.GetTypes();

                foreach (var itemType in types)
                {
                    if (itemType.IsPublic)
                    {
                        Object instance = assembly.CreateInstance(itemType.FullName);
                        if (instance is RegisterHelper)
                        {
                            m_register = instance as RegisterHelper;
                        }
                        else if(instance is OrderManager)
                        {
                            m_orderManager = instance as OrderManager;
                        }
                    }
                }
            }

            if (m_register == null || m_orderManager == null)
            {
                //插件功能未实现
                MessageBoxExS.ShowError("该插件功能实现不全，无法预约！");
                return;
            }

            AuthCodeForm frmAuthCode = new AuthCodeForm(m_register, m_orderManager,cbUserName.Text, tbUserPwd.Text);
            if (frmAuthCode.ShowDialog() == DialogResult.Yes)
            {              
                LoginSuccess();
                DialogResult = DialogResult.OK;            
            }
            frmAuthCode.Dispose();
        }

        /// <summary>
        /// 登录成功保存数据
        /// </summary>
        private void LoginSuccess()
        {
            if (m_loginUser != null)
            {
                if (cbUserName.Text != m_loginUser.UserName || m_nSelectedPlatformId != m_loginUser.PlatformId)
                {
                    //登录用户名不同或者平台不同，则原登录用户最近一次登录置为false并更新
                    m_loginUser.RecentLogin = false;
                    m_bllUser.Update(m_loginUser);
                }
            }

            User user = m_bllUser.GetUserForName(cbUserName.Text, m_nSelectedPlatformId);
            bool IsNew = false;      //是否是新建用户
            if (user == null)
            {
                //没有该用户，则新建
                IsNew = true;
                user = new User();
            }

            user.UserName = cbUserName.Text;
            user.PlatformId = m_nSelectedPlatformId;
            user.RememberPwd = cbkRememberPwd.Checked;
            if (cbkRememberPwd.Checked)
            {
                user.UserPwd = Encrypt.DES3Encrypt(tbUserPwd.Text, Encrypt.MD5Encrypt(cbUserName.Text));
            }
            else
            {
                user.UserPwd = string.Empty;
            }
            user.AutoLogin = cbkAutoLogin.Checked;
            user.RecentLogin = true;

            if (IsNew)
            {
                m_bllUser.Add(user);
            }
            else
            {
                m_bllUser.Update(user);
            }
                
        }

        private void btnRegisterUser_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(((Platform)(((ComboItem)cbPlatform.SelectedItem)).Value).RegisterUrl);
        }

        private void cbPlatform_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_nSelectedPlatformId = ((Platform)(((ComboItem)cbPlatform.SelectedItem)).Value).Id;
            ChangePlatformId(m_nSelectedPlatformId);
        }

        private void cbUserName_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetUserUI((User)(((ComboItem)cbUserName.SelectedItem)).Value);          
        }

        private void cbkRememberPwd_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbkRememberPwd.Checked)
            {
                cbkAutoLogin.Checked = false;
            }
        }

        private void cbkAutoLogin_CheckedChanged(object sender, EventArgs e)
        {
            if (cbkAutoLogin.Checked)
            {
                cbkRememberPwd.Checked = true;
            }
        }

        private void SetUserUI(User user)
        {
            cbUserName.Text = user.UserName;
            cbkRememberPwd.Checked = user.RememberPwd;
            cbkAutoLogin.Checked = user.AutoLogin;
            if (user.RememberPwd)
            {
                tbUserPwd.Text = Encrypt.DES3Decrypt(user.UserPwd, Encrypt.MD5Encrypt(user.UserName));
            }
        }

        private void ChangePlatformId(int platformId)
        {
            List<User> listUser = m_bllUser.GetUserListForPlatformId(platformId);
            cbUserName.Items.Clear();
            foreach (User user in listUser)
            {
                ComboItem item = new ComboItem(user.UserName);
                item.Value = user;
                cbUserName.Items.Add(item);
            }
        }

        private void cbUserName_TextChanged(object sender, EventArgs e)
        {
            User user = m_bllUser.GetUserForName(cbUserName.Text, m_nSelectedPlatformId);
            if (user != null)
            {
                //如果用户名在数据库中可以查找到则直接将数据库的值赋值过去
                cbkRememberPwd.Checked = user.RememberPwd;
                cbkAutoLogin.Checked = user.AutoLogin;
                if (user.RememberPwd)
                {
                    tbUserPwd.Text = Encrypt.DES3Decrypt(user.UserPwd, Encrypt.MD5Encrypt(user.UserName));
                }
            }
            else
            {
                tbUserPwd.Text = string.Empty;
                cbkRememberPwd.Checked = false;
                cbkAutoLogin.Checked = false;
            }
        }       
    }
}
