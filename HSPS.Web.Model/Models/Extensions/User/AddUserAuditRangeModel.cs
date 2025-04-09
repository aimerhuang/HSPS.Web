
namespace HSPS.Web.Model.Models.Extensions;

/// <summary>
/// 增加/修改 用户审核权限
/// </summary>
public partial class AddUserAuditRangeModel
{
    /// <summary>
    /// 审核级别
    /// </summary>
    public string AuditLevel { get; set; }
    /// <summary>
    /// 主键id
    /// </summary>
    public int ID { get; set; }
    /// <summary>
    /// 报告类别id
    /// </summary>
    public int ReportTypeID { get; set; }
    /// <summary>
    /// 来源id
    /// </summary>
    public string StationID { get; set; }
    /// <summary>
    /// 用户id
    /// </summary>
    public int UserID { get; set; }
}

public partial class AddUserAuditRangeModel
{
    public static implicit operator AddUserAuditRangeModel(HIPS.HSPS.Interface.Persistence.Web.UserAuditRange source)
    {
        if (source != null)
        {
            var target = new AddUserAuditRangeModel()
            {
                AuditLevel = source.AuditLevel,
                ID = source.ID,
                ReportTypeID = source.ReportTypeID,
                StationID = source.StationID,
                UserID = source.UserID,
            };
            return target;
        }
        return null;
    }

    public static implicit operator HIPS.HSPS.Interface.Persistence.Web.UserAuditRange(AddUserAuditRangeModel source)
    {
        if (source != null)
        {
            var target = new HIPS.HSPS.Interface.Persistence.Web.UserAuditRange()
            {
                AuditLevel = source.AuditLevel,
                ID = source.ID,
                ReportTypeID = source.ReportTypeID,
                StationID = source.StationID,
                UserID = source.UserID,
            };
            return target;
        }
        return null;
    }
}
