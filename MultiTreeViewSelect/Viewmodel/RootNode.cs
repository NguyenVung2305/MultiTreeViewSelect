using MultiTreeViewSelect.Viewmodel.ObjectValue;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
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
        public ICommand Option1Command { get; set; }
        public ICommand Option2Command { get; set; }


        public RootNode()
        {
            AddCommand = new RelayCommand<IEnumerable<object>>(CanExecuteAddCommand, ExecuteAddCommand);
            CopyCommand = new RelayCommand<IEnumerable<object>>(CanExecuteMultiSelectCommand, ExecuteCopyCommand);
            CutCommand = new RelayCommand<IEnumerable<object>>(CanExecuteMultiSelectCommand, ExecuteCutCommand);
            EditCommand = new RelayCommand<IEnumerable<object>>(CanExecuteMultiSelectCommand, ExecuteEditCommand);
            Option1Command = new RelayCommand<IEnumerable<object>>(CanExecuteMultiSelectCommand, ExecuteOption1Command);
            Option2Command = new RelayCommand<IEnumerable<object>>(CanExecuteMultiSelectCommand, ExecuteOption2Command);
            UpdateContextMenuItems(new List<object>());

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
            UpdateContextMenuItems(commandParameter);
            bool result = commandParameter.Count() == 1 && (commandParameter.First() is RootNode);
            return result;
           
        }

        public void ExecuteAddCommand(IEnumerable<object> commandParameter)
        {
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

            if (selectedItems.Count() == 1 && selectedItems.First() is ANodeItem)
            {
                // Add only relevant options
                ContextMenuItems.Add(new MenuItemViewModel { Header = "Edit", Command = EditCommand });
                ContextMenuItems.Add(new MenuItemViewModel { Header = "Delete", Command = DeleteCommand });
            }
            else
            {
                var optionsMenuItem = new MenuItemViewModel { Header = "Options" };
                var optionsSubMenuItems = new ObservableCollection<MenuItemViewModel>
        {
            new MenuItemViewModel { Header = "Option1", Command = Option1Command },
            new MenuItemViewModel { Header = "Option2", Command = Option2Command }
        };

                // Add SubMenuItems to optionsMenuItem
                foreach (var item in optionsSubMenuItems)
                {
                    optionsMenuItem.SubMenuItems.Add(item);
                }

                // Add all options
                ContextMenuItems.Add(optionsMenuItem);
                ContextMenuItems.Add(new MenuItemViewModel { Header = "Edit", Command = EditCommand });
                ContextMenuItems.Add(new MenuItemViewModel { Header = "Delete", Command = DeleteCommand });
            }
            OnPropertyChanged(nameof(ContextMenuItems));
        }
        

    }
}
