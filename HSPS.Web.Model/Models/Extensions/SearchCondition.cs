

namespace HSPS.Web.Model.Models.Extensions;

/// <summary>
/// 报告查询条件类
/// </summary>
public partial class SearchCondition
{
    /// <summary>
    /// 体检单位
    /// </summary>
    public string ExaminationCompany { get; set; }
    /// <summary>
    /// 体检科室
    /// </summary>
    public string ExaminationDepartment { get; set; }
    /// <summary>
    /// 身份证号
    /// </summary>
    public string IDNO { get; set; }
    /// <summary>
    /// 识别模式（自动，人工，无法识别
    /// </summary>
    public DiscernStatusEnum? DiscernStatus { get; set; }
    /// <summary>
    /// 打印状态
    /// </summary>
    public PrintStatusEnum? PrintStatus { get; set; }
    /// <summary>
    /// 报告状态
    /// </summary>
    public ReportStatusEnum? ReportStatus { get; set; }
    /// <summary>
    /// 页索引
    /// </summary>
    public int? PageIndex { get; set; }
    /// <summary>
    /// 页大小
    /// </summary>
    public int? PageSize { get; set; }
    /// <summary>
    /// 页数量
    /// </summary>
    public int? TotalCount { get; set; }
    /// <summary>
    /// 类别（报告/胶片/未知
    /// </summary>
    public FileTypeEnum? FileType { get; set; }
    /// <summary>
    /// 开始查询时间
    /// </summary>
    public DateTime? TimeBegin { get; set; }
    /// <summary>
    /// 结束查询时间
    /// </summary>
    public DateTime? TimeEnd { get; set; }
    /// <summary>
    /// 增加查询语句条件（后台使用
    /// </summary>
    public string Conditions { get; set; }
    /// <summary>
    /// 科室id集合
    /// </summary>
    public IEnumerable<int> DepartmentIds { get; set; }
    /// <summary>
    /// 是否倒序
    /// </summary>
    public bool IsDesc { get; set; }
    /// <summary>
    /// 是否历史报告（是否归档
    /// </summary>
    public bool IsHistory { get; set; }
    /// <summary>
    /// 类别id集合
    /// </summary>
    public IEnumerable<int> ReportTypeIds { get; set; }
    /// <summary>
    /// 排序集合
    /// </summary>
    public IEnumerable<string> SortItems { get; set; }
    /// <summary>
    /// 胶片报告是否匹配
    /// </summary>
    public bool? IsMatch { get; set; }
    /// <summary>
    /// 院区
    /// </summary>
    public IEnumerable<string> HospitalAreas { get; set; }

    /// <summary>
    /// 病区
    /// </summary>
    public IEnumerable<string> PatientAreas { get; set; }

    /// <summary>
    /// 住院号
    /// </summary>
    public string HospitalNo { get; set; }

    /// <summary>
    /// 临床科室
    /// </summary>
    public IEnumerable<string> ClinicalDepartments { get; set; }

    /// <summary>
    /// 操作类型 [0:我的报告,1:待审核报告, 2:未审核报告管理]
    /// </summary>
    public int? OperationType { get; set; }
    /// <summary>
    /// 用户ID
    /// </summary>
    public int? UserId { get; set; }
    /// <summary>
    /// 用户姓名
    /// </summary>
    public string UserName { get; set; }
    /// <summary>
    /// 用户姓名
    /// </summary>
    public string ReportContextId { get; set; }
    /// <summary>
    /// 打印次数
    /// </summary>
    public int? PrintCount { get; set; }

    /// <summary>
    /// 打印次数
    /// </summary>
    public EnumAuditLevel? EnumAuditLevel { get; set; }

    /// <summary>
    /// 报告医生
    /// </summary>
    public string ReportDoctorName { get; set; }

}
public partial class SearchCondition
{
    public static implicit operator SearchCondition(HIPS.HSPS.Interface.Persistence.Web.SearchReport source)
    {
        if (source != null)
        {
            var target = new SearchCondition()
            {
                PageIndex = source.QueryPage.PageIndex,
                PageSize = source.QueryPage.PageSize,
                TotalCount = source.QueryPage.PageTotal,
            };

            return target;
        }
        return null;
    }

    public static implicit operator HIPS.HSPS.Interface.Persistence.Web.SearchReport(SearchCondition source)
    {
        if (source != null)
        {
            HIPS.HSPS.Interface.Persistence.Web.EnumDiscernStatus? discernStatus = null;
            HIPS.HSPS.Interface.Persistence.Web.EnumReportStatus? reportStatus = null;
            if (source.DiscernStatus != null)
            {
                discernStatus = (source.DiscernStatus).ParseEnum<HIPS.HSPS.Interface.Persistence.Web.EnumDiscernStatus>(HIPS.HSPS.Interface.Persistence.Web.EnumDiscernStatus.UnDiscern);
            }
            if (source.ReportStatus != null)
            {
                reportStatus = (source.ReportStatus).ParseEnum<HIPS.HSPS.Interface.Persistence.Web.EnumReportStatus>(HIPS.HSPS.Interface.Persistence.Web.EnumReportStatus.Normal);
            }
            HIPS.HSPS.Interface.Persistence.Web.EnumPrintStatus? printStatus = null;
            if (source.PrintStatus != null)
            {
                printStatus = (source.PrintStatus).ParseEnum<HIPS.HSPS.Interface.Persistence.Web.EnumPrintStatus>(HIPS.HSPS.Interface.Persistence.Web.EnumPrintStatus.Unprint);
            }
            HIPS.HSPS.Interface.Persistence.Web.EnumFileType? fileType = null;
            if (source.FileType != null)
            {
                fileType = (source.FileType).ParseEnum<HIPS.HSPS.Interface.Persistence.Web.EnumFileType>(HIPS.HSPS.Interface.Persistence.Web.EnumFileType.Report);
            }

            HIPS.HSPS.Interface.Persistence.Web.EnumAuditLevel? enumAuditLevel = null;
            if (source.EnumAuditLevel != null)
            {
                enumAuditLevel = (source.EnumAuditLevel).ParseEnum<HIPS.HSPS.Interface.Persistence.Web.EnumAuditLevel>(HIPS.HSPS.Interface.Persistence.Web.EnumAuditLevel.UnAudit);
            }

            var target = new HIPS.HSPS.Interface.Persistence.Web.SearchReport()
            {
                DiscernStatus = discernStatus,
                PrintStatus = printStatus,
                QueryPage = new HIPS.HSPS.DataContract.QueryPage() { PageIndex = source.PageIndex, PageSize = source.PageSize },
                TimeEnd = source.TimeEnd,
                TimeBegin = source.TimeBegin,
                Conditions = source.Conditions,
                DepartmentIdList = source.DepartmentIds,
                IsDesc = source.IsDesc,
                IsHistory = source.IsHistory,
                ReportTypeIdList = source.ReportTypeIds,
                SortItems = source.SortItems,
                IsMatch = source.IsMatch,
                FileType = fileType,
                ExaminationCompany = source.ExaminationCompany,
                ExaminationDepartment = source.ExaminationDepartment,
                IDNO = source.IDNO,
                ReportStatus = reportStatus,
                ClinicalDepartments = source.ClinicalDepartments,
                HospitalAreas = source.HospitalAreas,
                HospitalNo = source.HospitalNo,
                PatientAreas = source.PatientAreas,
                OperationType = source.OperationType,
                UserID = source.UserId,
                EnumAuditLevel = enumAuditLevel,
                ReportDoctorName = source.ReportDoctorName,
            };

            return target;
        }
        return null;
    }
}
