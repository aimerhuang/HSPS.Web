using HSPS.Web.Model.Enum;
using HIPS.HSPS.Interface.Persistence.Web;

namespace HSPS.Web.Model.Models.Extensions;

/// <summary>
/// 类别表（报告/胶片）
/// </summary>
public partial class ReportType : IEntity
{
    /// <summary>
    /// 类别id
    /// </summary>
    public int ID { get; set; }
    /// <summary>
    /// 是否彩色
    /// </summary>
    public bool IsColorful { get; set; }
    /// <summary>
    /// 类别名
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// 科室id
    /// </summary>
    public int DepartmentID { get; set; }
    /// <summary>
    /// 打印介质
    /// </summary>
    public string Media { get; set; }
    /// <summary>
    /// 打印质量枚举值（Unknow = -1，Low = 0，Middle = 1，High = 2
    /// </summary>
    public PrintQualityEnum PintQuality { get; set; }
    /// <summary>
    /// 打印尺寸
    /// </summary>
    public string PrintSize { get; set; }
    /// <summary>
    /// 类别（报告/胶片/未知
    /// </summary>
    public FileTypeEnum ParseRuleType { get; set; }
    /// <summary>
    /// 打印介质名称
    /// </summary>
    public string MediaValue { get; set; }
    /// <summary>
    /// 打印质量名称
    /// </summary>
    public string PintQualityValue { get; set; }
    /// <summary>
    /// 打印尺寸名称
    /// </summary>
    public string PrintSizeValue { get; set; }
    /// <summary>
    /// 解析规则类别
    /// </summary>
    public string ParseRuleTypeValue { get; set; }
    /// <summary>
    /// 关联id（放射科室下胶片类别关联报告类别用
    /// </summary>
    public int? RelationID { get; set; }
    /// <summary>
    /// 打印方式（Auto_Work直打 = 0，Auto_NoWork非工作时间直打 = 1，Manual自助打 = 2，Nope不打印 = 3
    /// </summary>
    public PrintSolutionEnum PrintSolution { get; set; }
    /// <summary>
    /// 集成平台的报告类别Item（CT，MR，DR，CR，DSA，US，ES，PA，LIS）
    /// </summary>
    public string PlatformReportType { get; set; }
    /// <summary>
    /// 是否需要审核（默认0无需，1需要）
    /// </summary>
    public bool IsAudit { get; set; }
    /// <summary>
    /// 超时时长（分钟
    /// </summary>
    public int TimeoutHour { get; set; }
    /// <summary>
    /// 审核级别（1,2,3）
    /// </summary>
    public EnumAuditLevel AuditLevel { get; set; }
    /// <summary>
    /// 审核条件
    /// </summary>
    public IEnumerable<AuditConditions> AuditConditions { get; set; }
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
    /// 取片方式（取值从codemap取） 0：胶片报告需匹配 2:报告需识别，胶片需匹配 3：无需匹配
    /// </summary>

    public string GetFilmMode { get; set; }
}

public partial class ReportType:IEntity
{
    public static implicit operator ReportType(HIPS.HSPS.Interface.Persistence.Web.ReportType source)
    {
        if (source != null)
        {
            var target = new ReportType()
            {
                ID = source.ID,
                IsColorful = source.PrintParameter.PrintParam.IsColorful,
                Name = source.Name,
                Media = source.PrintParameter.PrintParam.Media,
                PintQuality = (source.PrintParameter.PrintParam.Quality).ParseEnum<PrintQualityEnum>(PrintQualityEnum.Unknow),
                PrintSize = source.PrintParameter.PrintParam.PrintSize,
                ParseRuleType = (source.ParseRuleType).ParseEnum<FileTypeEnum>(FileTypeEnum.Report),
                MediaValue = source.PrintParameter.PrintParam.Media,
                PintQualityValue = (source.PrintParameter.PrintParam.Quality).ParseEnum<PrintQualityEnum>(PrintQualityEnum.Unknow).ToString(),
                PrintSizeValue = source.PrintParameter.PrintParam.PrintSize,
                ParseRuleTypeValue = (source.ParseRuleType).ParseEnum<FileTypeEnum>(FileTypeEnum.Report).ToString(),
                RelationID = source.RelationID,
                DepartmentID = source.DepartmentID,
                PlatformReportType = source.PlatformReportType,
                IsAudit = source.IsAudit,
                TimeoutHour = source.TimeoutHour,
                AuditLevel = (source.EnumAuditLevel).ParseEnum<EnumAuditLevel>(EnumAuditLevel.FirstAudit),
                AuditConditions = null,//source.AuditConditions == null? null : source.AuditConditions.ForEachCast(item => { return (Model.Models.AuditConditions)item; }),
                // PrintSolution = (source.PrintParameter..Media).ParseEnum<MediaEnum>(MediaEnum.Unknow),
                MECReportType = source.MecreportType,
                BusinessType = source.BusinessType,
                Analysisway = source.Analysisway,

            };

            return target;
        }
        return null;
    }
}

