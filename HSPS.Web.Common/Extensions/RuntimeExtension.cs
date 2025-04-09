using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;
using System.Threading.Tasks;

namespace HSPS.Web.Common.Extensions;

public static class RuntimeExtension
{
    private static readonly List<string> ProjectAssemblies =
    [
        "HSPS.Web"
    ];

    /// <summary>
    /// 获取项目程序集，排除所有的系统程序集(Microsoft.***、System.***等)、Nuget下载包
    /// </summary>
    /// <returns></returns>
    public static IList<Assembly> GetAllAssemblies()
    {
        var assemblies = new List<Assembly>();
        var dllFiles = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll");

        foreach (var dllFile in dllFiles)
        {
            var fileName = Path.GetFileNameWithoutExtension(dllFile);
            if (!ProjectAssemblies.Any(s => fileName.StartsWith(s))) continue;
            try
            {
                var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(dllFile);
                assemblies.Add(assembly);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to load assembly: {fileName}. Error: {e.Message}");
            }
        }

        return assemblies;
    }



}
