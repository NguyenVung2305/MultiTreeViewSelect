using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTreeViewSelect.Viewmodel
{
    public class BNodeItem : NodeItem, IWBSChild
    {
        public IWBSParent WBSParent { get; set; }
        public BNodeItem(string name)
        {
            Name = name;
        }
    }
}
