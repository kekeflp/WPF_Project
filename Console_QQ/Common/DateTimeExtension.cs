using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_QQ.Common
{
   public static class DateTimeExtension
    {
        public static string ToFormatDateString(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }

        public static string ToFormatDateTimeString(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
