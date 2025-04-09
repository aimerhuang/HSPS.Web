
using SqlSugar;

namespace Entities;

/// <summary>
/// 用户角色关系表
/// </summary>
[SugarTable("UserRoleRelation", "用户角色关系表")]
public class UserRoleRelation
{
    /// <summary>
    /// 主键id
    /// </summary>
    [SugarColumn(IsNullable = false, IsPrimaryKey = true)]
    public int ID { get; set; }
    /// <summary>
    /// 用户id
    /// </summary>
    [SugarColumn(IsNullable = false)]
    public int UserID { get; set; }
    /// <summary>
    /// 角色id
    /// </summary>
    [SugarColumn(IsNullable = false)]
    public int RoleID { get; set; }
}
