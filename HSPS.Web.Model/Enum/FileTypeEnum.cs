

namespace HSPS.Web.Model.Models;

/// <summary>
/// 类别（报告/胶片/未知
/// </summary>
public enum FileTypeEnum
{
    /// <summary>
    /// 未知
    /// </summary>
    //[EnumDescription("未知", false)]
    Unknow = -1,
    /// <summary>
    /// 报告
    /// </summary>
    //[EnumDescription("报告", true)]
    Report=0,
    /// <summary>
    /// 影像
    /// </summary>
    //[EnumDescription("胶片", true)]
    Image=1,
}
