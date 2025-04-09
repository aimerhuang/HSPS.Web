namespace HSPS.Web.Model.Models.Extensions;

/// <summary>
/// 医生签章
/// </summary>
public partial class UserDoctor : IEntity
{
    public string Back { get; set; }
    /// <summary>
    /// 主键id
    /// </summary>
    public int ID { get; set; }
    /// <summary>
    /// 类别
    /// </summary>
    public int Type { get; set; }
    /// <summary>
    /// 医生姓名
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// 签章图形
    /// </summary>
    public byte[] SignatureImage { get; set; }
    /// <summary>
    /// 工作站id
    /// </summary>
    public string StationID { get; set; }

    public static implicit operator UserDoctor(HIPS.HSPS.Interface.Persistence.Web.UserDoctor source)
    {
        if (source != null)
        {
            var target = new UserDoctor()
            {
                ID = source.ID,
                Back = source.Guid,
                Name = source.Name,
                Type = source.Type,
                //Type = source.ID>=8 ?2:1,
                SignatureImage = source.SignatureImage,
                StationID = source.StationID
            };

            return target;
        }
        return null;
    }
    public static implicit operator HIPS.HSPS.Interface.Persistence.Web.UserDoctor(UserDoctor source)
    {
        if (source != null)
        {
            var target = new HIPS.HSPS.Interface.Persistence.Web.UserDoctor()
            {
                ID = source.ID,
                Guid = source.Back,
                Name = source.Name,
                Type = source.Type,
                SignatureImage = source.SignatureImage,
                StationID = source.StationID
            };

            return target;
        }
        return null;
    }
}
