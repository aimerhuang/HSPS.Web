
using HSPS.Web.Model.Helper;

namespace HSPS.Web.Model.Models.Extensions;

public partial class CodeMap
{
    /// <summary>
    /// ID
    /// </summary>
    public int ID { get; set; }

    /// <summary>
    /// 父ID
    /// </summary>
    public int ParentID { get; set; }

    /// <summary>
    /// 数据字典类别
    /// </summary>
    public string ClassType { get; set; }

    /// <summary>
    /// 编码
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    /// 数据字典项
    /// </summary>
    public string Item { get; set; }

    /// <summary>
    /// 排序字段
    /// </summary>
    public int Sort { get; set; }

    /// <summary>
    /// 数据字典描述
    /// </summary>
    public string Description { get; set; }
    /// <summary>
    /// 是否启用
    /// </summary>
    public bool IsEnable { get; set; }
}
public partial class CodeMap
{
    public static implicit operator CodeMap(HIPS.HSPS.Interface.Persistence.Web.CodeMap source)
    {
        if (source != null)
        {
            var target = new HSPS.Web.Model.Models.Extensions.CodeMap()
            {
                ClassType = source.ClassType,
                Code = source.Code,
                Description = source.Description,
                ID = source.ID,
                Item = source.Item,
                ParentID = source.ParentID,
                Sort = source.Sort,
                IsEnable = source.IsEnable
            };

            return target;
        }
        return null;
    }

    public static implicit operator TextValue(CodeMap source)
    {
        if (source != null)
        {
            var target = new TextValue()
            {
                Text = source.Item,
                Value = source.Code,
            };
            return target;
        }
        return null;
    }
}

