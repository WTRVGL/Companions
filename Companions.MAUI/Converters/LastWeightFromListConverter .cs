using Companions.MAUI.Models.App;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companions.MAUI.Converters
{
    public class LastWeightFromListConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            List<BuddyWeight> list = (List<BuddyWeight>)value;
            if (list.Count == 0) return 0;
            return list.ElementAt(0).Weight;
        }
            

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
