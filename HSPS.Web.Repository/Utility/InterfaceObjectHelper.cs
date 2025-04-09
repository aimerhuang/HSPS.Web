
using System.Net;

//using YiBan.HSPS.Main.Utility;
//using YiBan.HSPS.Main.Utility.Logs;
using HIPS.HSPS.DataContract;
using System.ServiceModel;
using System.Web;
using System.ServiceModel.Description;
using HSPS.Web.Common.DB;
using HSPS.Web.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Azure.Core;

namespace HSPS.Web.Repository;

/// <summary>
///转接口
/// </summary>
public class InterfaceObjectHelper
{
    //声明一个 IServiceCollection 接口类
    //public static IServiceCollection? serviceCollection;

    ////获取到 HttpContext  对象
    //public static HttpContext Current
    //{
    //    get
    //    {
    //        object factory = serviceCollection.BuildServiceProvider().GetService(typeof(IHttpContextAccessor));
    //        HttpContext context = ((IHttpContextAccessor)factory).HttpContext;
    //        return context;
    //    }
    //}


    /// <summary>
    /// 默认的发送超时时间
    /// </summary>
    public readonly static TimeSpan DEFAULT_SEND_TIMEOUT = new TimeSpan(0, 10, 0);

    #region 创建Remoting 远程对象
    /// <summary>
    /// 获取Remting远程接口的对象
    /// </summary>
    /// <param name="remoteIp">远程的IP</param>
    /// <param name="port">远程的端口</param>
    /// <param name="clsname">注册类名</param>
    /// <param name="objectMode">注册模式</param>
    /// <param name="failReason">获取失败的原因</param>
    /// <returns></returns>
    //private static T GetRemotingInterfaceObject<T>(string remoteIp, string port, string clsname, WellKnownObjectMode objectMode, ref string failReason)
    //{
    //    //连接检查
    //    #region IP地址检测
    //    IPAddress IPserver = IPAddress.Parse(remoteIp);
    //    if (new Ping().Send(IPserver, 50).Buffer.Length <= 0) //检查地址
    //    {
    //        failReason = "无法连接到该IP:" + remoteIp;
    //        LogHelper.Fatal(failReason);
    //        return default(T);
    //    }
    //    #endregion
    //    #region 端口检查
    //    using (TcpClient tcp = new TcpClient())
    //    {
    //        try
    //        {
    //            IPEndPoint IPEP = new IPEndPoint(IPserver, int.Parse(port));
    //            tcp.Connect(IPEP);
    //        }
    //        catch (Exception ex)
    //        {
    //            failReason = "无法连接到远程的服务器";
    //            LogHelper.Fatal(failReason, ex);
    //            return default(T);
    //        }
    //    }
    //    #endregion
    //    object obj = Activator.GetObject(typeof(T), "Tcp://" + remoteIp + ":" + port + "/" + clsname, objectMode);
    //    if (obj is T)
    //        return (T)obj;
    //    return default(T);
    //}
    /*
    /// <summary>
    /// 获取业务服务的远程接口对象
    /// </summary>
    /// <param name="clsname">注册类名</param>
    /// <returns></returns>
    public static T GetBusinessServiceInterfaceObject<T>(string clsname)
    {
        string errorMsg = string.Empty;
        return GetRemotingInterfaceObject<T>(ConfigSectionHelper.GetRemoteServerIp(), ConfigSectionHelper.GetRemotePort(), clsname, System.Runtime.Remoting.WellKnownObjectMode.Singleton, ref errorMsg);
    }

    /// <summary>
    /// 获取放射科室服务的远程接口对象
    /// </summary>
    /// <param name="clsname">注册类名</param>
    /// <returns></returns>
    public static T GetRadiologyServiceInterfaceObject<T>(string clsname)
    {
        string errorMsg = string.Empty;
        return GetRemotingInterfaceObject<T>(ConfigSectionHelper.GetRadiologyRemoteServerIp(), ConfigSectionHelper.GetRadiologyRemotePort(), clsname, System.Runtime.Remoting.WellKnownObjectMode.Singleton, ref errorMsg);
    }

    /// <summary>
    /// 获取打印代理服务的远程接口对象
    /// </summary>
    /// <param name="clsname">注册类名</param>
    /// <returns></returns>
    public static T GetPrintProxyServiceInterfaceObject<T>(string clsname)
    {
        string errorMsg = string.Empty;
        return GetRemotingInterfaceObject<T>(ConfigSectionHelper.GetPrintProxyRemoteServerIp(), ConfigSectionHelper.GetPrintProxyRemotePort(), clsname, System.Runtime.Remoting.WellKnownObjectMode.Singleton, ref errorMsg);
    }*/
    #endregion

    #region 创建WCF远程对象
    /// <summary>
    /// 创建WCF通道工厂的实例
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="remoteIp"></param>
    /// <param name="remotePort"></param>
    /// <param name="className"></param>
    /// <returns></returns>
    private static ChannelFactory<T> CreateWCFChannelFactory<T>(string remoteIp, string remotePort, string className)
    {
        return CreateWCFChannelFactory<T>(remoteIp, remotePort, className, DEFAULT_SEND_TIMEOUT);
    }

    /// <summary>
    /// 创建WCF通道工厂的实例
    /// 2025-2-25 hkl
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="remoteIp"></param>
    /// <param name="remotePort"></param>
    /// <param name="className"></param>
    /// <returns></returns>
    private static ChannelFactory<T> CreateWCFChannelFactory<T>(string remoteIp, string remotePort, string className, TimeSpan timeoutSpan)
    {
        string remoteAddress = string.Format("net.tcp://{0}:{1}/{2}", remoteIp, remotePort, className);

        ChannelFactory<T> channelFactory = new ChannelFactory<T>(CreateNetTcpBinding(timeoutSpan), new EndpointAddress(remoteAddress));//方法修改 2025-2-25 hkl

        foreach (OperationDescription op in channelFactory.Endpoint.Contract.Operations)
        {
            DataContractSerializerOperationBehavior dataContractBehavior = op.Behaviors.Find<DataContractSerializerOperationBehavior>()
              as DataContractSerializerOperationBehavior;
            if (dataContractBehavior != null)
            {
                dataContractBehavior.MaxItemsInObjectGraph = SectionHelperConfig.GetWCFDataMaxLength();
                //ConfigSectionHelper.GetWCFDataMaxLength();
            }
        }

        return channelFactory;
    }

    /// <summary>
    /// 构建NetTcpBingding，传输绑定扩展配置
    /// </summary>
    private static NetTcpBinding CreateNetTcpBinding(TimeSpan timeoutSpan)
    {

        NetTcpBinding netTcpBinding = new NetTcpBinding()
        {
            TransferMode = System.ServiceModel.TransferMode.Streamed,
            //ListenBacklog = 15,
            MaxReceivedMessageSize = SectionHelperConfig.GetWCFDataMaxLength(),//ConfigSectionHelper.GetWCFDataMaxLength(),
            MaxConnections = 3000,
            MaxBufferSize = SectionHelperConfig.GetWCFDataMaxLength(),//ConfigSectionHelper.GetWCFDataMaxLength(),
            MaxBufferPoolSize = SectionHelperConfig.GetWCFDataMaxLength(),//ConfigSectionHelper.GetWCFDataMaxLength(),
            ReceiveTimeout = TimeSpan.MaxValue,
            SendTimeout = timeoutSpan,
            Security = new NetTcpSecurity()
            {
                Mode = SecurityMode.None
            },
        };
        System.Xml.XmlDictionaryReaderQuotas readerQuotas = new System.Xml.XmlDictionaryReaderQuotas();
        readerQuotas.MaxArrayLength = SectionHelperConfig.GetWCFDataMaxLength();//ConfigSectionHelper.GetWCFDataMaxLength();
        readerQuotas.MaxStringContentLength = SectionHelperConfig.GetWCFDataMaxLength();//ConfigSectionHelper.GetWCFDataMaxLength();
        readerQuotas.MaxBytesPerRead = SectionHelperConfig.GetWCFDataMaxLength(); //ConfigSectionHelper.GetWCFDataMaxLength();
        netTcpBinding.ReaderQuotas = readerQuotas;

        return netTcpBinding;
    }

    /// <summary>
    /// 获取业务服务的远程接口对象
    /// <param name="className"></param>
    /// </summary>
    /// <returns></returns>
    public static T GetBusinessServiceInterfaceObject<T>(string className)
    {
        return GetBusinessServiceInterfaceObject<T>(className, SectionHelperConfig.GetDataServiceTimeout());//ConfigSectionHelper.GetDataServiceTimeout()
    }

    /// <summary>
    /// 获取业务服务的远程接口对象
    /// <param name="className"></param>
    /// </summary>
    /// <returns></returns>
    public static T GetBusinessServiceInterfaceObject<T>(string className, TimeSpan timeoutSpan)
    {
        ChannelFactory<T> factory = CreateWCFChannelFactory<T>(SectionHelperConfig.GetRemoteServerIp(), SectionHelperConfig.GetRemotePort(), className, timeoutSpan);
        //ConfigSectionHelper.GetRemoteServerIp(),ConfigSectionHelper.GetRemotePort()
        return factory.CreateChannel();
    }

    /// <summary>
    /// 获取放射科室服务的远程接口对象
    /// </summary>
    /// <param name="className"></param>
    /// <returns></returns>
    public static T GetRadiologyServiceInterfaceObject<T>(string className)
    {
        return GetRadiologyServiceInterfaceObject<T>(className, SectionHelperConfig.GetRadiologyDepartmentTimeout());
    }

    /// <summary>
    /// 获取放射科室服务的远程接口对象
    /// </summary>
    /// <param name="className"></param>
    /// <returns></returns>
    public static T GetRadiologyServiceInterfaceObject<T>(string className, TimeSpan timeoutSpan)
    {

        ChannelFactory<T> factory = CreateWCFChannelFactory<T>(SectionHelperConfig.GetRadiologyRemoteServerIp(), SectionHelperConfig.GetRadiologyRemotePort(), className, timeoutSpan);
        return factory.CreateChannel();
    }

    /// <summary>
    /// 获取打印代理服务的远程接口对象
    /// </summary>
    /// <param name="className"></param>
    /// <returns></returns>
    public static T GetPrintProxyServiceInterfaceObject<T>(string className)
    {
        return GetPrintProxyServiceInterfaceObject<T>(className, SectionHelperConfig.GetPrintProxyTimeout());
    }

    /// <summary>
    /// 获取打印代理服务的远程接口对象
    /// </summary>
    /// <param name="className"></param>
    /// <returns></returns>
    public static T GetPrintProxyServiceInterfaceObject<T>(string className, TimeSpan timeoutSpan)
    {

        string remoteAddress = string.Format("net.tcp://{0}:{1}/{2}", SectionHelperConfig.GetPrintProxyRemoteServerIp(), SectionHelperConfig.GetPrintProxyRemotePort(), className);
        NetTcpBinding netTcpBinding = CreateNetTcpBinding(timeoutSpan);
        netTcpBinding.TransferMode = TransferMode.Buffered;
        ChannelFactory<T> channelFactory = new ChannelFactory<T>(netTcpBinding, new EndpointAddress(remoteAddress));

        return channelFactory.CreateChannel();
    }

    /// <summary>
    /// 获取日志服务的远程接口对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="className"></param>
    /// <param name="timeoutSpanMinute"></param>
    /// <returns></returns>
    private static T GetLoggerServiceInterfaceObject<T>(string className, TimeSpan timeoutSpan)
    {
        string remoteAddress = string.Format("net.tcp://{0}:{1}/{2}", SectionHelperConfig.GetLoggerRemoteServerIp(), SectionHelperConfig.GetLoggerRemoteServerPort(), className);
        NetTcpBinding netTcpBinding = CreateNetTcpBinding(timeoutSpan);
        netTcpBinding.TransferMode = TransferMode.Buffered;
        ChannelFactory<T> channelFactory = new ChannelFactory<T>(netTcpBinding, new EndpointAddress(remoteAddress));
        return channelFactory.CreateChannel();
    }
    /// <summary>
    /// 获取日志服务的远程接口对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="className"></param>
    /// <returns></returns>
    private static T GetLoggerServiceInterfaceObject<T>(string className)
    {
        return GetLoggerServiceInterfaceObject<T>(className, SectionHelperConfig.GetLoggerServiceTimeout());
    }

    /// <summary>
    /// 获取业务服务的远程接口对象
    /// </summary>
    /// <returns></returns>
    public static T GetBusinessServiceInterfaceObject<T>()
    {
        return GetBusinessServiceInterfaceObject<T>(typeof(T).Name.TrimStart('I'));
    }

    /// <summary>
    /// 获取放射科室服务的远程接口对象
    /// </summary>
    /// <returns></returns>
    public static T GetRadiologyServiceInterfaceObject<T>()
    {
        return GetRadiologyServiceInterfaceObject<T>(typeof(T).Name.TrimStart('I'));
    }

    /// <summary>
    /// 获取打印代理服务的远程接口对象
    /// </summary>
    /// <returns></returns>
    public static T GetPrintProxyServiceInterfaceObject<T>()
    {
        return GetPrintProxyServiceInterfaceObject<T>(typeof(T).Name.TrimStart('I'));
    }

    /// <summary>
    /// 获取日志服务的远程接口对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T GetLoggerServiceInterfaceObject<T>()
    {
        return GetLoggerServiceInterfaceObject<T>(typeof(T).Name.TrimStart('I'));
    }

    /// <summary>
    /// 获取业务服务的远程接口对象
    /// </summary>
    /// <returns></returns>
    public static T GetBusinessServiceInterfaceObject<T>(TimeSpan timeoutSpan)
    {
        return GetBusinessServiceInterfaceObject<T>(typeof(T).Name.TrimStart('I'), timeoutSpan);
    }

    /// <summary>
    /// 获取放射科室服务的远程接口对象
    /// </summary>
    /// <returns></returns>
    public static T GetRadiologyServiceInterfaceObject<T>(TimeSpan timeoutSpan)
    {
        return GetRadiologyServiceInterfaceObject<T>(typeof(T).Name.TrimStart('I'), timeoutSpan);
    }

    /// <summary>
    /// 获取打印代理服务的远程接口对象
    /// </summary>
    /// <returns></returns>
    public static T GetPrintProxyServiceInterfaceObject<T>(TimeSpan timeoutSpan)
    {
        return GetPrintProxyServiceInterfaceObject<T>(typeof(T).Name.TrimStart('I'), timeoutSpan);
    }

    /// <summary>
    /// 获取日志服务的远程接口对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="timeoutSpanMinute"></param>
    /// <returns></returns>
    public static T GetLoggerServiceInterfaceObject<T>(TimeSpan timeoutSpan)
    {
        return GetLoggerServiceInterfaceObject<T>(typeof(T).Name.TrimStart('I'), timeoutSpan);
    }
    #endregion

    /// <summary>
    /// 调用服务接口方法
    /// </summary>
    /// <typeparam name="T">参数类型</typeparam>
    /// <typeparam name="TResult">返回值的类型</typeparam>
    /// <param name="action">方法对象</param>
    /// <param name="param">方法参数</param>
    /// <returns></returns>
    public static TResult CallMethod<T, TResult>(Func<Request<T>, Response<TResult>> action, T param)
    {
        Request<T> request = new Request<T>();
        if (!(param is System.Reflection.Missing))
            request.ReqBody = param;
        request.ReqHead = new ReqHead(action.Method.Name);
        //var a =request.ReqHead.ClientCode
        //记录UserName,通过ReqHead传入服务端
        request.ReqHead.Creator = AppSettings.app(new string[] { "Audience", "Issuer" });//配置使用人
                                                                                         //if (HttpContext.Current.Session != null)
                                                                                         //{
                                                                                         //    string username = HttpContext.Current.Session[Constant.SESSION_USER_USERNAME] == null ? "" : HttpContext.Current.Session[Constant.SESSION_USER_USERNAME].ToString();
                                                                                         //    request.ReqHead.Creator = username;
                                                                                         //}
        request.ReqHead.ClientIP = "127.0.0.1";//System.Net.Dns.GetHostByAddress().//clientInfo.Item1;//HttpContext.Current.Request.UserHostAddress;
        request.ReqHead.ClientName = "teest";//clientInfo.Item2;
        //Tuple<string, string> clientInfo = GetClientInfo();
        //if (clientInfo != null)
        //{
        //    request.ReqHead.ClientIP = "127.0.0.1";//System.Net.Dns.GetHostByAddress().//clientInfo.Item1;//HttpContext.Current.Request.UserHostAddress;
        //    request.ReqHead.ClientName = clientInfo.Item2;
        //}
        request.ReqHead.AppType = "WebApi";//Constant.DEFAULT_APP_NAME;

        Response<TResult> response = action(request);
        TResult result = default(TResult);
        if (response != null)
            result = response.RspBody;
        return result;
    }
    /// <summary>
    /// 获取客户端真实IP（通过DNS反查IP）
    /// </summary>
    /// <returns></returns>
    public static Tuple<string, string> GetClientInfo()
    {

        string clientIP = GetClientIP();
        /*
         * string ipv4 = string.Empty;
        string hostName = string.Empty;

        IPHostEntry ipHost = null;
        try
        {
            ipHost = Dns.GetHostEntry(clientIP);
        }
        catch (Exception ex)
        {
            LogHelper.Error("根据IP获取IPHostEntry信息出错", ex);
        }

        foreach (IPAddress ip in Dns.GetHostAddresses(clientIP))
        {
            if (ip.AddressFamily== AddressFamily.InterNetwork)
            {
                ipv4 = ip.ToString();
                break;
            }
        }

        if (ipv4 == string.Empty && ipHost != null)
        {
            foreach (IPAddress ip in ipHost.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    ipv4 = ip.ToString();
                    break;
                }
            }
        }
        if(ipHost != null)
        {
            hostName = ipHost.HostName;
        }
        else
        {
            hostName = Dns.GetHostName();
        }
        return new Tuple<string,string>(ipv4,hostName);
         */
        return new Tuple<string, string>(clientIP, Dns.GetHostName());
    }


    /// <summary>
    /// 获取客户端IP
    /// </summary>
    /// <returns></returns>
    public static string GetClientIP()
    {
        return "";
        //Tuple<string, string> tuple = new Tuple()

        //var ip=System.Net.IPAddress.Any;

        //return Current.Connection.RemoteIpAddress.MapToIPv4().ToString();

        //if (null == HttpContext.Current.Request.ServerVariables["HTTP_VIA"])
        //{
        //    return HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        //}
        //else
        //{
        //    return HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        //}

    }

}
