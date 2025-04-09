using HSPS.Web.Controllers;
using HSPS.Web.IServices;
using HSPS.Web.Model;
using HSPS.Web.Model.Dtos;
using HSPS.Web.Model.Models.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace HSPS.Web.Api.Controllers;

/// <summary>
/// 角色控制器
/// </summary>
[Produces("application/json")]
[Route("api/[controller]/[action]")]
public class RoleController : BaseApiController
{
    private readonly IRoleServices _roleServices;
    private readonly IPermissionServices _permissionServices;

    /// <summary>
    /// 构造函数
    /// </summary>
    public RoleController(IRoleServices roleServices, IPermissionServices permissionServices)
    {
        _roleServices = roleServices;
        _permissionServices = permissionServices;
    }

    /// <summary>
    /// 获取所有权限树(wcf)
    /// </summary>
    /// <returns>权限树集合列表</returns>
    [HttpGet]
    public List<RuleTreeDto> GetRolePermissionTree()
    {
        //所有模块的集合
        IEnumerable<Module> allModuleList = _roleServices.GetModules();
        //所有页面的集合
        IEnumerable<Resource> allResourceList = _roleServices.GetResources();
        //所有规则的集合
        //IEnumerable<Permission> allPermissionList = _permissionServices.GetAllPermissions();
        //序列化成规则树之前的结果集合
        List<RuleTreeDto> result = new List<RuleTreeDto>();

        Dictionary<string, RuleTreeDto> dicModule = new Dictionary<string, RuleTreeDto>();
        Dictionary<string, RuleTreeDto> dicResource = new Dictionary<string, RuleTreeDto>();

        foreach (Module m in allModuleList)
        {
            dicModule.Add("Module" + m.ID, new RuleTreeDto()
            {
                id = m.ID,
                state = "open",
                type = "Module",
                attributes = new { type = "Module", sourceID = m.ID },
                text = m.Name,
                children = new List<RuleTreeDto>() { }
            });
        }

        foreach (Resource r in allResourceList)
        {
            dicResource.Add("Resource" + r.ID, new RuleTreeDto()
            {
                id = r.ID,
                state = "open",
                type = "Resource",
                text = r.Name,
                attributes = new { type = "Resource", sourceID = r.ID },
                parentId = r.ModuleID.ToString(),
                children = new List<RuleTreeDto>() { }
            });
        }
        //foreach (Permission p in allPermissionList)
        //{
        //    dicResource["Resource" + p.ResourceID].children.Add(new RuleTreeDto()
        //    {
        //        id = p.ResourceID,
        //        state = "open",
        //        type = "Permission",
        //        text = p.Name,
        //        attributes = new { type = "Permission", sourceID = p.ID, code = p.Code },
        //        parentId = p.ResourceID.ToString(),
        //        children = new List<RuleTreeDto>() { }
        //    });
        //}
        foreach (Resource r in allResourceList)
        {
            dicModule["Module" + r.ModuleID].children.Add(dicResource["Resource" + r.ID]);
        }

        foreach (var m in dicModule)
        {
            result.Add(m.Value);
        }
        return result;



    }

    /// <summary>
    /// 获取所有角色 wcf
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public MessageModel<List<Role>> GetAllRole()
    {
        var data = new MessageModel<List<Role>>();
        data.success = true;
        data.status = 200;
        var roleList = _roleServices.GetAllRole();
        data.response = roleList is null || roleList.ToList().Count <= 0 ? new List<Role>() : roleList.ToList();

        return data;
    }

    /// <summary>
    /// 根据角色ID获取用户 wcf
    /// </summary>
    /// <param name="roleID"></param>
    /// <returns></returns>
    [HttpGet]
    public MessageModel<List<User>> GetUsersByRoleID(int roleID)
    {
        var data = new MessageModel<List<User>>();
        data.success = true;
        data.status = 200;
        var user = _roleServices.GetUsersByRoleID(roleID).ToList();
        data.response = user is null || user.Count <= 0 ? new List<User>() : user;
        return data;
    }

    /// <summary>
    /// 根据角色名称获取角色 wcf
    /// </summary>
    /// <param name="roleName"></param>
    /// <returns></returns>
    [HttpGet]
    public MessageModel<Role> GetRoleByRoleName(string roleName)
    {
        var data = new MessageModel<Role>();
        data.success = true;
        data.status = 200;
        var user = _roleServices.GetRoleByRoleName(roleName);
        data.response = user is null ? new Role() : user;
        return data;
    }

    /// <summary>
    /// 角色是否存在 wcf
    /// </summary>
    /// <param name="roleName"></param>
    /// <returns></returns>
    [HttpGet]
    public MessageModel<bool> IsExists(string roleName)
    {
        var data = new MessageModel<bool>();
        data.success = true;
        data.status = 200;
        var user = _roleServices.GetRoleByRoleName(roleName);
        data.response = user != null ? true : false;
        return data;
    }

    /// <summary>
    /// 根据角色id删除角色 wcf 未通
    /// </summary>
    /// <param name="roleID">角色id</param>
    /// <returns></returns>
    [HttpPost]
    public MessageModel<string> DeleteRole(int roleID)
    {
        return Failed("删除失败");
        var data = new MessageModel<string>();
        data.success = true;
        data.status = 200;
        _roleServices.DeleteRole(new List<int>() { roleID });
        data.response = "删除成功";
        return data;
    }

    /// <summary>
    /// 修改角色 wcf 未通
    /// </summary>
    /// <param name="role">角色</param>
    /// <returns></returns>
    [HttpPost]
    public MessageModel<string> UpdateRole(Role role)
    {
        return Failed("删除失败");
        var data = new MessageModel<string>();
        data.success = true;
        data.status = 200;
        _roleServices.UpdateRole(role);
        data.response = "修改成功";
        return data;
    }

    /// <summary>
    /// 新增角色 wcf 暂未通
    /// </summary>
    /// <param name="role">角色</param>
    /// <returns></returns>
    [HttpPost]
    public MessageModel<string> AddRole(Role role)
    {
        return Failed("增加失败");
        var data = new MessageModel<string>();
        data.success = true;
        data.status = 200;
        _roleServices.AddRole(role);
        data.response = "增加成功";
        return data;
    }

    


}
