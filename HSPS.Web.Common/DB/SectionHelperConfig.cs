
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Serilog;

namespace HSPS.Web.Common.DB;
public class SectionHelperConfig
{
    private static string _remoteServerIp = string.Empty;
    private static string _remoteServerPort = string.Empty;
    private static string _printProxyRemoteServerIp = string.Empty;
    private static string _printProxyRemoteServerPort = string.Empty;
    private static string _radiologyRemoteServerIp = string.Empty;
    private static string _radiologyRemoteServerPort = string.Empty;
    private static string _loggerRemoteServerIp = string.Empty;
    private static string _loggerRemoteServerPort = string.Empty;
    private static string _pdf2JpegLib = "Aspose";

    private static string _reportFilePath = string.Empty;
    private static string _commentFolderPath = string.Empty;
    private static string _signatureFilePath = string.Empty;
    private static string _rRCodeFilePath = string.Empty;
    private static string _downloadFilePath = string.Empty;
    private static string _reportFileConvertorPath = string.Empty;
    private static int _maxFilmCount = 20;
    private static int _wCFDataMaxLength = int.MaxValue;
    private static string _superAdministrator = string.Empty;

    private static readonly TimeSpan DEFAULT_SEND_TIMEOUT = new TimeSpan(0, 10, 0);

    /// <summary>
    /// 获取打印代理远程服务器IP
    /// </summary>
    /// <returns></returns>
    public static string GetPrintProxyRemoteServerIp()
    {
        return AppSettings.app(new string[] { "PrintProxy", "Host" });
        //ServerConfigManager.Instance.GetConfigValue("PrintProxy", "Host", "192.168.29.212");
    }

    /// <summary>
    /// 获取打印代理远程服务器端口
    /// </summary>
    /// <returns></returns>
    public static string GetPrintProxyRemotePort()
    {
        return AppSettings.app(new string[] { "PrintProxy", "Port" });
        //ServerConfigManager.Instance.GetConfigValue("PrintProxy", "Port", "53000");
    }

    /// <summary>
    /// 获取全院远程服务器IP
    /// </summary>
    /// <returns></returns>
    public static string GetRemoteServerIp()
    {
        return AppSettings.app(new string[] { "DataService", "Host" });
        //ServerConfigManager.Instance.GetConfigValue("DataService", "Host", "192.168.29.212");
    }

    /// <summary>
    /// 获取全院远程服务器端口
    /// </summary>
    /// <returns></returns>
    public static string GetRemotePort()
    {
        return AppSettings.app(new string[] { "DataService", "Port" });
        //ServerConfigManager.Instance.GetConfigValue("DataService", "Port", "52000");
    }
    /// <summary>
    /// 获取文件服务器IP
    /// </summary>
    /// <returns></returns>
    public static string GetFileServerIp()
    {
        return AppSettings.app(new string[] { "FileServer", "Host" });
        //ServerConfigManager.Instance.GetConfigValue("FileServer", "Host", "192.168.29.212");
    }

    /// <summary>
    /// 获取文件服务器端口
    /// </summary>
    /// <returns></returns>
    public static string GetFileServerPort()
    {
        return AppSettings.app(new string[] { "FileServer", "Port" });
        //ServerConfigManager.Instance.GetConfigValue("FileServer", "Port", "58000");
    }

    /// <summary>
    /// 获取放射放射服务器IP
    /// </summary>
    /// <returns></returns>
    public static string GetRadiologyRemoteServerIp()
    {
        return AppSettings.app(new string[] { "WebManage", "RadiologyServerHost" });
        //ServerConfigManager.Instance.GetConfigValue("WebManage", "RadiologyServerHost", "192.168.29.212");
    }

    /// <summary>
    /// 获取放射远程服务器端口
    /// </summary>
    /// <returns></returns>
    public static string GetRadiologyRemotePort()
    {
        return AppSettings.app(new string[] { "WebManage", "RadiologyServerPort" });
        //ServerConfigManager.Instance.GetConfigValue("WebManage", "RadiologyServerPort", "41000");
    }

    /// <summary>
    /// 获取放射远程服务器端口
    /// </summary>
    /// <returns></returns>
    public static string GetRadiologyDepartmentName()
    {
        return AppSettings.app(new string[] { "WebManage", "RadiologyServerPort" });//ServerConfigManager.Instance.GetConfigValue("LoggerServer", "Host", "192.168.29.212");
    }

    /// <summary>
    /// 获取病案服务IP
    /// </summary>
    /// <returns></returns>
    public static string GetMedicalRecordServiceIP()
    {
        return AppSettings.app(new string[] { "WebManage", "MedicalRecordServiceHost" });//ServerConfigManager.Instance.GetConfigValue("MedicalRecordService", "Host", "192.168.29.212");
    }

    /// <summary>
    /// 获取病案服务端口
    /// </summary>
    /// <returns></returns>
    public static string GetMedicalRecordServicePort()
    {
        return AppSettings.app(new string[] { "WebManage", "MedicalRecordServicePort" });//ServerConfigManager.Instance.GetConfigValue("MedicalRecordService", "Port", "51000");
    }

    /// <summary>
    /// 获取网关服务Url
    /// </summary>
    /// <returns></returns>
    public static string GetGatewayServiceUrl()
    {
        return AppSettings.app(new string[] { "PrintProxy", "Host" });//ServerConfigManager.Instance.GetConfigValue("PrintProxy", "Host", "192.168.29.212");
    }
    /// <summary>
    /// 获取网关服务端口
    /// </summary>
    /// <returns></returns>
    public static string GetGatewayServicePort()
    {
        return AppSettings.app(new string[] { "PrintProxy", "Port" });//ServerConfigManager.Instance.GetConfigValue("PrintProxy", "Port", "53000");
    }

    /// <summary>
    /// 获取网关服务前缀
    /// </summary>
    /// <returns></returns>
    public static string GetGatewayServicePrefix()
    {
        return AppSettings.app(new string[] { "PrintProxy", "Prefix" });//ServerConfigManager.Instance.GetConfigValue("PrintProxy", "Prefix", "Api");
    }

    /// <summary>
    /// 获取日志服务器IP
    /// </summary>
    /// <returns></returns>
    public static string GetLoggerRemoteServerIp()
    {
        return AppSettings.app(new string[] { "LoggerServer", "Host" });//ServerConfigManager.Instance.GetConfigValue("LoggerServer", "Host", "192.168.29.212");
    }

    /// <summary>
    /// 获取日志服务器端口
    /// </summary>
    /// <returns></returns>
    public static string GetLoggerRemoteServerPort()
    {
        return AppSettings.app(new string[] { "LoggerServer", "Port" });//ServerConfigManager.Instance.GetConfigValue("LoggerServer", "Port", "55000");
    }
    /// <summary>
    /// 获取体检服务IP
    /// </summary>
    /// <returns></returns>
    public static string GetExaminationRemoteServerIp()
    {
        return AppSettings.app(new string[] { "MedicalExaminationService", "Host" });//ServerConfigManager.Instance.GetConfigValue("MedicalExaminationService", "Host", "192.168.29.212");
    }

    /// <summary>
    /// 获取体检服务远程服务器端口
    /// </summary>
    /// <returns></returns>
    public static string GetExaminationRemotePort()
    {
        return AppSettings.app(new string[] { "MedicalExaminationService", "Port" });//ServerConfigManager.Instance.GetConfigValue("MedicalExaminationService", "Port", "50001");
    }

    /// <summary>
    /// 获取日志服务器上传时间间隔
    /// </summary>
    /// <returns></returns>
    public static string GetLoggerRemoteServerUploadLevel()
    {
        return AppSettings.app(new string[] { "WebManage", "RadiologyServerPort" });//ServerConfigManager.Instance.GetConfigValue("WebManage", "LoggerLevel", "Info");
    }

    /// <summary>
    /// 获取日志服务器上传时间间隔
    /// </summary>
    /// <returns></returns>
    public static int GetLoggerRemoteServerUploadInterval()
    {
        return AppSettings.app(new string[] { "WebManage", "UploadInterval" }).ObjToInt();//ServerConfigManager.Instance.GetConfigValue("WebManage", "UploadInterval").AsTargetType(10);
    }

    /// <summary>
    /// 获取报告文件存放的路径
    /// </summary>
    /// <returns></returns>
    public static string GetReportFilePath()
    {
        if (string.IsNullOrEmpty(_reportFilePath))
        {
            _reportFilePath = AppSettings.app(new string[] { "WebManage", "ReportFilePath" });//ConfigurationManager.AppSettings["ReportFilePath"];
        }
        return _reportFilePath;
    }

    /// <summary>
    /// 获取签章文件存放的路径
    /// </summary>
    /// <returns></returns>
    public static string GetSignatureFilePath()
    {
        if (string.IsNullOrEmpty(_signatureFilePath))
        {
            _signatureFilePath = AppSettings.app(new string[] { "WebManage", "SignatureFilePath" });//ConfigurationManager.AppSettings["SignatureFilePath"];
        }
        return _signatureFilePath;
    }

    /// <summary>
    /// 获取二维码文件存放的路径
    /// </summary>
    /// <returns></returns>
    public static string GetQRCodeFilePath()
    {
        if (string.IsNullOrEmpty(_rRCodeFilePath))
        {
            _rRCodeFilePath = AppSettings.app(new string[] { "WebManage", "QRCodeFilePath" });//ConfigurationManager.AppSettings["QRCodeFilePath"];
        }
        return _rRCodeFilePath;
    }

    /// <summary>
    /// 获取导出临时文件夹路径
    /// </summary>
    /// <returns></returns>
    public static string GetDownloadFilePath()
    {
        if (string.IsNullOrEmpty(_downloadFilePath))
        {
            _downloadFilePath = AppSettings.app(new string[] { "WebManage", "DownloadFilePath" });//ConfigurationManager.AppSettings["DownloadFilePath"];
        }
        return _downloadFilePath;
    }

    /// <summary>
    /// 加载未识别的胶片时，最多加载张数
    /// </summary>
    /// <returns></returns>
    public static int GetFlimListMaxCount()
    {

        if (AppSettings.app(new string[] { "WebManage", "FlimListMaxCount" }).IsNotEmptyOrNull())//ConfigurationManager.AppSettings["FlimListMaxCount"])
            _maxFilmCount = AppSettings.app(new string[] { "WebManage", "FlimListMaxCount" }).ObjToInt();
        else
            _maxFilmCount = 20;
        return _maxFilmCount;
    }

    /// <summary>
    /// 获取WCF通信最大长度
    /// </summary>
    /// <returns></returns>
    public static int GetWCFDataMaxLength()
    {
        if (!string.IsNullOrEmpty(AppSettings.app(new string[] { "WebManage", "WCFDataMaxLength" })))//ConfigurationManager.AppSettings["WCFDataMaxLength"]
        {
            _wCFDataMaxLength = AppSettings.app(new string[] { "WebManage", "WCFDataMaxLength" }).ObjToInt();
        }
        return _wCFDataMaxLength;
    }

    /// <summary>
    /// 日志服务默认超时时间
    /// </summary>
    /// <returns></returns>
    public static TimeSpan GetLoggerServiceTimeout()
    {
        try
        {
            return TimeSpan.Parse(AppSettings.app(new string[] { "WebManage", "LoggerServiceTimeout" })); //ConfigurationManager.AppSettings["LoggerServiceTimeout"]
        }
        catch (Exception ex)
        {
            Log.Error("日志服务默认超时时间转换失败", ex);
        }
        return DEFAULT_SEND_TIMEOUT;
    }

    public static TimeSpan GetMECServiceTimeout()
    {
        try
        {
            return TimeSpan.Parse(AppSettings.app(new string[] { "WebManage", "MECServiceTimeout" }));//ConfigurationManager.AppSettings["MECServiceTimeout"]
        }
        catch (Exception ex)
        {
            Log.Error("体检服务默认超时时间转换失败", ex);
        }
        return DEFAULT_SEND_TIMEOUT;
    }

    /// <summary>
    /// 业务服务默认超时时间
    /// </summary>
    /// <returns></returns>
    public static TimeSpan GetDataServiceTimeout()
    {
        try
        {
            return TimeSpan.Parse(AppSettings.app(new string[] { "WebManage", "DataServiceTimeout" }));//ConfigurationManager.AppSettings["DataServiceTimeout"]
        }
        catch (Exception ex)
        {
            Log.Error("业务服务默认超时时间转换失败", ex);
        }
        return DEFAULT_SEND_TIMEOUT;
    }

    /// <summary>
    /// 打印代理默认超时时间
    /// </summary>
    /// <returns></returns>
    public static TimeSpan GetPrintProxyTimeout()
    {
        try
        {
            return TimeSpan.Parse(AppSettings.app(new string[] { "WebManage", "PrintProxyTimeout" }));//ConfigurationManager.AppSettings["PrintProxyTimeout"]
        }
        catch (Exception ex)
        {
            Log.Error("打印代理默认超时时间转换失败", ex);
        }
        return DEFAULT_SEND_TIMEOUT;
    }

    /// <summary>
    /// 放射科室默认超时时间
    /// </summary>
    /// <returns></returns>
    public static TimeSpan GetRadiologyDepartmentTimeout()
    {
        try
        {
            return TimeSpan.Parse(AppSettings.app(new string[] { "WebManage", "RadiologyDepartmentTimeout" }));//ConfigurationManager.AppSettings["RadiologyDepartmentTimeout"]
        }
        catch (Exception ex)
        {
            Log.Error("放射科室默认超时时间转换失败", ex);
        }
        return DEFAULT_SEND_TIMEOUT;
    }

    /// <summary>
    /// xps/pdf转jpeg/txt文件工具的路径
    /// </summary>
    /// <returns></returns>
    //public static string GetReportFileConvertorPath()
    //{
    //    if (string.IsNullOrEmpty(_reportFileConvertorPath))
    //    {
    //        _reportFileConvertorPath = ConfigurationManager.AppSettings["ReportFileConvertorPath"];
    //    }
    //    return _reportFileConvertorPath;
    //}

    /// <summary>
    /// 超级管理员的用户名
    /// </summary>
    /// <returns></returns>
    public static string GetsSuperAdministrator()
    {
        if (string.IsNullOrEmpty(_superAdministrator))
        {
            _superAdministrator = AppSettings.app(new string[] { "WebManage", "SuperAdministrator" });//ConfigurationManager.AppSettings["SuperAdministrator"];
        }
        return _superAdministrator;
    }

    /// <summary>
    /// PDF转图片组件
    /// </summary>
    /// <returns></returns>
    public static string GetsPDF2JpegLib()
    {

        _pdf2JpegLib = AppSettings.app(new string[] { "WebManage", "PDF2JpegLib" }); //ConfigurationManager.AppSettings["PDF2JpegLib"];

        return _pdf2JpegLib;
    }

    /// <summary>
    /// 定时删除临时缓存文件的时间点（时：分：秒）
    /// </summary>
    /// <returns></returns>
    public static string GetDeleteTempFilesTime()
    {
        return AppSettings.app(new string[] { "WebManage", "DeleteTempFilesTime" });//ConfigurationManager.AppSettings["DeleteTempFilesTime"];
    }

    /// <summary>
    /// 获取报告文件存放的路径
    /// </summary>
    /// <returns></returns>
    public static string GetCommentFolderPath()
    {
        if (string.IsNullOrEmpty(_commentFolderPath))
        {
            _commentFolderPath = AppSettings.app(new string[] { "WebManage", "CommentFilePath" });//ConfigurationManager.AppSettings["CommentFilePath"];
        }
        return _commentFolderPath;
    }

    /// <summary>
    /// 获取弹窗开关
    /// </summary>
    /// <returns></returns>
    public static string GetIsOpen()
    {
        if (string.IsNullOrEmpty(_commentFolderPath))
        {
            _commentFolderPath = AppSettings.app(new string[] { "WebManage", "IsOpen" });//ConfigurationManager.AppSettings["IsOpen"];
        }
        return _commentFolderPath;
    }

    /// <summary>
    /// 获取患者汇总字段
    /// </summary>
    /// <returns></returns>
    //public static string GetGroupByField()
    //{
    //    if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["GroupByField"]))
    //    {
    //        return "checkid";
    //    }
    //    else if (ConfigurationManager.AppSettings["GroupByField"] != "barcode" || ConfigurationManager.AppSettings["GroupByField"] != "checkid")
    //    {
    //        return "checkid";

    //    }

    //    return ConfigurationManager.AppSettings["GroupByField"];
    //}
}

