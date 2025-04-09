using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSPS.Web.Model.Models.Extensions;

/// <summary>
/// 审核记录
/// </summary>
public partial class ReportAudit
{
    /// <summary>
    /// 编号
    /// </summary>
    public long ID { get; set; }
    /// <summary>
    /// 一级审核医生姓名
    /// </summary>
    public string FirstAuditDoctor { get; set; }
    /// <summary>
    /// 一级审核医生用户名
    /// </summary>
    public string FirstAuditDoctorID { get; set; }

    /// <summary>
    /// 一级审核时间
    /// </summary>
    public DateTime? FirstAuditTime { get; set; }
    /// <summary>
    /// 二级审核医生姓名
    /// </summary>
    public string SecondAuditDoctor { get; set; }

    /// <summary>
    ///  二级审核医生用户名
    /// </summary>
    public string SecondAuditDoctorID { get; set; }

    /// <summary>
    /// 二级审核时间
    /// </summary>
    public DateTime? SecondAuditTime { get; set; }

    /// <summary>
    /// 三级审核医生姓名
    /// </summary>
    public string ThirdAuditDoctor { get; set; }

    /// <summary>
    /// 三级审核医生用户名
    /// </summary>
    public string ThirdAuditDoctorID { get; set; }

    /// <summary>
    /// 三级审核时间
    /// </summary>
    public DateTime? ThirdAuditTime { get; set; }


}
