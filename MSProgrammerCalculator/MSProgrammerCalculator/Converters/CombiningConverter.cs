using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Markup;

namespace MSProgrammerCalculator.Converters
{
    [ContentProperty("Converters")]
    [ContentWrapper(typeof(ConverterCollection))]
    public class CombiningConverter : IValueConverter
    {
        private readonly ConverterCollection _converters = new ConverterCollection();

        public ConverterCollection Converters
        {
            get => _converters;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Converters.Aggregate(value, (current, converter) => converter.Convert(current, targetType, parameter, culture));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Converters.Reverse().Aggregate(value, (current, converter) => converter.Convert(current, targetType, parameter, culture));
        }
    }

    public sealed class ConverterCollection : Collection<IValueConverter> { }
}
