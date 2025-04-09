using SqlSugar;

namespace Entities
{
    /// <summary>
    /// 权限表
    /// </summary>
    [SugarTable("Permission", "权限表")]
    public class Permission
    {
        /// <summary>
        /// 主键id
        /// </summary>
        [SugarColumn(IsNullable = false, IsPrimaryKey = true, IsIdentity = true)]
        public int ID { get; set; }
        /// <summary>
        /// 权限代号（Visit可访问，NeedPrint按需打印，Update可修改，Delete可删除）
        /// </summary>
        [SugarColumn(IsNullable = false, Length = 100)]
        public string Code { get; set; }
        /// <summary>
        /// 权限代号名称
        /// </summary>
        [SugarColumn(IsNullable = false, Length = 200)]
        public string Name { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 对应资源表id
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public int ResourceID { get; set; }

        /// <summary>
        /// 对应资源
        /// </summary>
        [Navigate(NavigateType.OneToOne, nameof(ResourceID))]
        public Resource Resource { get; set; }
    }
}
