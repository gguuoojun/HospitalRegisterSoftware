using HospitalRegisterSoftware.OrmLite.Model;
using HospitalRegisterSoftware.OrmLite.Context;
using System.Collections.Generic;
using PWMIS.DataMap.Entity;

/// <summary>
/// 逻辑层 PlatformBllBase 不建议在这里修改代码
///	作者：郭军
///	版本：1.0
///	Created on 2016/8/15 19:45:45
/// </summary>
namespace HospitalRegisterSoftware.OrmLite.BLL.Base
{
	public class PlatformBllBase
	{
		protected LocalDbHelper<Platform> m_dbHelper;

		public PlatformBllBase()
		{
			m_dbHelper = LocalDbHelper<Platform>.Instance;
		}

		public int Add(Platform data)
		{
			return m_dbHelper.Add(data);
		}

		public int Add(IEnumerable<Platform> data)
		{
			return m_dbHelper.Add(data);
		}

		public int Update(Platform data)
		{
			return m_dbHelper.Update(data);
		}

		public int Delete(Platform data)
		{
			return m_dbHelper.Delete(data);
		}

		public Platform GetModel(Platform data, OQLCompareFunc cmpFun)
		{
			return m_dbHelper.GetModel(data, cmpFun);
		}

		public List<Platform> GetModelList(Platform data, OQLCompareFunc cmpFun)
		{
			return m_dbHelper.GetModelList(data, cmpFun);
		}
	}
}
