

namespace HSPS.Web.Model.Models;

public enum MediaEnum
{
    /// <summary>
    /// 未知
    /// </summary>
    //[EnumDescription("未知", false)]
    Unknow = -1,
    //[EnumDescription("普通纸", "Report", true)]
    GeneralGraph = 0,
    //[EnumDescription("白基", "Report,Image", true)]
    WhiteGraph = 1,
    //[EnumDescription("蓝基","Image", true)]
    BlueGraph = 2,
    //[EnumDescription("相纸", "Report", true)]
    PhotoGraph = 3,
}
