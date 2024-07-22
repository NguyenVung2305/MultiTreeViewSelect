using MultiTreeViewSelect.Viewmodel;
using System.Collections.Generic;
using System.Globalization;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace MultiTreeViewSelect
{
    public class NodeContextMenuSelector : IValueConverter
    {
        public DataTemplate RootNodeTemplate { get; set; }
        public DataTemplate ANodeTemplate { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is IEnumerable<object> selectedItems)
            {
                foreach (var item in selectedItems)
                {
                    if (item is RootNode)
                    {
                        return RootNodeTemplate;
                    }
                    if (item is ANodeItem)
                    {
                        return ANodeTemplate;
                    }
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
