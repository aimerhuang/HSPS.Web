using HSPS.Web.Common.AppConfig;
using HSPS.Web.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using HSPS.Web.AuthHelper;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace HSPS.Web.Extensions;

/// <summary>
/// 系统授权服务配置
/// </summary>
public static class AuthorizationSetup
{
    public static void AddAuthorizationSetup(this IServiceCollection services)
    {
        //读取配置文件
        var symmetricKeyAsBase64 = AppSecretConfig.Audience_Secret_String;
        var keyByteArray = Encoding.ASCII.GetBytes(symmetricKeyAsBase64);
        var signingKey = new SymmetricSecurityKey(keyByteArray);
        var Issuer = AppSettings.app(new string[] { "Audience", "Issuer" });
        var Audience = AppSettings.app(new string[] { "Audience", "Audience" });

        var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

        var permission = new List<PermissionItem>();

        // 角色与接口的权限要求参数
        var permissionRequirement = new PermissionRequirement(
            "/api/denied",// 拒绝授权的跳转地址（目前无用）
            permission,
            ClaimTypes.Role,//基于角色的授权
            Issuer,//发行人
            Audience,//听众
            signingCredentials,//签名凭据
            expiration: TimeSpan.FromSeconds(60 * 60)//接口的过期时间
            );
        //自定义策略授权
        services.AddAuthorization(options =>
        {
            options.AddPolicy(Permissions.Name,
                     policy => policy.Requirements.Add(permissionRequirement));
        });
        // 注入自定义权限处理器
        services.AddScoped<IAuthorizationHandler, PermissionHandler>();
        services.AddSingleton(permissionRequirement);
    }
}
