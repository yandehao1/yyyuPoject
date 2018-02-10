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
        public int Id { get; set; }
        public string Name { get; set; }
        public int Pid { get; set; }
        public List<TreeObject> Children { get; set; }  
    }
}
