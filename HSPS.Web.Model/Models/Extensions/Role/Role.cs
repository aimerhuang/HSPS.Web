using HIPS.HSPS.Interface.Persistence.Web;

namespace HSPS.Web.Model.Models.Extensions;

/// <summary>
/// 角色
/// </summary>
public partial class Role : IEntity
{
    /// <summary>
    /// 主键
    /// </summary>
    public int ID { get; set; }
    /// <summary>
    /// 角色名
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// 备注
    /// </summary>
    public string Description { get; set; }
    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreateTime { get; set; }
    /// <summary>
    /// 创建人
    /// </summary>
    public string Creator { get; set; }
    /// <summary>
    /// 角色的权限集合
    /// </summary>
    public virtual IEnumerable<Permission> Permissions { get; set; }
    /// <summary>
    /// 角色的权限id集合
    /// </summary>
    public virtual IEnumerable<int> PermissionsIDs { get; set; }
    /// <summary>
    /// 角色的默认菜单id
    /// </summary>
    public string DefaultMenuId { get; set; }
    /// <summary>
    /// 路径
    /// </summary>
    public string Url { get; set; }
    /// <summary>
    /// 路径名称
    /// </summary>
    public string UrlName { get; set; }
    /// <summary>
    /// 角色默认菜单路径
    /// </summary>
    public string DefaultUrl { get; set; }
}

public partial class Role : IEntity
{
    public static implicit operator HIPS.HSPS.Interface.Persistence.Web.UpdateRole(Role source)
    {
        if (source != null)
        {
            var target = new HIPS.HSPS.Interface.Persistence.Web.UpdateRole()
            {
                Description = source.Description,
                ID = source.ID,
                Name = source.Name,
                PermissionIds = source.PermissionsIDs,
                DefaultMenuId = source.DefaultMenuId.AsTargetType(0)
            };
            return target;
        }
        return null;
    }

    public static implicit operator HIPS.HSPS.Interface.Persistence.Web.AddRole(Role source)
    {
        if (source != null)
        {
            var target = new HIPS.HSPS.Interface.Persistence.Web.AddRole()
            {
                CreateTime = source.CreateTime,
                Creator = source.Creator,
                Description = source.Description,
                Name = source.Name,
                DefaultMenuId = source.DefaultMenuId.AsTargetType(0)
            };
            return target;
        }
        return null;
    }

    public static implicit operator Role(HIPS.HSPS.Interface.Persistence.Web.Role source)
    {
        if (source != null)
        {
            var target = new Role()
            {
                ID = source.ID,
                CreateTime = source.CreateTime,
                Creator = source.Creator,
                Description = source.Description,
                Name = source.Name,
                Permissions = source.Permissions.CastExtension<Permission>(),
                DefaultMenuId = source.DefaultMenuId.ToString(),
                Url = source.Url,
                UrlName = source.UrlName,
                DefaultUrl = string.IsNullOrEmpty(source.Url) ? "" : source.UrlName + "(" + source.Url + ")"
            };
            return target;
        }
        return null;
    }
}

