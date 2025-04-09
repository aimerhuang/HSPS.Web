using HSPS.Web.Model.Models;

namespace HSPS.Web.Model;

/// <summary>
/// 报告文件
/// </summary>
public class ReportFile
{
    /// <summary>
    /// 文件名称
    /// </summary>
    public string FileName { get; set; }
    public int No { get; set; }
    /// <summary>
    /// 文件类型枚举
    /// </summary>
    public FileExtTypeEnum FileExtType { get; set; }
}
