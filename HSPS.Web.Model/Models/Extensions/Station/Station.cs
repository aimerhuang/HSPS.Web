namespace HSPS.Web.Model.Models.Extensions;

/// <summary>
/// 来源表
/// </summary>
public partial class Station : IEntity
{
    /// <summary>
    /// 科室
    /// </summary>
    public virtual Department Department { get; set; }
    /// <summary>
    /// 来源ip
    /// </summary>
    public string Host { get; set; }
    /// <summary>
    /// 主键id
    /// </summary>
    public int ID { get; set; }
    /// <summary>
    /// 来源名称
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// 名称和ip
    /// </summary>
    public string NameAndIP { get; set; }
    /// <summary>
    /// 电脑名
    /// </summary>
    public string ComputerName { get; set; }
    /// <summary>
    /// mac地址
    /// </summary>
    public string Mac { get; set; }
    /// <summary>
    /// 类型
    /// </summary>
    public string Type { get; set; }
    /// <summary>
    /// 科室id
    /// </summary>
    public string DepartmentID { get; set; }
    /// <summary>
    /// 科室名称
    /// </summary>
    public string DepartmentName { get; set; }
    /// <summary>
    /// 类型名称
    /// </summary>
    public string TypeStr { get; set; }

    public static implicit operator Station(HIPS.HSPS.Interface.Persistence.Web.Station source)
    {
        if (source != null)
        {
            var target = new Station()
            {
                ID = source.ID,
                Department = source.Department,
                Host = source.Host,
                Name = source.Name,
                NameAndIP = string.IsNullOrEmpty(source.Name) ? source.Host : string.Format("{0}({1})", source.Host, source.Name),
                ComputerName = source.ComputerName,
                Mac = source.Mac,
                Type = source.Type,
                DepartmentID = source.Department.ID.ToString(),
                DepartmentName = source.Department.Name,
                TypeStr = GetTypeStr((source.Type).ParseEnum<StationEnum>(StationEnum.Unknow))
                //NameAndIP = string.Format("{0}({1})", source.Host, source.Name)
            };

            return target;
        }
        return null;
    }

    public static string GetTypeStr(StationEnum PrintSolution)
    {
        var result = "未知";
        switch (PrintSolution)
        {
            case StationEnum.Unknow:
                result = "未知";
                break;
            case StationEnum.IPS:
                result = "IPS";
                break;
            case StationEnum.IntegrationPlatform:
                result = "集成平台";
                break;
            case StationEnum.Customization:
                result = "定制化";
                break;
            case StationEnum.Radiation:
                result = "放射";
                break;
        }

        return result;
    }
}
