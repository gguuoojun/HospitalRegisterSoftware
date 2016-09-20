using HospitalRegisterSoftware.OrmLite.Model;
using HospitalRegisterSoftware.OrmLite.Context;
using HospitalRegisterSoftware.OrmLite.BLL.Base;
using System.Collections.Generic;
using PWMIS.DataMap.Entity;
using PWMIS.Core.Extensions;

/// <summary>
/// 逻辑层 PluginBll
///	作者：郭军
///	版本：1.0
///	Created on 2016/7/29 13:10:55
/// </summary>
namespace HospitalRegisterSoftware.OrmLite.BLL
{
	public class PlatformBll : PlatformBllBase
    {
		private static PlatformBll instance = null;

		private PlatformBll()
		{

		}

		public static PlatformBll Instance
		{
			get
			{
				if(instance == null)
				{
					instance = new PlatformBll();
				}
				return instance;
			}
		}
	}
}
