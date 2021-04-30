using CourseManagement.DTO;
using System;
using System.Globalization;
using System.Windows.Data;

namespace CourseManagement.Common
{
    public class BoolToArrowConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // 应该考虑有3态 ,增长,下降和持平 , 建议用枚举
            //if (value!= null && bool.Parse(value.ToString()))
            //{
            //    return "↑";
            //}
            //return "↓";

            if (value != null)
            {
                var state = (GrowingState)value;
                switch (state)
                {
                    case GrowingState.Increase:
                        return "↑";
                    case GrowingState.Decrease:
                        return "↓";
                    default:
                        return "一";
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
