using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MultiTreeViewSelect.Viewmodel.ObjectValue
{
    public class MenuItemViewModel : INotifyPropertyChanged
    {
        public string Header { get; set; }
        public ICommand Command { get; set; }
        public ObservableCollection<MenuItemViewModel> SubMenuItems { get; set; } = new ObservableCollection<MenuItemViewModel>();
        public object CommandParameter { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



    }
}
