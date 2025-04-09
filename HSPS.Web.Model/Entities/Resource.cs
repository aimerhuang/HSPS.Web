using SqlSugar;

namespace Entities
{
    /// <summary>
    /// 资源表
    /// </summary>
    [SugarTable("Resource", "资源表")]
    public class Resource
    {
        /// <summary>
        /// 资源id
        /// </summary>
        [SugarColumn(IsNullable = false, IsPrimaryKey = true, IsIdentity = true)]
        public int ID { get; set; }
        /// <summary>
        /// 模块id（顶级菜单栏id
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public int ModuleID { get; set; }
        /// <summary>
        /// 资源名称
        /// </summary>
        [SugarColumn(IsNullable = false, Length =200)]
        public string Name { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(Length = 200)]
        public string Description { get; set; }
        /// <summary>
        /// 资源代码
        /// </summary>
        [SugarColumn(IsNullable = false, Length = 200)]
        public string Code { get; set; }
        /// <summary>
        /// 资源路径
        /// </summary>
        [SugarColumn(IsNullable = false, Length = 200)]
        public string Url { get; set; }
        /// <summary>
        /// 对应模块
        /// </summary>
        [Navigate(NavigateType.OneToOne, nameof(ModuleID))]
        public Module Module { get; set; }
    }
}
