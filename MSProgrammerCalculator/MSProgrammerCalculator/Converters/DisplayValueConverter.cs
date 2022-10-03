using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MSProgrammerCalculator.Converters
{
    public class DisplayValueConverter : IMultiValueConverter
    {
        private static readonly LongToBaseNumberConverter longToBaseNumberConverter = new LongToBaseNumberConverter();

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return longToBaseNumberConverter.Convert(values[0], targetType, values[1], culture); 
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
