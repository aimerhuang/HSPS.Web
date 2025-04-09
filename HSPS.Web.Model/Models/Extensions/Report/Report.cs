using HIPS.HSPS.Interface.Persistence.Web;
using HSPS.Web.Model.Enum;
using HSPS.Web.Model.Helper;
using System.Xml;

namespace HSPS.Web.Model.Models.Extensions;

/// <summary>
/// wcf接口的报告类
/// </summary>
public partial class Report : IEntity
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

    /// <summary>
    /// wcf接口的report类
    /// </summary>
    /// <param name="source"></param>

    public static implicit operator Report(ReportContext source)
    {
        if (source != null)
        {

            var target = new Report()
            {
                ID = source.ID.ToString(),
                ReportID = source.Report.ID.ToString(),
                BarCode = source.BarCode,
                CheckID = source.CheckID,
                CheckPart = source.CheckPart,
                ReceiveTime = source.Report.ReceiveTime == null ? "" : source.Report.ReceiveTime.ToString("yyyy-MM-dd HH:mm:ss"),
                PatientName = source.PatientName,
                PrintStatus = source.Report.PrintStatus.ParseEnum(PrintStatusEnum.Unprint),
                PrintSize = source.Report.PrintParameter == null ? "" : source.Report.PrintParameter.PrintParam.PrintSize,
                ParseRuleType = source.Report.FileType.ParseEnum(FileTypeEnum.Report),
                FileExtType = source.Report.PrintFileType.ParseEnum(FileExtTypeEnum.Xps),
                DiscernStatusValue = source.Report.DiscernStatus.ToString(),
                PrintColorValue = source.Report.PrintParameter == null ? "false" : source.Report.PrintParameter.PrintParam.IsColorful ? "true" : "false",
                PrintMediaValue = source.Report.PrintParameter == null ? "" : source.Report.PrintParameter.PrintParam.Media.ToString(),
                PrintSizeValue = source.Report.PrintParameter == null ? "" : source.Report.PrintParameter.PrintParam.PrintSize.ToString(),
                PrintStatusValue = source.Report.PrintStatus.ToString(),
                ReportStatusValue = source.Report.ReportStatus.ParseEnum(ReportStatusEnum.Normal).ToString(),
                ParseRuleTypeValue = source.Report.FileType.ParseEnum(FileTypeEnum.Report).ToString(),
                PrintColorName = source.Report.PrintParameter == null ? "" : source.Report.PrintParameter.PrintParam.IsColorful ? "彩色" : "黑白",
                PrintMediaName = source.Report.PrintParameter == null ? "普通纸" : GetMediaValue(source.Report.PrintParameter.PrintParam.Media),//CodemapHelper.GetNameByCode("DicomMedia,ReportMedia", source.Report.PrintParameter.PrintParam.Media),
                PrintSizeName = source.Report.PrintParameter == null ? "未知" : source.Report.PrintParameter.PrintParam.PrintSize,//CodemapHelper.GetNameByCode("ReportPrintSize,DicomPrintSize", source.Report.PrintParameter.PrintParam.PrintSize),
                DiscernStatusName = EnumHelper.ConvertToEnumDescription(source.Report.DiscernStatus.ParseEnum(DiscernStatusEnum.Unknow)),
                PrintStatusName = EnumHelper.ConvertToEnumDescription(source.Report.PrintStatus.ParseEnum(PrintStatusEnum.Unprint)),
                ReportStatusName = EnumHelper.ConvertToEnumDescription(source.Report.ReportStatus.ParseEnum(ReportStatusEnum.Normal)),
                ParseRuleTypeName = source.Report.FileType == EnumFileType.Report ? "报告" : "胶片",
                ReportTypeID = source.Report.ReportTypeID,
                ReportTypeName = source.Report.ReportTypeName,
                PatientIDStr = source.PatientIDStr,
                PrintLastTime = source.Report.PrintLastTime == null ? "" : source.Report.PrintLastTime.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                ReportPath = source.Report.ReportPath,
                StationID = source.Report.StationID.ToString(),
                StationIP = source.Report.Station != null ? source.Report.Station.Host : "",
                StationName = source.Report.Station != null ? source.Report.Station.Name : "",
                DepartmentID = source.Report.Station != null ? source.Report.Station.Department != null ? source.Report.Station.Department.ID.ToString() : "" : "",
                DepartmentName = source.Report.Station != null ? source.Report.Station.Department != null ? source.Report.Station.Department.Name.ToString() : "" : "",
                Age = source.Age,
                CheckTime = source.CheckTime,
                HspsPatientID = source.HspsPatientID,
                Layout = source.Report.Layout,
                PageCount = source.Report.PageCount,
                ParseData = source.ParseData,
                PrintFileType = source.Report.PrintFileType.ToString(),
                RelationID = source.RelationID.HasValue ? source.RelationID.ToString() : "",
                Sex = source.Sex,
                Title = source.Title,
                ExaminationCompany = source.ExaminationCompany,
                ExaminationDepartment = source.ExaminationDepartment,
                IDNO = source.IDNO,
                Phone = source.Phone,
                CustomFieldsValueList = GetCustomFieldsValueListByXml(source.ParseData),
                PrintCount = source.Report.PrintCount,
                VisitType = source.VisitType,//ConvertToVisitTypeName(source.VisitType),
                IsColorful = source.Report.PrintParameter == null ? false : source.Report.PrintParameter.PrintParam.IsColorful ? true : false,
                Media = source.Report.PrintParameter == null ? "" : source.Report.PrintParameter.PrintParam.Media,
                HospitalArea = source.HospitalArea,
                PatientArea = source.PatientArea,
                ClinicalDepartment = source.ClinicalDepartment,
                HospitalNo = source.HospitalNo,
                ReportDoctor = source.ReportDoctor,
                FirstAuditDoctor = source.ReportAudit != null && source.ReportAudit.FirstAuditDoctor != null ?
                source.ReportAudit.FirstAuditDoctor : source.FirstAuditDoctor,
                FirstAuditTime = source.ReportAudit != null && source.ReportAudit.FirstAuditTime.HasValue ?
                    source.ReportAudit.FirstAuditTime.Value.ToString("yyyy-MM-dd HH:mm") : string.Empty,
                SecondAuditDoctor = source.ReportAudit != null && source.ReportAudit.SecondAuditDoctor != null ?
                source.ReportAudit.SecondAuditDoctor : source.SecondAuditDoctor,
                SecondAuditTime = source.ReportAudit != null && source.ReportAudit.SecondAuditTime.HasValue ?
                    source.ReportAudit.SecondAuditTime.Value.ToString("yyyy-MM-dd HH:mm") : string.Empty,
                ThirdAuditDoctor = source.ReportAudit != null && source.ReportAudit.ThirdAuditDoctor != null ?
                source.ReportAudit.ThirdAuditDoctor : source.ThirdAuditDoctor,
                ThirdAuditTime = source.ReportAudit != null && source.ReportAudit.ThirdAuditTime.HasValue ?
                    source.ReportAudit.ThirdAuditTime.Value.ToString("yyyy-MM-dd HH:mm") : string.Empty,
                AuditLevel = source.Report.ReportStatus == EnumReportStatus.AuditNotPassed ? "未通过" : "待审核",
                ReportCurrentAuditLevel = source.ReportCurrentAuditLevel.ToString()
            };
            return target;
        }
        return null;
    }
    //private static string ConvertToVisitTypeName(string visitTypeCode)
    //{
    //    if (!string.IsNullOrEmpty(visitTypeCode))
    //    {
    //        try
    //        {
    //            object codeMapObj = YiBan.HSPS.Main.Utility.CacheHelper.GetCache(Constant.CACHE_HSPS_CODEMAP);
    //            if (codeMapObj != null)
    //            {
    //                IEnumerable<CodeMap> codeMapList = codeMapObj as IEnumerable<CodeMap>;
    //                if (codeMapList != null)
    //                {
    //                    CodeMap visitType = codeMapList.FirstOrDefault(item => item.ClassType == CodeMapConstant.VISIT_TYPE && item.Code == visitTypeCode);

    //                    if (visitType != null)
    //                    {
    //                        return visitType.Item;
    //                    }
    //                }
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            LogHelper.Warn("根据就诊类型值获取就诊类型名称失败", ex);
    //        }
    //    }
    //    return visitTypeCode;
    //}

    /// <summary>
    /// 解析自定义规则列的值并返回
    /// </summary>
    /// <param name="xml"></param>
    /// <returns></returns>
    public static Dictionary<string, string> GetCustomFieldsValueListByXml(string xml)
    {
        Dictionary<string, string> customFieldsByXml = new Dictionary<string, string>();
        if (!string.IsNullOrEmpty(xml))
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xml);
                //查找<Other>
                XmlNode others = xmlDoc.SelectSingleNode("Other");
                //获取到所有<Other>的子节点
                if (others != null)
                {
                    XmlNodeList nodeList = others.ChildNodes;

                    if (nodeList != null)
                    {
                        //遍历所有子节点
                        foreach (XmlNode xn in nodeList)
                        {
                            if (!string.IsNullOrEmpty(xn.InnerText))
                            {
                                customFieldsByXml[xn.Name] = xn.InnerText;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //LogHelper.Info("解析自定义规则列内容失败,xml:" + xml, ex);
            }
        }
        return customFieldsByXml;
    }

    public static implicit operator UpdateReport(Report source)
    {
        if (source != null)
        {
            PrintParam printParam = null;
            if (source.ParseRuleType == FileTypeEnum.Report)//胶片不能修改打印参数
            {
                printParam = new PrintParam();
                printParam.Media = source.Media;
                var pSize = source.PrintSize;
                if (pSize == "Unknow")
                {
                    pSize = "A4";
                }
                printParam.PrintSize = pSize;
                printParam.IsColorful = source.IsColorful;
            }

            var target = new UpdateReport()
            {
                ReportContextID = long.Parse(source.ID),
                BarCode = source.BarCode,
                PrintParam = printParam,
                CheckPart = source.CheckPart,
                PatientName = source.PatientName,
                PatientIdStr = source.PatientIDStr,
                CheckId = source.CheckID,
                ExaminationCompany = source.ExaminationCompany,
                ExaminationDepartment = source.ExaminationDepartment,
                IDNO = source.IDNO,
                ReportTypeID = source.ReportTypeID == null ? 0 : source.ReportTypeID.Value,
                ReportDoctor = source.ReportDoctor,
                FirstAuditDoctor = source.FirstAuditDoctor,
                SecondAuditDoctor = source.SecondAuditDoctor,
                ThirdAuditDoctor = source.ThirdAuditDoctor
            };

            return target;
        }
        return null;
    }


    public static string GetMediaValue(string media)
    {
        var value = string.Empty;
        value = media switch
        {
            "Unknow" => "未知",
            "GeneralGraph" => "普通纸",
            "WhiteGraph" => "白基",
            "BlueGraph" => "蓝基",
            "PhotoGraph" => "相纸",
            _ => string.Empty,
        };
        return value;
    }
}
