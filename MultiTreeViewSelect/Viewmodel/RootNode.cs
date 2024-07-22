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
        //public ObservableCollection<MenuItemViewModel> ContextMenuItems { get; set; } = new ObservableCollection<MenuItemViewModel>();

       

        public ICommand AddCommand { get; set; }
        public ICommand CopyCommand { get; set; }
        public ICommand CutCommand { get; set; }
        public ICommand EditCommand { get; set; }
        //private IEnumerable<object> _selectedItems;
        //public IEnumerable<object> SelectedItems
        //{
        //    get => _selectedItems;
        //    set
        //    {
        //        _selectedItems = value;
        //        OnPropertyChanged(nameof(SelectedItems));
        //    }
        //}

      
        public RootNode()
        {
           // AddCommand = new RelayCommand<object>(CanExecuteCommand, ExecuteAddCommand);
            AddCommand = new RelayCommand<IList<object>>(CanExecuteCommand,ExecuteAddCommand);

        }

        private bool CanExecuteCommand(IList<object> commandParameter)
        {
          
            return true;
        }
        private void ExecuteAddCommand(IList<object> commandParameter) 
        {
            // IEnumerable<NodeItem> selectedNodes = commandParameter.Cast<NodeItem>();
            // AddWBSChild(new ANodeItem("node A1"));
            var selectedNode = commandParameter.FirstOrDefault();

            if (selectedNode is RootNode)
            {
                AddWBSChild(new ANodeItem("root"));
            }
            else if (selectedNode is ANodeItem)
            {
                AddWBSChild(new ANodeItem("Aroot"));
            }
            else if (selectedNode is BNodeItem)
            {
                AddWBSChild(new ANodeItem("Broot"));
            }
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
