

namespace HSPS.Web.Model.Enum
{
    /// <summary>
    /// 打印质量
    /// </summary>
    public enum PrintQualityEnum
    {
        /// <summary>
        /// 未知
        /// </summary>
        //[EnumDescription("自动识别", false)]
        Unknow = -1,
        /// <summary>
        /// 高速,低质量
        /// </summary>
        //[EnumDescription("低质量", true)]
        Low = 0,
        /// <summary>
        /// 中速,标准质量
        /// </summary>
        //[EnumDescription("标准质量", true)]
        Middle = 1,

        /// <summary>
        /// 慢速,高质量
        /// </summary>
        //[EnumDescription("高质量", true)]
        High = 2,
    }
}
