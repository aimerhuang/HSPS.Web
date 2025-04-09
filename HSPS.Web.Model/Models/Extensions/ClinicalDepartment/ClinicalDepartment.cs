namespace HSPS.Web.Model.Models.Extensions;

public partial class ClinicalDepartment
{
    //临床科室代码
    public string ClinicalDepartmentCode { get; set; }
    //临床科室名称
    public string ClinicalDepartmentName { get; set; }
    //病区ID
    public int PatientAreaID { get; set; }
    //病区
    public PatientArea PatientArea { get; set; }
    //ID
    public int ID { get; set; }
    //备注
    public string Remark { get; set; }

    public static implicit operator ClinicalDepartment(HIPS.HSPS.Interface.Persistence.Web.ClinicalDepartment source)
    {
        if (source != null)
        {
            var target = new ClinicalDepartment()
            {
                ID = source.ID,
                ClinicalDepartmentName = source.ClinicalDepartmentName,
                ClinicalDepartmentCode = source.ClinicalDepartmentCode,
                PatientAreaID = source.PatientAreaID,
                PatientArea = source.PatientArea,
                //PatientAreaName = source.PatientArea.PatientAreaName,
                //PatientAreaCode = source.PatientArea.PatientAreaCode,
                //HospitalAreaName =source.PatientArea.HospitalArea.HospitalAreaName,
                Remark = source.Remark,
            };
            return target;
        }
        return null;
    }

    public static implicit operator HIPS.HSPS.Interface.Persistence.Web.ClinicalDepartment(ClinicalDepartment source)
    {
        if (source != null)
        {
            var target = new HIPS.HSPS.Interface.Persistence.Web.ClinicalDepartment()
            {
                ID = source.ID,
                ClinicalDepartmentName = source.ClinicalDepartmentName,
                ClinicalDepartmentCode = source.ClinicalDepartmentCode,
                PatientAreaID = source.PatientAreaID,
                PatientArea = source.PatientArea,
                Remark = source.Remark,
            };
            return target;
        }
        return null;
    }
}
