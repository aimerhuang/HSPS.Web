using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HSPS.Web.Model.Models;

/// <summary>
/// 打印状态
/// </summary>
public enum PrintStatusEnum
{
    /// <summary>
    /// 未知
    /// </summary>
    //[EnumDescription("未知", false)]
    Unknow = -1,
    /// <summary>
    /// 未打印
    /// </summary>
    //[EnumDescription("未打印", true)]
    Unprint=0,
    /// <summary>
    /// 正在打印
    /// </summary>
    //[EnumDescription("打印中", true)]
    Printing=1,
    /// <summary>
    /// 已打
    /// </summary>
    //[EnumDescription("已打印", true)]
    Printed=2,
}
