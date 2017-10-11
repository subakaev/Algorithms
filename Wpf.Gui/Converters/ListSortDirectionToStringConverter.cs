using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Wpf.Gui.Converters
{
    class ListSortDirectionToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            var direction = (ListSortDirection) value;

            switch (direction) {
                case ListSortDirection.Ascending:
                    return "По возрастанию";
                case ListSortDirection.Descending:
                    return "По убыванию";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return DependencyProperty.UnsetValue;
        }
    }
}
