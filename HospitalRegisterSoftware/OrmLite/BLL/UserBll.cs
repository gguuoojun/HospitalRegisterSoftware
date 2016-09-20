using HospitalRegisterSoftware.OrmLite.Model;
using HospitalRegisterSoftware.OrmLite.Context;
using HospitalRegisterSoftware.OrmLite.BLL.Base;
using System.Collections.Generic;
using PWMIS.DataMap.Entity;
using PWMIS.Core.Extensions;

/// <summary>
/// 逻辑层 UserBll
///	作者：郭军
///	版本：1.0
///	Created on 2016/7/29 13:10:56
/// </summary>
namespace HospitalRegisterSoftware.OrmLite.BLL
{
	public class UserBll : UserBllBase
	{
		private static UserBll instance = null;

		private UserBll()
		{

		}

		public static UserBll Instance
		{
			get
			{
				if(instance == null)
				{
					instance = new UserBll();
				}
				return instance;
			}
		}

        public User GetLastLoginUser()
        {
            User user = new User()
            {
                RecentLogin = true
            };

            return OQL.From(user).Select().Where(user.RecentLogin).END.ToEntity<User>(); 
        }

        public User GetUserForName(string userName, int platflormId)
        {
            User user = new User()
            {
                UserName = userName,
                PlatformId = platflormId
            };
            return OQL.From(user).Select().Where(user.UserName, user.PlatformId).END.ToEntity<User>();
        }

        public List<User> GetUserListForPlatformId(int id)
        {
            User user = new User()
            {
                PlatformId = id
            };

            return OQL.From(user).Select().Where(user.PlatformId).END.ToList<User>();
        }
	}
}
