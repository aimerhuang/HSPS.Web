﻿using HSPS.Web.Common.Seed;
using Microsoft.Extensions.DependencyInjection;

namespace HSPS.Web.Extensions;

/// <summary>
/// Db 启动服务
/// </summary>
public static class DbSetup
{
    public static void AddDbSetup(this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        //services.AddScoped<DBSeed>();
        services.AddScoped<MyContext>();
    }
}
