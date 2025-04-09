using Entities;

namespace HSPS.Web.Model.Dtos;

public class ResourceDto
{
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
