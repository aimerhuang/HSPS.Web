using SqlSugar;

namespace Entities;

/// <summary>
/// 用户类别关联表
/// </summary>
[SugarTable("UserReporttypeIdRelation", "用户类别关联表")]
public class UserReporttypeIdRelation
{
    /// <summary>
    /// 主键id
    /// </summary>
    [SugarColumn(IsNullable = false, IsPrimaryKey = true)]
    public int Id { get; set; }

    /// <summary>
    /// 用户id
    /// </summary>
    [SugarColumn(IsNullable = false)]
    public int UserID { get; set; }

    /// <summary>
    /// 类别id
    /// </summary>
    [SugarColumn(IsNullable = false)]
    public string ReportTypeId { get; set; }
}
