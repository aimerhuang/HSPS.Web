

namespace HSPS.Web.Model.Models;

///<summary>
/// 打印方式
/// </summary>
public enum PrintWayEnum
{
    /// <summary>
    /// 未知
    /// </summary>
    //[EnumDescription("未知", false)]
    Unknow,
    /// <summary>
    /// 直接打印
    /// </summary>
    //[EnumDescription("直接打印", true)]
    Auto,
    /// <summary>
    /// 自助打印
    /// </summary>
    //[EnumDescription("自助打印", true)]
    Manual,
    /// <summary>
    /// 不打印
    /// </summary>
    //[EnumDescription("不打印", true)]
    Nope,
    /// <summary>
    /// 按需打印
    /// </summary>
    //[EnumDescription("按需打印", false)]
    Need,
}
