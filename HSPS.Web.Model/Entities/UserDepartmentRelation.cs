using SqlSugar;

namespace Entities;

/// <summary>
/// 用户和科室关系表
/// </summary>
[SugarTable("UserDepartmentRelation", "用户和科室关系表")]
public class UserDepartmentRelation
{
    /// <summary>
    /// 主键id
    /// </summary>
    [SugarColumn(IsNullable = false, IsPrimaryKey = true, IsIdentity = true)]
    public int ID { get; set; }
    /// <summary>
    /// 用户id
    /// </summary>
    [SugarColumn(IsNullable = false)]
    public int UserID { get; set; }
    /// <summary>
    /// 科室id
    /// </summary>
    [SugarColumn(IsNullable = false)]
    public int DepartmentID { get; set; }
}
