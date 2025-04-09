namespace HSPS.Web.Model.Models.Extensions;

/// <summary>
/// 权限表
/// </summary>
public partial class Permission
{
    /// <summary>
    /// 主键id
    /// </summary>
    public int ID { get; set; }
    /// <summary>
    /// 权限代号（Visit可访问，NeedPrint按需打印，Update可修改，Delete可删除）
    /// </summary>
    public string Code { get; set; }
    /// <summary>
    /// 权限代号名称
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// 备注
    /// </summary>
    public string Description { get; set; }
    /// <summary>
    /// 对应资源
    /// </summary>
    public Resource Resource { get; set; }
    /// <summary>
    /// 对应资源表id
    /// </summary>
    public int ResourceID { get; set; }
}

public partial class Permission
{
    public static implicit operator Permission(HIPS.HSPS.Interface.Persistence.Web.Permission source)
    {
        if (source != null)
        {
            var target = new Permission()
            {
                ID = source.ID,
                Code = source.Code,
                Name = source.Name,
                Resource = (Resource)source.Resource,
                ResourceID = source.Resource.ID
            };

            return target;
        }
        return null;
    }
    public static implicit operator HIPS.HSPS.Interface.Persistence.Web.Permission(Permission source)
    {
        if (source != null)
        {
            var target = new HIPS.HSPS.Interface.Persistence.Web.Permission()
            {
                ID = source.ID,
                Code = source.Code,
                Name = source.Name,
                Resource = (HIPS.HSPS.Interface.Persistence.Web.Resource)source.Resource,
                ResourceID = source.ResourceID
            };

            return target;
        }
        return null;
    }
}