using System;

namespace HospitalRegisterSoftware.Register.Model
{
    /// <summary>
    /// 医生预约信息
    /// </summary>
    public class DoctorRegInfo : ICloneable
    {
        private const int TOTAL_DAYS = 8;            //存储8天信息
        /// <summary>
        /// 医生名称
        /// </summary>
        public string Name;
        /// <summary>
        /// 预约票源剩余个数
        /// </summary>
        public string[] RemainNums = new string[TOTAL_DAYS * 2];
        /// <summary>
        /// 预约订单指向地址
        /// </summary>
        public string[] OrderUrls = new string[TOTAL_DAYS * 2];
        /// <summary>
        /// 提示文本
        /// </summary>
        public string[] ToolTipTexts = new string[TOTAL_DAYS * 2];
        /// <summary>
        /// 预约挂号信息类型
        /// </summary>
        public RegistionType[] RegistionTypes = new RegistionType[TOTAL_DAYS * 2];

        public object Clone()
        {
            DoctorRegInfo regDoctor = (DoctorRegInfo)base.MemberwiseClone();
            regDoctor.OrderUrls = new string[OrderUrls.Length];
            regDoctor.ToolTipTexts = new string[ToolTipTexts.Length];
            regDoctor.RemainNums = new string[RemainNums.Length];
            regDoctor.RegistionTypes = new RegistionType[ToolTipTexts.Length];
            Array.Copy(RemainNums, regDoctor.RemainNums, RemainNums.Length);
            Array.Copy(ToolTipTexts, regDoctor.ToolTipTexts, ToolTipTexts.Length);
            Array.Copy(OrderUrls, regDoctor.OrderUrls, OrderUrls.Length);
            Array.Copy(RegistionTypes, regDoctor.RegistionTypes, RegistionTypes.Length);
            return regDoctor;
        }
    }

    /// <summary>
    /// 预约挂号信息类型
    /// </summary>
    public enum RegistionType
    {
        Normal,             //正常
        Full,               //已满
        StopAdmission,      //停诊
        NoAllocation,       //暂未放号
        Timeout,            //已过预约
        Empty,              //无预约信息
        Other               //其他未知状态
    }
}
