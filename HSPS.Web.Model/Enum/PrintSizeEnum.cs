using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HSPS.Web.Model.Models;

/// <summary>
///打印尺寸
/// </summary>   
public enum PrintSizeEnum
{
    /// <summary>
    /// 未知
    /// </summary>
    //[EnumDescription("未知", false)]
    Unknow = -1,
    //[EnumDescription("", false)]
    A0 = 0,
    //[EnumDescription("", false)]
    A1 = 1,
    //[EnumDescription("", false)]
    A2 = 2,
    //[EnumDescription("", false)]
    A3 = 3,
    //[EnumDescription("A4","Report", true)]
    A4 = 4,
    //[EnumDescription("A5", "Report", true)]
    A5 = 5,
    //[EnumDescription("", false)]
    A6 = 6,
    //[EnumDescription("", false)]
    A7 = 7,
    //[EnumDescription("", false)]
    A8 = 8,
    //[EnumDescription("", false)]
    A9 = 9,
    //[EnumDescription("", false)]
    B0 = 10,
    //[EnumDescription("", false)]
    B1 = 11,
    //[EnumDescription("", false)]
    B2 = 12,
    //[EnumDescription("", false)]
    B3 = 13,
    //[EnumDescription("", false)]
    B4 = 14,
    //[EnumDescription("B5", "Report", true)]
    B5 = 15,
    //[EnumDescription("", false)]
    B6 = 16,
    //[EnumDescription("", false)]
    B7 = 17,
    //[EnumDescription("", false)]
    B8 = 18,
    //[EnumDescription("", false)]
    B9 = 19,
    //[EnumDescription("_8INX10IN", "Image", true)]
    _8INX10IN = 20,
    //[EnumDescription("_8_5INX11IN", "Image", true)]
    _8_5INX11IN = 21,
    //[EnumDescription("_11INX14IN", "Image", true)]
    _11INX14IN = 22,
    //[EnumDescription("_10INX14IN", "Image", true)]
    _10INX14IN = 23,
    //[EnumDescription("_10INX12IN", "Image", true)]
    _10INX12IN = 24,
    //[EnumDescription("_14INX14IN", "Image", true)]
    _14INX14IN = 25,
    //[EnumDescription("_14INX17IN", "Image", true)]
    _14INX17IN = 26,
}
