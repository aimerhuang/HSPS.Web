using HSPS.Web.Common;
using Microsoft.Extensions.DependencyInjection;

namespace HSPS.Web.Extensions;

/// <summary>
/// Cors 启动服务
/// </summary>
public static class CorsSetup
{
    /// <summary>
    /// Cors 启动服务
    /// </summary>
    /// <param name="services"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public static void AddCorsSetup(this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        services.AddCors(c =>
        {
            if (!AppSettings.app(new string[] { "Startup", "Cors", "EnableAllIPs" }).ObjToBool())
            {
                c.AddPolicy(AppSettings.app(new string[] { "Startup", "Cors", "PolicyName" }),

                    policy =>
                    {

                        policy
                        .WithOrigins(AppSettings.app(new string[] { "Startup", "Cors", "IPs" }).Split(','))
                        .AllowAnyHeader()//Ensures that the policy allows any header.
                        .AllowAnyMethod();
                    });
            }
            else
            {
                //允许任意跨域请求
                c.AddPolicy(AppSettings.app(new string[] { "Startup", "Cors", "PolicyName" }),
                    policy =>
                    {
                        policy
                        .SetIsOriginAllowed((host) => true)
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                    });
            }

        });
    }


}
