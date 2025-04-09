using HIPS.HSPS.Interface.Persistence.Web;

namespace HSPS.Web.Model.Models.Extensions;

/// <summary>
/// 工作站打印机
/// </summary>
public class StationTerminalRelation : IEntity
{
    /// <summary>
    /// 主键id
    /// </summary>
    public int ID { get; set; }
    /// <summary>
    /// 打印机集合
    /// </summary>
    public virtual Printer Printer { get; set; }
    /// <summary>
    /// 类别id
    /// </summary>
    public int ReportTypeID { get; set; }
    /// <summary>
    /// 类别名称
    /// </summary>
    public string ReportTypeName { get; set; }
    /// <summary>
    /// 打印方式枚举
    /// </summary>
    public PrintSolutionEnum PrintSolution { get; set; }
    /// <summary>
    /// 打印方式
    /// </summary>
    public string PrintSolutionStr { get; set; }
    /// <summary>
    /// 工作站id
    /// </summary>
    public int StationID { get; set; }
    /// <summary>
    /// 工作站
    /// </summary>
    public string StationHost { get; set; }
    /// <summary>
    /// 就诊类型编码。0-未知，1-门诊，2-住院，3-体检。
    /// </summary>
    public string VisitType { get; set; }
    /// <summary>
    /// 打印机id
    /// </summary>
    public int UserTerminalID { get; set; }
    /// <summary>
    /// 打印机名称
    /// </summary>
    public string UserTerminalName { get; set; }
    /// <summary>
    /// 打印类别
    /// </summary>
    public string ParseRuleType { get; set; }
    /// <summary>
    /// 科室id
    /// </summary>
    public int DepartmentID { get; set; }
    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; }
    public static implicit operator StationTerminalRelation(HIPS.HSPS.Interface.Persistence.Web.StationTerminalRelation source)
    {
        if (source != null)
        {
            Printer printer = new Printer();
            printer.ID = source.UserTerminalID;
            printer.Name = source.UserTerminalName;
            printer.Host = source.UserTerminalHost;
            var target = new StationTerminalRelation()
            {
                Name = source.Station.Name,
                ID = source.ID,
                PrintSolution = (source.PrintSolutionApply.PrintSolution.Solution).ParseEnum<PrintSolutionEnum>(PrintSolutionEnum.Manual),
                PrintSolutionStr = PrintSolutionApply.GetPrintSolutionStr((source.PrintSolutionApply.PrintSolution.Solution).ParseEnum<PrintSolutionEnum>(PrintSolutionEnum.Manual)),
                StationHost = source.Station.Host,
                StationID = source.Station.ID,
                Printer = printer,
                VisitType = source.VisitType,
                ReportTypeID = source.PrintSolutionApply.ReportType.ID,
                ReportTypeName = source.PrintSolutionApply.ReportType.Name,
                ParseRuleType = source.PrintSolutionApply.ReportType.ParseRuleType.ToString(),
                DepartmentID = source.PrintSolutionApply.ReportType.DepartmentID
            };

            return target;
        }
        return null;
    }

    public static implicit operator HIPS.HSPS.Interface.Persistence.Web.AddOrUpdatePrintBindRelation(StationTerminalRelation source)
    {
        if (source != null)
        {
            var target = new HIPS.HSPS.Interface.Persistence.Web.AddOrUpdatePrintBindRelation()
            {
                BindID = source.ID,
                UserTerminalID = source.Printer.ID,
                ReportTypeID = source.ReportTypeID,
                StationID = source.StationID,
                VisitType = source.VisitType,
                PrintSolution = (source.PrintSolution).ParseEnum<HIPS.HSPS.Interface.Persistence.Web.EnumPrintSolution>(HIPS.HSPS.Interface.Persistence.Web.EnumPrintSolution.Manual),
            };

            return target;
        }
        return null;
    }
}
