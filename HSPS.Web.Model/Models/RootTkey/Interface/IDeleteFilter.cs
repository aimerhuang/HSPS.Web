﻿namespace HSPS.Web.Model.Models.RootTkey.Interface;

/// <summary>
/// 软删除 过滤器
/// </summary>
public interface IDeleteFilter
{
    public bool IsDeleted { get; set; }
}