namespace HSPS.Web.Model.Models.Extensions;

/// <summary>
/// 资源表
/// </summary>
public partial class Resource
{
    /// <summary>
    /// 资源id
    /// </summary>
    public int ID { get; set; }
    /// <summary>
    /// 模块id（顶级菜单栏id
    /// </summary>
    public int ModuleID { get; set; }
    /// <summary>
    /// 资源名称
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// 备注
    /// </summary>
    public string Description { get; set; }
    /// <summary>
    /// 资源代码
    /// </summary>
    public string Code { get; set; }
    /// <summary>
    /// 资源路径
    /// </summary>
    public string Url { get; set; }
    /// <summary>
    /// 对应模块
    /// </summary>
    public Module Module { get; set; }
}

public partial class Resource
{
    public static implicit operator Resource(HIPS.HSPS.Interface.Persistence.Web.Resource source)
    {
        if (source != null)
        {
            var target = new Resource()
            {
                ID = source.ID,
                Code = source.Code,
                Name = source.Name,
                Description = source.Description,
                Module = (Module)source.Module,
                ModuleID = source.Module.ID,
                Url = source.Url
            };

            return target;
        }
        return null;
    }

    public static implicit operator HIPS.HSPS.Interface.Persistence.Web.Resource(Resource source)
    {
        if (source != null)
        {
            var target = new HIPS.HSPS.Interface.Persistence.Web.Resource()
            {
                ID = source.ID,
                Code = source.Code,
                Name = source.Name,
                Description = source.Description,
                ModuleID = source.Module.ID,
                Module = (HIPS.HSPS.Interface.Persistence.Web.Module)source.Module,
                Url = source.Url
            };

            return target;
        }
        return null;
    }
}