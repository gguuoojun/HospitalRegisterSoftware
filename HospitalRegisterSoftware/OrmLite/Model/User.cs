using PWMIS.DataMap.Entity;

/// <summary>
/// 实体类 User
///	作者：郭军
///	版本：1.0
///	Created on 2016/8/15 19:45:45
/// </summary>
namespace HospitalRegisterSoftware.OrmLite.Model
{
	public class User : EntityBase
	{

		#region 默认构造函数
		public User()
		{
			TableName = "User";
			IdentityName = "Id";
			PrimaryKeys.Add("Id");
		}
		#endregion 

		#region 公有属性

		public int Id
		{
			get { return getProperty<int>("Id"); }
			set { setProperty("Id", value); }
		}

		/// <summary>
		/// 用户名称
		/// </summary>
		public string UserName
		{
			get { return getProperty<string>("UserName"); }
			set { setProperty("UserName", value, 50); }
		}

		/// <summary>
		/// 用户密码
		/// </summary>
		public string UserPwd
		{
			get { return getProperty<string>("UserPwd"); }
			set { setProperty("UserPwd", value, 50); }
		}

		/// <summary>
		/// 平台ID
		/// </summary>
		public int PlatformId
		{
			get { return getProperty<int>("PlatformId"); }
			set { setProperty("PlatformId", value); }
		}

		/// <summary>
		/// 预约总次数
		/// </summary>
		public int? RegisterTotalCount
		{
			get { return getProperty<int?>("RegisterTotalCount"); }
			set { setProperty("RegisterTotalCount", value); }
		}

		/// <summary>
		/// 预约成功次数
		/// </summary>
		public int? RegisterSuccessCount
		{
			get { return getProperty<int?>("RegisterSuccessCount"); }
			set { setProperty("RegisterSuccessCount", value); }
		}

		/// <summary>
		/// 是否最近一次登录
		/// </summary>
		public bool RecentLogin
		{
			get { return getProperty<bool>("RecentLogin"); }
			set { setProperty("RecentLogin", value); }
		}

		/// <summary>
		/// 是否记住密码
		/// </summary>
		public bool RememberPwd
		{
			get { return getProperty<bool>("RememberPwd"); }
			set { setProperty("RememberPwd", value); }
		}

		/// <summary>
		/// 是否自动登录
		/// </summary>
		public bool AutoLogin
		{
			get { return getProperty<bool>("AutoLogin"); }
			set { setProperty("AutoLogin", value); }
		}

		#endregion 
	}
}
