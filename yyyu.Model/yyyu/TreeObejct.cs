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
        public string ID { set; get; }
        public string PID { set; get; }
        public string Name { set; get; }
        public string Url { set; get; }
        public string MeunNum { set; get; }

        public IList<TreeObejct> children = new List<TreeObejct>();

        //需方法，为子节点添加数据
        public virtual void Addchildren(TreeObejct node)
        {
            this.children.Add(node);
        }
    }
}
