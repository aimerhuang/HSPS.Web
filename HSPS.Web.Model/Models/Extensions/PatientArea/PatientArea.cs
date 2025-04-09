using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSPS.Web.Model.Models.Extensions;

public partial class PatientArea
{
    public HospitalArea HospitalArea { get; set; }
    public int HospitalAreaID { get; set; }
    public int ID { get; set; }
    public string PatientAreaCode { get; set; }
    public string PatientAreaName { get; set; }
    public string Remark { get; set; }


    public static implicit operator PatientArea(HIPS.HSPS.Interface.Persistence.Web.PatientArea source)
    {
        if (source != null)
        {
            var target = new PatientArea()
            {
                ID = source.ID,
                HospitalArea = source.HospitalArea,
                HospitalAreaID = source.HospitalAreaID,
                PatientAreaCode = source.PatientAreaCode,
                PatientAreaName = source.PatientAreaName,
                Remark = source.Remark,
            };
            return target;
        }
        return null;
    }

    public static implicit operator HIPS.HSPS.Interface.Persistence.Web.PatientArea(PatientArea source)
    {
        if (source != null)
        {
            var target = new HIPS.HSPS.Interface.Persistence.Web.PatientArea()
            {
                ID = source.ID,
                HospitalArea = source.HospitalArea,
                HospitalAreaID = source.HospitalAreaID,
                PatientAreaCode = source.PatientAreaCode,
                PatientAreaName = source.PatientAreaName,
                Remark = source.Remark,
            };
            return target;
        }
        return null;
    }
}

