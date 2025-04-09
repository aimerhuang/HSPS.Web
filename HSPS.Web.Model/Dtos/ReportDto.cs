using HSPS.Web.Model.Enum;
using HSPS.Web.Model.Models;
using HSPS.Web.Model.Models.Extensions;

namespace HSPS.Web.Model.Dtos;

/// <summary>
/// 报告列表集合
/// </summary>
public class ReportDto
{

    /// <summary>
    /// ReportID
    /// </summary>
    public string ReportID { get; set; }
    /// <summary>
    /// ReportContextID
    /// </summary>
    public string ID { get; set; }
    /// <summary>
    /// 关联的报告ID
    /// </summary>
    public string RelationID { get; set; }
    /// <summary>
    /// 色彩
    /// </summary>
    public string PrintColorValue { get; set; }

    /// <summary>
    /// 介质
    /// </summary>
    public string PrintMediaValue { get; set; }
    /// <summary>
    /// 尺寸
    /// </summary>
    public string PrintSizeValue { get; set; }
    /// <summary>
    /// 打印状态枚举值
    /// </summary>
    public string PrintStatusValue { get; set; }
    /// <summary>
    /// 报告状态值
    /// </summary>
    public string ReportStatusValue { get; set; }
    /// <summary>
    /// 报告类型值
    /// </summary>
    public string ParseRuleTypeValue { get; set; }
    /// <summary>
    /// 条码号
    /// </summary>
    /// 
    public string BarCode { get; set; }
    /// <summary>
    /// 检查号
    /// </summary>
    //[Export("体检编号")]
    public string CheckID { get; set; }

    /// <summary>
    /// 检查时间
    /// </summary>
    public string CheckTime { get; set; }
    /// <summary>
    /// 病人编号
    /// </summary>
    public string PatientIDStr { get; set; }
    /// <summary>
    /// 病人姓名
    /// </summary>
    //[Export("姓名")]
    public string PatientName { get; set; }
    /// <summary>
    /// 来源ID
    /// </summary>
    public string StationID { get; set; }
    /// <summary>
    /// 来源ID
    /// </summary>
    public string StationName { get; set; }
    /// <summary>
    /// 来源IP
    /// </summary>
    public string StationIP { get; set; }
    /// <summary>
    /// 科室ID
    /// </summary>
    public string DepartmentID { get; set; }
    /// <summary>
    /// 科室名称
    /// </summary>
    public string DepartmentName { get; set; }

    /// <summary>
    /// 年龄
    /// </summary>
    public string Age { get; set; }

    /// <summary>
    /// 病人性别
    /// </summary>
    public string Sex { get; set; }
    /// <summary>
    /// 检查部位
    /// </summary>
    public string CheckPart { get; set; }
    /// <summary>
    /// 报告类别
    /// </summary>
    //[Export("体检类型")]
    public string ReportTypeName { get; set; }
    /// <summary>
    /// 报告类型ID
    /// </summary>
    public int? ReportTypeID { get; set; }
    /// <summary>
    /// 报告状态名称
    /// </summary>
    //[Export("报告状态")]
    public string ReportStatusName { get; set; }
    /// <summary>
    /// 识别状态
    /// </summary>
    //[Export("识别状态")]
    public string DiscernStatusName { get; set; }
    /// <summary>
    /// 打印状态
    /// </summary>
	//[Export("打印状态")]
    public string PrintStatusName { get; set; }
    /// <summary>
    /// 报告类型中文描述：胶片或者报告
    /// </summary>
    public string ParseRuleTypeName { get; set; }
    /// <summary>
    /// 接收时间
    /// </summary>
    //[Export("接收时间")]
    public string ReceiveTime { get; set; }
    /// <summary>
    /// 介质
    /// </summary>
    //[Export("介质")]
    public string PrintMediaName { get; set; }
    /// <summary>
    /// 尺寸
    /// </summary>
    //[Export("尺寸")]
    public string PrintSizeName { get; set; }
    /// <summary>
    /// 色彩
    /// </summary>
    public string PrintColorName { get; set; }
    /// <summary>
    /// 最后打印时间
    /// </summary>
    //[Export("打印时间")]
    public string PrintLastTime { get; set; }
    /// <summary>
    /// 排版
    /// </summary>
    public string Layout { get; set; }
    /// <summary>
    /// 页数
    /// </summary>
    public int PageCount { get; set; }
    /// <summary>
    /// 打印时报告文件的后缀
    /// </summary>
    public string PrintFileType { get; set; }
    /// <summary>
    /// 报告关键字
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// 报告路径
    /// </summary>
    public string ReportPath { get; set; }

    /// <summary>
    /// 自定义规则列的值
    /// </summary>
    public Dictionary<string, string> CustomFieldsValueList { get; set; }

    /// <summary>
    /// 病人表的ID
    /// </summary>
    public int? HspsPatientID { get; set; }
    /// <summary>
    /// 解析数据？
    /// </summary>
    public string ParseData { get; set; }
    /// <summary>
    /// 识别状态枚举值
    /// </summary>
    public string DiscernStatusValue { get; set; }
    /// <summary>
    /// 是否彩色
    /// </summary>
    public bool IsColorful { get; set; }

    /// <summary>
    /// 打印状态
    /// </summary>
    public PrintStatusEnum PrintStatus { get; set; }
    /// <summary>
    /// 打印介质
    /// </summary>
    public string Media { get; set; }
    /// <summary>
    /// 打印质量
    /// </summary>
    public PrintQualityEnum PintQuality { get; set; }
    /// <summary>
    /// 尺寸
    /// </summary>
    public string PrintSize { get; set; }
    /// <summary>
    /// 打印方式
    /// </summary>
    public PrintWayEnum PrintWay { get; set; }

    /// <summary>
    /// 报告类别（胶片或报告）
    /// </summary>
    public FileTypeEnum ParseRuleType { get; set; }
    /// <summary>
    /// 报告原始文件的后缀
    /// </summary>
    public FileExtTypeEnum FileExtType { get; set; }
    /// <summary>
    /// 检查单位
    /// </summary>
    //[Export("体检单位")]
    public string ExaminationCompany { get; set; }
    /// <summary>
    /// 检查部门
    /// </summary>
    //[Export("体检部门")]
    public string ExaminationDepartment { get; set; }
    /// <summary>
    /// 身份证号
    /// </summary>
    //[Export("身份证号")]
    public string IDNO { get; set; }
    /// <summary>
    /// 联系电话
    /// </summary>
    //[Export("电话")]
    public string Phone { get; set; }
    /// <summary>
    /// 就诊类型
    /// </summary>
    public string VisitType { get; set; }
    /// <summary>
    /// 打印次数
    /// </summary>
    //[Export("打印次数")]
    public int? PrintCount { get; set; }
    /// <summary>
    /// 院区
    /// </summary>
    public string HospitalArea { get; set; }
    /// <summary>
    /// 病区
    /// </summary>
    public string PatientArea { get; set; }
    /// <summary>
    /// 临床科室
    /// </summary>
    public string ClinicalDepartment { get; set; }
    /// <summary>
    /// 住院号
    /// </summary>
    public string HospitalNo { get; set; }
    /// <summary>
    /// 总检医生
    /// </summary>
    public string AuditDoctor { get; set; }
    /// <summary>
    /// 是否总监报告
    /// </summary>
    public bool IsExamination { get; set; }
    /// <summary>
    /// 审核记录
    /// </summary>
    public ReportAudit ReportAudit { get; set; }
    /// <summary>
    /// 报告医生
    /// </summary>
    public string ReportDoctor { get; set; }
    /// <summary>
    /// 一级审核医生
    /// </summary>
    public string FirstAuditDoctor { get; set; }
    /// <summary>
    /// 一级审核时间
    /// </summary>
    public string FirstAuditTime { get; set; }
    /// <summary>
    /// 二级审核医生
    /// </summary>
    public string SecondAuditDoctor { get; set; }
    /// <summary>
    /// 二级审核时间
    /// </summary>
    public string SecondAuditTime { get; set; }
    /// <summary>
    /// 三级审核医生
    /// </summary>
    public string ThirdAuditDoctor { get; set; }
    /// <summary>
    /// 三级审核时间
    /// </summary>
    public string ThirdAuditTime { get; set; }
    /// <summary>
    /// 审核状态
    /// </summary>
    public string AuditLevel { get; set; }

    //     报告当前进程审核级别
    public string ReportCurrentAuditLevel { get; set; }

}
