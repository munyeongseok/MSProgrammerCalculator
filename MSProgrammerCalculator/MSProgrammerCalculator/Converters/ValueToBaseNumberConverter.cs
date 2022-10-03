using MSProgrammerCalculator.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MSProgrammerCalculator.Converters
{
    public class ValueToBaseNumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((BaseNumber)parameter)
            {
                case BaseNumber.Binary:
                    return Regex.Replace(System.Convert.ToString((long)value, 2), ".{4}", "$0 ");
                case BaseNumber.Octal:
                    return Regex.Replace(System.Convert.ToString((long)value, 8), ".{3}", "$0 ");
                case BaseNumber.Decimal:
                    return System.Convert.ToString((long)value, 10);
                case BaseNumber.Hexadecimal:
                    return Regex.Replace(System.Convert.ToString((long)value, 16), ".{4}", "$0 ");
            }

            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
