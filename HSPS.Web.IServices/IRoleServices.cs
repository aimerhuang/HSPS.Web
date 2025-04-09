
using HSPS.Web.Model.Models.Extensions;

namespace HSPS.Web.IServices;

public interface IRoleServices
{
    /// <summary>
    /// 新增角色
    /// </summary>
    /// <param name="role">角色</param>
    void AddRole(Role role);
    /// <summary>
    /// 修改角色
    /// </summary>
    /// <param name="role">角色</param>
    void UpdateRole(Role role);
    /// <summary>
    /// 获取所有角色
    /// </summary>
    /// <returns>角色列表</returns>
    IEnumerable<Role> GetAllRole();
    /// <summary>
    /// 获取所有角色
    /// </summary>
    /// <returns>角色列表</returns>
    Role GetRoleByRoleID(int roleIDList);
    /// <summary>
    /// 根据角色ID获取用户
    /// </summary>
    /// <returns>角色列表</returns>
    IEnumerable<User> GetUsersByRoleID(int roleIDList);
    /// <summary>
    /// 获取所有角色
    /// </summary>
    /// <returns>角色列表</returns>
    Role GetRoleByRoleName(string roleName);
    /// <summary>
    /// 获取所有模块
    /// </summary>
    /// <returns>模块列表</returns>
    IEnumerable<Module> GetModules();
    /// <summary>
    /// 获取所有的页面
    /// </summary>
    /// <returns>页面列表</returns>
    IEnumerable<Resource> GetResources();
    /// <summary>
    /// 删除角色
    /// </summary>
    /// <param name="roleIDList">角色ID列表</param>
    void DeleteRole(List<int> roleIDList);
}
