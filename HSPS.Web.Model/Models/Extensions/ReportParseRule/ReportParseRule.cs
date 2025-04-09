namespace HSPS.Web.Model.Models.Extensions;

public partial class ReportParseRule : IEntity
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string ParseRegular { get; set; }
    /// <summary>
    /// 类别id
    /// </summary>
    public int ReportTypeID { get; set; }
    /// <summary>
    /// 字段枚举
    /// </summary>
    public virtual ParseFieldEnum ParseField { get; set; }
    public string ContentKey { get; set; }

    public static implicit operator ReportParseRule(HIPS.HSPS.Interface.Persistence.Web.ParseRule source)
    {
        if (source != null)
        {

            var target = new ReportParseRule()
            {
                ID = source.ID,
                Name = source.Name,
                ParseRegular = source.ParseRegular,
                ParseField = (source.ParseField).ParseEnum<ParseFieldEnum>(ParseFieldEnum.Title),
                ReportTypeID = source.ReportTypeID,
                ContentKey = source.ContentKey,
            };
            return target;
        }
        return null;
    }

    public static implicit operator HIPS.HSPS.Interface.Persistence.Web.AddParseRule(ReportParseRule source)
    {
        if (source != null)
        {

            var target = new HIPS.HSPS.Interface.Persistence.Web.AddParseRule()
            {
                ParseRuleName = source.Name,
                ParseRegular = source.ParseRegular,
                ParseField = source.ParseField.ToString(),
                ReportTypeID = source.ReportTypeID,
                ContentKey = source.ContentKey,
            };
            return target;
        }
        return null;
    }

    public static implicit operator HIPS.HSPS.Interface.Persistence.Web.UpdateParseRule(ReportParseRule source)
    {
        if (source != null)
        {

            var target = new HIPS.HSPS.Interface.Persistence.Web.UpdateParseRule()
            {
                ParseRuleID = source.ID,
                ParseRuleName = source.Name,
                ParseRegular = source.ParseRegular,
            };
            return target;
        }
        return null;
    }


}
