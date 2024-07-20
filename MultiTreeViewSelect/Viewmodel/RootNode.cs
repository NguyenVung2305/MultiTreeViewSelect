using MultiTreeViewSelect.Viewmodel.ObjectValue;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security;
using System.Windows;
using System.Windows.Input;

namespace MultiTreeViewSelect.Viewmodel
{
    public class RootNode : NodeItem, IWBSParent
    {
        public ObservableCollection<IWBSChild> Children { get; set; } = new ObservableCollection<IWBSChild>();
        public ReadOnlyCollection<IWBSChild> WBSChildren => new ReadOnlyCollection<IWBSChild>(Children);
        public ObservableCollection<MenuItemViewModel> ContextMenuItems { get; set; } = new ObservableCollection<MenuItemViewModel>();
        private IEnumerable<object> selectedNode;
        public IEnumerable<object> SelectedNode
        {
            get => selectedNode;
            set
            {
                selectedNode = value;
                OnPropertyChanged(nameof(SelectedNode));
            }
        }
        private bool _isRootNode;
        public bool IsRootNode
        {
            get => _isRootNode;
            set
            {
                _isRootNode = value;
                OnPropertyChanged(nameof(IsRootNode));
            }
        }

        private bool _isNode;
        public bool IsNode
        {
            get => _isNode;
            set
            {
                _isNode = value;
                OnPropertyChanged(nameof(IsNode));
            }
        }

        private bool _isLeafNode;
        public bool IsLeafNode
        {
            get => _isLeafNode;
            set
            {
                _isLeafNode = value;
                OnPropertyChanged(nameof(IsLeafNode));
            }
        }
        public ICommand AddCommand { get; set; }
        public ICommand CopyCommand { get; set; }
        public ICommand CutCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand Option1Command { get; set; }
        public ICommand Option2Command { get; set; }
        public ICommand OptionsCommand { get;  set; }

        private IEnumerable<object> _selectedItem;  
     
       

        public RootNode()
        {

            CopyCommand = new RelayCommand<IEnumerable<object>>(CanExecuteMultiSelectCommand, ExecuteCopyCommand);
            AddCommand = new RelayCommand<IEnumerable<object>>(CanExecuteMultiSelectCommand, ExecuteAddCommand);
            CutCommand = new RelayCommand<IEnumerable<object>>(CanExecuteMultiSelectCommand, ExecuteCutCommand);
            EditCommand = new RelayCommand<IEnumerable<object>>(CanExecuteMultiSelectCommand, ExecuteEditCommand);
            Option1Command = new RelayCommand<IEnumerable<object>>(CanExecuteMultiSelectCommand, ExecuteOption1Command);
            Option2Command = new RelayCommand<IEnumerable<object>>(CanExecuteMultiSelectCommand, ExecuteOption2Command);
            
           
           

        }

        public void AddWBSChild(IWBSChild oChild)
        {
            if (oChild is ANodeItem || oChild is BNodeItem)
            {
                oChild.WBSParent = this;
                Children.Add(oChild);
                OnPropertyChanged(nameof(Children));
            }
            else
            {
                throw new InvalidOperationException("Child must be an ANode or BNode");
            }
        }

        public bool BelongsToWBS(IWBSChild oItemChild)
        {
            throw new NotImplementedException();
        }

        public IWBSChild FindWbsChild(Guid oid)
        {
            throw new NotImplementedException();
        }

        public void RemoveWBSChild(IWBSChild oChild)
        {
            if (Children.Contains(oChild))
            {
                Children.Remove(oChild);
                oChild.WBSParent = null;
                OnPropertyChanged(nameof(Children));
            }
        }

        public void Add(object selectedObject)
        {
            // Handle Add operation based on the selected item type
        }

        private bool CanExecuteAddCommand(IEnumerable<object> commandParameter)
        {

            bool result = commandParameter.Count() == 1 && (commandParameter.First() is RootNode);
            return result;

        }

        public void ExecuteAddCommand(IEnumerable<object> commandParameter)
        {
            UpdateContextMenuItems(commandParameter);
            // Add command logic
            AddWBSChild(new ANodeItem("node A1"));
            AddWBSChild(new BNodeItem("node B1"));
        }

        private bool CanExecuteMultiSelectCommand(IEnumerable<object> commandParameter)
        {
            return commandParameter.Any();
        }

        private void ExecuteCopyCommand(IEnumerable<object> commandParameter)
        {
            // Copy command logic
        }

        private void ExecuteCutCommand(IEnumerable<object> commandParameter)
        {
            // Cut command logic
        }

        private void ExecuteEditCommand(IEnumerable<object> commandParameter)
        {
            // Edit command logic
        }
        private void ExecuteOption1Command(IEnumerable<object> commandParameter)
        {
            // Option 1 command logic
        }

        private void ExecuteOption2Command(IEnumerable<object> commandParameter)
        {
            // Option 2 command logic
        }

        public void UpdateContextMenuItems(IEnumerable<object> selectedItems)
        {
            ContextMenuItems.Clear();

            // Reset flags
            IsRootNode = false;
            IsNode = false;
            IsLeafNode = false;

            if (selectedItems.All(item => item is RootNode))
            {
                IsRootNode = true;
                ContextMenuItems.Add(new MenuItemViewModel { Header = "Add Root", Command = AddCommand });
            }
            else if (selectedItems.All(item => item is ANodeItem || item is BNodeItem))
            {
                IsNode = true;
                ContextMenuItems.Add(new MenuItemViewModel { Header = "Add Node", Command = AddCommand });
                ContextMenuItems.Add(new MenuItemViewModel { Header = "Add Leaf", Command = AddCommand });
            }
           

            ContextMenuItems.Add(new MenuItemViewModel { Header = "Edit", Command = EditCommand });
            ContextMenuItems.Add(new MenuItemViewModel { Header = "Delete", Command = DeleteCommand });
            ContextMenuItems.Add(new MenuItemViewModel { Header = "Copy", Command = CopyCommand });
            ContextMenuItems.Add(new MenuItemViewModel { Header = "Cut", Command = CutCommand });
        }

    }
}
