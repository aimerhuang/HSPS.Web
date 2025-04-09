using HIPS.HSPS.Interface.Common;
using HIPS.HSPS.DepartmentService.Interface.ParseImage;
using HIPS.HSPS.Interface.Persistence.Web;
using HIPS.HSPS.Interface.PrintProxy.Web;
using System.ServiceModel;
using YiBan.LoggerServer.Contracts;
using HIPS.HSPS.Interface.Persistence.Rmp;
//using Yiban.SHMedicalRecord.Interface.Web.Codemaps;
//using Yiban.ServiceProxy;
//using Yiban.SHMedicalRecord.Common.Services;
//using Yiban.SHMedicalRecord.Interface.Web.EMR_Reimburses;
//using Yiban.SHMedicalRecord.Interface.Web.EMR_Categorys;
//using YiBan.HSPS.Main.Framework.IOC;
//using YiBan.SHMedicalExamination.Application.MECReportsFromDepartment;
//using YiBan.SHMedicalExamination.Application.MECReports;
//using YiBan.SHMedicalExamination.Application.MECCovers;
//using YiBan.HSPS.Main.Utility;
namespace HSPS.Web.Repository;

/// <summary>
/// Romting远程接口对象
/// </summary>
public class RemotingInterfaceService
{
    static IMtReportTypeService _mtReportTypeService;
    
    public static IMtReportTypeService MtReportTypeService
    {
        get
        {
            return CreateBusinessInterfaceService<IMtReportTypeService>(_mtReportTypeService);
        }
    }
    /// <summary>
    /// 创建远程接口对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="interfaceService"></param>
    /// <returns></returns>
    private static bool NotExistInterfaceService<T>(T interfaceService)
    {
        return interfaceService == null
                           || ((ICommunicationObject)interfaceService).State == CommunicationState.Closing
                           || ((ICommunicationObject)interfaceService).State == CommunicationState.Closed
                           || ((ICommunicationObject)interfaceService).State == CommunicationState.Faulted;
    }

    /// <summary>
    /// 创建业务服务远程接口对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="interfaceService"></param>
    /// <returns></returns>
    private static T CreateBusinessInterfaceService<T>(T interfaceService)
    {
        if (NotExistInterfaceService<T>(interfaceService))
        {
            interfaceService = InterfaceObjectHelper.GetBusinessServiceInterfaceObject<T>();
        }
        return interfaceService;
    }

    /// <summary>
    /// 创建远放射科室程接口对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="interfaceService"></param>
    /// <returns></returns>
    private static T CreateRadiologyInterfaceService<T>(T interfaceService)
    {
        if (NotExistInterfaceService<T>(interfaceService))
        {
            interfaceService = InterfaceObjectHelper.GetRadiologyServiceInterfaceObject<T>();
        }
        return interfaceService;
    }

    /// <summary>
    /// 创建打印代理远程接口对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="interfaceService"></param>
    /// <returns></returns>
    private static T CreatePrintProxyInterfaceService<T>(T interfaceService)
    {
        if (NotExistInterfaceService<T>(interfaceService))
        {
            interfaceService = InterfaceObjectHelper.GetPrintProxyServiceInterfaceObject<T>();
        }
        return interfaceService;
    }

    /// <summary>
    /// 创建日志服务接口对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="interfaceService"></param>
    /// <returns></returns>
    private static T CreateLoggerInterfaceService<T>(T interfaceService)
    {
        if (NotExistInterfaceService<T>(interfaceService))
        {
            interfaceService = InterfaceObjectHelper.GetLoggerServiceInterfaceObject<T>();
        }
        return interfaceService;
    }

    /// <summary>
    /// 创建业务服务远程接口对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="interfaceService"></param>
    /// <returns></returns>
    private static T CreateBusinessInterfaceService<T>(T interfaceService, TimeSpan sendTimeout)
    {
        if (NotExistInterfaceService<T>(interfaceService))
        {
            interfaceService = InterfaceObjectHelper.GetBusinessServiceInterfaceObject<T>(sendTimeout);
        }
        return interfaceService;
    }

    /// <summary>
    /// 创建远放射科室程接口对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="interfaceService"></param>
    /// <returns></returns>
    private static T CreateRadiologyInterfaceService<T>(T interfaceService, TimeSpan sendTimeout)
    {
        if (NotExistInterfaceService<T>(interfaceService))
        {
            interfaceService = InterfaceObjectHelper.GetRadiologyServiceInterfaceObject<T>(sendTimeout);
        }
        return interfaceService;
    }

    /// <summary>
    /// 创建打印代理远程接口对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="interfaceService"></param>
    /// <returns></returns>
    private static T CreatePrintProxyInterfaceService<T>(T interfaceService, TimeSpan sendTimeout)
    {
        if (NotExistInterfaceService<T>(interfaceService))
        {
            interfaceService = InterfaceObjectHelper.GetPrintProxyServiceInterfaceObject<T>(sendTimeout);
        }
        return interfaceService;
    }

    /// <summary>
    /// 创建日志服务接口对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="interfaceService"></param>
    /// <param name="sendTimeoutMinute"></param>
    /// <returns></returns>
    private static T CreateLoggerInterfaceService<T>(T interfaceService, TimeSpan sendTimeout)
    {
        if (NotExistInterfaceService<T>(interfaceService))
        {
            interfaceService = InterfaceObjectHelper.GetLoggerServiceInterfaceObject<T>(sendTimeout);
        }
        return interfaceService;
    }

    static IMtConfigService _mtConfigService;
    public static IMtConfigService MtConfigService
    {
        get
        {
            return CreateBusinessInterfaceService<IMtConfigService>(_mtConfigService);
        }
    }

    static IMtCodeMap _mtCodeMapService;
    public static IMtCodeMap MtCodeMapService
    {
        get
        {
            return CreateBusinessInterfaceService<IMtCodeMap>(_mtCodeMapService);
        }
    }

    static IMtDepartmentService _mtDepartmentService;
    public static IMtDepartmentService MtDepartmentService
    {
        get
        {
            return CreateBusinessInterfaceService<IMtDepartmentService>(_mtDepartmentService);
        }
    }

    static IMtAutoPrintBindService _mtAutoPrintBindService;
    public static IMtAutoPrintBindService MtAutoPrintBindService
    {
        get
        {
            return CreateBusinessInterfaceService<IMtAutoPrintBindService>(_mtAutoPrintBindService);
        }
    }

    static IMtSignatureService _mtSignatureService;
    public static IMtSignatureService MtSignatureService
    {
        get
        {
            return CreateBusinessInterfaceService<IMtSignatureService>(_mtSignatureService);
        }
    }

    static IMtParseRuleService _reportParseRuleService;
    public static IMtParseRuleService ReportParseRuleService
    {
        get
        {
            return CreateBusinessInterfaceService<IMtParseRuleService>(_reportParseRuleService);
        }
    }

    static IMtReportService _mtReportService;
    public static IMtReportService MtReportService
    {
        get
        {
            return CreateBusinessInterfaceService<IMtReportService>(_mtReportService);
        }
    }

    static IMtPrintSolutionService _mtPrintSolutionService;
    public static IMtPrintSolutionService MtPrintSolutionService
    {
        get
        {
            return CreateBusinessInterfaceService<IMtPrintSolutionService>(_mtPrintSolutionService);
        }
    }

    static IMtTerminalService _mtTerminalService;
    public static IMtTerminalService MtTerminalService
    {
        get
        {
            return CreateBusinessInterfaceService<IMtTerminalService>(_mtTerminalService);
        }
    }
    static IMtPrintRecordService _mtPrintRecordService;
    public static IMtPrintRecordService MtPrintRecordService
    {
        get
        {
            return CreateBusinessInterfaceService<IMtPrintRecordService>(_mtPrintRecordService);
        }
    }
    static IMtStatisticsService _mtStatisticsService;
    public static IMtStatisticsService MtStatisticsService
    {
        get
        {
            return CreateBusinessInterfaceService<IMtStatisticsService>(_mtStatisticsService);
        }
    }

    static ILayoutService _layoutService;
    public static ILayoutService LayoutService
    {
        get
        {
            return CreateRadiologyInterfaceService<ILayoutService>(_layoutService);
        }
    }

    static IParseRuleService _filmParseRuleService;
    public static IParseRuleService FilmParseRuleService
    {
        get
        {
            return CreateRadiologyInterfaceService<IParseRuleService>(_filmParseRuleService);
        }
    }

    static IConfigService _configService;
    public static IConfigService ConfigService
    {
        get
        {
            return CreateBusinessInterfaceService<IConfigService>(_configService);
        }
    }

    static IWebEntityService _entityService;
    public static IWebEntityService EntityService
    {
        get
        {
            return CreateBusinessInterfaceService<IWebEntityService>(_entityService);
        }
    }

    static INwPrintService _nwPrintService;
    public static INwPrintService NwPrintService
    {
        get
        {
            return CreatePrintProxyInterfaceService<INwPrintService>(_nwPrintService);
        }
    }
    static IMtQRCodeService _mtQRCodeService;
    public static IMtQRCodeService QRCodeService
    {
        get
        {
            return CreateBusinessInterfaceService<IMtQRCodeService>(_mtQRCodeService);
        }
    }
    static IMtPermissionControlService _mtPermissionControlService;
    public static IMtPermissionControlService MtPermissionControlService
    {
        get
        {
            return CreateBusinessInterfaceService<IMtPermissionControlService>(_mtPermissionControlService);
        }
    }
    static ILoggerServer _loggerService;
    public static ILoggerServer LoggerServer
    {
        get
        {
            return CreateLoggerInterfaceService<ILoggerServer>(_loggerService);
        }
    }
    static IMonitorAlarmService _monitorAlarmService;
    public static IMonitorAlarmService MonitorAlarmService
    {
        get
        {
            return CreateBusinessInterfaceService<IMonitorAlarmService>(_monitorAlarmService);
        }
    }
    static IMtClinicalDepartmentService _clinicalDepartment;
    public static IMtClinicalDepartmentService MtClinicalDepartment
    {
        get
        {
            return CreateBusinessInterfaceService<IMtClinicalDepartmentService>(_clinicalDepartment);
        }
    }
    static IMtOperationLogService _operationLogService;
    public static IMtOperationLogService OperationLogService
    {
        get
        {
            return CreateBusinessInterfaceService<IMtOperationLogService>(_operationLogService);
        }
    }
    static IMtTerminalPartService _terminalManagementService;
    public static IMtTerminalPartService TerminalPartsManagementService
    {
        get
        {
            return CreateBusinessInterfaceService<IMtTerminalPartService>(_terminalManagementService);
        }
    }

    static IMtEquipmentService _equipmentService = null;
    public static IMtEquipmentService EquipmentService
    {
        get
        {
            return CreateBusinessInterfaceService<IMtEquipmentService>(_equipmentService);
        }
    }
    static IMtMenuManageService _menuManageService;
    public static IMtMenuManageService MenuManageService
    {
        get
        {
            return CreateBusinessInterfaceService<IMtMenuManageService>(_menuManageService);
        }
    }

    static IMtStationService _mtStationService;
    public static IMtStationService MtStationService
    {
        get
        {
            return CreateBusinessInterfaceService<IMtStationService>(_mtStationService);
        }
    }
    /// <summary>
    /// 体检服务：报告接收
    /// </summary>
    //static IMECReportFromDepartmentAppService _mecReportFromDepartmentAppService;
    //public static IMECReportFromDepartmentAppService MECReportFromDepartmentAppService
    //{
    //    get
    //    {
    //        string remoteAddress = string.Format("net.tcp://{0}:{1}/{2}", ConfigSectionHelper.GetExaminationRemoteServerIp(), ConfigSectionHelper.GetExaminationRemotePort(), "MECReportFromDepartmentAppService");
    //        return ServiceCreator.Create<IMECReportFromDepartmentAppService>(new Uri(remoteAddress));
    //        //return CreateMECInterfaceService<IMECReportFromDepartmentAppService>(_mecReportFromDepartmentAppService);
    //    }
    //}
    /// <summary>
    /// 体检服务：报告处理
    /// </summary>
    //static IMECReportAppService _mecReportAppService;
    //public static IMECReportAppService MECReportAppService
    //{
    //    get
    //    {
    //        string remoteAddress = string.Format("net.tcp://{0}:{1}/{2}", ConfigSectionHelper.GetExaminationRemoteServerIp(), ConfigSectionHelper.GetExaminationRemotePort(), "MECReportAppService");
    //        return ServiceCreator.Create<IMECReportAppService>(new Uri(remoteAddress));
    //        //return CreateMECInterfaceService<IMECReportFromDepartmentAppService>(_mecReportFromDepartmentAppService);
    //    }
    //}

    static IMtVersionControlService _mtVersionControlService;
    public static IMtVersionControlService MtVersionControlService
    {
        get
        {
            return CreateBusinessInterfaceService<IMtVersionControlService>(_mtVersionControlService);
        }
    }
    //static IMECCoverAppService _mecCoverAppService;

    //public static IMECCoverAppService MECCoverAppService
    //{
    //    get
    //    {
    //        string remoteAddress = string.Format("net.tcp://{0}:{1}/{2}", ConfigSectionHelper.GetExaminationRemoteServerIp(), ConfigSectionHelper.GetExaminationRemotePort(), "MECCoverAppService");
    //        return ServiceCreator.Create<IMECCoverAppService>(new Uri(remoteAddress));
    //        //return CreateMECInterfaceService<IMECReportFromDepartmentAppService>(_mecReportFromDepartmentAppService);
    //    }
    //}
}
