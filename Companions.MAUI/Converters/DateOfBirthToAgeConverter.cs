using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companions.MAUI.Converters
{
    /// <summary>
    /// Calculates the age based on a Date of Birth
    /// </summary>
    public class DateOfBirthToAgeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime dateOfBirth = (DateTime)value;

            DateTime today = DateTime.Today;

            int months = today.Month - dateOfBirth.Month;
            int years = today.Year - dateOfBirth.Year;

            if (today.Day < dateOfBirth.Day)
            {
                months--;
            }

            if (months < 0)
            {
                years--;
            }

            return $"{years}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
