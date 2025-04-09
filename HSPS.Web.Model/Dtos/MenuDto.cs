

namespace HSPS.Web.Model.Dtos;

public class MenuDto
{
    public int ID { get; set; }
    /// <summary>
    /// 菜单URL
    /// </summary>
    public string Url { get; set; }
    /// <summary>
    /// 菜单名称
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// 菜单级别 1-一级菜单，2-二级菜单，3-三级菜单
    /// </summary>
    public int MenuLevel { get; set; }
    /// <summary>
    /// 父级ID
    /// </summary>
    public int ParentID { get; set; }
    /// <summary>
    /// 帮助链接
    /// </summary>
    public string HelpLink { get; set; }
    /// <summary>
    /// 排序
    /// </summary>
    public int Sort { get; set; }
    /// <summary>
    /// 是否启用
    /// </summary>
    public int IsEnable { get; set; }
}
