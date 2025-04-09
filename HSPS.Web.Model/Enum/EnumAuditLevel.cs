

namespace HSPS.Web.Model.Models;
/// <summary>
/// 审核级别枚举
/// </summary>
public enum EnumAuditLevel
{
    //[EnumDescription("无", true)]
    UnAudit = 0,
    //[EnumDescription("一级审核", true)]
    FirstAudit = 1,
    //[EnumDescription("二级审核", true)]
    SecondAudit = 2,
    //[EnumDescription("三级审核", true)]
    ThirdAudit = 3,
}
