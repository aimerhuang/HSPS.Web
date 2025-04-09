using HIPS.HSPS.Interface.Persistence.Web;
using HSPS.Web.Repository;
using HSPS.Web.IServices;
using System.Reflection;
using HSPS.Web.Services.BASE;


namespace HSPS.Web.Services;

public class ReportTypeServices : BaseServices<ReportType>, IReportTypeServices
{
    /// <summary>
    /// 添加报告类别
    /// </summary>
    /// <param name="reportType"></param>
    /// <returns></returns>
    public void AddReportType(Model.Models.Extensions.ReportType reportType)
    {
        if (reportType != null)
        {
            var pSize = reportType.PrintSize;
            if (pSize == "Unknow")
            {
                pSize = "A4";
            }
            var request = new AddReportType()
            {
                DepartmentID = reportType.DepartmentID,
                ReportTypeName = reportType.Name,
                PrintSolution = (reportType.PrintSolution).ParseEnum<EnumPrintSolution>(EnumPrintSolution.Auto_Work),
                RelationID = reportType.RelationID,
                ParseRuleType = (EnumParseRuleType)reportType.ParseRuleType,
                PlatformReportType = reportType.PlatformReportType,
                PrintParam = new PrintParam()
                {
                    IsColorful = reportType.IsColorful,
                    Media = reportType.Media,
                    PrintSize = pSize,
                    Quality = (reportType.PintQuality).ParseEnum<EnumQuality>(EnumQuality.Low)
                },
                IsAudit = reportType.IsAudit,
                TimeoutHour = reportType.TimeoutHour,
                EnumAuditLevel = (reportType.AuditLevel).ParseEnum<HIPS.HSPS.Interface.Persistence.Web.EnumAuditLevel>(HIPS.HSPS.Interface.Persistence.Web.EnumAuditLevel.FirstAudit),
                AuditConditions = reportType.AuditConditions == null ? null : reportType.AuditConditions.CastExtension<AuditConditions>(),
                BusinessType = reportType.BusinessType,
                MecreportType = reportType.MECReportType,
                GetFilmMode = reportType.GetFilmMode
            };

            InterfaceObjectHelper.CallMethod<AddReportType, ReportType>(RemotingInterfaceService.MtReportTypeService.AddReportType, request);
        }
    }

    /// <summary>
    /// 删除报告类别
    /// </summary>
    /// <param name="reportTypeID"></param>
    /// <returns></returns>
    public void DeleteReportType(int reportTypeID)
    {
        InterfaceObjectHelper.CallMethod<int, Missing>(RemotingInterfaceService.MtReportTypeService.DeleteReportType, reportTypeID);
    }

    /// <summary>
    /// 根据科室获取所有报告类别
    /// </summary>
    /// <param name="departmentid"></param>
    /// <returns></returns>
    public async Task<List<ReportType>> GetReportTypesByDepartment(int departmentid)
    {
        return await base.Query(u => u.DepartmentID == departmentid);
    }

    /// <summary>
    /// 获取所有报告列表
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Model.Models.Extensions.ReportType> GetReportTypes()
    {
        IEnumerable<ReportType> result = InterfaceObjectHelper.CallMethod<DBNull, IEnumerable<ReportType>>(RemotingInterfaceService.MtReportTypeService.GetReportTypes, null);//Missing.Value
        if (result != null && result.Count() > 0)
        {
            return result.CastExtension<Model.Models.Extensions.ReportType>();
            //return result.HIPS.HSPS.Common.CastExtension<Model.Models.ReportType>();
        }
        return new List<Model.Models.Extensions.ReportType>().AsEnumerable();
    }

    /// <summary>
    /// 修改报告类别
    /// </summary>
    /// <param name="reportType"></param>
    /// <returns></returns>
    public void UpdateReportType(Model.Models.Extensions.ReportType reportType)
    {
        if (reportType != null)
        {
            var pSize = reportType.PrintSize;
            if (pSize == "Unknow")
            {
                pSize = "A4";
            }
            var request = new HIPS.HSPS.Interface.Persistence.Web.UpdateReportType()
            {
                ReportTypeID = reportType.ID,
                ReportTypeName = reportType.Name,
                //PrintSolution = (reportType.PrintSolution).ParseEnum<EnumPrintSolution>(EnumPrintSolution.Auto_Work),
                RelationID = reportType.RelationID,
                PlatformReportType = reportType.PlatformReportType,
                PrintParam = new PrintParam()
                {
                    IsColorful = reportType.IsColorful,
                    Media = reportType.Media,
                    PrintSize = pSize,
                    Quality = (reportType.PintQuality).ParseEnum<EnumQuality>(EnumQuality.Low)
                },
                IsAudit = reportType.IsAudit,
                TimeoutHour = reportType.TimeoutHour,
                EnumAuditLevel = (reportType.AuditLevel).ParseEnum<HIPS.HSPS.Interface.Persistence.Web.EnumAuditLevel>(HIPS.HSPS.Interface.Persistence.Web.EnumAuditLevel.FirstAudit),
                AuditConditions = reportType.AuditConditions == null ? null : reportType.AuditConditions.CastExtension<AuditConditions>(),
                BusinessType = reportType.BusinessType,
                MecreportType = reportType.MECReportType,
                GetFilmMode = reportType.GetFilmMode
            };

            InterfaceObjectHelper.CallMethod<UpdateReportType, Missing>(RemotingInterfaceService.MtReportTypeService.UpdateReportType, request);
        }
    }

    /// <summary>
    /// 根据科室ID集合获取需要审核的报告
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Model.Models.Extensions.ReportType> GetAuditingReportTypesByDepartment(List<int> departmentIDList)
    {
        System.Collections.Generic.List<int> coverImageIDList = departmentIDList;
        IEnumerable<ReportType> result = InterfaceObjectHelper.CallMethod<System.Collections.Generic.List<int>, IEnumerable<ReportType>>(RemotingInterfaceService.MtReportTypeService.GetAuditingReportTypesByDepartment, coverImageIDList);
        if (result != null && result.Count() > 0)
        {
            return result.CastExtension<Model.Models.Extensions.ReportType>();
        }
        return null;
    }

    /// <summary>
    /// 查询报告类别名称
    /// </summary>
    /// <param name="reporttypeid"></param>
    /// <returns></returns>
    public async Task<List<ReportType>> GetReportTypeByID(int reporttypeid)
    {
        return await base.Query(u => u.ID == reporttypeid);

    }
}

