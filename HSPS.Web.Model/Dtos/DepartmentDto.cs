namespace HSPS.Web.Model.Dtos;

public class DepartmentDto
{
    /// <summary>
    /// 主键id
    /// </summary>
    public int ID { get; set; }
    /// <summary>
    /// 科室名称
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// 主机名/IP
    /// </summary>
    public string Host { get; set; }
    /// <summary>
    /// 科室端口
    /// </summary>
    public int Port { get; set; }

    /// <summary>
    /// 报告延迟领取时间（秒）
    /// </summary>
    public int DelayTimes { get; set; }

    /// <summary>
    /// 领取报告期限
    /// </summary>
    public int GetReportPeriod { get; set; }

    /// <summary>
    /// 是否在线 0离线 1在线
    /// </summary>
    public int IsAlive { get; set; }
    /// <summary>
    /// 是否允许重复报告  0不允许 1允许
    /// </summary>
    public int IsAllowRepeat { get; set; }
}
