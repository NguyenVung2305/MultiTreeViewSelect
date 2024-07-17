using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MultiTreeViewSelect.Viewmodel
{
    public class NodeItem: BaseViewModel
    {
        public Guid Oid { get; set; }
        public string Name { get; set; }
        public bool IsVisible { get; set; } = true;
        public bool IsEnabled { get; set; } = true;
        public bool IsExpanded { get; set; } = true;
        public ICommand DeleteCommand { get; set; }
    }
}
