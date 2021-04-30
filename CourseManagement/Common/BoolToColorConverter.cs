using CourseManagement.DTO;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace CourseManagement.Common
{
    public class BoolToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //if (value != null && bool.Parse(value.ToString()))
            //{
            //    return Brushes.Blue;
            //}
            //return Brushes.Red;

            if (value != null)
            {
                var state = (GrowingState)value;
                switch (state)
                {
                    case GrowingState.Increase:
                        return Brushes.Green;
                    case GrowingState.Decrease:
                        return Brushes.Red;
                    default:
                        return Brushes.Yellow;
                }
            }
            return Brushes.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
