using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HSPS.Web.Model.Models;

public enum StationEnum
{
    /// 未知
    
    //[EnumDescription("未知", false)]
    Unknow = 0,
    /// <summary>
    /// IPS
    /// </summary>
    //[EnumDescription("IPS", true)]
    IPS = 1,
    /// <summary>
    /// 集成平台
    /// </summary>
    //[EnumDescription("集成平台", true)]
    IntegrationPlatform = 2,
    /// <summary>
    /// 定制化
    /// </summary>
   // [EnumDescription("定制化", true)]
    Customization = 3,
    /// <summary>
    /// 放射
    /// </summary>
    //[EnumDescription("放射", true)]
    Radiation = 4,
}
