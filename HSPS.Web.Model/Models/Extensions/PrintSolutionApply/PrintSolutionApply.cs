namespace HSPS.Web.Model.Models.Extensions;

/// <summary>
/// 类别对应打印方式
/// </summary>
public partial class PrintSolutionApply : IEntity
{
    /// <summary>
    /// 是否启用
    /// </summary>
    public bool Enabled { get; set; }
    /// <summary>
    /// 主键id
    /// </summary>
    public int ID { get; set; }
    /// <summary>
    /// 类别集合
    /// </summary>
    public ReportType ReportType { get; set; }
    /// <summary>
    /// 打印方式名称
    /// </summary>
    public string PrintSolutionName { get; set; }
    /// <summary>
    /// 打印方式枚举
    /// </summary>
    public PrintSolutionEnum PrintSolution { get; set; }

    public static implicit operator PrintSolutionApply(HIPS.HSPS.Interface.Persistence.Web.PrintSolutionApply source)
    {
        if (source != null)
        {
            var target = new PrintSolutionApply()
            {
                ID = source.ID,
                Enabled = source.Enabled,
                ReportType = source.ReportType,
                PrintSolution = (source.PrintSolution.Solution).ParseEnum<PrintSolutionEnum>(PrintSolutionEnum.Manual),
                PrintSolutionName = GetPrintSolutionStr((source.PrintSolution.Solution).ParseEnum<PrintSolutionEnum>(PrintSolutionEnum.Manual))
            };
            return target;
        }
        return null;
    }
    public static string GetPrintSolutionStr(PrintSolutionEnum PrintSolution)
    {
        var relust = "未设置方案";
        switch (PrintSolution)
        {
            case PrintSolutionEnum.Auto_NoWork:
                relust = "非工作时间直打";
                break;
            case PrintSolutionEnum.Auto_Work:
                relust = "直接打印";
                break;
            case PrintSolutionEnum.Manual:
                relust = "自助打印";
                break;
            case PrintSolutionEnum.Nope:
                relust = "不打印";
                break;
        }

        return relust;
    }
}
