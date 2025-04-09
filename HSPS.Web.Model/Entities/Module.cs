using SqlSugar;

namespace Entities;

/// <summary>
/// 模块表（顶级菜单栏
/// </summary>
[SugarTable("Module", "模块表")]
public class Module
{
    /// <summary>
    /// 主键id
    /// </summary>
    [SugarColumn(IsNullable = false, IsPrimaryKey = true, IsIdentity = true)]
    public int ID { get; set; }
    /// <summary>
    /// 模块名称（顶级菜单栏名称
    /// </summary>
    [SugarColumn(IsNullable = false, Length = 200)]
    public string Name { get; set; }
    /// <summary>
    /// 英文代号
    /// </summary>
    [SugarColumn(IsNullable = false, Length = 200)]
    public string Code { get; set; }
    /// <summary>
    /// 父级id
    /// </summary>
    [SugarColumn(IsNullable = false)]
    public int ParentID { get; set; }
    /// <summary>
    /// 菜单列表（二级菜单列表
    /// </summary>
    [Navigate(NavigateType.OneToMany, nameof(Resource.ModuleID), nameof(ID))]
    public List<Resource> Resources { get; set; }
}
