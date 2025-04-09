using SqlSugar;

namespace Entities;

/// <summary>
/// 权限角色关联表
/// </summary>
[SugarTable("RolePermissionRelation", "权限角色关联表")]
public class RolePermissionRelation
{
    /// <summary>
    /// 主键id
    /// </summary>
    [SugarColumn(IsNullable = false, IsPrimaryKey = true, IsIdentity = true)]
    public int ID { get; set; }

    /// <summary>
    /// 角色id
    /// </summary>
    [SugarColumn(IsNullable = false)]
    public int RoleID { get; set; }

    /// <summary>
    /// 权限id
    /// </summary>
    [SugarColumn(IsNullable = false)]
    public int PermissionID { get; set; }
}
