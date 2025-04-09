
using Entities;

namespace HSPS.Web.Model.Dtos;

public class UserDto
{
    /// <summary>
    /// 主键
    /// </summary>
    public int ID { get; set; }

    /// <summary>
    /// 用户登陆名
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// 密码
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? CreateTime { get; set; }
    /// <summary>
    /// 最后登陆时间
    /// </summary>
    public DateTime? LastLoginTime { get; set; }

    /// <summary>
    /// 创建人
    /// </summary>
    public string Creator { get; set; }
    /// <summary>
    /// 是否启用
    /// </summary>
    public bool Enabled { get; set; }

    /// <summary>
    /// 院区
    /// </summary>
    public string HospitalAreas { get; set; }

    /// <summary>
    /// 病区
    /// </summary>
    public string PatientAreas { get; set; }

    /// <summary>
    /// 临床科室
    /// </summary>
    public string ClinicalDepartments { get; set; }

    /// <summary>
    /// 用户对应的科室权限集合
    /// </summary>
    public List<UserDepartmentRelation> userDepartmentRelations { get; set; }
    /// <summary>
    /// 用户对应规则权限集合
    /// </summary>
    public List<UserRoleRelation> userRoleRelations { get; set; }

    /// <summary>
    /// 用户对应类别权限集合
    /// </summary>
    public List<UserReporttypeIdRelation> userReporttypeIdRelations { get; set; }
}

