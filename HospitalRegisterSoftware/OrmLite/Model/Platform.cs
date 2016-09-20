using PWMIS.DataMap.Entity;

/// <summary>
/// 实体类 Platform
///	作者：郭军
///	版本：1.0
///	Created on 2016/8/15 19:45:45
/// </summary>
namespace HospitalRegisterSoftware.OrmLite.Model
{
	public class Platform : EntityBase
	{

		#region 默认构造函数
		public Platform()
		{
			TableName = "Platform";
			IdentityName = "Id";
			PrimaryKeys.Add("Id");
		}
		#endregion 

		#region 公有属性

		/// <summary>
		/// ID序号
		/// </summary>
		public int Id
		{
			get { return getProperty<int>("Id"); }
			set { setProperty("Id", value); }
		}

		/// <summary>
		/// 预约平台名称
		/// </summary>
		public string PlatformName
		{
			get { return getProperty<string>("PlatformName"); }
			set { setProperty("PlatformName", value, 200); }
		}

		/// <summary>
		/// 预约平台地址
		/// </summary>
		public string PlatformUrl
		{
			get { return getProperty<string>("PlatformUrl"); }
			set { setProperty("PlatformUrl", value, 255); }
		}

		/// <summary>
		/// 用户注册地址
		/// </summary>
		public string RegisterUrl
		{
			get { return getProperty<string>("RegisterUrl"); }
			set { setProperty("RegisterUrl", value, 200); }
		}

		/// <summary>
		/// 提前开始时间，单位毫秒，用于抢先预约：比如3点开始预约，可设置提前50ms开始刷新，那么就设置为50
		/// </summary>
		public int AheadTime
		{
			get { return getProperty<int>("AheadTime"); }
			set { setProperty("AheadTime", value); }
		}

		/// <summary>
		/// 程序集名称
		/// </summary>
		public string AssemblyName
		{
			get { return getProperty<string>("AssemblyName"); }
			set { setProperty("AssemblyName", value, 200); }
		}

		/// <summary>
		/// 预约平台描述
		/// </summary>
		public string Remark
		{
			get { return getProperty<string>("Remark"); }
			set { setProperty("Remark", value, 255); }
		}

		/// <summary>
		/// 插件作者
		/// </summary>
		public string Author
		{
			get { return getProperty<string>("Author"); }
			set { setProperty("Author", value, 100); }
		}

		/// <summary>
		/// 插件版本
		/// </summary>
		public string Version
		{
			get { return getProperty<string>("Version"); }
			set { setProperty("Version", value, 50); }
		}

		/// <summary>
		/// 是否识别验证码
		/// </summary>
		public bool IsRecognize
		{
			get { return getProperty<bool>("IsRecognize"); }
			set { setProperty("IsRecognize", value); }
		}

		/// <summary>
		/// 识别验证码失败次数，即失败满足次数后不再自动识别
		/// </summary>
		public int RecognizeFailCount
		{
			get { return getProperty<int>("RecognizeFailCount"); }
			set { setProperty("RecognizeFailCount", value); }
		}

		#endregion 
	}
}
