using HIPS.HSPS.Interface.Persistence.Web;
using HSPS.Web.IServices;
using HSPS.Web.Repository;
using System.Reflection;

namespace HSPS.Web.Services;

public class RoleServices: IRoleServices
{
    /// <summary>
    /// 保存角色
    /// </summary>
    /// <param name="role">角色</param>
    public void UpdateRole(Model.Models.Extensions.Role role)
    {
        InterfaceObjectHelper.CallMethod<UpdateRole, Missing>(RemotingInterfaceService.MtPermissionControlService.UpdateRole, (UpdateRole)role);
    }

    /// <summary>
    /// 保存角色
    /// </summary>
    /// <param name="role">角色</param>
    public void AddRole(Model.Models.Extensions.Role role)
    {
        InterfaceObjectHelper.CallMethod<AddRole, Missing>(RemotingInterfaceService.MtPermissionControlService.AddRole, (AddRole)role);
    }

    /// <summary>
    /// 删除角色
    /// </summary>
    /// <param name="roleIDList">角色ID列表</param>
    public void DeleteRole(List<int> roleIDList)
    {
        InterfaceObjectHelper.CallMethod<IEnumerable<int>, Missing>(RemotingInterfaceService.MtPermissionControlService.DeleteRole, roleIDList);
    }

    /// <summary>
    /// 获取所有角色
    /// </summary>
    /// <returns>角色列表</returns>
    public IEnumerable<Model.Models.Extensions.Role> GetAllRole()
    {
        var roleList = InterfaceObjectHelper.CallMethod<DBNull, IEnumerable<Role>>(RemotingInterfaceService.MtPermissionControlService.GetRoles, DBNull.Value);
        return roleList.CastExtension<Model.Models.Extensions.Role>();
    }
    /// <summary>
    /// 获取所有角色
    /// </summary>
    /// <returns>角色列表</returns>
    public IEnumerable<Model.Models.Extensions.User> GetUsersByRoleID(int RoleID)
    {
        var roleList = InterfaceObjectHelper.CallMethod<int, IEnumerable<User>>(RemotingInterfaceService.MtPermissionControlService.GetUsersByRole, RoleID);
        return roleList.CastExtension<Model.Models.Extensions.User>();
    }

    /// <summary>
    /// 根据角色ID获取角色
    /// </summary>
    /// <param name="roleID">角色ID</param>
    /// <returns></returns>
    public Model.Models.Extensions.Role GetRoleByRoleID(int roleID)
    {
        var role = InterfaceObjectHelper.CallMethod<int, Role>(RemotingInterfaceService.MtPermissionControlService.GetRoleByID, roleID);
        return role;
    }

    /// <summary>
    /// 根据角色ID获取角色
    /// </summary>
    /// <returns></returns>
    public Model.Models.Extensions.Role GetRoleByRoleName(string roleName)
    {
        var role = InterfaceObjectHelper.CallMethod<string, Role>(RemotingInterfaceService.MtPermissionControlService.GetRoleByName, roleName);
        return role;
    }

    /// <summary>
    /// 获取所有模块
    /// </summary>
    /// <returns>模块列表</returns>
    public IEnumerable<Model.Models.Extensions.Module> GetModules()
    {
        var list = InterfaceObjectHelper.CallMethod<DBNull, IEnumerable<HIPS.HSPS.Interface.Persistence.Web.Module>>(RemotingInterfaceService.MtPermissionControlService.GetModules, DBNull.Value);
        return list.CastExtension<Model.Models.Extensions.Module>();
    }

    /// <summary>
    /// 获取所有的页面
    /// </summary>
    /// <returns>页面列表</returns>
    public IEnumerable<Model.Models.Extensions.Resource> GetResources()
    {
        var list = InterfaceObjectHelper.CallMethod<DBNull, IEnumerable<Resource>>(RemotingInterfaceService.MtPermissionControlService.GetResources, DBNull.Value);
        return list.CastExtension<Model.Models.Extensions.Resource>();
    }

}
