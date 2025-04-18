﻿using AutoMapper;


namespace HSPS.Web.AutoMapper;

/// <summary>
/// 静态全局 AutoMapper 配置文件
/// </summary>
public class AutoMapperConfig
{
    public static MapperConfiguration RegisterMappings()
    {
        return new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new AutoMapperProfile());
        });
    }
}
