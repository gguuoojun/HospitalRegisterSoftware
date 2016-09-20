using System.Drawing;
using System.Collections.Generic;
using System.Text;
using HospitalRegisterSoftware.Register;
using Utility;
using HtmlAgilityPack;
using System;
using HospitalRegisterSoftware.Register.Model;
using Newtonsoft.Json;
using HospitalRegisterSoftware.Plugins;

namespace Hangzhou12580
{
    [PluginInfo("杭州12580预约平台", "http://www.zj12580.cn/", "http://www.zj12580.cn/patient/reg1", "日行一米")]
    public class HangzhouRegister : RegisterHelper
    {
        private const string AREA_LIST_URL = "http://www.zj12580.cn/area";
        private const string HOS_LIST_URL = "http://www.zj12580.cn/hos/list/";
        private const string DEPT_LIST_URL = "http://www.zj12580.cn/dept/list/";
        private const string DOCTER_LIST_URL = "http://www.zj12580.cn/doc/list/";
        private const string DEPT_INFO_URL = "http://www.zj12580.cn/dept/queryDepartInfo/";
        private const string AUTHCODE_URL = "http://www.zj12580.cn/authCode.svl?type=captcha&time=";
        private const string ORDER_URL = "http://www.zj12580.cn/regCaptcha.svl?";
        private const string CHECK_CAP_CODE_URL = "http://www.zj12580.cn/order/capchk?";
        private const string LOGIN_URL = "http://www.zj12580.cn/login";
        private const string INDEX_URL = "http://www.zj12580.cn/";
        private const string LOGOUT_URL = "http://www.zj12580.cn/logout";
        private const string ORDER_SAVE_URL = "http://www.zj12580.cn/order/save";
        private const string ORDER_CHECK_URL = "http://www.zj12580.cn/order/check";

        private const string REGISTER_INFO_XPATH = "/html/body/div[@id='middle']/div[@class='middle_content']/div[@class='right_boxs']/div[@class='right_box_1']/div[@class='right_box_1_r']/table";
        private const string LOGIN_RESULT_XPATH = "/html/body/div[@id='middle_login']/div[@class='right_box']/p[@class='center']/span";
        private const string NON_USRR_XPATH = "/html/body/div[@id='middle_pwd']";
        private const string USER_INFO_XPATH = "/html/body/div[@class='header_3']/div[@class='ad_box']/div[@class='ad']/div[@class='login_next_box']/div[@class='login_next']/table";
        private const string ORDER_INFO_XPATH = "/html/body/div[@id='middle']/div[@class='m_b']";
        private const string ORDER_SUCCESS_XPATH = "/html/body/div[@id='middle']/div[@class='m_b']/div[@class='succe']";
        private const string LOGIN_RANDOM_XPATH = "/html/body/div[@id ='middle_login']/div[@class ='right_box']/input";

        /// <summary>
        /// 预约订单内容
        /// </summary>
        private string m_postRegisterOrderData = string.Empty; 

        private AreaBack m_areaBack = null;
        private HospitalBack m_hosBack = null;
        private DepartmentBack m_depBack = null;

        private TimeSpan tSpanProvince = new TimeSpan(15, 0, 0);         //省直放号时间
        private TimeSpan tSpanNotProvince = new TimeSpan(14, 0, 0);      //非省直放号时间

        /// <summary>
        /// 医生预约信息，作为全部变量存储每次获取的预约信息
        /// </summary>
        private DoctorRegInfo m_doctorRegInfo = new DoctorRegInfo();

        private int m_indexArea = 0;
        private int m_indexHos = 0;
        private int m_indexDep = 0;

        public override void SetAreaIndex(int index)
        {
            m_indexArea = index;
        }

        public override void SetHospitalIndex(int index)
        {
            m_indexHos = index;
        }

        public override void SetDepartmentIndex(int index)
        {
            m_indexDep = index;
        }

        public override TimeSpan GetAllocationTime(string areaName)
        {
            if (areaName == "省直")
            {
                return tSpanProvince;
            }
            else
            {
                return tSpanNotProvince;
            }
        }

        public override string GetTipMessage(string areaName)
        {
            if (areaName == "省直")
            {
                return "(提前7天下午15:00放号，取号时间请以接收的短信为准)";
            }
            else
            {
                return "(提前7天下午14:00放号，取号时间请以接收的短信为准)";
            }
        }

        public override Image GetLoginAuthCode()
        {
            Image result = null;
            try
            {
                m_httpItem.URL = AUTHCODE_URL + Common.GetLocalTime();
                m_httpItem.ResultType = ResultType.Byte;
                m_httpItem.Method = "GET";
                m_httpItem.ContentType = "text/html";
                HttpResult html = m_httpHelper.GetHtml(m_httpItem);
                if (html.Cookie != null)
                {
                    m_httpItem.Cookie = html.Cookie;
                }
                result = Common.ConvertbyteArrayToImage(html.ResultByte);
            }
            catch (Exception err)
            {
                m_lastError = "验证码获取失败：" + err.Message;
                Logger.WriteError("验证码获取失败", err);
            }
            return result;
        }


        public override bool Login(string userName, string passwd, string authCode)
        {
            m_bIsLogin = false;
            try
            {
               
                m_httpItem.URL = LOGIN_URL;
                m_httpItem.ResultType = ResultType.String;
                m_httpItem.Method = "POST";
                m_httpItem.Allowautoredirect = false;
                passwd = Encrypt.MD5Encrypt(passwd);
                m_httpItem.Postdata = string.Format("password={0}&username={1}&pwd={2}&captcha={3}", passwd, userName, passwd, authCode);
                m_httpItem.ContentType = "application/x-www-form-urlencoded";
                HttpResult html = m_httpHelper.GetHtml(m_httpItem);
                if (html.RedirectUrl == INDEX_URL)
                {
                    m_bIsLogin = true;
                    return m_bIsLogin;
                }
                m_htmlDocument.LoadHtml(html.Html);
                HtmlNode htmlNode = m_htmlDocument.DocumentNode.SelectSingleNode(LOGIN_RESULT_XPATH);
                if (htmlNode != null)
                {
                    m_lastError = htmlNode.InnerHtml.Trim();
                }
                else if (m_htmlDocument.DocumentNode.SelectSingleNode(NON_USRR_XPATH) != null)
                {
                    m_lastError = "登录失败：该用户名没有注册";
                }
                else
                {
                    m_lastError = "登录失败：登陆信息获取失败";
                }
            }
            catch (Exception ex)
            {
                Logger.WriteError("登陆失败", ex);
                m_lastError = "登录失败：" + ex.Message;
            }
            return m_bIsLogin;
        }

        public override void Logout()
        {
            m_httpItem.URL = LOGOUT_URL;
            m_httpItem.ResultType = ResultType.String;
            m_httpItem.Method = "GET";
            m_httpItem.Postdata = string.Empty;
            m_httpItem.ContentType = "text/html";
            m_httpHelper.GetHtml(m_httpItem);
            m_httpItem.Cookie = null;

            m_bIsLogin = false;
        }

        public override AreaBack GetArea()
        {
            m_areaBack = null;
            try
            {
                m_httpItem.URL = AREA_LIST_URL;
                m_httpItem.ResultType = ResultType.String;
                m_httpItem.Method = "GET";
                m_httpItem.ContentType = "text/html";
                m_areaBack = JsonConvert.DeserializeObject<AreaBack>(m_httpHelper.GetHtml(m_httpItem).Html);
            }
            catch (Exception err)
            {
                m_lastError = "获取地区信息失败：" + err.Message;
                Logger.WriteError("获取地区信息失败:", err);
            }
            return m_areaBack;
        }

        public override HospitalBack GetHospital()
        {
            m_hosBack = null;
            try
            {
                if (m_areaBack != null && m_areaBack.data != null)
                {
                    m_httpItem.URL = HOS_LIST_URL + m_areaBack.data.areaList[m_indexArea].areaCode;
                    m_httpItem.ResultType = ResultType.String;
                    m_httpItem.Method = "GET";
                    m_httpItem.ContentType = "text/html";
                    m_httpItem.Postdata = string.Empty;
                    m_hosBack = JsonConvert.DeserializeObject<HospitalBack>(m_httpHelper.GetHtml(m_httpItem).Html);
                }
                else
                {
                    m_lastError = "获取医院信息失败：地区信息为空" ;
                }                
            }
            catch (Exception err)
            {
                m_lastError = "获取医院信息失败：" + err.Message;
                Logger.WriteError("获取医院信息失败", err);
            }
            return m_hosBack;
        }

        public override DepartmentBack GetDepartment()
        {
            m_depBack = null;
            try
            {
                if (m_hosBack != null && m_hosBack.data != null)
                {
                    m_httpItem.URL = DEPT_LIST_URL + m_hosBack.data.hos[m_indexHos].hosCode;
                    m_httpItem.ResultType = ResultType.String;
                    m_httpItem.Method = "GET";
                    m_httpItem.ContentType = "text/html";
                    m_httpItem.Postdata = string.Empty;
                    m_depBack = JsonConvert.DeserializeObject<DepartmentBack>(m_httpHelper.GetHtml(m_httpItem).Html);
                }
                else
                {
                    m_lastError = "获取科室信息失败：医院信息为空";
                }
               
            }
            catch (Exception err)
            {
                m_lastError = "获取科室信息失败：" + err.Message;
                Logger.WriteError("获取科室信息失败", err);
            }
            return m_depBack;
        }

        public override UserInfo GetUserInfo()
        {
            UserInfo userInfo = new UserInfo();
            try
            {
                m_httpItem.URL = INDEX_URL;
                m_httpItem.ResultType = ResultType.String;
                m_httpItem.Method = "GET";
                m_httpItem.Postdata = string.Empty;
                m_httpItem.ContentType = "text/html";
                m_httpItem.Allowautoredirect = true;
                HttpResult html = m_httpHelper.GetHtml(m_httpItem);
                m_htmlDocument.LoadHtml(html.Html);
                HtmlNode htmlNode = m_htmlDocument.DocumentNode.SelectSingleNode(USER_INFO_XPATH);
                if (htmlNode != null)
                {
                    HtmlNodeCollection htmlNodeCollection = htmlNode.SelectNodes("tr");
                    if (htmlNodeCollection.Count == 4)
                    {
                        userInfo.Name = htmlNodeCollection[0].ChildNodes[3].InnerHtml.Trim();
                        userInfo.CardId = htmlNodeCollection[1].ChildNodes[3].InnerHtml.Trim();
                        userInfo.PhoneNumber = htmlNodeCollection[2].ChildNodes[3].InnerHtml.Trim();
                        userInfo.Credibility = htmlNodeCollection[3].ChildNodes[3].InnerHtml.Trim();
                    }
                }
            }
            catch (Exception err)
            {
                m_lastError = "用户信息获取失败：" + err.Message;
                Logger.WriteError("用户信息获取失败", err);
            }
            return userInfo;
        }

        public override bool GetDepartmenRegisterInfo(ref DepartmentRegisterInfo depRegisterInfo)
        {
            try
            {
                depRegisterInfo.Clear();

                m_httpItem.URL = DEPT_INFO_URL + m_hosBack.data.hos[m_indexHos].hosCode + "/" + m_depBack.data.dept[m_indexDep].deptName;
                m_httpItem.ResultType = ResultType.String;
                m_httpItem.Method = "POST";
                m_httpItem.ContentType = "text/html";
                m_httpItem.Postdata = string.Empty;
                m_htmlDocument.LoadHtml(m_httpHelper.GetHtml(m_httpItem).Html);
                HtmlNode htmlNode = m_htmlDocument.DocumentNode;
                htmlNode = htmlNode.SelectSingleNode(REGISTER_INFO_XPATH);
                if (htmlNode == null)
                {
                    m_lastError = "科室信息获取失败：可能网路连接失败，或者不存在该科室信息";
                    return false;
                }
                HtmlNodeCollection htmlNodeCollection = htmlNode.SelectNodes("tr");
                if (htmlNodeCollection.Count == 2)
                {
                    m_lastError = "该科室暂无排班";
                    return false;
                }
                StringBuilder stringBuilder = new StringBuilder();
                foreach (HtmlNode current in htmlNodeCollection)
                {
                    string attributeValue = current.GetAttributeValue("class", "");
                    if (attributeValue == string.Empty)
                    {
                        HtmlNodeCollection htmlNodeCollection2 = current.SelectNodes("td");
                        if (htmlNodeCollection2.Count == 17)
                        {
                            int num = 0;
                            foreach (HtmlNode current2 in ((IEnumerable<HtmlNode>)htmlNodeCollection2))
                            {
                                if (current2.SelectSingleNode("form") != null)
                                {
                                    HtmlNode htmlNode2 = current2.SelectSingleNode("input[@type='submit']");
                                    if (htmlNode2 != null && num > 0)
                                    {
                                        //正常预约信息
                                        m_doctorRegInfo.RegistionTypes[num - 1] = RegistionType.Normal;

                                        m_doctorRegInfo.RemainNums[num - 1] = htmlNode2.GetAttributeValue("value", "").Replace("&#13;&#10;", "\r\n");
                                        m_doctorRegInfo.ToolTipTexts[num - 1] = htmlNode2.GetAttributeValue("title", "");
                                        HtmlNodeCollection htmlNodeCollection3 = current2.SelectNodes("input");
                                        if (htmlNodeCollection3.Count == 14)
                                        {
                                            stringBuilder.Length = 0;
                                            stringBuilder.Append("http://www.zj12580.cn/order/num?");
                                            for (int i = 0; i < 13; i++)
                                            {
                                                stringBuilder.Append(htmlNodeCollection3[i].GetAttributeValue("name", ""));
                                                stringBuilder.Append("=");
                                                stringBuilder.Append(htmlNodeCollection3[i].GetAttributeValue("value", ""));
                                                if (i < 12)
                                                {
                                                    stringBuilder.Append("&");
                                                }
                                            }
                                        }
                                        this.m_doctorRegInfo.OrderUrls[num - 1] = stringBuilder.ToString();
                                    }
                                    else
                                    {
                                        htmlNode2 = current2.SelectSingleNode("span");
                                        if (htmlNode2 != null)
                                        {
                                            string text = htmlNode2.InnerHtml.Trim();
                                            if (text == "已满")
                                            {
                                                m_doctorRegInfo.RegistionTypes[num - 1] = RegistionType.Full;
                                                m_doctorRegInfo.RemainNums[num - 1] =  text;
                                                m_doctorRegInfo.ToolTipTexts[num - 1] = text;
                                            }
                                            else if (text == "停诊")
                                            {
                                                m_doctorRegInfo.RegistionTypes[num - 1] = RegistionType.StopAdmission;
                                                m_doctorRegInfo.RemainNums[num - 1] = text;
                                                m_doctorRegInfo.ToolTipTexts[num - 1] = text;
                                            }
                                            else if (text == "预约")
                                            {
                                                m_doctorRegInfo.RemainNums[num - 1] = text;
                                                if (num >= 15)
                                                {
                                                    m_doctorRegInfo.RegistionTypes[num - 1] = RegistionType.NoAllocation;
                                                    m_doctorRegInfo.ToolTipTexts[num - 1] = "暂未放号";
                                                }
                                                else
                                                {
                                                    m_doctorRegInfo.RegistionTypes[num - 1] = RegistionType.Timeout;
                                                    m_doctorRegInfo.ToolTipTexts[num - 1] = "已过预约";
                                                }
                                            }
                                            else
                                            {
                                                m_doctorRegInfo.RegistionTypes[num - 1] = RegistionType.Empty;
                                                m_doctorRegInfo.RemainNums[num - 1] = text;
                                                m_doctorRegInfo.ToolTipTexts[num - 1] = text;
                                            }
                                            m_doctorRegInfo.OrderUrls[num - 1] = null;
                                        }
                                    }
                                }
                                else if (num == 0)
                                {
                                    if (current2.SelectSingleNode("p/a") == null)
                                    {
                                        m_doctorRegInfo.Name = current2.InnerHtml.Trim();
                                    }
                                    else
                                    {
                                        m_doctorRegInfo.Name = current2.SelectSingleNode("p/a").InnerHtml + "\n" + current2.SelectNodes("p")[1].InnerHtml;
                                    }
                                }
                                else
                                {
                                    m_doctorRegInfo.ToolTipTexts[num - 1] = null;
                                    m_doctorRegInfo.OrderUrls[num - 1] = null;
                                    m_doctorRegInfo.RemainNums[num - 1] = null;
                                    m_doctorRegInfo.RegistionTypes[num - 1] = RegistionType.Other;
                                }
                                num++;
                            }
                        }
                        //深度复制预约信息
                        depRegisterInfo.AddDoctorRegInfo(m_doctorRegInfo);
                    }
                    else if (attributeValue == "tr_t")
                    {
                        HtmlNodeCollection htmlNodeCollection4 = current.SelectNodes("td");
                        if (htmlNodeCollection4.Count >= 9)
                        {
                            for (int j = 1; j < 9; j++)
                            {
                                depRegisterInfo.RegisterDates[j - 1] = htmlNodeCollection4[j].InnerHtml.Replace("<br>", "\n");
                            }
                        }
                    }
                }
            }
            catch (Exception err)
            {             
                m_lastError = "科室信息获取失败：" + err.Message;
                Logger.WriteError("科室信息获取失败", err);
                return false;
            }
            return true;
        }

        public override bool GetOrderManager(string requestData, ref OrderManager orderManger)
        {
            try
            {
                if (orderManger == null)
                {
                    m_lastError = "获得预约订单管理信息失败：预约订单管理对象为null";
                    Logger.WriteError(m_lastError);
                    return false;
                }

                m_httpItem.URL = requestData;
                m_httpItem.ResultType = ResultType.String;
                m_httpItem.Method = "GET";
                m_httpItem.Postdata = string.Empty;
                m_httpItem.ContentType = "text/html";
                m_httpItem.Allowautoredirect = false;
                HttpResult html = m_httpHelper.GetHtml(m_httpItem);
                if (html.RedirectUrl.Length == 0)
                {
                    m_htmlDocument.LoadHtml(html.Html);
                    HtmlNode htmlNode = m_htmlDocument.DocumentNode.SelectSingleNode(ORDER_INFO_XPATH);
                    if (htmlNode != null)
                    {
                        HtmlNodeCollection htmlNodeCollection = htmlNode.SelectNodes("div[@class='m_l']/div[@class='m_l_1']/div[@class='con_r']/p");
                        if (htmlNodeCollection != null && htmlNodeCollection.Count == 3)
                        {
                            orderManger.Doctor.Name = htmlNodeCollection[0].InnerHtml.Trim();
                            orderManger.Doctor.HospitalName = htmlNodeCollection[2].InnerHtml.Trim();
                        }
                        HtmlNode htmlNode2 = htmlNode.SelectSingleNode("input[@name='hosId']");
                        if (htmlNode2 != null)
                        {
                            orderManger.Doctor.HospitalId = htmlNode2.GetAttributeValue("value", "");
                        }
                        HtmlNodeCollection htmlNodeCollection2 = htmlNode.SelectNodes("input");
                        if (htmlNodeCollection2 != null && htmlNodeCollection2.Count == 14)
                        {
                            StringBuilder stringBuilder = new StringBuilder();
                            stringBuilder.Append("numId={0}&resTime={1}&resNumber={2}&");
                            for (int i = 3; i < 14; i++)
                            {
                                stringBuilder.Append(htmlNodeCollection2[i].GetAttributeValue("name", ""));
                                stringBuilder.Append("=");
                                stringBuilder.Append(htmlNodeCollection2[i].GetAttributeValue("value", ""));
                                stringBuilder.Append("&");
                            }
                            stringBuilder.Append("num={3}");
                            orderManger.CheckOrderPostUrlFormat = stringBuilder.ToString();
                        }
                        HtmlNodeCollection htmlNodeCollection3 = htmlNode.SelectNodes("div[@class='m_l']/div[@class='m_l_2']/p/span");
                        if (htmlNodeCollection3 != null && htmlNodeCollection3.Count == 3)
                        {
                            orderManger.RegisterFee = htmlNodeCollection3[0].InnerHtml.Trim();
                            orderManger.Doctor.Department = htmlNodeCollection3[1].InnerHtml.Trim();
                            orderManger.RegisterDate = htmlNodeCollection3[2].InnerHtml.Trim().Replace("&nbsp;", " ");
                        }
                        HtmlNodeCollection htmlNodeCollection4 = htmlNode.SelectNodes("div[@class='m_r']/div[@class='m_r_1']/table/tr/td/input");
                        if (htmlNodeCollection4 == null)
                        {
                            m_lastError = "获得预约订单管理信息失败：预约订单信息解析失败";
                            Logger.WriteError(m_lastError);
                            return false;
                        }
                        using (IEnumerator<HtmlNode> enumerator = ((IEnumerable<HtmlNode>)htmlNodeCollection4).GetEnumerator())
                        {
                            while (enumerator.MoveNext())
                            {
                                HtmlNode current = enumerator.Current;
                                string[] array = current.GetAttributeValue("value", "").Split(new char[]
                                {
                                    ','
                                });
                                if (array != null && array.Length == 3)
                                {
                                    OrderInfo orderInfo = new OrderInfo();
                                    orderInfo.OrderNum = array[2];
                                    orderInfo.OrderId = array[0];
                                    orderInfo.OrderTime = array[1];
                                    orderManger.OrderInfos.Add(orderInfo);
                                }
                            }
                        }
                    }
                }
                else
                {
                    m_lastError = "获得预约订单管理信息失败：用户未登录";
                    Logger.WriteError(m_lastError);
                    return false;
                }
            }
            catch (Exception err)
            {
                m_lastError = "获得预约订单管理信息失败：" + err.Message;
                Logger.WriteError("获得预约订单管理信息失败", err);
                return false;
            }
            return true;
        }

        public override bool CheckOrderInfo(string postData)
        {
            try
            {
                m_httpItem.URL = ORDER_CHECK_URL;
                m_httpItem.ResultType = ResultType.String;
                m_httpItem.Method = "POST";
                m_httpItem.Allowautoredirect = false;
                m_httpItem.PostEncoding = Encoding.UTF8;
                m_httpItem.Postdata = postData;            
                m_httpItem.ContentType = "application/x-www-form-urlencoded";
                HttpResult html = m_httpHelper.GetHtml(m_httpItem);
                if (html.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    m_htmlDocument.LoadHtml(html.Html);
                    HtmlNode htmlNode = m_htmlDocument.DocumentNode.SelectSingleNode(ORDER_INFO_XPATH);
                    if (htmlNode != null)
                    {
                        HtmlNodeCollection htmlNodeCollection = htmlNode.SelectNodes("div[@class='m_r']/input");
                        if (htmlNodeCollection != null && htmlNodeCollection.Count == 15)
                        {
                            StringBuilder stringBuilder = new StringBuilder();
                            for (int i = 0; i < 15; i++)
                            {
                                stringBuilder.Append(htmlNodeCollection[i].GetAttributeValue("name", ""));
                                stringBuilder.Append("=");
                                stringBuilder.Append(htmlNodeCollection[i].GetAttributeValue("value", ""));
                                stringBuilder.Append("&");
                            }
                            m_postRegisterOrderData = stringBuilder.ToString();
                        }
                    }
                }
            }
            catch (Exception err)
            {
                m_lastError = "预约订单选择失败：" + err.Message;
                Logger.WriteError("预约订单选择失败", err);
            }
            return true;
        }

        public override Image GetOrderCode(string requestData)
        {
            Image result = null;
            try
            {
                System.Globalization.CultureInfo provider = new System.Globalization.CultureInfo("en-US");
                m_httpItem.URL = ORDER_URL + requestData;
                m_httpItem.ResultType = ResultType.Byte;
                m_httpItem.Method = "GET";
                m_httpItem.ContentType = "text/html";
                HttpResult html = m_httpHelper.GetHtml(m_httpItem);
                if (html.Cookie != null)
                {
                    m_httpItem.Cookie = html.Cookie;
                }
                result = Common.ConvertbyteArrayToImage(html.ResultByte);
            }
            catch (Exception err)
            {
                m_lastError = "验证码获取失败：" + err.Message;
                Logger.WriteError("验证码获取失败", err);
                result = null;
            }
            return result;
        }

        public override bool CheckOrderCode(string requestData)
        {
            bool result = false;
            try
            {
                System.Globalization.CultureInfo provider = new System.Globalization.CultureInfo("en-US");
                m_httpItem.URL = CHECK_CAP_CODE_URL + requestData;
                m_httpItem.ResultType = ResultType.String;
                m_httpItem.Method = "GET";
                m_httpItem.ContentType = "text/html";
                HttpResult html = m_httpHelper.GetHtml(m_httpItem);
                if(html.Html == "success")
                {
                    result = true;
                }
                else
                {
                    m_lastError = "验证码验证失败：服务端返回结果为" + html.Html;
                }              
            }
            catch (Exception err)
            {
                m_lastError = "验证码验证失败：" + err.Message;
                Logger.WriteError("验证码验证失败", err);
            }
            return result;
        }

        public override bool SaveOrderInfo(string authCode, ref  RegisterSuccessInfo successInfo)
        {          
            try
            {
                m_httpItem.URL = ORDER_SAVE_URL;
                m_httpItem.ResultType = ResultType.String;
                m_httpItem.Method = "POST";
                m_httpItem.Allowautoredirect = false;
                m_httpItem.Postdata = m_postRegisterOrderData + "code=" + authCode;
                m_httpItem.PostEncoding = Encoding.UTF8;
                m_httpItem.Encoding = Encoding.UTF8;
                m_httpItem.ContentType = "application/x-www-form-urlencoded";
                HttpResult html = m_httpHelper.GetHtml(m_httpItem);
                if (html.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    m_htmlDocument.LoadHtml(html.Html);
                    HtmlNode htmlNode = m_htmlDocument.DocumentNode.SelectSingleNode(ORDER_SUCCESS_XPATH);
                    if (htmlNode != null)
                    {
                        HtmlNodeCollection htmlNodeCollection = htmlNode.SelectNodes("p/span");
                        successInfo.Passwd = htmlNodeCollection[0].InnerHtml;
                        successInfo.Phone = htmlNodeCollection[1].InnerHtml;
                        successInfo.DiagnoseTime = htmlNodeCollection[3].InnerHtml;
                        successInfo.DiagnoseNum = htmlNodeCollection[5].InnerHtml;
                    }
                    else
                    {
                        m_lastError = "预约订单提交失败：未找到预约成功信息";
                        Logger.WriteError(m_lastError);
                        return false;
                    }
                }
                else
                {
                    m_lastError = string.Format("验证码提交失败：返回状态码 {0}", html.StatusCode);
                    Logger.WriteError(m_lastError);
                    return false;
                }
            }
            catch (Exception err)
            {
                m_lastError = "预约订单提交失败：" + err.Message;
                Logger.WriteError("预约订单提交失败", err);
                return false;
            }
            return true;
        }


        #region 私有方法
        //private string GetLoginRandom()
        //{
        //    m_httpItem.URL = LOGIN_URL;
        //    m_httpItem.ResultType = ResultType.String;
        //    m_httpItem.Method = "GET";
        //    m_httpItem.Postdata = string.Empty;
        //    m_httpItem.ContentType = "text/html";
        //    HttpResult html = m_httpHelper.GetHtml(m_httpItem);
        //    m_htmlDocument.LoadHtml(html.Html);
        //    HtmlNode htmlNode = m_htmlDocument.DocumentNode.SelectSingleNode(LOGIN_RANDOM_XPATH);
        //    if (htmlNode != null)
        //    {
        //        return htmlNode.Attributes[0].Value;
        //    }
        //    else
        //    {
        //        m_lastError = "网络连接异常，请尝试重新登录！";
        //        return string.Empty;
        //    }
        //}
       
        #endregion
    }
}
