//.net8 д��
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

// 1������host������
builder.Host
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())//ʹ�÷��񹤳�����Autofac������ӵ�Host
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutofacModuleRegister());//����ע��
        builder.RegisterModule<AutofacPropertityModuleReg>();// ��������ע��
    })
    .ConfigureAppConfiguration((hostingContext, config) =>
    {
        hostingContext.Configuration.ConfigureApplication();
        config.Sources.Clear();//���������
        config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: false);//ע�������ļ�
    });
builder.ConfigureApplication();


// 2�����÷���
builder.Services.AddSingleton(new AppSettings(builder.Configuration));//AppSettings��̬�����ļ�
builder.Services.AddAllOptionRegister();//����ע��  ��ʵ��IConfigurableOptions�ӿڵ�������ע�뵽ServiceCollection��
builder.Services.AddUiFilesZipSetup(builder.Environment);//ǰ��UIѹ���ļ����н�ѹ

Permissions.IsUseAuthing = AppSettings.app(new string[] { "Startup", "Authing", "Enabled" }).ObjToBool();
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();//����jwt����ӳ��

builder.Services.AddSqlsugarSetup();//����ʷ���
builder.Services.AddDbSetup();//db��������
builder.Host.AddSerilogSetup();//Serilog��־����

builder.Services.AddAutoMapperSetup();//AutoMapper����ӳ����
builder.Services.AddCorsSetup();//�������
builder.Services.AddMiniProfilerSetup();//MiniProfiler���ܼ�ط���
builder.Services.AddSwaggerSetup();//Swagger��������
builder.Services.AddHttpContextSetup();//http������ע��
builder.Services.AddAuthorizationSetup();//��Ȩ����
if (Permissions.IsUseAuthing)
    builder.Services.AddAuthentication_AuthingSetup();//Ȩ�� ��֤����
else
    builder.Services.AddAuthentication_JWTSetup();//jwtȨ�� ��֤����

builder.Services.Configure<KestrelServerOptions>(x => x.AllowSynchronousIO = true)
    .Configure<IISServerOptions>(x => x.AllowSynchronousIO = true);//����Kestrel��IIS����ͬ��IO����

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
 {
     options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
     options.SerializerSettings.ContractResolver = new DefaultContractResolver();
     options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
     options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
     options.SerializerSettings.Converters.Add(new StringEnumConverter());
     //��long����תΪstring
     options.SerializerSettings.Converters.Add(new NumberConverter(NumberConverterShip.Int64));
 });


builder.Services.AddEndpointsApiExplorer();

builder.Services.Replace(ServiceDescriptor.Transient<IControllerActivator, ServiceBasedControllerActivator>());
Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

var app = builder.Build();
IdentityModelEventSource.ShowPII = true;

app.UseSwaggerMiddle(() => Assembly.GetExecutingAssembly().GetManifestResourceStream("HSPS.Web.Api.index.html"));//�Զ���swaggerҳ��
app.UseCors(AppSettings.app(new string[] { "Startup", "Cors", "PolicyName" }));

app.UseAuthentication();
app.UseAuthorization();
app.UseMiniProfilerMiddleware();
app.MapControllers();

app.Run();
