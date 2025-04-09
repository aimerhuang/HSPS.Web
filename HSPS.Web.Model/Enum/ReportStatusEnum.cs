
namespace HSPS.Web.Model.Models;

public enum ReportStatusEnum
{
    //[EnumDescription("正常", true)]
    Normal = 0,
    //[EnumDescription("废弃", true)]
    Abandoned = 1,
    //[EnumDescription("不可取", true)]
    UnableGet = 2,
    //[EnumDescription("待审核", false)]
    UnAudited = 3,
    //[EnumDescription("审核未通过", false)]
    AuditNotPassed = 4,
}
