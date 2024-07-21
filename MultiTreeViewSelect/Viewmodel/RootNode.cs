using MultiTreeViewSelect.Viewmodel.ObjectValue;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace MultiTreeViewSelect.Viewmodel
{
    public class RootNode : NodeItem, IWBSParent
    {
        public ObservableCollection<IWBSChild> Children { get; set; } = new ObservableCollection<IWBSChild>();
        public ReadOnlyCollection<IWBSChild> WBSChildren => new ReadOnlyCollection<IWBSChild>(Children);
        public ObservableCollection<MenuItemViewModel> ContextMenuItems { get; set; } = new ObservableCollection<MenuItemViewModel>();

       

        public ICommand AddCommand { get; set; }
        public ICommand CopyCommand { get; set; }
        public ICommand CutCommand { get; set; }
        public ICommand EditCommand { get; set; }
       

        public RootNode()
        {
            AddCommand = new RelayCommand<IEnumerable<object>>(CanExecuteCommand, ExecuteAddCommand);
           
        }

        private bool CanExecuteCommand(IEnumerable<object> parameter)
        {
          return parameter.Any();
        }
        private void ExecuteAddCommand(IEnumerable<object> parameter) 
        {
            AddWBSChild(new ANodeItem("node A1"));
        }


       



        public IWBSChild FindWbsChild(Guid oid)
        {
            throw new NotImplementedException();
        }

        public void AddWBSChild(IWBSChild oChild)
        {
            oChild.WBSParent = this;
            Children.Add(oChild);
            OnPropertyChanged(nameof(Children));
        }

        public void RemoveWBSChild(IWBSChild oChild)
        {
            Children.Remove(oChild);
            oChild.WBSParent = null;
            OnPropertyChanged(nameof(Children));
        }
    }
}
