using System.Collections.Generic;
using PWMIS.DataMap.Entity;
using PWMIS.Core.Extensions;

namespace HospitalRegisterSoftware.OrmLite.Context
{
    public class LocalDbHelper<T> where T : EntityBase, new()
    {
        protected  LocalDbContext localDbContext = null;

        private static object lockObject = new object();

        private static LocalDbHelper<T> _intance;
        public static LocalDbHelper<T> Instance
        {
            get
            {
                if (_intance == null)
                {
                    lock (lockObject)
                    {
                        if (_intance == null)
                        {
                            _intance = new LocalDbHelper<T>();
                        }
                    }
                }

                return _intance;
            }
        }

        private LocalDbHelper()
        {
            localDbContext = new LocalDbContext();
        }

        public int Add(T data) 
        {
            return localDbContext.Add<T>(data);
        }

        public int Add(IEnumerable<T> list)
        {
            return localDbContext.AddList<T>(list);
        }

        public int Update(T data)
        {
            return localDbContext.Update<T>(data);
        }

        public int Delete(T data)
        {
            return localDbContext.Remove<T>(data);
        }

         /// <summary>
        /// 查询所有字段匹配的实体类，传入的实体类需要保证要查询的字段有值
        /// </summary>
        /// <param name="data">传入的实体类，查询字段需要有值</param>
        /// <param name="cmpFun">查询比较方法,传入null表示搜索表中所有数据</param>
        /// <returns></returns>
        public List<T> GetModelList(T data, OQLCompareFunc cmpFun)
        {
            if (cmpFun == null)
            {
                return OQL.From(data).Select().END.ToList<T>();
            }

            return OQL.From(data).Select().Where(cmpFun).END.ToList<T>();
        }

        /// <summary>
        /// 查询字段匹配的实体类，传入的实体类需要保证查询的字段有值
        /// </summary>
        /// <param name="data">传入的实体类，查询字段需要有值</param>
        /// <param name="cmpFun">查询比较方法</param>
        /// <returns></returns>
        public T GetModel(T data, OQLCompareFunc cmpFun)
        {
            if (cmpFun == null)
            {
                return null;
            }

            return OQL.From(data).Select().Where(cmpFun).END.ToEntity<T>();
        }
    }
}
