namespace HSPS.Web.Model;

/// <summary>
/// 查询排序基类
/// </summary>
public class OrderBy
{
    /// <summary>
    /// 排序字段名
    /// </summary>
    public string? Orderby { get; set; }

    /// <summary>
    /// 排序方式 --asc 升序 ---desc 降序
    /// </summary>
    public string? Order { get; set; }
}
