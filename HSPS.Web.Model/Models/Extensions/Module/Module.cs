namespace HSPS.Web.Model.Models.Extensions;

/// <summary>
/// 模块表（顶级菜单栏
/// </summary>
public partial class Module
{
    /// <summary>
    /// 主键id
    /// </summary>
    public int ID { get; set; }
    /// <summary>
    /// 模块名称（顶级菜单栏名称
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// 英文代号
    /// </summary>
    public string Code { get; set; }
    /// <summary>
    /// 父级id
    /// </summary>
    public int ParentID { get; set; }
    /// <summary>
    /// 菜单列表（二级菜单列表
    /// </summary>
    public List<Resource> Resources { get; set; }
}

public partial class Module
{
    public static implicit operator Module(HIPS.HSPS.Interface.Persistence.Web.Module source)
    {
        if (source != null)
        {
            var target = new Model.Models.Extensions.Module()
            {
                ID = source.ID,
                Code = source.Code,
                Name = source.Name,
                ParentID = source.ParentID
            };

            return target;
        }
        return null;
    }

    public static implicit operator HIPS.HSPS.Interface.Persistence.Web.Module(Module source)
    {
        if (source != null)
        {
            var target = new HIPS.HSPS.Interface.Persistence.Web.Module()
            {
                ID = source.ID,
                Code = source.Code,
                Name = source.Name,
                ParentID = source.ParentID
            };

            return target;
        }
        return null;
    }
}
