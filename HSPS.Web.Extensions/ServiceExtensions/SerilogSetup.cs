using Serilog;
using Microsoft.Extensions.Hosting;
using Serilog.Debugging;
using Serilog.Events;
using HSPS.Web.Common;
using HSPS.Web.Serilog.Configuration;
using HSPS.Web.Serilog.Extensions;
using HSPS.Web.Common.Option;
using HSPS.Web.Common.LogHelper;


namespace HSPS.Web.Extensions.ServiceExtensions;

/// <summary>
/// Serilog日志服务
/// </summary>
public static class SerilogSetup
{
    /// <summary>
    /// Serilog日志服务
    /// </summary>
    /// <param name="host"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IHostBuilder AddSerilogSetup(this IHostBuilder host)
    {
        if (host == null) throw new ArgumentNullException(nameof(host));

        var loggerConfiguration = new LoggerConfiguration()
            .ReadFrom.Configuration(AppSettings.Configuration)
            .Enrich.FromLogContext()
            //输出到控制台
            .WriteToConsole()
            //将日志保存到文件中
            .WriteToFile()
            //配置日志库
            .WriteToLogBatching();

        var option = App.GetOptions<SeqOptions>();
        //配置Seq日志中心
        if (option.Enabled)
        {

            var address = option.Address;
            var apiKey = option.ApiKey;
            if (!string.IsNullOrEmpty(address))
            {
                loggerConfiguration =
                    loggerConfiguration.WriteTo.Seq(address, restrictedToMinimumLevel: LogEventLevel.Verbose,
                        apiKey: apiKey, eventBodyLimitBytes: 10485760);
            }
        }

        Log.Logger = loggerConfiguration.CreateLogger();

        //Serilog 内部日志
        var file = File.CreateText(LogContextStatic.Combine($"SerilogDebug{DateTime.Now:yyyyMMdd}.txt"));
        SelfLog.Enable(TextWriter.Synchronized(file));

        host.UseSerilog();
        return host;
    }
}
