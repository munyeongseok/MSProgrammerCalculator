using MSProgrammerCalculator.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSProgrammerCalculator.ViewModels
{
    public class CalculatorViewModel : BindableBase
    {
        private long displayValue;
        public long DisplayValue
        {
            get => displayValue;
            set => SetProperty(ref displayValue, value);
        }

        private BaseNumber selectedBaseNumber;
        public BaseNumber SelectedBaseNumber
        {
            get => selectedBaseNumber;
            set
            {
                if (SetProperty(ref selectedBaseNumber, value))
                {
                    SelectedBaseNumberChanged();
                }
            }
        }

        public DelegateCommand NumericKeypadButtonClickCommand { get; private set; }

        private const long MSB1000 = unchecked((long)0b_1000000000000000_0000000000000000_0000000000000000_0000000000000000);
        private const long MSB1110 = unchecked((long)0b_1110000000000000_0000000000000000_0000000000000000_0000000000000000);
        private const long MSB1111 = unchecked((long)0b_1111000000000000_0000000000000000_0000000000000000_0000000000000000);
        private long _trackingValue;

        public CalculatorViewModel()
        {
            NumericKeypadButtonClickCommand = new DelegateCommand(parameter => NumericKeypadButtonClicked(parameter));
        }

        private void NumericKeypadButtonClicked(object parameter)
        {
            switch ((NumericKeypadKeys)parameter)
            {
                case NumericKeypadKeys.Num0: AddNumber(0); break;
                case NumericKeypadKeys.Num1: AddNumber(1); break;
                case NumericKeypadKeys.Num2: AddNumber(2); break;
                case NumericKeypadKeys.Num3: AddNumber(3); break;
                case NumericKeypadKeys.Num4: AddNumber(4); break;
                case NumericKeypadKeys.Num5: AddNumber(5); break;
                case NumericKeypadKeys.Num6: AddNumber(6); break;
                case NumericKeypadKeys.Num7: AddNumber(7); break;
                case NumericKeypadKeys.Num8: AddNumber(8); break;
                case NumericKeypadKeys.Num9: AddNumber(9); break;
                case NumericKeypadKeys.NumA: AddNumber(10); break;
                case NumericKeypadKeys.NumB: AddNumber(11); break;
                case NumericKeypadKeys.NumC: AddNumber(12); break;
                case NumericKeypadKeys.NumD: AddNumber(13); break;
                case NumericKeypadKeys.NumE: AddNumber(14); break;
                case NumericKeypadKeys.NumF: AddNumber(15); break;
                case NumericKeypadKeys.OpLeftShift: break;
                case NumericKeypadKeys.OpRightShift: break;
                case NumericKeypadKeys.OpModulo: break;
                case NumericKeypadKeys.OpDivide: break;
                case NumericKeypadKeys.OpMultiply: break;
                case NumericKeypadKeys.OpMinus: break;
                case NumericKeypadKeys.OpPlus: break;
                case NumericKeypadKeys.OpNegate: break;
                case NumericKeypadKeys.OpClear: break;
                case NumericKeypadKeys.OpBackSpace: break;
                case NumericKeypadKeys.OpOpenParenthesis: break;
                case NumericKeypadKeys.OpCloseParenthesis: break;
                case NumericKeypadKeys.OpDecimalSeparator: break;
                case NumericKeypadKeys.OpResult: break;
            }
        }

        private void AddNumber(long number)
        {
            var value = _trackingValue;
            switch (SelectedBaseNumber)
            {
                case BaseNumber.Binary:
                    if ((value & MSB1000) == 0)
                    {
                        value = (value << 1) + number;
                    }
                    break;
                case BaseNumber.Octal:
                    if ((value & MSB1110) == 0)
                    {
                        value = (value << 3) + number;
                    }
                    break;
                case BaseNumber.Decimal:
                    try
                    {
                        value = checked(value * 10) + number;
                    }
                    catch (OverflowException)
                    {
                    }
                    break;
                case BaseNumber.Hexadecimal:
                    if ((value & MSB1111) == 0)
                    {
                        value = (value << 4) + number;
                    }
                    break;
            }

            DisplayValue = _trackingValue = value;
        }

        private void SelectedBaseNumberChanged()
        {
            _trackingValue = 0;
        }
    }
}
