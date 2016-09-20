using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using HospitalRegisterSoftware.OrmLite.BLL;
using HospitalRegisterSoftware.OrmLite.Model;

namespace HospitalRegisterSoftware.Plugins
{
    class PluginManager
    {
        private string m_dirPlugin = Path.Combine(Environment.CurrentDirectory, "Plugin");

        private PlatformBll m_bllPlatform = PlatformBll.Instance;

        /// <summary>
        /// 已加载的程序集
        /// </summary>
        private Dictionary<string, Assembly> m_dicAssembly = new Dictionary<string, Assembly>();

        public void LoadPlugins()
        {
            Platform platform = new Platform();
            //获得插件目录下所有动态链接库
            FileInfo[] fileInfos = new DirectoryInfo(m_dirPlugin).GetFiles("*.dll", SearchOption.TopDirectoryOnly);
            //查找到表中所有插件信息
            List<Platform> listPlatform = m_bllPlatform.GetModelList(platform, null);
            foreach (FileInfo fileInfo in fileInfos)
            {
                if(listPlatform.Exists((Platform p) =>
                {
                    return p.AssemblyName == fileInfo.Name;
                }))
                {
                    //如果程序集已经在数据库中则不加载
                    break;
                }

                LoadAssembly(fileInfo.Name);
            }
        }

        /// <summary>
        /// 载入程序集
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <returns></returns>
        private Assembly LoadAssembly(string assemblyName)
        {
            string assemblyPath = Path.Combine(m_dirPlugin, assemblyName);
            //加载程序集
            Assembly assembly = Assembly.LoadFile(assemblyPath);           

            PluginInfoAttribute attribute = new PluginInfoAttribute();
            Type[] types = assembly.GetTypes();
            foreach (var itemType in types)
            {
                object[] attbs = itemType.GetCustomAttributes(attribute.GetType(), false);
                if (attbs.Length == 1 && attbs[0] is PluginInfoAttribute)
                {
                    //字典中加入符合要求的插件
                    m_dicAssembly[assemblyName] = assembly;

                    Platform plugin = new Platform();
                    //查找到表中所有插件信息
                    List<Platform> listPlatform = m_bllPlatform.GetModelList(plugin, null);

                    attribute = attbs[0] as PluginInfoAttribute;

                    Platform find = listPlatform.Find((Platform p) =>
                    {
                        return p.AssemblyName == assemblyName;
                    });

                    if (find != null)
                    {
                        plugin = find;
                    }

                    plugin.PlatformName = attribute.PlatformName;
                    plugin.PlatformUrl = attribute.PatformUrl;
                    plugin.RegisterUrl = attribute.RegisterUrl;
                    plugin.Version = assembly.GetName().Version.ToString();
                    plugin.Author = attribute.Author;
                    plugin.AssemblyName = assemblyName;

                    if (find == null)
                    {
                        //如果数据存在程序集，则添加，提前开始时间默认为0
                        plugin.AheadTime = 0;
                        m_bllPlatform.Add(plugin);
                    }
                    else
                    {
                        //如果数据存在程序集，则更新
                        m_bllPlatform.Update(plugin);
                    }
                   
                    break;
                }
            }
            return assembly;
        }

        
        /// <summary>
        /// 返回指定的程序集
        /// </summary>
        /// <param name="assemblyName">程序集名称</param>
        /// <returns></returns>
        public Assembly GetAssembly(string assemblyName)
        {
            if (m_dicAssembly.ContainsKey(assemblyName))
            {
                return m_dicAssembly[assemblyName];
            }
            else
            {
                return LoadAssembly(assemblyName);
            }
        }
    }
}
