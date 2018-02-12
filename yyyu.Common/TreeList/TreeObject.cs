using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yyyu.Common.TreeList
{
    //树存储实体
    public class TreeObject
    {
        public string Id { get; set; }
        public string Pid { get; set; }
        public string Name { get; set; }
        public string ShowName { get; set; }
        public string url { get; set; }
        public List<TreeObject> Children { get; set; }  
    }
}
