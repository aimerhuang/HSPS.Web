namespace HSPS.Web.Model.Models.Extensions;

/// <summary>
/// 报告查询类型
/// </summary>
public class ReportQueryModel : OrderBy
{
    /// <summary>
    /// 姓名/条码号/影像号/住院号
    /// </summary>
    public string? BarCode { get; set; }
    /// <summary>
    /// 住院号
    /// </summary>
    public string? HospitalNo { get; set; }
    /// <summary>
    /// 是否模糊查询
    /// </summary>
    public bool IsFuzzy { get; set; }
    /// <summary>
    /// 识别状态
    /// </summary>
    public string? DiscernStatus { get; set; }
    /// <summary>
    /// 报告状态
    /// </summary>
    //[DisplayName("报告状态：")]
    public string? ReportStatus { get; set; }
    /// <summary>
    /// 匹配状态
    /// </summary>
    //[DisplayName("匹配状态：")]
    public bool IsMatch { get; set; }
    /// <summary>
    /// 打印状态
    /// </summary>
    //[DisplayName("打印状态：")]
    public string? PrintStatus { get; set; }
    /// <summary>
    /// 作业类别
    /// </summary>
    //[DisplayName("作业类别：")]
    public string? FileType { get; set; }
    /// <summary>
    /// 医技科室id:多个科室用,隔开
    /// </summary>
    //[DisplayName("医技科室：")]
    public string? MedicalTechDepart { get; set; }
    /// <summary>
    ///报告/胶片类别
    /// </summary>
    //[DisplayName("报告/胶片类别：")]
    public string? ReportType { get; set; }
    /// <summary>
    /// 院区
    /// </summary>
    //[DisplayName("院区：")]
    public string? HospitalArea { get; set; }
    /// <summary>
    /// 病区
    /// </summary>
    //[DisplayName("病区：")]
    public string? PatientArea { get; set; }
    /// <summary>
    /// 临床科室
    /// </summary>
    //[DisplayName("临床科室：")]
    public string? ClinicalDepartment { get; set; }
    /// <summary>
    /// 是否是历史报告
    /// </summary>
    public bool IsHistory { get; set; }

    /// <summary>
    /// 查询时间
    /// </summary>
    public DatetimePeriod? TotalTimePeriod { get; set; }

    /// <summary>
    /// 是否按来源纬度统计
    /// 2023-3-23 hkl 来源ip
    /// </summary>
    //[DisplayName("来源IP")]
    public string? IsByStation { get; set; }

    /// <summary>
    /// 页索引
    /// </summary>
    public int? PageIndex { get; set; }

    /// <summary>
    /// 页显示数量
    /// </summary>
    public int? PageSize { get; set; }

}

