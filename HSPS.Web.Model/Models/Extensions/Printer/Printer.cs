namespace HSPS.Web.Model.Models.Extensions;

public partial class Printer : IEntity
{
    /// <summary>
    /// 医院编码
    /// </summary>
    public string HospitalCode { get; set; }
    /// <summary>
    /// 主键id
    /// </summary>
    public int ID { get; set; }
    /// <summary>
    /// 打印机名称
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// ip地址
    /// </summary>
    public string Host { get; set; }
    /// <summary>
    /// 端口
    /// </summary>
    public Nullable<int> Port { get; set; }

    /// <summary>
    /// 设备型号
    /// </summary>
    public string TerminalType { get; set; }
    /// <summary>
    /// 终端类别名称
    /// </summary>
    public string TerminalTypeName { get; set; }
    /// <summary>
    /// 可打印类型枚举 0报告/1胶片/2报告和胶片
    /// </summary>
    public SupportFileTypeEnum SupportFileType { get; set; }
    /// <summary>
    /// 设备编号(SN)
    /// </summary>
    public string SNumber { get; set; }
    /// <summary>
    /// AETitle
    /// </summary>
    public string AETitle { get; set; }
    /// <summary>
    /// 终端版本
    /// </summary>
    public string Version { get; set; }
    /// <summary>
    /// 科室id（弃用
    /// </summary>
    public string SupportDeptId { get; set; }
    /// <summary>
    /// 科室名称（弃用
    /// </summary>
    public string SupportDeptString { get; set; }
    /// <summary>
    /// 是否在线
    /// </summary>
    public bool IsAlive { get; set; }
    /// <summary>
    /// 打印机状态（弃用
    /// </summary>
    public string PrinterStata { get; set; }
    /// <summary>
    /// 品牌
    /// </summary>
    public string Brand { get; set; }
    /// <summary>
    /// 所属院区
    /// </summary>
    public string HospitalArea { get; set; }
    /// <summary>
    /// 所属院区
    /// </summary>
    public int HospitalAreaValue { get; set; }
    /// <summary>
    /// 所属病区
    /// </summary>
    public string PatientArea { get; set; }
    /// <summary>
    /// 所属病区
    /// </summary>
    public int PatientAreaValue { get; set; }
    /// <summary>
    /// 临床科室
    /// </summary>
    public string ClinicalDepartment { get; set; }
    /// <summary>
    /// 临床科室
    /// </summary>
    public int ClinicalAreaValue { get; set; }
    /// <summary>
    /// 二维码
    /// </summary>
    public string QRCode { get; set; }
    /// <summary>
    /// 备注
    /// </summary>
    public string Remark { get; set; }
    /// <summary>
    /// 共享打印机名称
    /// </summary>
    public string SharedName { get; set; }
    /// <summary>
    /// 是否可用
    /// </summary>
    public bool IsEnabled { get; set; }
    /// <summary>
    /// 型号
    /// </summary>
    public string ModelNo { get; set; }
    /// <summary>
    /// 打印机类型
    /// </summary>
    public string PrinterType { get; set; }
    /// <summary>
    /// 安装时间
    /// </summary>
    public string InstallTime { get; set; }
    /// <summary>
    /// 最后修改时间
    /// </summary>
    public string LastUpdateTime { get; set; }
    /// <summary>
    /// 有效性
    /// </summary>
    public string IsEnabledText { get; set; }
    /// <summary>
    /// 支持打印格式
    /// </summary>
    public string PrintFormatText { get; set; }
    /// <summary>
    /// 支持打印格式描述
    /// </summary>
    public string PrintFormatValue { get; set; }
    /// <summary>
    /// 打印机余量显示
    /// </summary>
    public string PaperRemain { get; set; }

    public static implicit operator Printer(HIPS.HSPS.Interface.Persistence.Web.UserTerminal source)
    {
        if (source != null)
        {
            var target = new Printer()
            {
                ID = source.ID,
                AETitle = source.AETitle,
                TerminalType = source.TerminalType,
                TerminalTypeName = source.TerminalType,
                Host = source.Host,
                Name = source.Name,
                Port = source.Port,
                SNumber = source.SNumber,
                SupportFileType = (source.SupportFileType).ParseEnum<SupportFileTypeEnum>(SupportFileTypeEnum.Report),
                Version = source.Version,
                SupportDeptId = source.SupportReportTypeIds,
                IsAlive = source.IsAlive,
                Brand = source.Brand,
                ClinicalDepartment = source.ClinicalDepartment == null ? string.Empty : source.ClinicalDepartment.ClinicalDepartmentName,
                ClinicalAreaValue = source.ClinicalDepartmentID,
                IsEnabled = source.IsEnabled,
                ModelNo = source.ModelNo,
                PatientArea = source.PatientArea == null ? string.Empty : source.PatientArea.PatientAreaName,
                PatientAreaValue = source.PatientAreaID,
                PrinterType = source.PrinterType,
                QRCode = source.QRCode,
                Remark = source.Remark,
                SharedName = source.CustomName,
                HospitalArea = source.HospitalArea == null ? string.Empty : source.HospitalArea.HospitalAreaName,
                HospitalAreaValue = source.HospitalAreaID,
                InstallTime = source.InstallTime,
                LastUpdateTime = source.LastUpdateTime == null ? string.Empty : Convert.ToDateTime(source.LastUpdateTime).ToString("yyyy-MM-dd HH:mm"),
                IsEnabledText = source.IsEnabled ? "是" : "否",
                PrintFormatValue = ((PrintFormatEnum)source.PrintFormat).ToString(),
                PrintFormatText = source.PrintFormat == 0 ? "源文件" : "图片",


            };

            return target;
        }
        return null;
    }

    public static implicit operator HIPS.HSPS.Interface.Persistence.Web.UserTerminal(Printer source)
    {
        if (source != null)
        {
            var target = new HIPS.HSPS.Interface.Persistence.Web.UserTerminal()
            {
                ID = source.ID,
                AETitle = source.AETitle,
                TerminalType = source.TerminalType,
                Host = source.Host,
                Name = source.Name,
                Port = source.Port,
                SNumber = source.SNumber,
                SupportFileType = (source.SupportFileType).ParseEnum<HIPS.HSPS.Interface.Persistence.Web.EnumSupportFileType>(HIPS.HSPS.Interface.Persistence.Web.EnumSupportFileType.Report),
                Brand = source.Brand,
                ClinicalDepartmentID = source.ClinicalAreaValue,
                IsAlive = source.IsAlive,
                IsEnabled = source.IsEnabled,
                ModelNo = source.ModelNo,
                PatientAreaID = source.PatientAreaValue,
                PrinterType = source.PrinterType,
                QRCode = source.QRCode,
                Remark = source.Remark,
                CustomName = source.SharedName,
                SupportReportTypeIds = source.SupportDeptId,
                Version = source.Version,
                HospitalAreaID = source.HospitalAreaValue,
                InstallTime = source.InstallTime,
                PrintFormat = (int)source.PrintFormatValue.ParseEnum<PrintFormatEnum>(PrintFormatEnum.SourceFile)
            };

            return target;
        }
        return null;
    }
}


