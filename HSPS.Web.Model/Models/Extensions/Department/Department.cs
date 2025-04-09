using HIPS.HSPS.Interface.Persistence.Web;

namespace HSPS.Web.Model.Models.Extensions;

/// <summary>
/// 科室表
/// </summary>
public partial class Department
{
    /// <summary>
    /// 报告延迟领取时间（秒）
    /// </summary>
    public int DelayTimes { get; set; }
    /// <summary>
    /// （未使用，弃用）
    /// </summary>
    public int FilingTime { get; set; }
    /// <summary>
    /// 主机名/IP
    /// </summary>
    public string Host { get; set; }
    /// <summary>
    /// 领取报告期限
    /// </summary>
    public int GetReportPeriod { get; set; }
    /// <summary>
    /// 主键id
    /// </summary>
    public int ID { get; set; }
    /// <summary>
    /// 是否在线
    /// </summary>
    public bool IsAlive { get; set; }
    /// <summary>
    /// 是否允许重复报告
    /// </summary>
    public bool IsAllowRepeat { get; set; }
    /// <summary>
    /// 科室名称
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// 科室端口
    /// </summary>
    public int Port { get; set; }
    /// <summary>
    /// 打印类型
    /// </summary>
    public PrintModeEnum PrintMode { get; set; }
}

public partial class Department : IEntity
{
    public static implicit operator Department(HIPS.HSPS.Interface.Persistence.Web.Department source)
    {
        if (source != null)
        {
            var target = new Department()
            {
                DelayTimes = source.DelayTimes,
                IsAlive = source.IsAlive,
                IsAllowRepeat = source.IsAllowRepeat,
                ID = source.ID,
                Host = source.Host,
                Name = source.Name,
                Port = source.Port,
                GetReportPeriod = source.GetReportPeriod
            };
            return target;
        }
        return null;
    }

    public static implicit operator HIPS.HSPS.Interface.Persistence.Web.Department(Department source)
    {
        if (source != null)
        {
            var target = new HIPS.HSPS.Interface.Persistence.Web.Department()
            {

                DelayTimes = source.DelayTimes,
                IsAlive = source.IsAlive,
                IsAllowRepeat = source.IsAllowRepeat,
                ID = source.ID,
                Host = source.Host,
                Name = source.Name,
                Port = source.Port,
                GetReportPeriod = source.GetReportPeriod
            };
            return target;
        }
        return null;
    }
}