
namespace HospitalRegisterSoftware.Register.Model
{
    public class UserInfo
    {
        /// <summary>
        /// 用户真实名称
        /// </summary>
        public string Name = string.Empty;
        /// <summary>
        /// 用户识别码，一般为身份证
        /// </summary>
        public string CardId = string.Empty;
        /// <summary>
        /// 电话号码
        /// </summary>
        public string PhoneNumber = string.Empty;
        /// <summary>
        /// 信誉度
        /// </summary>
        public string Credibility = string.Empty;

    }
}
