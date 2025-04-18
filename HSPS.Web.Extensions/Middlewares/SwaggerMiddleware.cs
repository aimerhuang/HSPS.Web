﻿using HSPS.Web.Common;
using Microsoft.AspNetCore.Builder;
using Swashbuckle.AspNetCore.SwaggerUI;
using static HSPS.Web.Extensions.CustomApiVersion;

namespace HSPS.Web.Extensions;

public static class SwaggerMiddleware
{
    public static void UseSwaggerMiddle(this IApplicationBuilder app, Func<Stream> streamHtml)
    {
        if (app == null) throw new ArgumentNullException(nameof(app));

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            //根据版本名称倒序 遍历展示
            var apiName = AppSettings.app(new string[] { "Startup", "ApiName" });
            typeof(ApiVersions).GetEnumNames().OrderByDescending(e => e).ToList().ForEach(version => { c.SwaggerEndpoint($"/swagger/{version}/swagger.json", $"{apiName} {version}"); });

            // 将swagger首页，设置成我们自定义的页面，记得这个字符串的写法：{项目名.index.html}
            if (streamHtml.Invoke() == null)
            {
                var msg = "index.html的属性，必须设置为嵌入的资源";
                //Log.Error(msg);
                throw new Exception(msg);
            }

            c.IndexStream = streamHtml;//设置自定义首页
            c.DocExpansion(DocExpansion.None); //->修改界面打开时自动折叠

            //增加令牌本地缓存 reload不会丢失
            c.ConfigObject.AdditionalItems.Add("persistAuthorization", "true");

            // 路径配置，设置为空，表示直接在根域名（localhost:8001）访问该文件,注意localhost:8001/swagger是访问不到的，去launchSettings.json把launchUrl去掉，如果你想换一个路径，直接写名字即可，比如直接写c.RoutePrefix = "doc";
            c.RoutePrefix = "";

        });
    }
}
