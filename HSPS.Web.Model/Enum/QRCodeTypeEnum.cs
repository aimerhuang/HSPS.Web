

namespace HSPS.Web.Model.Models;

/// <summary>
/// 二维码类别
/// </summary>
public enum QRCodeTypeEnum
{
    //[EnumDescription("报告静态图片", true)]
    Image = 0,
    //[EnumDescription("报告动态二维码", true)]
    MedicalURL = 1,
    //[EnumDescription("终端二维码", false)]
    Terminal = 2,
}
