using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSPS.Web.Model.Models.Extensions;

/// <summary>
/// 用户审核权限
/// </summary>
public partial class UserAuditRange
{
    /// <summary>
    /// 审核级别
    /// </summary>
    public string AuditLevel { get; set; }
    public int ID { get; set; }
    /// <summary>
    /// 报告类别
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

    public static implicit operator UserAuditRange(HIPS.HSPS.Interface.Persistence.Web.UserAuditRange source)
    {
        if (source != null)
        {
            var target = new UserAuditRange()
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

    public static implicit operator HIPS.HSPS.Interface.Persistence.Web.UserAuditRange(UserAuditRange source)
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
