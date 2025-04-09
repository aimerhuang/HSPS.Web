using HSPS.Web.Common;
using HSPS.Web.Controllers;
using HSPS.Web.IServices;
using HSPS.Web.Model;
using HSPS.Web.Model.Dtos;
using HSPS.Web.Model.Models;
using HSPS.Web.Model.Models.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;
using StackExchange.Profiling;
using System.Threading.Tasks;

namespace HSPS.Web.Api.Controllers;

/// <summary>
/// 权限控制器
/// </summary>
[Produces("application/json")]
[Route("api/[controller]/[action]")]
public class PermissionController : BaseApiController
{
    private readonly IPermissionServices _permissionServices;
    private readonly ILogger<PermissionController> _logger;
    /// <summary>
    /// 构造函数
    /// </summary>
    public PermissionController(IPermissionServices permissionServices, ILogger<PermissionController> logger)
    {
        _permissionServices = permissionServices;
        _logger = logger;
    }

    /// <summary>
    /// 获取所有的权限，用于给用户配置权限
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<MessageModel<PageModel<PermissionDto>>> LoadPageList(PermissionQueryModel model)
    {
        try
        {
            Log.Information($"LoadPageList入参:{JsonConvert.SerializeObject(model)}");
            _logger.LogInformation($"LoadPageList入参:{JsonConvert.SerializeObject(model)}");
            var list = await _permissionServices.LoadPageList(model.StartPage ?? 1, model.PageSize ?? 20, model);
            if (list != null && list.dataCount > 0)
            {
                //var adminUser = AppSettings.app("WebManage", "SuperAdministrator");
                //if (model.UserID == adminUser)
                //{
                //    MiniProfiler.Current.Step("管理员赋予所有权限");

                //}
                return Success(list);
            }
            return Failed<PageModel<PermissionDto>>("未查询到数据");
        }
        catch (Exception ex)
        {
            Log.Error("获取所有权限异常：" + ex);
            _logger.LogError("获取所有权限异常：" + ex);
            return Failed<PageModel<PermissionDto>>("获取所有权限异常：" + ex);
        }

    }

    /// <summary>
    /// 根据用户名获取用户拥有资源下的所有权限
    /// </summary>
    /// <param name="username">用户登录名</param>
    /// <returns></returns>
    //[HttpPost]
    //[Authorize]
    //public Dictionary<string, List<Permission>> GetUserResourcePermissionDict(string username)
    //{
    //    return Failed<Dictionary<string, List<Permission>>>("失败");
    //}



    /// <summary>
    /// 判断用户是否有访问权限
    /// </summary>
    /// <param name="username"></param>
    /// <param name="localPath"></param>
    /// <returns></returns>
    [HttpGet]
    [AllowAnonymous]
    public bool HasVisitPermission(string username, string localPath)
    {

        return false;
    }


}
