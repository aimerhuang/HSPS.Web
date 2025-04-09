using SqlSugar;

namespace Entities
{
    /// <summary>
    /// 科室表
    /// </summary>
    [SugarTable("Department", "科室表")]
    public class Department
    {
        /// <summary>
        /// 主键id
        /// </summary>
        [SugarColumn(IsNullable = false, IsPrimaryKey = true, IsIdentity = true)]
        public int ID { get; set; }
        /// <summary>
        /// 科室名称
        /// </summary>
        [SugarColumn(IsNullable = false, Length = 50)]
        public string Name { get; set; }
        /// <summary>
        /// 主机名/IP
        /// </summary>
        [SugarColumn(IsNullable = false, Length = 50)]
        public string Host { get; set; }
        /// <summary>
        /// 科室端口
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public int Port { get; set; }

        /// <summary>
        /// 报告延迟领取时间（秒）
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public int DelayTimes { get; set; }

        /// <summary>
        /// 领取报告期限
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public int GetReportPeriod { get; set; }

        /// <summary>
        /// 是否在线 0离线 1在线
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public int IsAlive { get; set; }
        /// <summary>
        /// 是否允许重复报告  0不允许 1允许
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public int IsAllowRepeat { get; set; }

    }
}
