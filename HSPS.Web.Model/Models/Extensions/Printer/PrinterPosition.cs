using HSPS.Web.Model.Helper;
using ServerEntity = HIPS.HSPS.Interface.Persistence.Web;

namespace HSPS.Web.Model.Models.Extensions;

/// <summary>
/// 终端对应打印机列表
/// </summary>
public partial class PrinterPosition : IEntity
{
    /// <summary>
    /// 医院编码
    /// </summary>
    public string HospitalCode { get; set; }
    /// <summary>
    /// 打印机ID
    /// </summary>
    public int PrinterID { get; set; }
    /// <summary>
    /// 打印机名称
    /// </summary>
    public string PrinterName { get; set; }
    /// <summary>
    /// 类型
    /// </summary>
    public string PartTypeName { get; set; }
    /// <summary>
    /// 型号
    /// </summary>
    public string ModelNo { get; set; }
    /// <summary>
    /// 型号
    /// </summary>
    public string ModelNoText { get; set; }
    /// <summary>
    /// SN
    /// </summary>
    public string SNumber { get; set; }
    /// <summary>
    /// 二维码
    /// </summary>
    public string QRCode { get; set; }
    /// <summary>
    /// 终端名称
    /// </summary>
    public string TerminalName { get; set; }
    /// <summary>
    /// 终端SN
    /// </summary>
    public string TerminalSN { get; set; }
    /// <summary>
    /// 终端类型
    /// </summary>
    public string TerminalType { get; set; }
    /// <summary>
    /// 终端类型
    /// </summary>
    public string TerminalTypeName { get; set; }
    /// <summary>
    /// 终端二维码
    /// </summary>
    public string TerminalQRCode { get; set; }
    /// <summary>
    /// 安装时间
    /// </summary>
    public string InstallTime { get; set; }
    /// <summary>
    /// 打印机尺寸
    /// </summary>
    public string PrintSize { get; set; }
    /// <summary>
    /// 终端id
    /// </summary>
    public int TerminalID { get; set; }
    /// <summary>
    /// 打印机状态
    /// </summary>
    public string PrinterStatus { get; set; }
    /// <summary>
    /// 打印机状态(原值)
    /// </summary>
    public string PrinterStatusValue { get; set; }
    /// <summary>
    /// 上报时间
    /// </summary>
    public string ReportTime { get; set; }
    /// <summary>
    /// 终端与打印机名称
    /// </summary>
    public string UENameAndPrinterName { get; set; }

    /// <summary>
    /// 类型
    /// </summary>

    public string PartType { get; set; }

    /// <summary>
    /// 有效性
    /// </summary>
    public string IsEnabledText { get; set; }
    /// <summary>
    /// 有效性
    /// </summary>
    public bool IsEnabled { get; set; }
    /// <summary>
    /// 最后修改时间
    /// </summary>
    public string LastUpdateTime { get; set; }
    /// <summary>
    /// 媒体
    /// </summary>
    public string Media { get; set; }
    /// <summary>
    /// 是否彩印
    /// </summary>
    public bool? IsColorful { get; set; }
    /// <summary>
    /// 打印机口错误代码
    /// </summary>
    public string ErrorCode { get; set; }
    /// <summary>
    /// 打印机口错误信息
    /// </summary>
    public string ErrorMessage { get; set; }
    /// <summary>
    /// 纸张剩余量
    /// 2.4 耗材剩余量增加
    /// </summary>
    public string PaperRemain { get; set; }
    /// <summary>
    /// 打印机耗材剩余量 
    /// </summary>
    public string ConsumablesRemain { get; set; }
    /// <summary>
    /// 打印机耗材余量数字
    /// </summary>
    public string PaperCount { get; set; }
}

public partial class PrinterPosition
{
    public static implicit operator PrinterPosition(HIPS.HSPS.Interface.Persistence.Web.PrinterPosition source)
    {
        if (source != null)
        {
            var target = new PrinterPosition()
            {
                PrinterID = source.ID,
                PrinterName = source.Position,
                UENameAndPrinterName = string.Format("{0}({1})", source.Position, source.UserTerminal == null ? "" : source.UserTerminal.Name),
                TerminalName = source.UserTerminal == null ? "" : source.UserTerminal.Name,
                TerminalID = source.UserTerminal == null ? 0 : source.UserTerminal.ID,
                TerminalSN = source.UserTerminal == null ? "" : source.UserTerminal.SNumber,
                TerminalQRCode = source.UserTerminal == null ? "" : source.UserTerminal.QRCode,
                TerminalType = source.UserTerminal == null ? "" : (source.UserTerminal.TerminalType).ToString(),
                PrinterStatus = EnumHelper.ConvertToEnumDescription(((source.PrinterStatus).ParseEnum<PrinterStatusEnum>(PrinterStatusEnum.Normal))),
                PrinterStatusValue = source.PrinterStatus.ToString(),
                ReportTime = source.ReportTime.ToString(),
                InstallTime = source.InstallTime,
                ModelNo = source.ModelNo,
                PartType = source.PartType,
                QRCode = source.QRCode,
                SNumber = source.SN,
                IsEnabled = source.IsEnabled,
                Media = source.Media,
                PrintSize = source.PrintSize,
                IsColorful = source.IsColorful,
                LastUpdateTime = source.LastUpdateTime == null ? string.Empty : Convert.ToDateTime(source.LastUpdateTime).ToString("yyyy-MM-dd HH:mm"),
                IsEnabledText = source.IsEnabled ? "是" : "否",
                PartTypeName = source.PartTypeName,
                ErrorCode = source.ErrorCode,
                ErrorMessage = source.ErrorMessage,
                PaperRemain = source.PaperRemain,//2.4 耗材剩余量增加
                ConsumablesRemain = source.ConsumablesRemain

            };

            return target;
        }
        return null;
    }

    public static implicit operator HIPS.HSPS.Interface.Persistence.Web.PrinterPosition(PrinterPosition source)
    {
        if (source != null)
        {
            var target = new HIPS.HSPS.Interface.Persistence.Web.PrinterPosition()
            {
                ID = source.PrinterID,
                Position = source.PrinterName,
                UserTerminalID = source.TerminalID,
                InstallTime = source.InstallTime,
                ModelNo = source.ModelNo,
                PartType = source.PartType,
                QRCode = source.QRCode,
                SN = source.SNumber,
                IsEnabled = source.IsEnabled,
                Media = source.Media,
                PrintSize = source.PrintSize,
                IsColorful = source.IsColorful,
                PrinterStatus = source.PrinterStatusValue.IsNullOrEmpty() ? ServerEntity.EnumPrinterStatus.Normal : (ServerEntity.EnumPrinterStatus)System.Enum.Parse(typeof(ServerEntity.EnumPrinterStatus), source.PrinterStatusValue, true),

            };
            if (source.ReportTime.IsNullOrEmpty())
            {
                target.ReportTime = null;
            }
            else
            {
                target.ReportTime = Convert.ToDateTime(source.ReportTime);
            }
            return target;
        }
        return null;
    }
}
