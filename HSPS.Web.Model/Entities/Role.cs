

using SqlSugar;

namespace Entities;

/// <summary>
/// 角色表
/// </summary>
[SugarTable("Role", "角色表")]
public class Role
{
    /// <summary>
    /// 主键id
    /// </summary>
    [SugarColumn(IsNullable = false, IsPrimaryKey = true, IsIdentity = true)]
    public int ID { get; set; }
    /// <summary>
    /// 角色名称
    /// </summary>
    [SugarColumn(IsNullable = false, Length = 200)]
    public string Name { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    [SugarColumn(Length = 200)]
    public string Description { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    [SugarColumn(IsNullable = false)]
    public DateTime CreatedTime { get; set; }

    /// <summary>
    /// 创建人
    /// </summary>
    [SugarColumn(IsNullable = false)]
    public string Creator { get; set; }


    /// <summary>
    /// 默认菜单id
    /// </summary>
    public int DefaultMenuId { get; set; }
}
