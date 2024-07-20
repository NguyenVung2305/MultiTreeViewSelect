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
    internal class ANodeItem : NodeItem, IWBSChild, IWBSParent
    {
        public IWBSParent WBSParent { get; set; }
        public ObservableCollection<IWBSChild> Children { get; set; } = new ObservableCollection<IWBSChild>();
        public ReadOnlyCollection<IWBSChild> WBSChildren => new ReadOnlyCollection<IWBSChild>(Children);
        public ICommand AddCommand { get; set; }

        public ANodeItem(string name)
        {
            Name = name;
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

        public bool BelongsToWBS(IWBSChild oItemChild)
        {
            throw new NotImplementedException();
        }

        public IWBSChild FindWbsChild(Guid oid)
        {
            throw new NotImplementedException();
        }

        public void Add(object selectedObject)
        {
            if (selectedObject is ANodeItem)
            {
                AddWBSChild(new ANodeItem("New ANode"));
            }
            else if (selectedObject is BNodeItem)
            {
                AddWBSChild(new BNodeItem("New BNode"));
            }
        }

        private bool CanExecuteAddCommand(IEnumerable<object> commandParameter)
        {
            return commandParameter.Count() == 1 && (commandParameter.First() is ANodeItem);
        }

        private void ExecuteAddCommand(IEnumerable<object> commandParameter)
        {
            if (CanExecuteAddCommand(commandParameter))
            {
                Add(new ANodeItem("New ANode"));
            }
        }
    }
}
