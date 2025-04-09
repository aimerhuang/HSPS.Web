using HSPS.Web.Common.DB;
using YiBan.LogClient;
using YiBan.LogClient.Enums;

namespace HSPS.Web.Common;

/// <summary>
/// 日志服务操作类
/// </summary>
public static class LogServicesHelper
{
    private static Logger? log = null;
    /// <summary>
    /// 构造函数
    /// </summary>
    static LogServicesHelper()
    {
        if (log == null)
        {
            var logIp = SectionHelperConfig.GetLoggerRemoteServerIp();//ConfigSectionHelper.GetLoggerRemoteServerIp();
            var logPort = SectionHelperConfig.GetLoggerRemoteServerPort();
            var logUploadInterval = SectionHelperConfig.GetLoggerRemoteServerUploadInterval();
            var logUploadLevel = StringToLoglevel(SectionHelperConfig.GetLoggerRemoteServerUploadLevel());

            log = new Logger(AppSettings.app(new string[] { "Audience", "Issuer" }), "Web", logUploadLevel, logIp, logPort, logUploadInterval, "LoggerServer");
        }
    }


    public static Loglevel StringToLoglevel(string strLevel)
    {
        strLevel = strLevel.ToLower();
        Loglevel level = Loglevel.Error;
        switch (strLevel)
        {
            case "error":
                level = Loglevel.Error;
                break;
            case "debug":
                level = Loglevel.Debug;
                break;
            case "warm":
                level = Loglevel.Warn;
                break;
            case "info":
                level = Loglevel.Info;
                break;
            case "trace":
                level = Loglevel.Trace;
                break;
            case "fatal":
                level = Loglevel.Fatal;
                break;
        }
        return level;
    }

    public static void Debug(string message, Exception? ex = null)
    {
        log.Debug(message, ex);
    }
    public static void Warn(string message, Exception? ex = null)
    {
        log.Warn(message, ex);
    }


    public static void Error(string message, Exception? ex = null)
    {
        log.Error(message, ex);
    }


    public static void Info(string message, Exception? ex = null)
    {
        log.Info(message, ex);
    }


    public static void Trace(string message, Exception? ex = null)
    {
        log.Trace(message, ex);
    }

    public static void Fatal(string message, Exception? ex = null)
    {
        log.Fatal(message, ex);
    }

}

