using System.Collections.Generic;

//********************************************************************
//* 按照zj12580返回的JSON结构处理，如果要接入其他网站的信息，格式需要
//* 按照以下实体类进行处理下
//*********************************************************************/

namespace HospitalRegisterSoftware.Register.Model
{
    /// <summary>
    /// 返回的地区信息
    /// </summary>
    public class AreaBack
    {
        /// <summary>
        /// 获取地区结果，success表示成功，其他认为失败
        /// </summary>
        public string result;
        /// <summary>
        /// 地区列表
        /// </summary>
        public AreaList data;
    }

    /// <summary>
    /// 地区信息里列表
    /// </summary>
    public class AreaList
    {
        public List<area> areaList;
    }

    /// <summary>
    /// 一个地区信息
    /// </summary>
    public class area
    {
        /// <summary>
        /// 地区编码
        /// </summary>
        public string areaCode;
        /// <summary>
        /// 地区名称
        /// </summary>
        public string areaName;
    }

    /// <summary>
    /// 返回的医院信息
    /// </summary>
    public class HospitalBack
    {
        public string result;
        public HosList data;
    }

    /// <summary>
    /// 医院列表
    /// </summary>
    public class HosList
    {
        public List<HospitalInfo> hos;
    }

    /// <summary>
    /// 医院信息
    /// </summary>
    public class HospitalInfo
    {
        /// <summary>
        /// 医院编码
        /// </summary>
        public string hosCode;
        /// <summary>
        /// 医院名称（别称）
        /// </summary>
        public string aliasName;
    }

    /// <summary>
    /// 返回的科室信息
    /// </summary>
    public class DepartmentBack
    {
        public string result;
        public DeptList data;
    }

    /// <summary>
    /// 科室列表
    /// </summary>
    public class DeptList
    {
        public List<DeptInfo> dept;
    }

    /// <summary>
    /// 科室信息
    /// </summary>
    public class DeptInfo
    {
        /// <summary>
        /// 科室名称
        /// </summary>
        public string deptName;
    }
}
