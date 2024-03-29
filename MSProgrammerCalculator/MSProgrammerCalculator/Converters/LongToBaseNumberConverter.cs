﻿using Calculator;
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
            if (value is long number && parameter is BaseNumber baseNumber)
            {
                switch (baseNumber)
                {
                    case BaseNumber.Binary:
                        return FormatNumberSpacing(System.Convert.ToString(number, 2), 4, number != 0 ? true : false);
                    case BaseNumber.Octal:
                        return FormatNumberSpacing(System.Convert.ToString(number, 8), 3);
                    case BaseNumber.Decimal:
                        return number.ToString("N0");
                    case BaseNumber.Hexadecimal:
                        return FormatNumberSpacing(System.Convert.ToString(number, 16).ToUpper(), 4);
                }
            }
            
            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private string FormatNumberSpacing(string number, int spacing, bool fillZero = false)
        {
            var num = number.Reverse();
            var numCount = num.Count();
            var sb = new StringBuilder();

            if (fillZero)
            {
                var mod = numCount % spacing;
                if (mod > 0)
                {
                    sb.Append('0', spacing - mod);
                }
            }

            for (int i = numCount - 1; i >= 0; i--)
            {
                sb.Append(num.ElementAt(i));

                if (i != 0 && i % spacing == 0)
                {
                    sb.Append(' ');
                }
            }

            return sb.ToString();
        }
    }
}
