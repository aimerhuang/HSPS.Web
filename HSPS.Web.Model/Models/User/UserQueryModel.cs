using HSPS.Web.Model;

namespace HSPS.Web.Models;

public class UserQueryModel : OrderBy
{
    /// <summary>
    /// 登录名/用户名
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// 状态0未启用 1启用
    /// </summary>
    public int? Enabled { get; set; }

   
    public int? StartPage { get; set; }

    
    public int? PageSize { get; set; }
}
