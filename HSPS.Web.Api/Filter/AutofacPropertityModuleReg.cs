using Autofac;
using Microsoft.AspNetCore.Mvc;

namespace HSPS.Web.Api.Filter;

/// <summary>
/// 服务注册
/// </summary>
public class AutofacPropertityModuleReg : Autofac.Module
{
    /// <summary>
    /// 服务注册
    /// </summary>
    /// <param name="builder"></param>
    protected override void Load(ContainerBuilder builder)
    {
        // 启动服务注册
        var controllerBaseType = typeof(ControllerBase);
        builder.RegisterAssemblyTypes(typeof(Program).Assembly)
            .Where(t => controllerBaseType.IsAssignableFrom(t) && t != controllerBaseType)
            .PropertiesAutowired();

    }
}
