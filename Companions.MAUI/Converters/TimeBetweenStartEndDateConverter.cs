using Companions.MAUI.Models.App;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companions.MAUI.Converters
{
    /// <summary>
    /// Calculates the amount of time between two DateTimes
    /// </summary>
    public class TimeBetweenStartEndDateConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        
        {
            if (values[0] is null || values[1] is null)
            {
                return "";
            }
            
            DateTime startDate = (DateTime)values[0];
            DateTime endDate = (DateTime)values[1];

            var activityDuration = endDate - startDate;

            if(activityDuration.Hours < 24 && activityDuration.Hours > 0)
            {
                return activityDuration.Hours + " hour";
            }

            return activityDuration.Minutes + " minute";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
