using System;
using System.ComponentModel;
using DevComponents.DotNetBar.Metro;
using HospitalRegisterSoftware.Register;
using System.Windows.Forms;
using Utility;
using System.Threading;
using DevComponents.DotNetBar;
//using FSLib.App.SimpleUpdater;

namespace HospitalRegisterSoftware.Forms
{
    public partial class RegisterForm : MetroForm
    {
        private RegisterHelper m_register = null;

        private LoginForm m_frmLogin = new LoginForm();

        private TimeSpan m_spanServer;
        private BeijingTime m_bjTime = BeijingTime.Instance;
        private Thread m_tdTimeManager;
        private bool m_bIsConnectNtp = false;     //是否同步Ntp时间中
        private bool m_bIsExitTimeThread = false; //是否退出时间刷新线程

        //private const string UPDATE_URL = @"ftp://批控仪组态软件\{0}";
        //private const string UPDATE_XML = "update_c.xml";
        //private Updater updater = null;
        //private bool bIsFirstLogin = true;

        public RegisterForm()
        {
            InitializeComponent();

            MessageBoxEx.UseSystemLocalizedString = true;
            MessageBoxEx.OwnerStartPosition = FormStartPosition.CenterParent;
        }

        protected override void OnLoad(EventArgs e)
        {
            Login();

            m_bjTime.NTPServerTimeConnectedEventHander += NTPServerTimeConnected;
            RefreshTime();

            m_tdTimeManager = new Thread(new ThreadStart(tmManager));
            m_tdTimeManager.IsBackground = true;
            m_tdTimeManager.Start();

            //InitAutoUpdate();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            registerControl1.Close();
            m_frmLogin.Close();
        }

        private void lbItemTime_Click(object sender, EventArgs e)
        {
            RefreshTime();
        }

        private void btnItemDonate_Click(object sender, EventArgs e)
        {
            DonateForm frmDonate = new DonateForm();
            frmDonate.ShowDialog();
            frmDonate.Dispose();
        }

        private void RegisterForm_HelpButtonClick(object sender, EventArgs e)
        {
            //关于
            AboutBox boxAbout = new AboutBox();
            boxAbout.ShowDialog();
            boxAbout.Dispose();
        }

        private void RegisterForm_SettingsButtonClick(object sender, EventArgs e)
        {
            //注销
            m_register.Logout();
            this.Hide();
            //进入登录界面
            Login();
        }

        private void Login()
        {
            if (m_frmLogin.ShowDialog() == DialogResult.OK)
            {
                m_register = m_frmLogin.RegisterHelper;
                registerControl1.SetRegisterHelper(m_register, m_frmLogin.OrderManager);
                Text = "预约挂号辅助软件 - " + m_frmLogin.OrderManager.User.Name;
                m_frmLogin.Hide();
                this.Show();
            }
            else
            {
                m_bjTime.Close();
                if (m_tdTimeManager != null)
                {
                    m_bIsExitTimeThread = true;
                    while(m_tdTimeManager.IsAlive)
                    {
                        Application.DoEvents();
                    }
                    m_tdTimeManager = null;
                }
                
                Close();
            }
        }

        private void RefreshTime()
        {
            if (m_bIsConnectNtp)
            {
                return;
            }

            m_bIsConnectNtp = true;
            this.lbItemTime.Text = "时间获取中...";
            this.lbItemSpanTime.Text = string.Empty;
            this.m_spanServer = TimeSpan.Zero;
            this.metroStatusBar1.Refresh();
            this.m_bjTime.GetNtpTime();
        }

        private void tmManager()
        {
            //线程启动后先自动刷新下时间
            Invoke(new Action(delegate
            {
                RefreshTime();
            }));

            while (!m_bIsExitTimeThread)
            {
                if (!IsDisposed && !m_bIsConnectNtp)
                {
                    Invoke(new Action(delegate
                    {
                        lbItemTime.Text = DateTime.Now.Add(m_spanServer).ToString();
                        if (!m_bjTime.IsConnect)
                        {
                            lbItemTime.Text += "(本地时间)  时间获取失败(点击以重新获取)";
                        }
                        metroStatusBar1.Refresh();

                    }));

                }
                Thread.Sleep(1000);
            }
        }

        private void NTPServerTimeConnected(bool bIsConnected, TimeSpan tsClock)
        {
            if (bIsConnected && !IsDisposed)
            {        
                m_spanServer = tsClock;
                registerControl1.SetSpanTime(tsClock);

                Invoke((Action)(() =>
                {
                    if (m_spanServer.TotalSeconds > 0.0)
                    {
                        lbItemSpanTime.Text = string.Format("慢{0:f6}秒", m_spanServer.TotalSeconds);
                    }
                    else
                    {
                        lbItemSpanTime.Text = string.Format("快{0:f6}秒", Math.Abs(m_spanServer.TotalSeconds));
                    }
                    metroStatusBar1.Refresh();
                }));

            }
            m_bIsConnectNtp = false;
        }

        private void InitAutoUpdate()
        {
            //if (updater == null)
            //{
            //    updater = Updater.CreateUpdaterInstance(UPDATE_URL, UPDATE_XML);
            //    updater.Error += (s, e) =>
            //    {
            //        btnCheckUpgrate.Enabled = true;
            //        btnCheckUpgrate.Text = "检查更新";
            //        if (!bIsFirstLogin)
            //        {
            //            MessageBoxExS.ShowError("更新失败：" + updater.Context.Exception.Message);
            //        }                    
            //    };

            //    updater.UpdateCancelled += (s, e) =>
            //    {
            //        btnCheckUpgrate.Text = "检查更新";
            //        btnCheckUpgrate.Enabled = true;
            //    };

            //    updater.NoUpdatesFound += (s, e) =>
            //    {
            //        btnCheckUpgrate.Text = "版本最新";
            //        btnCheckUpgrate.Enabled = true;
            //    };

            //    updater.MinmumVersionRequired += (s, e) =>
            //    {
            //        MessageBoxExS.ShowError("当前版本过低无法使用自动更新！");
            //        btnCheckUpgrate.Text = "检查更新";
            //        btnCheckUpgrate.Enabled = true;
                    
            //    };
            //}

            //CheckUpdateProgram();
        }

        ///// <summary>
        ///// 检查是否有更新，有则更新程序
        ///// </summary>
        //private void CheckUpdateProgram()
        //{
        //    btnCheckUpgrate.Text = "检查更新中...";
        //    btnCheckUpgrate.Enabled = false;
        //    updater.BeginCheckUpdateInProcess();         
        //}

        //private void btnCheckUpgrate_Click(object sender, EventArgs e)
        //{
        //    //bIsFirstLogin = false; 
        //    //CheckUpdateProgram();            
        //}
    }
}
