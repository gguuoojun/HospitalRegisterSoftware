using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalRegisterSoftware.Register.Model
{
    /// <summary>
    /// 科室下所有预约信息管理
    /// </summary>
    public class DepartmentRegisterInfo
    {
        private const int TOTAL_DAYS = 8;            //存储8天信息

        /// <summary>
        /// 当前存储医生预约信息起始索引
        /// </summary>
        private int m_nCurrentIndex = 0;
        
        private List<DoctorRegInfo> doctorRegInfoList = null;
        /// <summary>
        /// 医生预约信息
        /// </summary>
        public List<DoctorRegInfo> DoctorRegInfoList
        {
            get
            {
                return doctorRegInfoList;
            }
        }

        /// <summary>
        /// 获取的预约医生个数
        /// </summary>
        public int Count
        {
            get { return m_nCurrentIndex; }
        }

        /// <summary>
        /// 预约有效的八天时间信息
        /// </summary>
        public string[] RegisterDates = new string[TOTAL_DAYS];

        public DepartmentRegisterInfo()
        {
            doctorRegInfoList = new List<DoctorRegInfo>();
        }

        public void AddDoctorRegInfo(DoctorRegInfo doctorRegInfo)
        {
            if (m_nCurrentIndex < doctorRegInfoList.Count)
            {
                doctorRegInfoList[m_nCurrentIndex].Name = doctorRegInfo.Name;
                for (int i = 0; i < TOTAL_DAYS * 2; i++)
                {
                    doctorRegInfoList[m_nCurrentIndex].RemainNums[i] = doctorRegInfo.RemainNums[i];
                    doctorRegInfoList[m_nCurrentIndex].ToolTipTexts[i] = doctorRegInfo.ToolTipTexts[i];
                    doctorRegInfoList[m_nCurrentIndex].OrderUrls[i] = doctorRegInfo.OrderUrls[i];
                    doctorRegInfoList[m_nCurrentIndex].RegistionTypes[i] = doctorRegInfo.RegistionTypes[i];
                }
            }
            else
            {
                doctorRegInfoList.Add((DoctorRegInfo)doctorRegInfo.Clone());
            }
            m_nCurrentIndex++;
        }

        public void Clear()
        {
            m_nCurrentIndex = 0;
        }
    }
}
