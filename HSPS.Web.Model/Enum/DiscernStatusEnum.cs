using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HSPS.Web.Model.Models;

/// <summary>
/// 识别模式
/// </summary>
public enum DiscernStatusEnum
{
    /// <summary>
    /// 未知
    /// </summary>
    //[EnumDescription("未知",false)]
    Unknow = -1,
    /// <summary>
    /// 自动识别
    /// </summary>
    //[EnumDescription("自动识别", true)]
    AutoDiscern=0,
    /// <summary>
    /// 人工操作识别
    /// </summary>
    //[EnumDescription("人工操作识别", true)]
    ManualDiscern=1,
    /// <summary>
    /// 无法自动识别
    /// </summary>
    //[EnumDescription("无法自动识别", true)]
    UnDiscern=2,
    ///// <summary>
    ///// 已辨识
    ///// </summary>
    //Discernable,
}
