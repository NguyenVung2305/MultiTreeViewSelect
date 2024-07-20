using MultiTreeViewSelect.Viewmodel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MultiTreeViewSelect
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var rootnode=new RootNode(); 
            rootnode.Name = "RootNode";
            rootnode.AddWBSChild(new ANodeItem("node A"));
            rootnode.AddWBSChild(new BNodeItem("node B"));
            DataContext = new ObservableCollection<NodeItem> { rootnode };
           // DataContext = rootnode;
        }

      
    }
}
