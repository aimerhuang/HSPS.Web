namespace HSPS.Web.Model.Models.Extensions;

/// <summary>
/// 条件类
/// </summary>
public partial class AuditConditions
{
    /// <summary>
    /// 审核等级（一级，二级，三级）
    /// </summary>
    public EnumAuditLevel EnumAuditLevel { get; set; }
    /// <summary>
    /// id
    /// </summary>
    public int ID { get; set; }
    /// <summary>
    /// 是否使用了Ukey
    /// </summary>
    public bool IsUsedUKey { get; set; }
    /// <summary>
    /// 报告类别id
    /// </summary>
    public int ReportTypeID { get; set; }

}

public partial class AuditConditions
{
    public static implicit operator AuditConditions(HIPS.HSPS.Interface.Persistence.Web.AuditConditions source)
    {
        if (source != null)
        {
            var target = new Models.Extensions.AuditConditions()
            {
                EnumAuditLevel = (source.EnumAuditLevel).ParseEnum<EnumAuditLevel>(EnumAuditLevel.FirstAudit),
                IsUsedUKey = source.IsUsedUKey,
                ID = source.ID,
                ReportTypeID = source.ReportTypeID,
            };
            return target;
        }
        return null;
    }

    public static implicit operator HIPS.HSPS.Interface.Persistence.Web.AuditConditions(AuditConditions source)
    {
        if (source != null)
        {
            var target = new HIPS.HSPS.Interface.Persistence.Web.AuditConditions()
            {
                EnumAuditLevel = (source.EnumAuditLevel).ParseEnum<HIPS.HSPS.Interface.Persistence.Web.EnumAuditLevel>(HIPS.HSPS.Interface.Persistence.Web.EnumAuditLevel.FirstAudit),
                IsUsedUKey = source.IsUsedUKey,
                ID = source.ID,
                ReportTypeID = source.ReportTypeID,
            };
            return target;
        }
        return null;
    }
}
