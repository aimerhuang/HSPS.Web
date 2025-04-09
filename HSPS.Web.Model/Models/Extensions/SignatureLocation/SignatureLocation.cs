namespace HSPS.Web.Model.Models.Extensions;

/// <summary>
/// 签章位置放置表
/// </summary>
public partial class SignatureLocation : IEntity
{
    /// <summary>
    /// 高度
    /// </summary>
    public int Height { get; set; }
    /// <summary>
    /// 主键id
    /// </summary>
    public int ID { get; set; }
    /// <summary>
    /// 签章页码
    /// </summary>
    public int Page { get; set; }
    /// <summary>
    /// 对应报告类别id
    /// </summary>
    public int ReportTypeID { get; set; }
    /// <summary>
    /// 宽度
    /// </summary>
    public int Width { get; set; }
    /// <summary>
    /// x坐标
    /// </summary>
    public int XPoint { get; set; }
    /// <summary>
    /// y坐标
    /// </summary>
    public int YPoint { get; set; }
    /// <summary>
    /// 文件类型枚举
    /// </summary>
    public DoctorTypeEnum DoctorType { get; set; }
    /// <summary>
    /// 医生类型（报告：审核）
    /// </summary>
    public string DoctorTypeValue { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int DoctorTypeKey { get; set; }

    public static implicit operator SignatureLocation(HIPS.HSPS.Interface.Persistence.Web.SignatureLocation source)
    {
        if (source != null)
        {
            var target = new SignatureLocation()
            {
                ID = source.ID,
                Height = source.Height,
                Page = source.Page,
                ReportTypeID = source.ReportTypeID,
                Width = source.Width,
                XPoint = source.XPoint,
                YPoint = source.YPoint,
                DoctorType = (source.EnumDocoterType).ParseEnum<DoctorTypeEnum>(DoctorTypeEnum.ReportDoctor),
                DoctorTypeValue = (source.EnumDocoterType).ParseEnum<DoctorTypeEnum>(DoctorTypeEnum.ReportDoctor).ToString(),
                DoctorTypeKey = (int)(source.EnumDocoterType).ParseEnum<DoctorTypeEnum>(DoctorTypeEnum.ReportDoctor)

            };

            return target;
        }
        return null;
    }
    public static implicit operator HIPS.HSPS.Interface.Persistence.Web.SignatureLocation(SignatureLocation source)
    {
        if (source != null)
        {
            var target = new HIPS.HSPS.Interface.Persistence.Web.SignatureLocation()
            {
                ID = source.ID,
                Height = source.Height,
                Page = source.Page,
                ReportTypeID = source.ReportTypeID,
                Width = source.Width,
                XPoint = source.XPoint,
                YPoint = source.YPoint,
                EnumDocoterType = (source.DoctorTypeValue).ParseEnum<HIPS.HSPS.Interface.Persistence.Web.EnumDoctorType>(HIPS.HSPS.Interface.Persistence.Web.EnumDoctorType.ReportDoctor)
            };

            return target;
        }
        return null;
    }

    public static implicit operator HIPS.HSPS.Interface.Persistence.Web.AddSignatureLocation(SignatureLocation source)
    {
        if (source != null)
        {
            var target = new HIPS.HSPS.Interface.Persistence.Web.AddSignatureLocation()
            {

                Height = source.Height,
                Page = source.Page,
                ReportTypeID = source.ReportTypeID,
                Width = source.Width,
                XPoint = source.XPoint,
                YPoint = source.YPoint,
                EnumDoctorType = (source.DoctorTypeValue).ParseEnum<HIPS.HSPS.Interface.Persistence.Web.EnumDoctorType>(HIPS.HSPS.Interface.Persistence.Web.EnumDoctorType.ReportDoctor)
            };

            return target;
        }
        return null;
    }
}
