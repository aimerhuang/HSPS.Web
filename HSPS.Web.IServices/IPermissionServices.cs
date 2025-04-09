using Entities;
using HSPS.Web.IServices.BASE;
using HSPS.Web.Model.Dtos;
using HSPS.Web.Model.Models;
using HSPS.Web.Model;

namespace HSPS.Web.IServices;

public interface IPermissionServices:IBaseServices<Permission>
{
    /// <summary>
    /// 获取权限分页
    /// </summary>
    /// <param name="startPage"></param>
    /// <param name="pageSize"></param>
    /// <param name="model"></param>
    /// <returns></returns>
    Task<PageModel<PermissionDto>> LoadPageList(int startPage, int pageSize, PermissionQueryModel model);

    /// <summary>
    /// 根据id取权限
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<List<Permission>> GetById(int id);
    ///// <summary>
    ///// 登录
    ///// </summary>
    ///// <param name="username"></param>
    ///// <param name="password"></param>
    ///// <returns></returns>
    //bool Login(string username, string password);

    ///// <summary>
    ///// 登录成功
    ///// </summary>
    ///// <param name="username"></param>
    ///// <param name="password"></param>
    ///// <returns></returns>
    //bool LoginSuccess(string username);

    ///// <summary>
    ///// 获取用户的权限信息
    ///// </summary>
    ///// <param name="username"></param>
    ///// <returns></returns>
    //IEnumerable<Permission> GetUserPermission(string username);

    ///// <summary>
    ///// 获取所有的权限，用于给用户配置权限
    ///// </summary>
    ///// <returns></returns>
    IEnumerable<Permission> GetAllPermissions();
}
