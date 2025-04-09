using SqlSugar;

namespace HSPS.Web.Model.Base;
/// <summary>
/// log
/// </summary>
public abstract class BaseLog : RootEntityTkey<long>
{
    /// <summary>
    /// 时间
    /// </summary>
    [SplitField]
    public DateTime? DateTime { get; set; }
    
    [SugarColumn(IsNullable = true)]
    public string Level { get; set; }
    [SugarColumn(IsNullable = true, ColumnDataType = "longtext,text,clob")]
    public string Message { get; set; }

    [SugarColumn(IsNullable = true, ColumnDataType = "longtext,text,clob")]
    public string MessageTemplate { get; set; }

    [SugarColumn(IsNullable = true, ColumnDataType = "longtext,text,clob")]
    public string Properties { get; set; }
}

