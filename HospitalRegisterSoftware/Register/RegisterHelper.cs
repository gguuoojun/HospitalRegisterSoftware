using Utility;
using System.Drawing;
using HtmlAgilityPack;
using HospitalRegisterSoftware.Register.Model;
using System;

namespace HospitalRegisterSoftware.Register
{
    public abstract class RegisterHelper 
    {
        /// <summary>
        /// 最近一次错误信息
        /// </summary>
        protected string m_lastError = string.Empty;

        /// <summary>
        /// HTTP封装类库
        /// </summary>
        protected HttpHelper m_httpHelper = new HttpHelper();
        /// <summary>
        /// Http请求参考类
        /// </summary>
        protected HttpItem m_httpItem = new HttpItem();
        /// <summary>
        /// HTTP请求后获得html格式文档
        /// </summary>
        protected HtmlDocument m_htmlDocument = new HtmlDocument();

        protected bool m_bIsLogin;
        /// <summary>
        /// 是否已经登录
        /// </summary>
        public bool IsLogin
        {
            get
            {
                return m_bIsLogin;
            }
        }

        /// <summary>
        /// 获取最近一次错误内容
        /// </summary>
        /// <returns></returns>
        public string GetLastError()
        {
            return m_lastError;
        }

        /// <summary>
        /// 根据地区名称获取预约放号时间
        /// </summary>
        /// <param name="areaName"></param>
        /// <returns></returns>
        public abstract TimeSpan GetAllocationTime(string areaName);
        /// <summary>
        /// 预约平台不同地区的提示信息
        /// </summary>
        /// <returns></returns>
        public abstract string GetTipMessage(string areaName);
        /// <summary>
        /// 选择地区
        /// </summary>
        /// <param name="index"></param>
        public abstract void SetAreaIndex(int index);
        /// <summary>
        /// 选择医院
        /// </summary>
        /// <param name="index"></param>
        public abstract void SetHospitalIndex(int index);
        /// <summary>
        /// 选择科室
        /// </summary>
        /// <param name="index"></param>
        public abstract void SetDepartmentIndex(int index);
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passwd"></param>
        /// <param name="authCode"></param>
        /// <returns></returns>
        public abstract bool Login(string userName, string passwd, string authCode);
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        public abstract UserInfo GetUserInfo();
        /// <summary>
        /// 注销
        /// </summary>
        public abstract void Logout();
        /// <summary>
        /// 获取所有地区名称
        /// </summary>
        /// <returns></returns>
        public abstract AreaBack GetArea();
        /// <summary>
        /// 获取地区下所有医院名称
        /// </summary>
        /// <returns></returns>
        public abstract HospitalBack GetHospital();
        /// <summary>
        /// 获取医院下所有科室
        /// </summary>
        /// <param name="hosCode"></param>
        /// <returns></returns>
        public abstract DepartmentBack GetDepartment();
        /// <summary>
        /// 获取科室下所有医生预约信息
        /// </summary>
        /// <returns></returns>
        public abstract bool GetDepartmenRegisterInfo(ref DepartmentRegisterInfo depRegisterInfo);
        /// <summary>
        /// 获取登录验证码
        /// </summary>
        /// <returns></returns>
        public abstract Image GetLoginAuthCode();
        /// <summary>
        /// 获取医生的所有可预约信息
        /// </summary>
        /// <param name="query"></param>
        /// <param name="orderManger"></param>
        /// <returns></returns>
        public abstract bool GetOrderManager(string requestData, ref OrderManager orderManger);
        /// <summary>
        /// 确认（选择）预约定订单
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="authCode"></param>
        /// <returns></returns>
        public abstract bool CheckOrderInfo(string postData);
        /// <summary>
        /// 获取订单提交验证码
        /// </summary>
        /// <param name="orderId">订单ID</param>
        /// <returns></returns>
        public abstract Image GetOrderCode(string requestData);
        /// <summary>
        /// 检测验证码是否正确
        /// <param name="orderId"></param>
        /// <param name="authCode"></param>
        /// <returns></returns>
        public abstract bool CheckOrderCode(string requestData);
        /// <summary>
        /// 提交预约订单
        /// </summary>
        /// <param name="authCode"></param>
        /// <param name="successInfo"></param>
        /// <returns></returns>
        public abstract bool SaveOrderInfo(string authCode, ref RegisterSuccessInfo successInfo);
    }
}
