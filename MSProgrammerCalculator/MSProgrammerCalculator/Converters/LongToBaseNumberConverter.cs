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
    public class LongToBaseNumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is long longValue && parameter is BaseNumber baseNumber)
            {
                switch (baseNumber)
                {
                    case BaseNumber.Binary:
                        return Regex.Replace(System.Convert.ToString(longValue, 2), ".{4}", "$0 ");
                    case BaseNumber.Octal:
                        return Regex.Replace(System.Convert.ToString(longValue, 8), ".{3}", "$0 ");
                    case BaseNumber.Decimal:
                        return longValue.ToString("N0");
                    case BaseNumber.Hexadecimal:
                        return Regex.Replace(System.Convert.ToString(longValue, 16), ".{4}", "$0 ");
                }
            }
            
            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
