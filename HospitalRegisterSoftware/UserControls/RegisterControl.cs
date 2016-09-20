using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DevComponents.Editors;
using HospitalRegisterSoftware.Register;
using HospitalRegisterSoftware.Forms;
using HospitalRegisterSoftware.Register.Model;
using Utility;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using System.Threading;

namespace HospitalRegisterSoftware.UserControls
{
    public partial class RegisterControl : UserControl
    {
        private TimeSpan m_spanBeijingTime = new TimeSpan(0L);        //北京时间与本地时间之差

        private RegisterHelper m_register = null;
        private OrderManager m_orderManager = null;
        private DepartmentRegisterInfo m_deptRegisterInfo = new DepartmentRegisterInfo();

        private TimeSpan m_spanRegister;                              //预约时间

        private WaitingForm m_frmWating = new WaitingForm();

        private List<DoctorPriority> m_listDoctorPriority = new List<DoctorPriority>();

        private Thread m_tdRefreshRegInfo = null;               //刷新预约信息线程
        private ManualResetEvent m_RefreshRegInfoEvent = new ManualResetEvent(false);
        private bool m_bIsExitRegInfoThread = false;            //是否退出预约信息线程
        private bool m_bIsRefreshing = false;                   //是否刷新中

        private Point m_posCellMouseDown;                       //单元格鼠标点击位置               

        private string[] m_displayDays = new string[16];

        public RegisterControl()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            InitDateLable();
            InitRefreshThread();
            toolTip1.SetToolTip(this.itemPrioritys, "请拖动表格中预约信息到这里");
        }

        public void SetRegisterHelper(RegisterHelper register, OrderManager orderManager)
        {
            m_register = register;
            m_orderManager = orderManager;

            InitAreaControl();
        }

        public void SetSpanTime(TimeSpan spanTime)
        {
            m_spanBeijingTime = spanTime;
        }

        private void InitAreaControl()
        {
            cmbArea.Items.Clear();
            ComboItem comboItem = new ComboItem();
            comboItem.Text = "请选择";
            comboItem.Value = "-1";
            cmbArea.Items.Add(comboItem);
            AreaBack area = m_register.GetArea(); ;

            if (area != null)
            {
                foreach (area current in area.data.areaList)
                {
                    ComboItem comboArea = new ComboItem();
                    comboArea.Text = current.areaName;
                    comboArea.Value = current.areaCode;
                    cmbArea.Items.Add(comboArea);
                }
            }
            cmbArea.SelectedIndex = 0;
        }

        private void InitRefreshThread()
        {
            m_bIsExitRegInfoThread = false;
            m_tdRefreshRegInfo = new Thread(new ThreadStart(RefreshRegInfo));
            m_tdRefreshRegInfo.IsBackground = true;
            m_tdRefreshRegInfo.Start();
        }

        private void cmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbHospital.Items.Clear();
            ComboItem comboHospitalItem = new ComboItem();
            comboHospitalItem.Text = "请选择";
            cmbHospital.Items.Add(comboHospitalItem);

            if (cmbArea.SelectedIndex > 0)
            {
                m_spanRegister = m_register.GetAllocationTime(cmbArea.Text);

                m_register.SetAreaIndex(cmbArea.SelectedIndex - 1);
                HospitalBack hospital = m_register.GetHospital();
                if (hospital != null)
                {
                    foreach (HospitalInfo current in hospital.data.hos)
                    {
                        ComboItem item = new ComboItem();
                        item.Text = current.aliasName;
                        cmbHospital.Items.Add(item);
                    }
                }
            }
            cmbHospital.SelectedIndex = 0;
        }

        private void cmbHospital_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDepartment.Items.Clear();
            ComboItem comboItem = new ComboItem();
            comboItem.Text = "请选择";
            cmbDepartment.Items.Add(comboItem);
            if (cmbHospital.SelectedIndex > 0)
            {
                m_register.SetHospitalIndex(cmbHospital.SelectedIndex - 1);
                DepartmentBack department = m_register.GetDepartment();
                if (department != null)
                {
                    foreach (DeptInfo dept in department.data.dept)
                    {
                        ComboItem comboItem3 = new ComboItem();
                        comboItem3.Text = dept.deptName;
                        cmbDepartment.Items.Add(comboItem3);
                    }
                }
            }
            cmbDepartment.SelectedIndex = 0;
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_listDoctorPriority.Clear();
            itemPrioritys.Items.Clear();
            if (cmbDepartment.SelectedIndex - 1 >= 0)
            {
                m_register.SetDepartmentIndex(cmbDepartment.SelectedIndex - 1);
                RefreshRegisterInfo();
            }
        }

        private void RegisterControl_SizeChanged(object sender, EventArgs e)
        {
            tableLayoutPanel1.ColumnStyles[0].Width = (float)dataGridViewX1.Columns[0].Width;
            for (int i = 1; i < 9; i++)
            {
                tableLayoutPanel1.ColumnStyles[i].Width = (float)(dataGridViewX1.Columns[(i - 1) * 2 + 1].Width + dataGridViewX1.Columns[i * 2].Width);
            }
        }

        private void InitDateLable()
        {
            DateTime now = DateTime.Now;
            lbDate1.Text = now.ToString("MM/dd\ndddd");
            lbDate2.Text = now.AddDays(1.0).ToString("MM/dd\ndddd");
            lbDate3.Text = now.AddDays(2.0).ToString("MM/dd\ndddd");
            lbDate4.Text = now.AddDays(3.0).ToString("MM/dd\ndddd");
            lbDate5.Text = now.AddDays(4.0).ToString("MM/dd\ndddd");
            lbDate6.Text = now.AddDays(5.0).ToString("MM/dd\ndddd");
            lbDate7.Text = now.AddDays(6.0).ToString("MM/dd\ndddd");
            lbDate8.Text = now.AddDays(7.0).ToString("MM/dd\ndddd");
            ParseDays();
        }

        private void ParseDays()
        {
            m_displayDays[0] = m_displayDays[1] = lbDate1.Text.Substring(0, lbDate1.Text.IndexOf("\n"));
            m_displayDays[2] = m_displayDays[3] = lbDate2.Text.Substring(0, lbDate2.Text.IndexOf("\n"));
            m_displayDays[4] = m_displayDays[5] = lbDate3.Text.Substring(0, lbDate3.Text.IndexOf("\n"));
            m_displayDays[6] = m_displayDays[7] = lbDate4.Text.Substring(0, lbDate4.Text.IndexOf("\n"));
            m_displayDays[8] = m_displayDays[9] = lbDate5.Text.Substring(0, lbDate5.Text.IndexOf("\n"));
            m_displayDays[10] = m_displayDays[11] = lbDate6.Text.Substring(0, lbDate6.Text.IndexOf("\n"));
            m_displayDays[12] = m_displayDays[13] = lbDate7.Text.Substring(0, lbDate7.Text.IndexOf("\n"));
            m_displayDays[14] = m_displayDays[15] = lbDate8.Text.Substring(0, lbDate8.Text.IndexOf("\n"));
        }


        private void btnSwitch_ValueChanged(object sender, EventArgs e)
        {
            plPriority.Visible = btnSwitch.Value;
        }

        private void itemPrioritys_ItemClick(object sender, EventArgs e)
        {
            LabelItem labelItem = sender as LabelItem;
            if (labelItem != null)
            {
                itemPrioritys.Items.Remove(labelItem);
                itemPrioritys.Cursor = Cursors.Default;
                itemPrioritys.Refresh();
                if (labelItem.Tag != null)
                {
                    m_listDoctorPriority.Remove((DoctorPriority)labelItem.Tag);
                }
            }
        }

        private void itemPrioritys_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void itemPrioritys_DragDrop(object sender, DragEventArgs e)
        {
            DataGridViewCell dataGridViewCell = e.Data.GetData(typeof(DataGridViewButtonXCell)) as DataGridViewCell;
            if (dataGridViewCell != null)
            {
                AddPriorityItem(dataGridViewCell);               
            }
        }

        private void dataGridViewX1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            m_posCellMouseDown = e.Location;
        }

        private void dataGridViewX1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.RowIndex >= 0 && e.ColumnIndex > 0)
            {
                if(Math.Abs(e.Location.X - m_posCellMouseDown.X) < 1 || Math.Abs(e.Location.Y - m_posCellMouseDown.Y) < 1)
                {
                    return;
                }

                DataGridViewCell dataGridViewCell = this.dataGridViewX1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (!string.IsNullOrEmpty(dataGridViewCell.ToolTipText) && dataGridViewCell.ToolTipText != "已过预约")
                {
                    itemPrioritys.DoDragDrop(dataGridViewCell, DragDropEffects.All);
                }
            }
        }


        private void dataGridViewX1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex <= 0 || e.RowIndex < 0)
            {
                return;
            }
            DataGridViewCell dataGridViewCell = this.dataGridViewX1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (dataGridViewCell != null && dataGridViewCell.Tag != null)
            {
                if (m_register.GetOrderManager((string)dataGridViewCell.Tag, ref m_orderManager))
                {
                    OrderForm orderForm = new OrderForm(m_register, m_orderManager);
                    orderForm.ShowDialog();
                    orderForm.Dispose();
                }
            }
        }

        private void AddPriorityItem(DataGridViewCell cell)
        {
            //防止重复添加
            if (!m_listDoctorPriority.Exists((DoctorPriority T) => T.CellIndex == cell.ColumnIndex - 1 && T.RowsIndex == cell.RowIndex))
            {
                DoctorPriority docPriority = new DoctorPriority
                {
                    CellIndex = cell.ColumnIndex - 1,
                    RowsIndex = cell.RowIndex,
                    Name = string.Format("{0} {1}({2})", dataGridViewX1.Rows[cell.RowIndex].Cells[0].Value,
                           dataGridViewX1.Columns[cell.ColumnIndex].HeaderText, m_displayDays[cell.ColumnIndex - 1])

                };

                m_listDoctorPriority.Add(docPriority);
                LabelItem labelItem = new LabelItem();
                labelItem.Text = docPriority.Name;
                labelItem.Font = new Font("宋体", 9.5f, FontStyle.Underline);
                labelItem.Cursor = Cursors.Hand;
                itemPrioritys.Items.Add(labelItem);
                labelItem.Tag = docPriority;
                itemPrioritys.Refresh();
            }
        }

        private void cmbArea_DropDown(object sender, EventArgs e)
        {
            if (cmbArea.Items.Count == 1)
            {
                InitAreaControl();
                if (cmbArea.Items.Count == 1)
                {
                    MessageBoxExS.ShowError("网络连接失败,无法获取地区信息！");
                }
            }
        }     

        private bool InvokeRefreshRegInfo()
        {
            bool bIsSuccess = false;
            if (!IsDisposed)
            {
                Invoke((Action)(delegate
                {
                    btnRefresh.Text = "刷新";
                    btnRefresh.Refresh();
                    bIsSuccess = RefreshRegisterInfo();
                }));
            }
            return bIsSuccess;
        }

        private bool RefreshRegisterInfo()
        {
            dataGridViewX1.Rows.Clear();
            if (cmbHospital.Items.Count == 0 || cmbDepartment.Items.Count == 0
                || cmbHospital.SelectedIndex == 0 || cmbDepartment.SelectedIndex == 0)
            {
                return false;
            }

            return RefreshDatagridView();
        }

        private bool RefreshDatagridView()
        {
            if (!m_register.GetDepartmenRegisterInfo(ref m_deptRegisterInfo))
            {
                panelInfo.Text = m_register.GetLastError();
                return false;
            }

            panelInfo.Text = m_register.GetTipMessage(cmbArea.Text);
            bool bIsSuccess = false;

            if (GetDetailRegisterInfo())
            {
                bIsSuccess = true;
                //如果成功预约，那么这里就再刷新一次列表信息
                m_register.GetDepartmenRegisterInfo(ref m_deptRegisterInfo);
            }

            if (lbDate1.Text != m_deptRegisterInfo.RegisterDates[0])
            {
                lbDate1.Text = m_deptRegisterInfo.RegisterDates[0];
                lbDate2.Text = m_deptRegisterInfo.RegisterDates[1];
                lbDate3.Text = m_deptRegisterInfo.RegisterDates[2];
                lbDate4.Text = m_deptRegisterInfo.RegisterDates[3];
                lbDate5.Text = m_deptRegisterInfo.RegisterDates[4];
                lbDate6.Text = m_deptRegisterInfo.RegisterDates[5];
                lbDate7.Text = m_deptRegisterInfo.RegisterDates[6];
                lbDate8.Text = m_deptRegisterInfo.RegisterDates[7];
                ParseDays();
            }

            for (int i = 0; i < m_deptRegisterInfo.Count; i++)
            {
                int num = 0;
                int index = this.dataGridViewX1.Rows.Add();
                DoctorRegInfo regDoctor = m_deptRegisterInfo.DoctorRegInfoList[i];
                DataGridViewCell dataGridViewCell = dataGridViewX1.Rows[index].Cells[num];
                dataGridViewCell.Value = regDoctor.Name;
                num++;
                for (int j = 0; j < 16; j++)
                {
                    if (regDoctor.RemainNums[j] != null)
                    {
                        dataGridViewCell = dataGridViewX1.Rows[index].Cells[num];
                        dataGridViewCell.Value = GetCellValue(regDoctor.RemainNums[j], regDoctor.RegistionTypes[j]);
                        dataGridViewCell.ToolTipText = regDoctor.ToolTipTexts[j];
                        dataGridViewCell.Tag = regDoctor.OrderUrls[j];
                    }
                    num++;
                }
            }

            return bIsSuccess;
        }

        private bool GetDetailRegisterInfo()
        {
            bool bIsSuccess = false;
            if (m_listDoctorPriority.Count == 0)
            {
                return false;
            }         

            foreach (DoctorPriority priority in m_listDoctorPriority)
            {
                string requestData = m_deptRegisterInfo.DoctorRegInfoList[priority.RowsIndex].OrderUrls[priority.CellIndex];
                if (requestData != null)
                {
                    if (m_register.GetOrderManager(requestData, ref m_orderManager))
                    {
                        m_RefreshRegInfoEvent.Reset();
                        EnableControl(true);
                        btnRefresh.Text = "刷新";

                        OrderForm orderForm = new OrderForm(m_register, m_orderManager);
                        if (DialogResult.OK == orderForm.ShowDialog())
                        {
                            bIsSuccess = true;
                        }
                        orderForm.Dispose();
                        cmbArea.Enabled = true;
                        cmbDepartment.Enabled = true;
                        cmbHospital.Enabled = true;

                        break;
                    }
                }
            }
            return bIsSuccess;
        }

        /// <summary>
        /// 预约结果显示的颜色名称数组
        /// </summary>
        private string[] m_byRegistionColorName = new string[7]
        {
            "DarkGreen","DarkRed","Blue","Gray","Gray","Gray","Gray"
        };
        /// <summary>
        /// 根据预约结果返回要显示的值
        /// </summary>
        /// <param name="value"></param>
        /// <param name="enRegType"></param>
        /// <returns></returns>
        private string GetCellValue(string value, RegistionType enRegType)
        {
            string format = "<font face =\"Microsoft YaHei\" color=\"{0}\">{1}</font>";
            return string.Format(format, m_byRegistionColorName[enRegType.GetHashCode()], value);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (cmbDepartment.SelectedIndex <= 0)
            {
                dataGridViewX1.Rows.Clear();
                return;
            }

            if (m_bIsRefreshing)
            {
                m_RefreshRegInfoEvent.Reset();
                EnableControl(true);
                btnRefresh.Text = "刷新";
            }
            else
            {
                if (m_listDoctorPriority.Count == 0)
                {
                    EnableControl(false);
                    btnRefresh.Enabled = false;
                    m_frmWating.OnDoWork = (s, we) =>
                    {
                        InvokeRefreshRegInfo();
                    };
                    m_frmWating.MsgWait = "刷新预约信息中...";
                    m_frmWating.ShowDialog();
                    btnRefresh.Enabled = true;
                    EnableControl(true);
                }
                else
                {
                    EnableControl(false);
                    m_RefreshRegInfoEvent.Set();
                }
            }
        }


        private void RefreshRegInfo()
        {
            float total = 0;
            bool bIsContainNormalRegsiter = false;       //是否还有非第八天预约信息
            while (!m_bIsExitRegInfoThread)
            {
                m_RefreshRegInfoEvent.WaitOne();
                if(m_bIsExitRegInfoThread)
                {
                    return;
                }

                bIsContainNormalRegsiter = false;
                foreach (DoctorPriority doctorPriority in m_listDoctorPriority)
                {
                    if (doctorPriority.CellIndex < 14)
                    {
                        bIsContainNormalRegsiter = true;
                        break;
                    }
                }

                total = (float)((DateTime.Now.Add(m_spanBeijingTime) - DateTime.Today).TotalMilliseconds - m_spanRegister.TotalMilliseconds);
                if (bIsContainNormalRegsiter)
                {
                    if (Math.Abs(total) > 3000)
                    {
                        total = 500000f;
                    }
                }

                float count = 1000f;
                if (total < 0.0)
                {
                    Invoke((Action)(() =>
                    {
                        InvokeDisplayStopTimeInfo(Math.Abs(total));
                        this.btnRefresh.Refresh();
                    }));
                    Thread.Sleep(100);
                    if (m_bIsExitRegInfoThread)
                    {
                        return;
                    }
                }
                else if (total <= 0.0 && total > -1000f)
                {
                    if (!InvokeRefreshRegInfo())
                    {
                        InvokeDisplayStopTimeInfo(Math.Abs(total));
                        Thread.Sleep(300);
                        if (m_bIsExitRegInfoThread)
                        {
                            return;
                        }
                    }
                }
                else if (total < 500000f)
                {
                    if (!InvokeRefreshRegInfo())
                    {
                        //500秒以内每隔1秒刷新一次
                        count = 1000f;
                        for (int i = 0; i < 10; i++)
                        {
                            if (!m_bIsRefreshing)
                            {
                                break;
                            }

                            if (m_bIsExitRegInfoThread)
                            {
                                return;
                            }

                            InvokeDisplayStopTimeInfo(count);
                            count -= 100f;
                            Thread.Sleep(100);
                        }
                    }
                }
                else
                {
                    if (!InvokeRefreshRegInfo())
                    {
                        //大于500秒后每隔3秒刷新一次
                        count = 3000f;
                        for (int j = 0; j < 30; j++)
                        {
                            if (!m_bIsRefreshing)
                            {
                                break;
                            }

                            if (m_bIsExitRegInfoThread)
                            {
                                return;
                            }

                            InvokeDisplayStopTimeInfo(count);
                            count -= 100f;
                            Thread.Sleep(100);
                        }
                    }
                }
            }
        }

        private void InvokeDisplayStopTimeInfo(float time)
        {
            if (!IsDisposed)
            {
                Invoke((Action)(delegate
                {
                    btnRefresh.Text = string.Format("  停止<div align=\"center\"><font face=\"Times New Roman\" size=\"12\" color=\"red\">{0:f1}</font></div>", time / 1000f);
                    btnRefresh.Refresh();
                }));
            }
        }

        private void EnableControl(bool bIsEnable)
        {
            m_bIsRefreshing = !bIsEnable;
            cmbArea.Enabled = bIsEnable;
            cmbDepartment.Enabled = bIsEnable;
            cmbHospital.Enabled = bIsEnable;
            dataGridViewX1.Enabled = bIsEnable;
        }

        public void Close()
        {
            m_bIsExitRegInfoThread = true;
            m_RefreshRegInfoEvent.Set();
            while (m_tdRefreshRegInfo.IsAlive)
            {
                Application.DoEvents();
            }
            m_tdRefreshRegInfo = null;
            m_frmWating.Dispose();
        }

        /// <summary>
        /// 医生优先级信息
        /// </summary>
        private class DoctorPriority
        {
            /// <summary>
            /// 预约医生名称
            /// </summary>
            public string Name;
            /// <summary>
            /// 预约信息所在行
            /// </summary>
            public int RowsIndex;
            /// <summary>
            /// 预约信息所在列
            /// </summary>
            public int CellIndex;
        }

      
    }

   
}
