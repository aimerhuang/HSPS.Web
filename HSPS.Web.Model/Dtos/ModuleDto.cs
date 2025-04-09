using Entities;
using SqlSugar;

namespace HSPS.Web.Model.Dtos
{
    public class ModuleDto
    {
        public int ID { get; set; }
        /// <summary>
        /// 模块名称（顶级菜单栏名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 英文代号
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 父级id
        /// </summary>
        public int ParentID { get; set; }
        /// <summary>
        /// 菜单列表（二级菜单列表
        /// </summary>
        public List<Resource> Resources { get; set; }
    }
}
