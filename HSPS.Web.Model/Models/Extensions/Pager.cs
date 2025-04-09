namespace HSPS.Web.Model.Models.Extensions;

public class Pager<T>
{
    private int _pageIndex = 1;
    /// <summary>
    /// 当前页码
    /// </summary>
    public int PageIndex
    {
        get { return _pageIndex; }
        set { _pageIndex = value; }
    }

    private int _pageSize = 20;
    /// <summary>
    /// 每页显示条数
    /// </summary>
    public int PageSize
    {
        get { return _pageSize; }
        set { _pageSize = value; }
    }

    private int _totalCount = 0;
    /// <summary>
    /// 总条目数
    /// </summary>
    public int TotalCount
    {
        get { return _totalCount; }
        set { _totalCount = value; }
    }

    private List<T> _rowList = new List<T>();
    /// <summary>
    /// 数据集合
    /// </summary>
    public List<T> Result
    {
        get { return _rowList; }
        set { _rowList = value; }
    }

    public Pager()
    {

    }


}
