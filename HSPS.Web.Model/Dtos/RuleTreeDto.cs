

namespace HSPS.Web.Model.Dtos
{
    /// <summary>
    /// 权限树集合列表
    /// </summary>
    public class RuleTreeDto
    {
        /// <summary>
        /// 规则设置树状节点id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 规则设置树状节点名称
        /// </summary>
        public string text { get; set; }

        /// <summary>
        /// 规则的数据ID
        /// </summary>
        public string sourceId { get; set; }
        /// <summary>
        /// 节点状态（是否打开或关闭）
        /// </summary>
        public string state { get; set; }
        /// <summary>
        /// 节点类型
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 父节点ID
        /// </summary>
        public string parentId { get; set; }
        /// <summary>
        /// 是否默认
        /// </summary>
        public bool isDefault { get; set; }
        /// <summary>
        /// 角度模式
        /// </summary>
        public int rotation { get; set; }
        /// <summary>
        /// 规则设置树状孩子节点
        /// </summary>        
        public List<RuleTreeDto> children { get; set; }

        /// <summary>
        /// 节点是否允许拖动
        /// </summary>
        public bool isAllowDrop { get; set; }

        /// <summary>
        ///是否允许其它节点拖进来
        /// </summary>
        public bool isAllowIn { get; set; }

        /// <summary>
        /// 自定义属性
        /// </summary>
        public Object attributes { get; set; }


    }
}
