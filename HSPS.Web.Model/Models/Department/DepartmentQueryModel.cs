

namespace HSPS.Web.Model.Models;

public class DepartmentQueryModel : OrderBy
{
    /// <summary>
    /// 科室名称
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// 主机/IP
    /// </summary>
    public string Host { get; set; }
    /// <summary>
    /// 端口号
    /// </summary>
    public int? Port { get; set; }

    public int? StartPage { get; set; }


    public int? PageSize { get; set; }
}