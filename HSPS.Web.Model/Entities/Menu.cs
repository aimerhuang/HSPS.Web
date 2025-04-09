using SqlSugar;

namespace Entities;

/// <summary>
/// 菜单表
/// </summary>
[SugarTable("Department", "科室表")]
public class Menu
{
    /// <summary>
    /// 菜单ID
    /// </summary>
    [SugarColumn(IsNullable = false, IsPrimaryKey = true, IsIdentity = true)]
    public int ID { get; set; }
    /// <summary>
    /// 菜单URL
    /// </summary>
    [SugarColumn(IsNullable = false,Length =200)]
    public string Url { get; set; }
    /// <summary>
    /// 菜单名称
    /// </summary>
    [SugarColumn(IsNullable = false, Length = 200)]
    public string Name { get; set; }
    /// <summary>
    /// 菜单级别 1-一级菜单，2-二级菜单，3-三级菜单
    /// </summary>
    [SugarColumn(IsNullable = false)]
    public int MenuLevel { get; set; }
    /// <summary>
    /// 父级ID
    /// </summary>
    [SugarColumn(IsNullable = false)]
    public int ParentID { get; set; }
    /// <summary>
    /// 帮助链接
    /// </summary>
    [SugarColumn(IsNullable = false, Length = 200)]
    public string HelpLink { get; set; }
    /// <summary>
    /// 排序
    /// </summary>
    [SugarColumn(IsNullable = false)]
    public int Sort { get; set; }
    /// <summary>
    /// 是否启用
    /// </summary>
    [SugarColumn(IsNullable = false)]
    public int IsEnable { get; set; }
}
