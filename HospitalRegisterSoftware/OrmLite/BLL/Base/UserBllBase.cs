using HospitalRegisterSoftware.OrmLite.Model;
using HospitalRegisterSoftware.OrmLite.Context;
using System.Collections.Generic;
using PWMIS.DataMap.Entity;

/// <summary>
/// 逻辑层 UserBllBase 不建议在这里修改代码
///	作者：郭军
///	版本：1.0
///	Created on 2016/8/15 19:45:45
/// </summary>
namespace HospitalRegisterSoftware.OrmLite.BLL.Base
{
	public class UserBllBase
	{
		protected LocalDbHelper<User> m_dbHelper;

		public UserBllBase()
		{
			m_dbHelper = LocalDbHelper<User>.Instance;
		}

		public int Add(User data)
		{
			return m_dbHelper.Add(data);
		}

		public int Add(IEnumerable<User> data)
		{
			return m_dbHelper.Add(data);
		}

		public int Update(User data)
		{
			return m_dbHelper.Update(data);
		}

		public int Delete(User data)
		{
			return m_dbHelper.Delete(data);
		}

		public User GetModel(User data, OQLCompareFunc cmpFun)
		{
			return m_dbHelper.GetModel(data, cmpFun);
		}

		public List<User> GetModelList(User data, OQLCompareFunc cmpFun)
		{
			return m_dbHelper.GetModelList(data, cmpFun);
		}
	}
}
