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
        private IList<object> _seletedNodes=new List<object>();
        public  IList<object> SelectedNodes
        {
            get=> _seletedNodes;
            set
            {
                _seletedNodes = value;
                OnPropertyChanged(nameof(SelectedNodes));
            }
        }
        //public ObservableCollection<MenuItemViewModel> ContextMenuItems { get; set; } = new ObservableCollection<MenuItemViewModel>();

       

        public ICommand SelectedCommand { get; set; }
        public ICommand AddAnodeCommand { get; set; }
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
            SelectedCommand = new RelayCommand<IList<object>>(null, ExecuteSelectedNode);
            AddAnodeCommand = new RelayCommand<IList<object>>(null, ExecuteAddAnodeCommand);

        }

        private bool CanExecuteCommand(IList<object> commandParameter)
        {
          
            return true;
        }
        private void ExecuteSelectedNode(IList<object> commandParameter) 
        {
            SelectedNodes.Clear();
            SelectedNodes = commandParameter.ToList();
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
        private bool CanExecuteCommand(object commandParameter)
        {

            return true;
        }

        private void ExecuteAddAnodeCommand(object commandParameter)
        {
            AddWBSChild(new ANodeItem("Anoderoot"));
        }
    }
}
