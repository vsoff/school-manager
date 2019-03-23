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
    [ValueConversion(typeof(object), typeof(Visibility))]
    public sealed class IsNullToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        => value == null ? Visibility.Hidden : Visibility.Visible;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => throw new NotImplementedException();
    }
}
