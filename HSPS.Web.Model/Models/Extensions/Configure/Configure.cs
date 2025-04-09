

namespace HSPS.Web.Model.Models.Extensions;

/// <summary>
/// 配置表
/// </summary>
public partial class Configure : IEntity
{
    /// <summary>
    /// 主键id
    /// </summary>
    public int ID { get; set; }
    public string Category { get; set; }
    public string Key { get; set; }
    /// <summary>
    /// 值
    /// </summary>
    public string Value { get; set; }
    /// <summary>
    /// 描述
    /// </summary>
    public string Description { get; set; }
    /// <summary>
    /// 是否在页面显示
    /// </summary>
    public bool Dispaly { get; set; }

    
}

public partial class Configure : IEntity
{
    public static implicit operator Configure(HIPS.HSPS.Interface.Persistence.Web.Configure source)
    {
        if (source != null)
        {
            var target = new Configure()
            {
                ID = source.ID,
                Key = source.Name,
                Description = source.Description,
                Category = source.Flag,
                Value = source.Value,
                Dispaly = source.Display

            };

            return target;
        }
        return null;
    }

    public static implicit operator HIPS.HSPS.Interface.Persistence.Web.Configure(Configure source)
    {
        if (source != null)
        {
            var target = new HIPS.HSPS.Interface.Persistence.Web.Configure()
            {
                ID = source.ID,
                Name = source.Key,
                Description = source.Description,
                Flag = source.Category,
                Value = source.Value,
                Display = source.Dispaly
            };

            return target;
        }
        return null;
    }
}
