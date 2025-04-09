using AutoMapper;
using HSPS.Web.AuthHelper;
using HSPS.Web.AuthHelper.OverWrite;
using HSPS.Web.Common;
using HSPS.Web.Common.Helper;
using HSPS.Web.Controllers;
using HSPS.Web.Extensions;
using HSPS.Web.IServices;
using HSPS.Web.Model;
using HSPS.Web.Model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace HSPS.Web.Api.Controllers;

/// <summary>
/// 登录管理
/// </summary>
[Produces("application/json")]
[Route("api/Login")]
[AllowAnonymous]
public class LoginController : BaseApiController
{
    private readonly IUserServices _userServices;
    readonly PermissionRequirement _requirement;
    private readonly IPermissionServices _permissionServices;
    private readonly IMapper _mapper;

    /// <summary>
    /// 构造函数注入
    /// </summary>
    public LoginController(IUserServices userServices,
        IPermissionServices permissionServices,
        PermissionRequirement requirement,
        IMapper mapper)
    {
        _userServices = userServices;
        _permissionServices = permissionServices;
        _requirement = requirement;
        _mapper = mapper;
    }


    /// <summary>
    /// 登陆  获取JWT整个系统主要方法
    /// </summary>
    /// <param name="name">用户名</param>
    /// <param name="pass">密码</param>
    /// <returns>令牌</returns>
    [HttpGet]
    [Route("GetJwtToken")]
    public async Task<MessageModel<TokenInfoViewModel>> GetJwtToken(string name = "", string pass = "")
    {
        string jwtStr = string.Empty;

        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(pass))
            return Failed<TokenInfoViewModel>("用户名或密码不能为空");

        var user = await _userServices.Login(name, MD5Helper.MD5Encrypt32(pass));
        if (user.IsNotEmptyOrNull() && user.Count > 0)
        {
            //var userRoles = user.ClinicalDepartments;//用户的报告类别集合
            //如果是基于用户的授权策略，这里要添加用户;如果是基于角色的授权策略，这里要添加角色
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, name),
                    new Claim(JwtRegisteredClaimNames.Jti, user.FirstOrDefault().ID.ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.DateToTimeStamp()),
                    new Claim(ClaimTypes.Expiration,
                        DateTime.Now.AddSeconds(_requirement.Expiration.TotalSeconds).ToString())
                };
            //claims.AddRange(userRoles.Split(',').Select(s => new Claim(ClaimTypes.Role, s)));
            var token = JwtToken.BuildJwtToken(claims.ToArray(), _requirement);

            return Success(token, "认证成功");
        }
        else
        {
            return Failed<TokenInfoViewModel>("认证失败");
        }
    }

    /// <summary>
    /// 获取JWT
    /// </summary>
    /// <param name="name"></param>
    /// <param name="pass"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("GetJwtTokenSecret")]
    public async Task<MessageModel<TokenInfoViewModel>> GetJwtTokenSecret(string name = "", string pass = "")
    {
        var rlt = await GetJwtToken(name, pass);
        return rlt;
    }

    /// <summary>
    /// 测试 MD5 加密字符串
    /// </summary>
    /// <param name="password"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("Md5Password")]
    public string Md5Password(string password = "")
    {
        return MD5Helper.MD5Encrypt32(password);
    }

    

}

