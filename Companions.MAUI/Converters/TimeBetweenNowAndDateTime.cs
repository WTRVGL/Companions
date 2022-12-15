using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companions.MAUI.Converters
{
    /// <summary>
    /// Calculates how long ago a specific date occured.
    /// </summary>
    public class TimeBetweenNowAndDateTime : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime appointmentDate = (DateTime)value;
            var difference = appointmentDate - DateTime.Now;

            if(difference.TotalMinutes / 1440 >= 1)
            {
                return  $"in {difference.Days} days";
            }

            if(difference.TotalHours < 24 && difference.TotalHours > 0)
            {
                if(difference.Minutes > 30)
                {
                    return $"in {difference.Hours + 1} hours";
                }
                return $"in {difference.Hours} hours";
            }

            return $"in {difference.Minutes} minutes";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
