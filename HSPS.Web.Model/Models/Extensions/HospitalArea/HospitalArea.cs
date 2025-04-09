namespace HSPS.Web.Model.Models.Extensions;

public partial class HospitalArea
{
    public string HospitalAreaName { get; set; }
    public int ID { get; set; }
    public string Remark { get; set; }


    public static implicit operator HospitalArea(HIPS.HSPS.Interface.Persistence.Web.HospitalArea source)
    {
        if (source != null)
        {
            var target = new HospitalArea()
            {
                ID = source.ID,
                HospitalAreaName = source.HospitalAreaName,
                Remark = source.Remark,
            };
            return target;
        }
        return null;
    }

    public static implicit operator HIPS.HSPS.Interface.Persistence.Web.HospitalArea(HospitalArea source)
    {
        if (source != null)
        {
            var target = new HIPS.HSPS.Interface.Persistence.Web.HospitalArea()
            {
                ID = source.ID,
                HospitalAreaName = source.HospitalAreaName,
                Remark = source.Remark,
            };
            return target;
        }
        return null;
    }
}

