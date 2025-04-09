using Entities;
using HSPS.Web.Common.HttpContextUser;
using HSPS.Web.IServices;
using HSPS.Web.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;

namespace HSPS.Web.AuthHelper;

public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
{
    /// <summary>
    /// 验证方案提供对象
    /// </summary>
    public IAuthenticationSchemeProvider Schemes { get; set; }

    private readonly IHttpContextAccessor _accessor;
    private readonly IUserServices _userServices;
    private readonly IUser _user;

    /// <summary>
    /// 构造函数注入
    /// </summary>
    /// <param name="schemes"></param>
    /// <param name="roleModulePermissionServices"></param>
    /// <param name="accessor"></param>
    /// <param name="userServices"></param>
    /// <param name="user"></param>
    public PermissionHandler(IAuthenticationSchemeProvider schemes,
        IUserServices userServices, IHttpContextAccessor accessor,
        IUser user)
    {
        _accessor = accessor;
        _userServices = userServices;
        _user = user;
        Schemes = schemes;
    }

    /// <summary>
    /// 重写异步处理程序
    /// </summary>
    /// <param name="context"></param>
    /// <param name="requirement"></param>
    /// <returns></returns>
    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context,
            PermissionRequirement requirement)
    {
        var httpContext = _accessor.HttpContext;
        // 获取系统中所有的角色和菜单的关系集合
        //if (!requirement.Permissions.Any())
        //{
        //    var data = await _roleModulePermissionServices.RoleModuleMaps();
        //    var list = new List<PermissionItem>();
        //    // ids4和jwt切换

        //    list = (from item in data
        //            where item.IsDeleted == false
        //            orderby item.Id
        //            select new PermissionItem
        //            {
        //                Url = item.Module?.LinkUrl,
        //                Role = item.Role?.Name.ObjToString(),
        //            }).ToList();


        //    requirement.Permissions = list;
        //}

        if (httpContext != null)
        {
            var questUrl = httpContext.Request.Path.Value.ToLower();

            // 整体结构类似认证中间件UseAuthentication的逻辑，具体查看开源地址
            // https://github.com/dotnet/aspnetcore/blob/master/src/Security/Authentication/Core/src/AuthenticationMiddleware.cs
            httpContext.Features.Set<IAuthenticationFeature>(new AuthenticationFeature
            {
                OriginalPath = httpContext.Request.Path,
                OriginalPathBase = httpContext.Request.PathBase
            });

            // Give any IAuthenticationRequestHandler schemes a chance to handle the request
            // 主要作用是: 判断当前是否需要进行远程验证，如果是就进行远程验证
            var handlers = httpContext.RequestServices.GetRequiredService<IAuthenticationHandlerProvider>();
            foreach (var scheme in await Schemes.GetRequestHandlerSchemesAsync())
            {
                if (await handlers.GetHandlerAsync(httpContext, scheme.Name) is IAuthenticationRequestHandler
                        handler && await handler.HandleRequestAsync())
                {
                    context.Fail();
                    return;
                }
            }

            //判断请求是否拥有凭据，即有没有登录
            var defaultAuthenticate = await Schemes.GetDefaultAuthenticateSchemeAsync();
            if (defaultAuthenticate != null)
            {
                var result = await httpContext.AuthenticateAsync(defaultAuthenticate.Name);

                //result?.Principal不为空即登录成功
                if (result?.Principal != null)//|| httpContext.IsSuccessSwagger()
                {
                    //应该要先校验用户的信息 再校验菜单权限相关的
                    // JWT模式下校验当前用户状态
                    // IDS4也可以校验，可以通过服务或者接口形式
                    User user = new();

                    //校验用户
                    user = await _userServices.QueryById(_user.ID, true);
                    if (user == null)
                    {
                        _user.MessageModel = new ApiResponse(StatusCode.CODE401, "用户不存在或已被删除").MessageModel;
                        context.Fail(new AuthorizationFailureReason(this, _user.MessageModel.msg));
                        return;
                    }

                    //if (user.IsDeleted)
                    //{
                    //    _user.MessageModel = new ApiResponse(StatusCode.CODE401, "用户已被删除,禁止登录!").MessageModel;
                    //    context.Fail(new AuthorizationFailureReason(this, _user.MessageModel.msg));
                    //    return;
                    //}

                    if (user.Enabled != 1)
                    {
                        _user.MessageModel = new ApiResponse(StatusCode.CODE401, "用户已被禁用!禁止登录!").MessageModel;
                        context.Fail(new AuthorizationFailureReason(this, _user.MessageModel.msg));
                        return;
                    }


                    // 判断token是否过期，过期则重新登录
                    var isExp = false;

                    isExp =
                        (httpContext.User.Claims.FirstOrDefault(s => s.Type == ClaimTypes.Expiration)
                            ?.Value) != null &&
                        DateTime.Parse(httpContext.User.Claims
                            .FirstOrDefault(s => s.Type == ClaimTypes.Expiration)?.Value) >= DateTime.Now;


                    if (!isExp)
                    {
                        context.Fail(new AuthorizationFailureReason(this, "授权已过期,请重新授权"));
                        return;
                    }

                    // 获取当前用户的角色信息
                    var currentUserRoles = new List<string>();
                    currentUserRoles = (from item in httpContext.User.Claims
                                        where item.Type == ClaimTypes.Role
                                        select item.Value).ToList();
                    if (!currentUserRoles.Any())
                    {
                        currentUserRoles = (from item in httpContext.User.Claims
                                            where item.Type == "role"
                                            select item.Value).ToList();
                    }

                    //超级管理员 默认拥有所有权限
                    //if (currentUserRoles.All(s => s != "Admin"))
                    //{
                    //    var isMatchRole = false;
                    //    var permisssionRoles =
                    //        requirement.Permissions.Where(w => currentUserRoles.Contains(w.Role));
                    //    foreach (var item in permisssionRoles)
                    //    {
                    //        try
                    //        {
                    //            if (Regex.Match(questUrl, item.Url?.ObjToString().ToLower())?.Value == questUrl)
                    //            {
                    //                isMatchRole = true;
                    //                break;
                    //            }
                    //        }
                    //        catch (Exception)
                    //        {
                    //            // ignored
                    //        }
                    //    }

                    //    //验证权限
                    //    if (currentUserRoles.Count <= 0 || !isMatchRole)
                    //    {
                    //        context.Fail();
                    //        return;
                    //    }
                    //}


                    context.Succeed(requirement);
                    return;
                }
            }

            //判断没有登录时，是否访问登录的url,并且是Post请求，并且是form表单提交类型，否则为失败
            if (!(questUrl.Equals(requirement.LoginPath.ToLower(), StringComparison.Ordinal) &&
                  (!httpContext.Request.Method.Equals("POST") || !httpContext.Request.HasFormContentType)))
            {
                context.Fail();
                return;
            }
        }



    }



}
