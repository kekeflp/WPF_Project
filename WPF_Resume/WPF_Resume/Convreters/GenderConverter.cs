using System;
using System.Globalization;
using System.Windows.Data;

namespace WPF_Resume.Convreters
{
    public class GenderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                // 数据库中是什么数据，界面上显示的就是什么。如图，这样显示就非常不友好。
                // 此时可以使用到转换器，之前是直接在Services层取数据时转换（简单粗暴），使用转换器在view层转换比较好操作一些
                int newValue = System.Convert.ToInt32(value);
                return newValue == 1 ? "男" : "女";
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
