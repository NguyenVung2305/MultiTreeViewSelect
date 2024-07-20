using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MultiTreeViewSelect.Viewmodel
{
    public class RootNode : NodeItem, IWBSParent
    {
        public ObservableCollection<IWBSChild> Children { get; set; } = new ObservableCollection<IWBSChild>();
        public ReadOnlyCollection<IWBSChild> WBSChildren => new ReadOnlyCollection<IWBSChild>(Children);
        public ICommand AddCommand { get; set; }
        public RootNode()
        {
            AddCommand = new RelayCommand<IEnumerable<object>>(CanExecuteAddCommand, ExecuteAddCommand);
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
                throw new InvalidOperationException("Child must be a Anode or Bnode");
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
            // have 2 option if user select ANode=> Add Anode
            //if user select BNote=>Add Bnode

        }

        private bool CanExecuteAddCommand(IEnumerable<object> commandParameter)
        {
            IEnumerable<NodeItem> selectedNodes = commandParameter.Cast<NodeItem>();

            // Because you want to disable and hide the "Add" menu item
            // when the context menu is opened with a BNodeItem
            // simply return false if the selected items collection contains a BNodeItem.
            return !selectedNodes.Any(node => node is BNodeItem);
        }
        public void ExecuteAddCommand(IEnumerable<object> commandParameter)
        {
            IEnumerable<NodeItem> selectedNodes = commandParameter.Cast<NodeItem>();

            // have 2 option if user select ANode=> Add Anode
            //if user select BNote=>Add Bnode

            foreach (NodeItem selectedNode in selectedNodes)
            {
                // Because of CanExecuteAddCommand the items are all ANodeItems (for this AddCommand)
                var aNodeItem = (ANodeItem)selectedNode;

                // TODO::Handle ANodeItem
            }
        }
    }
}
