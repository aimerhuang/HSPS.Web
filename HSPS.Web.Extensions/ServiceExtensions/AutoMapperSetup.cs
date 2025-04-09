using HSPS.Web.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace HSPS.Web.Extensions.ServiceExtensions;

/// <summary>
/// Automapper 启动服务
/// </summary>
public static class AutoMapperSetup
{
    public static void AddAutoMapperSetup(this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        services.AddAutoMapper(typeof(AutoMapperConfig));
        AutoMapperConfig.RegisterMappings();
    }
}
