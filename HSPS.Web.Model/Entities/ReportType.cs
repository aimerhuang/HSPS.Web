using SqlSugar;

namespace Entities;

/// <summary>
/// 类别模型
/// </summary>
public class ReportType
{
    /// <summary>
    /// 主键id
    /// </summary>
    [SugarColumn(IsNullable = false, IsPrimaryKey = true, IsIdentity = false)]
    public int ID { get; set; }

    /// <summary>
    /// 类别名
    /// </summary>
    [SugarColumn(Length = 100, IsNullable = false)]
    public string Name { get; set; }

    /// <summary>
    /// 科室id
    /// </summary>
    [SugarColumn(IsNullable = false)]
    public int DepartmentID { get; set; }

    /// <summary>
    /// 解析规则类别
    /// </summary>
    [SugarColumn(Length = 50, IsNullable = false)]
    public string ParseRuleType { get; set; }

    /// <summary>
    /// 打印参数ID
    /// </summary>
    public string PrintParameterID { get; set; }

    /// <summary>
    /// 放射科室下胶片类别关联报告类别用
    /// </summary>
    public int? RelationID { get; set; }

    /// <summary>
    /// 集成平台的报告类别Item。CT，MR，DR，CR，DSA，US，ES，PA，LIS。
    /// </summary>
    public string PlatformReportType { get; set; }

    /// <summary>
    /// 是否需要审核
    /// </summary>
    public bool IsAudit { get; set; }

    /// <summary>
    /// 超时时间
    /// </summary>
    public int TimeoutHour { get; set; }
    /// <summary>
    /// 审核等级
    /// </summary>
    public string AuditLevel { get; set; }

    /// <summary>
    /// 业务类型--0：全院；1：体检；2：病案（暂时无用，UI隐藏）
    /// </summary>
    public int BusinessType { get; set; }
    /// <summary>
    /// 体检报告类型--0：孤岛报告（默认为0），1：总检报告
    /// </summary>
    public int MECReportType { get; set; }
    /// <summary>
    /// 解析方式（0为json解析，1为正则）。
    /// </summary>
    public int Analysisway { get; set; }
    /// <summary>
    /// 体检报告类型--0：孤岛报告（默认为0），1：总检报告
    /// </summary>
    public string GetFilmMode { get; set; }
}

