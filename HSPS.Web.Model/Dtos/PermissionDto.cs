

using Entities;

namespace HSPS.Web.Model.Dtos;
public class PermissionDto
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
    /// 对应资源表id
    /// </summary>
    public int ResourceID { get; set; }

    /// <summary>
    /// 对应资源
    /// </summary>
    public Resource Resource { get; set; }


}
