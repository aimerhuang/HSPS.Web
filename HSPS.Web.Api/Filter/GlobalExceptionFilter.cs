﻿using HSPS.Web.Common;
using HSPS.Web.Model;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using StackExchange.Profiling;
using HSPS.Web.Hubs;
using HSPS.Web.Common.Helper;
using HSPS.Web.Common.LogHelper;

namespace HSPS.Web.Filter;

/// <summary>
/// 全局异常错误日志
/// </summary>
public class GlobalExceptionsFilter : IExceptionFilter
{
    private readonly IWebHostEnvironment _env;
    private readonly IHubContext<ChatHub> _hubContext;
    private readonly ILogger<GlobalExceptionsFilter> _loggerHelper;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="env"></param>
    /// <param name="loggerHelper"></param>
    /// <param name="hubContext"></param>
    public GlobalExceptionsFilter(IWebHostEnvironment env, ILogger<GlobalExceptionsFilter> loggerHelper, IHubContext<ChatHub> hubContext)
    {
        _env = env;
        _loggerHelper = loggerHelper;
        _hubContext = hubContext;
    }

    /// <summary>
    /// 重写异常处理
    /// </summary>
    /// <param name="context"></param>
    public void OnException(ExceptionContext context)
    {
        var json = new MessageModel<string>();

        json.msg = context.Exception.Message;//错误信息
        json.status = 500;//500异常 
        var errorAudit = "Unable to resolve service for";
        if (!string.IsNullOrEmpty(json.msg) && json.msg.Contains(errorAudit))
        {
            json.msg = json.msg.Replace(errorAudit, $"（若新添加服务，需要重新编译项目）{errorAudit}");
        }

        if (_env.EnvironmentName.ObjToString().Equals("Development"))
        {
            json.msgDev = context.Exception.StackTrace;//堆栈信息
        }
        var res = new ContentResult();
        res.Content = JsonHelper.GetJSON<MessageModel<string>>(json);

        context.Result = res;

        MiniProfiler.Current.CustomTiming("Errors：", json.msg);


        //进行错误日志记录
        //_loggerHelper.LogError(json.msg + WriteLog(json.msg, context.Exception));
        //if (AppSettings.app(new string[] { "Middleware", "SignalRSendLog", "Enabled" }).ObjToBool())
        //{
        //    _hubContext.Clients.All.SendAsync("ReceiveUpdate", LogLock.GetLogData()).Wait();
        //}


    }

    /// <summary>
    /// 自定义返回格式
    /// </summary>
    /// <param name="throwMsg"></param>
    /// <param name="ex"></param>
    /// <returns></returns>
    public string WriteLog(string throwMsg, Exception ex)
    {
        return string.Format("\r\n【自定义错误】：{0} \r\n【异常类型】：{1} \r\n【异常信息】：{2} \r\n【堆栈调用】：{3}", new object[] { throwMsg,
                ex.GetType().Name, ex.Message, ex.StackTrace });
    }

}

/// <summary>
/// 
/// </summary>
public class InternalServerErrorObjectResult : ObjectResult
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public InternalServerErrorObjectResult(object value) : base(value)
    {
        StatusCode = StatusCodes.Status500InternalServerError;
    }
}

/// <summary>
/// 返回错误信息
/// </summary>
public class JsonErrorResponse
{
    /// <summary>
    /// 生产环境的消息
    /// </summary>
    public string? Message { get; set; }
    /// <summary>
    /// 开发环境的消息
    /// </summary>
    public string? DevelopmentMessage { get; set; }
}