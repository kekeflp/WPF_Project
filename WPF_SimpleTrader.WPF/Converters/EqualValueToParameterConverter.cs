using System;
using System.Globalization;
using System.Windows.Data;

namespace WPF_SimpleTrader.WPF.Converters
{
    public class EqualValueToParameterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // 比较类名字
            if (value != null)
            {
                string valueString = value.ToString();
                string paraString = parameter.ToString();
                return valueString == paraString;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
