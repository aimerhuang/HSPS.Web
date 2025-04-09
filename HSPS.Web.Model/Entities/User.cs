using SqlSugar;

namespace Entities;

[SugarTable("User", "用户表")]
public class User
{
    /// <summary>
    /// 主键
    /// </summary>
    [SugarColumn(IsNullable = false, IsPrimaryKey = true, IsIdentity = true)]
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
    [SugarColumn(Length = 100)]
    public string Creator { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    [SugarColumn(DefaultValue = "1")]
    public int Enabled { get; set; } 

    /// <summary>
    /// 院区
    /// </summary>
    [SugarColumn(Length = 100)]
    public string HospitalAreas { get; set; }

    /// <summary>
    /// 病区
    /// </summary>
    [SugarColumn(Length = 100)]
    public string PatientAreas { get; set; }

    /// <summary>
    /// 临床科室
    /// </summary>
    [SugarColumn(Length = 100)]
    public string ClinicalDepartments { get; set; }

    /// <summary>
    /// 用户对应的科室权限集合
    /// </summary>
    [Navigate(NavigateType.OneToMany, nameof(UserDepartmentRelation.UserID),nameof(ID))]
    public List<UserDepartmentRelation> userDepartmentRelations { get; set; } 

    /// <summary>
    /// 用户对应规则权限集合
    /// </summary>
    [Navigate(NavigateType.OneToMany, nameof(UserRoleRelation.UserID),nameof(ID))]
    public List<UserRoleRelation> userRoleRelations { get; set; }

    /// <summary>
    /// 用户对应类别权限集合
    /// </summary>
    [Navigate(NavigateType.OneToMany, nameof(UserReporttypeIdRelation.UserID),nameof(ID))]
    public List<UserReporttypeIdRelation> userReporttypeIdRelations { get; set; } //= new OneToOneInitializer<List<UserReporttypeIdRelation>>();

}
