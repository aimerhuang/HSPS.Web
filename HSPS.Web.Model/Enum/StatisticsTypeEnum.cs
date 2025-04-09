using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HSPS.Web.Model.Models;

public enum StatisticsTypeEnum
{
    //[EnumDescription("报告/胶片类别","Department,Send",true,true)]
    ReportType = 0,
    //[EnumDescription("来源", "Send",true)]
    Station = 1,
    //[EnumDescription("终端", true)]
    Terminal = 2,
    //[EnumDescription("介质", "Terminal,Department", true)]
    Media = 3,
    //[EnumDescription("尺寸", "Terminal,Department", true)]
    Size = 4,
    //[EnumDescription("报告/胶片量","Terminal",true)]
    FileType = 5,
    //[EnumDescription("打印机", "Terminal", true,true)]
    Printer = 6,
    //[EnumDescription("科室", true)]
    Department = 7,

}
