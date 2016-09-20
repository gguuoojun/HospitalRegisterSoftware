using System;

namespace HospitalRegisterSoftware.Plugins
{
    public class PluginInfoAttribute : Attribute
    {
        private string _platformName = string.Empty;
        private string _platformUrl = string.Empty;
        private string _registerUrl = string.Empty;
        private string _author = string.Empty;

        public PluginInfoAttribute()
        {
        }

        public PluginInfoAttribute(string platformName, string platformUrl, string registerUrl, string author)
        {
            _platformName = platformName;
            _platformUrl = platformUrl;
            _registerUrl = registerUrl;
            _author = author;
        }

        /// <summary>
        /// 预约平台名称
        /// </summary>
        public string PlatformName
        {
            get
            {
                return _platformName;
            }
        }

        /// <summary>
        /// 预约平台地址
        /// </summary>
        public string PatformUrl
        {
            get
            {
                return _platformUrl;
            }
        }

        /// <summary>
        /// 用户注册地址
        /// </summary>
        public string RegisterUrl
        {
            get
            {
                return _registerUrl;
            }
        }


        /// <summary>
        /// 作者名称
        /// </summary>
        public string Author
        {
            get
            {
                return _author;
            }
        }
    }
}
