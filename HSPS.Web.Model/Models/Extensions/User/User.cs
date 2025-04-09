using HIPS.HSPS.Interface.Persistence.Web;
using SqlSugar;

namespace HSPS.Web.Model.Models.Extensions;

/// <summary>
/// 用户表
/// </summary>
public partial class User
{
    /// <summary>
    /// 主键
    /// </summary>
    [SugarColumn(IsNullable = false, IsPrimaryKey = true, IsIdentity = false)]
    public int ID { get; set; }

    /// <summary>
    /// 用户名
    /// </summary>
    [SugarColumn(Length = 100, IsNullable = true)]
    public string? UserName { get; set; }

    /// <summary>
    /// 密码
    /// </summary>
    [SugarColumn(Length = 100, IsNullable = true)]
    public string? Password { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    [SugarColumn(Length = 200, IsNullable = true)]
    public string Name { get; set; }


    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreateTime { get; set; } = DateTime.Now;
    /// <summary>
    /// 最后登陆时间
    /// </summary>
    public DateTime? LastLoginTime { get; set; } = DateTime.Now;
    /// <summary>
    /// 创建人
    /// </summary>
    public string Creator { get; set; }

    public virtual IEnumerable<Department> Departments { get; set; }
    public virtual IEnumerable<int> DepartmentIds { get; set; }
    public virtual IEnumerable<Role> Roles { get; set; }
    public virtual IEnumerable<int> RoleIds { get; set; }
    public string RoleText { get; set; }
    public string DepartmentText { get; set; }
    public string UserAndName { get; set; }
    /// <summary>
    /// 院区
    /// </summary>
    public IEnumerable<int> HospitalAreaIds { get; set; }
    /// <summary>
    /// 病区
    /// </summary>
    public IEnumerable<int> PatientAreaIds { get; set; }
    /// <summary>
    /// 临床科室
    /// </summary>
    public IEnumerable<int> ClinicalDepartmentIds { get; set; }
    /// <summary>
    /// 院区
    /// </summary>
    public IEnumerable<HospitalArea> HospitalAreas { get; set; }
    /// <summary>
    /// 病区
    /// </summary>
    public IEnumerable<PatientArea> PatientAreas { get; set; }
    /// <summary>
    /// 临床科室
    /// </summary>
    public IEnumerable<ClinicalDepartment> ClinicalDepartments { get; set; }
    public string PatientAreaText { get; set; }
    public string ClinicalDepartmentText { get; set; }
    public string HospitalAreaText { get; set; }
    //报告审核权限
    public IEnumerable<UserAuditRange> UserAuditRanges { get; set; }
    public bool Enabled {  get; set; }
}

public partial class User
{
    public static implicit operator User(HIPS.HSPS.Interface.Persistence.Web.User source)
    {
        if (source != null)
        {
            var target = new User()
            {
                ID = source.ID,
                CreateTime = source.CreateTime,
                Creator = source.Creator,
                Departments = source.Departments.CastExtension<Department>().ToList(),
                LastLoginTime = source.LastLoginTime,
                Name = source.Name,
                Password = source.Password,
                Roles = source.Roles.CastExtension<Role>().ToList(),
                UserName = source.UserName,
                RoleText = GetRoleText(source.Roles),
                DepartmentText = GetDepartmentText(source.Departments),
                UserAndName = source.UserName + "（" + source.Name + "）",
                ClinicalDepartmentIds = source.ClinicalDepartmentIds,
                HospitalAreaIds = source.HospitalAreaIds,
                PatientAreaIds = source.PatientAreaIds,
                HospitalAreas = source.HospitalAreas?.ForEachCast(item => { return (HospitalArea)item; }),
                PatientAreas = source.PatientAreas?.ForEachCast(item => { return (PatientArea)item; }),
                ClinicalDepartments = source.ClinicalDepartments == null ? null : source.ClinicalDepartments.ForEachCast(item => { return (ClinicalDepartment)item; }),
                PatientAreaText = GetPatientText(source.PatientAreas),
                ClinicalDepartmentText = GetClinicalDepartmentText(source.ClinicalDepartments),
                HospitalAreaText = GetHospitalText(source.HospitalAreas),
                UserAuditRanges = source.UserAuditRanges == null ? null : source.UserAuditRanges.ForEachCast(item => { return (UserAuditRange)item; })
            };

            return target;
        }
        return null;
    }

    private static string GetHospitalText(IEnumerable<HIPS.HSPS.Interface.Persistence.Web.HospitalArea> enumerable)
    {
        var hospitalareaText = string.Empty;
        if (enumerable != null)
        {
            List<HIPS.HSPS.Interface.Persistence.Web.HospitalArea> pa = enumerable.ToList();
            for (int j = 0; j < pa.Count; j++)
            {
                hospitalareaText += pa[j].HospitalAreaName + ',';
            }
            return hospitalareaText.TrimEnd(',');
        }
        else
        {
            return "";
        }
    }
    private static string GetPatientText(IEnumerable<HIPS.HSPS.Interface.Persistence.Web.PatientArea> enumerable)
    {
        var patientareaText = string.Empty;
        if (enumerable != null)
        {
            List<HIPS.HSPS.Interface.Persistence.Web.PatientArea> pa = enumerable.ToList();
            for (int j = 0; j < pa.Count; j++)
            {
                patientareaText += pa[j].PatientAreaName + ',';
            }
            return patientareaText.TrimEnd(',');
        }
        else
        {
            return "";
        }
    }


    private static string GetClinicalDepartmentText(IEnumerable<HIPS.HSPS.Interface.Persistence.Web.ClinicalDepartment> enumerable)
    {
        var clinicalDepartmentText = string.Empty;
        if (enumerable != null)
        {
            List<HIPS.HSPS.Interface.Persistence.Web.ClinicalDepartment> pa = enumerable.ToList();
            for (int j = 0; j < pa.Count; j++)
            {
                clinicalDepartmentText += pa[j].ClinicalDepartmentName + ',';
            }
            return clinicalDepartmentText.TrimEnd(',');
        }
        else
        {
            return "";
        }
    }

    private static string GetDepartmentText(IEnumerable<HIPS.HSPS.Interface.Persistence.Web.Department> enumerable)
    {
        var departments = string.Empty;
        List<HIPS.HSPS.Interface.Persistence.Web.Department> role = enumerable.ToList();
        for (int j = 0; j < role.Count; j++)
        {
            departments += role[j].Name + ',';
        }
        return departments.TrimEnd(',');
    }

    private static string GetRoleText(IEnumerable<HIPS.HSPS.Interface.Persistence.Web.Role> enumerable)
    {
        var roles = string.Empty;
        List<HIPS.HSPS.Interface.Persistence.Web.Role> role = enumerable.ToList();
        for (int j = 0; j < role.Count; j++)
        {
            roles += role[j].Name + ',';
        }
        return roles.TrimEnd(',');
    }


    public static implicit operator HIPS.HSPS.Interface.Persistence.Web.UpdateUser(User source)
    {
        if (source != null)
        {
            var target = new HIPS.HSPS.Interface.Persistence.Web.UpdateUser()
            {
                ID = source.ID,
                DepartmentIds = source.DepartmentIds,
                LastLoginTime = source.LastLoginTime,
                Name = source.Name,
                Password = source.Password,
                RoleIds = source.RoleIds,
                UserName = source.UserName,
                ClinicalDepartmentIds = source.ClinicalDepartmentIds,
                HospitalAreaIds = source.HospitalAreaIds,
                PatientAreaIds = source.PatientAreaIds
            };

            return target;
        }
        return null;
    }

    private static string GetMD5(string password)
    {
        if (password != null)
        {
            return password;//MD5Helper.MD5Encrypt32(password);
        }
        else
        {
            return null;
        }
    }

    public static implicit operator HIPS.HSPS.Interface.Persistence.Web.AddUser(User source)
    {
        if (source != null)
        {
            var target = new HIPS.HSPS.Interface.Persistence.Web.AddUser()
            {
                CreateTime = source.CreateTime,
                Creator = source.Creator,
                DepartmentIds = source.DepartmentIds,
                Name = source.Name,
                Password = source.Password,//SecretHelper.Encrypt(source.Password),
                RoleIds = source.RoleIds,
                UserName = source.UserName,
                ClinicalDepartmentIds = source.ClinicalDepartmentIds,
                HospitalAreaIds = source.HospitalAreaIds,
                PatientAreaIds = source.PatientAreaIds
            };

            return target;
        }
        return null;


    }
}