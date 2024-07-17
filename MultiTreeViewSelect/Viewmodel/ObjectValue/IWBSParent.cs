using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTreeViewSelect.Viewmodel
{
    public interface IWBSParent
    {
        Guid Oid { get; set; }
        ReadOnlyCollection<IWBSChild> WBSChildren { get; }
        bool BelongsToWBS(IWBSChild oItemChild);
        IWBSChild FindWbsChild(Guid oid);
        void AddWBSChild(IWBSChild oChild);
        void RemoveWBSChild(IWBSChild oChild);

    }
}
