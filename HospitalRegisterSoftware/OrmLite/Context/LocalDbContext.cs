using HospitalRegisterSoftware.OrmLite.Model;
using PWMIS.Core.Extensions;

/// <summary>
/// ORM上下文  LocalDbContext
///	作者：郭军
///	版本：1.0
///	Created on 2016/8/15 19:45:45
/// </summary>
namespace HospitalRegisterSoftware.OrmLite.Context
{
	public class LocalDbContext : DbContext
	{

		#region 默认构造函数
		public  LocalDbContext() : base("DbConn")
		{
		}
		#endregion 

		protected override bool CheckAllTableExists()
		{
			CheckTableExists<Platform>();
			CheckTableExists<User>();
			return true;
		}
	}
}
