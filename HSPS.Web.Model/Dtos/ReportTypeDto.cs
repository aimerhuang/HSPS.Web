using HSPS.Web.Model.Enum;
using HSPS.Web.Model.Models;
using HSPS.Web.Model.Models.Extensions;

namespace HSPS.Web.Model.Dtos;
/// <summary>
/// 报告类别模型
/// </summary>
public class ReportTypeDto
{
    public int ID { get; set; }
    public bool IsColorful { get; set; }
    public string Name { get; set; }
    public int DepartmentID { get; set; }
    public string Media { get; set; }
    public PrintQualityEnum PintQuality { get; set; }
    public string PrintSize { get; set; }
    public FileTypeEnum ParseRuleType { get; set; }
    public string MediaValue { get; set; }
    public string PintQualityValue { get; set; }
    public string PrintSizeValue { get; set; }
    public string ParseRuleTypeValue { get; set; }
    public int? RelationID { get; set; }
    public PrintSolutionEnum PrintSolution { get; set; }
    public string PlatformReportType { get; set; }
    public bool IsAudit { get; set; }
    public int TimeoutHour { get; set; }
    public EnumAuditLevel AuditLevel { get; set; }
    public IEnumerable<AuditConditions> AuditConditions { get; set; }
    public int BusinessType { get; set; }
    public int MECReportType { get; set; }
    public int Analysisway { get; set; }
    /// <summary>
    /// 取片方式
    /// </summary>
    public string GetFilmMode{  get; set;  }
}

