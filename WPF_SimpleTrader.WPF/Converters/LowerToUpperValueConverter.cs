using System;
using System.Globalization;
using System.Windows.Data;

namespace WPF_SimpleTrader.WPF.Converters
{
    public class LowerToUpperValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                string v = value.ToString();
                return v.ToUpper();
            }
            return value;
        }
    }
}
