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
    public class EndDateToTimeAgoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime activityEndDate = (DateTime)value;
            var difference = DateTime.Now - activityEndDate;

            if(difference.Hours == 0)
            {
                if (difference.Minutes == 0)
                {
                    return difference.Seconds + " seconds ago";
                }

                if (difference.Minutes == 1)
                {
                    return difference.Minutes + " minute ago";
                }
                return difference.Minutes + " minutes ago";
            }

            if(difference.TotalMinutes / 1440 >= 1)
            {
                return  difference.Days + " days ago";
            }

            if(difference.TotalHours < 24 && difference.TotalHours > 0)
            {
                if(difference.Minutes > 30)
                {
                    return difference.Hours + 1 + " hours ago";
                }
                return difference.Hours + " hours ago";
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
