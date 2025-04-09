//.net8 写法
using Autofac;
using Autofac.Extensions.DependencyInjection;
using HSPS.Web;
using HSPS.Web.Common;
using HSPS.Web.Common.Core;
using HSPS.Web.Api.Filter;
using HSPS.Web.Extensions.ServiceExtensions;
using HSPS.Web.Extensions;
using HSPS.Web.Extensions.Middlewares;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using Microsoft.IdentityModel.Logging;
using SqlSugar;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using HSPS.Web.Common.Helper;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// 1、配置host与容器
builder.Host
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())//使用服务工厂，将Autofac容器添加到Host
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutofacModuleRegister());//服务注入
        builder.RegisterModule<AutofacPropertityModuleReg>();// 启动服务注册
    })
    .ConfigureAppConfiguration((hostingContext, config) =>
    {
        hostingContext.Configuration.ConfigureApplication();
        config.Sources.Clear();//先清除缓存
        config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: false);//注册配置文件
    });
builder.ConfigureApplication();


// 2、配置服务
builder.Services.AddSingleton(new AppSettings(builder.Configuration));//AppSettings静态配置文件
builder.Services.AddAllOptionRegister();//服务注册  将实现IConfigurableOptions接口的配置类注入到ServiceCollection中
builder.Services.AddUiFilesZipSetup(builder.Environment);//前端UI压缩文件进行解压

Permissions.IsUseAuthing = AppSettings.app(new string[] { "Startup", "Authing", "Enabled" }).ObjToBool();
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();//禁用jwt声明映射

builder.Services.AddSqlsugarSetup();//库访问服务
builder.Services.AddDbSetup();//db启动服务
builder.Host.AddSerilogSetup();//Serilog日志服务

builder.Services.AddAutoMapperSetup();//AutoMapper对象映射器
builder.Services.AddCorsSetup();//跨域服务
builder.Services.AddMiniProfilerSetup();//MiniProfiler性能监控服务
builder.Services.AddSwaggerSetup();//Swagger启动服务
builder.Services.AddHttpContextSetup();//http上下文注册
builder.Services.AddAuthorizationSetup();//授权服务
if (Permissions.IsUseAuthing)
    builder.Services.AddAuthentication_AuthingSetup();//权限 认证服务
else
    builder.Services.AddAuthentication_JWTSetup();//jwt权限 认证服务

builder.Services.Configure<KestrelServerOptions>(x => x.AllowSynchronousIO = true)
    .Configure<IISServerOptions>(x => x.AllowSynchronousIO = true);//允许Kestrel和IIS服务同步IO操作

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
 {
     options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
     options.SerializerSettings.ContractResolver = new DefaultContractResolver();
     options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
     options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
     options.SerializerSettings.Converters.Add(new StringEnumConverter());
     //将long类型转为string
     options.SerializerSettings.Converters.Add(new NumberConverter(NumberConverterShip.Int64));
 });


builder.Services.AddEndpointsApiExplorer();

builder.Services.Replace(ServiceDescriptor.Transient<IControllerActivator, ServiceBasedControllerActivator>());
Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

var app = builder.Build();
IdentityModelEventSource.ShowPII = true;

app.UseSwaggerMiddle(() => Assembly.GetExecutingAssembly().GetManifestResourceStream("HSPS.Web.Api.index.html"));//自定义swagger页面
app.UseCors(AppSettings.app(new string[] { "Startup", "Cors", "PolicyName" }));

app.UseAuthentication();
app.UseAuthorization();
app.UseMiniProfilerMiddleware();
app.MapControllers();

app.Run();
