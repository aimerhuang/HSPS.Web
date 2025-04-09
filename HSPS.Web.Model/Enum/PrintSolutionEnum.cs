

namespace HSPS.Web.Model.Models;

/// <summary>
/// 打印方式
/// </summary>
public enum PrintSolutionEnum
{
    //[EnumDescription("直接打印", "AutoPrint", true)]
    Auto_Work = 0,
    //[EnumDescription("非工作时间直打", "AutoPrint", true)]
    Auto_NoWork = 1,
    //[EnumDescription("自助打印", "Other", true,true)]
    Manual = 2,
    //[EnumDescription("不打印", "Other", true)]
    Nope = 3,
}
