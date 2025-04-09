

namespace HSPS.Web.Model.Models;

/// <summary>
/// 打印类型
/// </summary>
public enum PrintModeEnum
{
    /// <summary>
    /// 未知
    /// </summary>
    //[EnumDescription("未知", false)]
    Unknow = -1,
    /// <summary>
    /// 直接打印
    /// </summary>
    //[EnumDescription("直接打印", true)]
    Auto=0,
    /// <summary>
    /// 自助打印
    /// </summary>
    //[EnumDescription("自助打印", true)]
    Manual=1,
    /// <summary>
    /// 由报告类别决定
    /// </summary>
    //[EnumDescription("由报告类别决定", true)]
    Type=2,
}
