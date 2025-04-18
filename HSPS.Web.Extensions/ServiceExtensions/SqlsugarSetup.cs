﻿using HSPS.Web.Common.DB;
using HSPS.Web.Common;
using Microsoft.Extensions.DependencyInjection;
using SqlSugar;
using System.Text.RegularExpressions;
using HSPS.Web.Common.Utility;
using HSPS.Web.Common.Const;
using HSPS.Web.Common.DB.Aop;

namespace HSPS.Web.Extensions;


/// <summary>
/// SqlSugar 启动服务
/// </summary>
public static class SqlsugarSetup
{
    //private static readonly MemoryCache Cache = new MemoryCache(new MemoryCacheOptions());

    public static void AddSqlsugarSetup(this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        StaticConfig.CustomSnowFlakeFunc = IdGeneratorUtility.NextId;

        // 默认添加主数据库连接
        if (!AppSettings.app("MainDB").IsNullOrEmpty())
        {
            MainDb.CurrentDbConnId = AppSettings.app("MainDB");
        }

        BaseDBConfig.MutiConnectionString.allDbs.ForEach(m =>
        {
            var config = new ConnectionConfig()
            {
                ConfigId = m.ConnId.ObjToString().ToLower(),
                ConnectionString = m.Connection,
                DbType = (DbType)m.DbType,
                IsAutoCloseConnection = true,
                //IsShardSameThread = true,
                MoreSettings = new ConnMoreSettings()
                {
                    //IsWithNoLockQuery = true,
                    IsAutoRemoveDataCache = true,
                    SqlServerCodeFirstNvarchar = true,
                },
                // 从库
                SlaveConnectionConfigs = m.Slaves?.Where(s => s.HitRate > 0).Select(s => new SlaveConnectionConfig
                {
                    ConnectionString = s.Connection,
                    HitRate = s.HitRate
                }).ToList(),
                // 自定义特性
                //ConfigureExternalServices = new ConfigureExternalServices()
                //{
                //    //不建议使用,性能有很大问题,会导致redis堆积
                //    //核心问题在于SqlSugar，每次query都会查缓存, insert\update\delete,又会频繁GetAllKey，导致性能特别低
                //    DataInfoCacheService = new SqlSugarCacheService(),
                //    EntityService = (property, column) =>
                //    {
                //        if (column.IsPrimarykey && property.PropertyType == typeof(int))
                //        {
                //            column.IsIdentity = true;
                //        }
                //    }
                //},
                InitKeyType = InitKeyType.Attribute
            };
            if (SqlSugarConst.LogConfigId.ToLower().Equals(m.ConnId.ToLower()))
            {
                BaseDBConfig.LogConfig = config;
            }
            else
            {
                if (string.Equals(config.ConfigId.ToString(), MainDb.CurrentDbConnId,
                    StringComparison.CurrentCultureIgnoreCase))
                {
                    BaseDBConfig.MainConfig = config;
                }
                else if (m.ConnId.ToLower().StartsWith(MainDb.CurrentDbConnId.ToLower()))
                {
                    //复用连接
                    BaseDBConfig.ReuseConfigs.Add(config);
                }


                BaseDBConfig.ValidConfig.Add(config);
            }

            BaseDBConfig.AllConfigs.Add(config);
        });

        //if (BaseDBConfig.LogConfig is null)
        //{
        //    throw new ApplicationException("未配置Log库连接");
        //}

        Console.WriteLine("connecting:" + BaseDBConfig.MainConfig.ConnectionString);


        // SqlSugarScope是线程安全，使用单例注入
        // 参考：https://www.donet5.com/Home/Doc?typeId=1181
        // SqlSugarClient不能用单例
        services.AddSingleton<ISqlSugarClient>(o =>
        {
            return new SqlSugarScope(BaseDBConfig.AllConfigs, db =>
            {
                BaseDBConfig.ValidConfig.ForEach(config =>
                {
                    var dbProvider = db.GetConnectionScope((string)config.ConfigId);

                    // 打印SQL语句
                    dbProvider.Aop.OnLogExecuting = (s, parameters) =>
                    {
                        SqlSugarAop.OnLogExecuting(dbProvider, App.User?.Name.ObjToString(), ExtractTableName(s),
                            Enum.GetName(typeof(SugarActionType), dbProvider.SugarActionType), s, parameters,
                            config);
                    };

                    // 数据审计
                    dbProvider.Aop.DataExecuting = SqlSugarAop.DataExecuting;

                    // 配置实体假删除过滤器
                    RepositorySetting.SetDeletedEntityFilter(dbProvider);
                    // 配置实体数据权限
                    RepositorySetting.SetTenantEntityFilter(dbProvider);
                });
                //故障转移,检查主库链接自动切换备用连接
                SqlSugarReuse.AutoChangeAvailableConnect(db);
            });
        });
        services.AddTransient<SqlSugarScope>(s => s.GetService<ISqlSugarClient>() as SqlSugarScope);
    }

    private static string GetWholeSql(SugarParameter[] paramArr, string sql)
    {
        foreach (var param in paramArr)
        {
            sql.Replace(param.ParameterName, param.Value.ObjToString());
        }

        return sql;
    }

    private static string GetParas(SugarParameter[] pars)
    {
        string key = "【SQL参数】：";
        foreach (var param in pars)
        {
            key += $"{param.ParameterName}:{param.Value}\n";
        }

        return key;
    }

    private static string ExtractTableName(string sql)
    {
        // 匹配 SQL 语句中的表名的正则表达式
        //string regexPattern = @"\s*(?:UPDATE|DELETE\s+FROM|SELECT\s+\*\s+FROM)\s+(\w+)";
        string regexPattern = @"(?i)(?:FROM|UPDATE|DELETE\s+FROM)\s+`(.+?)`";
        Regex regex = new Regex(regexPattern, RegexOptions.IgnoreCase);
        Match match = regex.Match(sql);

        if (match.Success)
        {
            // 提取匹配到的表名
            return match.Groups[1].Value;
        }
        else
        {
            // 如果没有匹配到表名，则返回空字符串或者抛出异常等处理
            return string.Empty;
        }
    }

}
