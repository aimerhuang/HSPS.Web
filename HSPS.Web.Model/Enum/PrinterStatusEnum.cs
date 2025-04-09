using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HSPS.Web.Model.Models;

public enum PrinterStatusEnum
{
  //[EnumDescription("正常", true)]
    Normal = 0,
  //[EnumDescription("打印机缺纸", true)]  
    OutOfPaper = 1,
  //[EnumDescription("打印机缺墨", true)] 
    OutOfInk = 2,
  //[EnumDescription("打印机脱机", true)] 
    Offline = 3,
  //[EnumDescription("未知", true)] 
    Unknown = 4,
}
