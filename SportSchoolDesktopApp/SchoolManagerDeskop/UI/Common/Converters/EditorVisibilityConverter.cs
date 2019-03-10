using SchoolManagerDeskop.UI.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace SchoolManagerDeskop.UI.Common.Converters
{
    [ValueConversion(typeof(ItemsListEditState), typeof(Visibility))]
    public sealed class EditorVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        => (ItemsListEditState)value == ItemsListEditState.NoSelected ? Visibility.Hidden : Visibility.Visible;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => throw new NotImplementedException();
    }

    [ValueConversion(typeof(bool), typeof(Visibility))]
    public sealed class BoolEditorVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        => (bool)value ? Visibility.Collapsed : Visibility.Visible;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => throw new NotImplementedException();
    }

    [ValueConversion(typeof(ItemsListEditState), typeof(bool))]
    public sealed class EditorEnabledConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        => (ItemsListEditState)value == ItemsListEditState.Selected ? false : true;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => throw new NotImplementedException();
    }
}
