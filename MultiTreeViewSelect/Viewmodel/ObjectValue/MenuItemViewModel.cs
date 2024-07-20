using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MultiTreeViewSelect.Viewmodel.ObjectValue
{
    public class MenuItemViewModel
    {
        public string Header { get; set; }
        public ICommand Command { get; set; }
        public ObservableCollection<MenuItemViewModel> SubMenuItems { get; set; } = new ObservableCollection<MenuItemViewModel>();
    }
}
