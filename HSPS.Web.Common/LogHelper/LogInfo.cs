namespace HSPS.Web.Common.LogHelper;

public class LogInfo
{
    public DateTime Datetime { get; set; }
    /// <summary>
    /// 内容
    /// </summary>
    public string Content { get; set; }
    public string IP { get; set; }
    public string LogColor { get; set; }
    public int Import { get; set; } = 0;
}
