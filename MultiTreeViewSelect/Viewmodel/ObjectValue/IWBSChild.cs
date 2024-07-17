using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTreeViewSelect.Viewmodel
{
    public interface IWBSChild
    {
        Guid Oid { get; set; }
        IWBSParent WBSParent { get; set; }
    }
}
