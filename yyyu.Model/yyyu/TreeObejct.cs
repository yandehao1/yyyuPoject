using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yyyu.Model.yyyu
{
    /// <summary>
    /// 抽象类,生成树状结构
    /// </summary>
    public abstract class TreeObejct
    {
        /// <summary>
        /// 菜单Menu_Id
        /// </summary>
        public string Menu_Id { set; get; }
        /// <summary>
        /// Menu_ParentId
        /// </summary>
        public string Menu_ParentId { set; get; }
        /// <summary>
        /// 字段名称
        /// </summary>
        public string Name { set; get; }
        /// <summary>
        /// 系统管理
        /// </summary>
        public string ShowName { set; get; }
        /// <summary>
        /// 排序号
        /// </summary>
        public string MeunNum { set; get; }
        /// <summary>
        /// 访问路径
        /// </summary>
        public string NodeUrl { set; get; }
        /// <summary>
        /// 是否包含子节点
        /// </summary>
        public string IshasSon { set; get; }
        /// <summary>
        /// 子节点数据
        /// </summary>
        public IList<TreeObejct> children = new List<TreeObejct>();
        //需方法，为子节点添加数据
        public virtual void Addchildren(TreeObejct node)
        {
            this.children.Add(node);
        }
    }
}
