using System.Collections.Generic;

namespace HospitalRegisterSoftware.Register.Model
{
    /// <summary>
    /// 预约订单管理
    /// </summary>
    public class OrderManager
    {
        /// <summary>
        /// 医生基本信息
        /// </summary>
        public DoctorInfo Doctor = new DoctorInfo();
        /// <summary>
        /// 用户基本信息
        /// </summary>
        public UserInfo User = null;
        /// <summary>
        /// 挂号费用
        /// </summary>
        public string RegisterFee = string.Empty;
        /// <summary>
        /// 预约订单日期
        /// </summary>
        public string RegisterDate = string.Empty;
        /// <summary>
        /// 确认（选择）预约订单URL字符串格式
        /// </summary>
        public string CheckOrderPostUrlFormat = string.Empty;
        /// <summary>
        /// 订单选择后验证码格式
        /// </summary>
        public string OrderAuthCodeFormat = string.Empty;
        /// <summary>
        /// 提交订单前的验证码确认格式
        /// </summary>
        public string CheckOrderAuthCodeFormat = string.Empty;
        /// <summary>
        /// 医生的预约订单信息列表
        /// </summary>
        public List<OrderInfo> OrderInfos = new List<OrderInfo>();
        /// <summary>
        /// 选择的订单索引
        /// </summary>
        protected int m_nSelectedOrderIndex = -1;

        public void SelectOrderInfo(int index)
        {
            m_nSelectedOrderIndex = index;
        }

        /// <summary>
        /// 获取预约订单URL
        /// </summary>
        /// <returns></returns>
        public virtual string GetCheckOderPostData()
        {
            return string.Empty;
        }

        /// <summary>
        /// 获得订单选择后验证码请求内容
        /// </summary>
        /// <returns></returns>
        public virtual string GetOrderAuthCodeData()
        {
            return string.Empty;
        }

        /// <summary>
        /// 获得提交订单前验证码验证是否正确请求内容
        /// 也可以直接提交订单而忽略这一步
        /// </summary>
        /// <param name="authCode">验证码</param>
        /// <returns></returns>
        public virtual string GetCheckOrderAuthCodeData(string authCode)
        {
            return string.Empty;
        }

    }

    /// <summary>
    ///订单信息
    /// </summary>
    public class OrderInfo
    {
        /// <summary>
        /// 订单序号
        /// </summary>
        public string OrderNum;
        /// <summary>
        /// 订单ID号
        /// </summary>
        public string OrderId;
        /// <summary>
        /// 订单时间
        /// </summary>
        public string OrderTime;
    }

    /// <summary>
    /// 医生基本信息
    /// </summary>
    public class DoctorInfo
    {
        /// <summary>
        /// 医生名称
        /// </summary>
        public string Name;
        /// <summary>
        /// 医生所在医院
        /// </summary>
        public string HospitalName;
        /// <summary>
        /// 医生所在科室
        /// </summary>
        public string Department;
        /// <summary>
        /// 医生所在医院ID
        /// </summary>
        public string HospitalId;
    }
}
