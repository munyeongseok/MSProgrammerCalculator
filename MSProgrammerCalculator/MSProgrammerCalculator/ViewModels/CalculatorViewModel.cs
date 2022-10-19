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
                    BaseNumberChanged();
                }
            }
        }

        public DelegateCommand KeypadNumberButtonClickCommand { get; private set; }
        public DelegateCommand KeypadUnaryOperatorButtonClickCommand { get; private set; }
        public DelegateCommand KeypadBinaryOperatorButtonClickCommand { get; private set; }
        public DelegateCommand KeypadAuxiliaryOperatorButtonClickCommand { get; private set; }

        private const long MSB1000 = unchecked((long)0b_1000000000000000_0000000000000000_0000000000000000_0000000000000000);
        private const long MSB1110 = unchecked((long)0b_1110000000000000_0000000000000000_0000000000000000_0000000000000000);
        private const long MSB1111 = unchecked((long)0b_1111000000000000_0000000000000000_0000000000000000_0000000000000000);
        private long _leftHandOperand;
        private long _rightHandOperand;
        private KeypadOperators _operator;

        public CalculatorViewModel()
        {
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            KeypadNumberButtonClickCommand = new DelegateCommand(parameter => KeypadNumberButtonClicked(parameter));
            KeypadUnaryOperatorButtonClickCommand = new DelegateCommand(parameter => KeypadUnaryOperatorButtonClicked(parameter));
            KeypadBinaryOperatorButtonClickCommand = new DelegateCommand(parameter => KeypadBinaryOperatorButtonClicked(parameter));
            KeypadAuxiliaryOperatorButtonClickCommand = new DelegateCommand(parameter => KeypadAuxiliaryOperatorButtonClicked(parameter));
        }

        private void KeypadNumberButtonClicked(object parameter)
        {
            switch ((KeypadNumbers)parameter)
            {
                case KeypadNumbers.Num0: InsertNumber(0); break;
                case KeypadNumbers.Num1: InsertNumber(1); break;
                case KeypadNumbers.Num2: InsertNumber(2); break;
                case KeypadNumbers.Num3: InsertNumber(3); break;
                case KeypadNumbers.Num4: InsertNumber(4); break;
                case KeypadNumbers.Num5: InsertNumber(5); break;
                case KeypadNumbers.Num6: InsertNumber(6); break;
                case KeypadNumbers.Num7: InsertNumber(7); break;
                case KeypadNumbers.Num8: InsertNumber(8); break;
                case KeypadNumbers.Num9: InsertNumber(9); break;
                case KeypadNumbers.NumA: InsertNumber(10); break;
                case KeypadNumbers.NumB: InsertNumber(11); break;
                case KeypadNumbers.NumC: InsertNumber(12); break;
                case KeypadNumbers.NumD: InsertNumber(13); break;
                case KeypadNumbers.NumE: InsertNumber(14); break;
                case KeypadNumbers.NumF: InsertNumber(15); break;
            }
        }

        private void KeypadUnaryOperatorButtonClicked(object parameter)
        {
            var value = _rightHandOperand;
            switch ((KeypadOperators)parameter)
            {
                case KeypadOperators.NOT:
                    value = ~value;
                    break;
                case KeypadOperators.Negate:
                    value = -value;
                    break;
            }

            DisplayValue = _rightHandOperand = value;
        }

        private void KeypadBinaryOperatorButtonClicked(object parameter)
        {
            if (_rightHandOperand != 0)
            {
                _leftHandOperand = _rightHandOperand;
                _rightHandOperand = 0;
                _operator = (KeypadOperators)parameter;
            }
        }

        private void KeypadAuxiliaryOperatorButtonClicked(object parameter)
        {
            switch ((KeypadOperators)parameter)
            {
                case KeypadOperators.Clear:
                    ClearNumber();
                    break;
                case KeypadOperators.BackSpace:
                    RemoveNumber();
                    break;
                case KeypadOperators.OpenParenthesis:
                    break;
                case KeypadOperators.CloseParenthesis:
                    break;
                case KeypadOperators.DecimalSeparator:
                    break;
                case KeypadOperators.Result:
                    CalculateResult();
                    break;
            }
        }

        private void InsertNumber(long number)
        {
            var value = _rightHandOperand;
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

            DisplayValue = _rightHandOperand = value;
        }

        private void RemoveNumber()
        {
            if (_rightHandOperand != 0)
            {
                var value = _rightHandOperand;
                switch (SelectedBaseNumber)
                {
                    case BaseNumber.Binary:
                        value >>= 1;
                        break;
                    case BaseNumber.Octal:
                        value >>= 3;
                        break;
                    case BaseNumber.Decimal:
                        value /= 10;
                        break;
                    case BaseNumber.Hexadecimal:
                        value >>= 4;
                        break;
                }

                DisplayValue = _leftHandOperand = _rightHandOperand = value;
            }
        }

        private void ClearNumber()
        {
            DisplayValue = _leftHandOperand = _rightHandOperand = 0;
            _operator = KeypadOperators.None;
        }

        private void CalculateResult()
        {
            var value = 0L;
            switch (_operator)
            {
                case KeypadOperators.AND:
                    value = _leftHandOperand & _rightHandOperand;
                    break;
                case KeypadOperators.OR:
                    value = _leftHandOperand | _rightHandOperand;
                    break;
                case KeypadOperators.NAND:
                    value = ~(_leftHandOperand & _rightHandOperand);
                    break;
                case KeypadOperators.NOR:
                    value = ~(_leftHandOperand | _rightHandOperand);
                    break;
                case KeypadOperators.XOR:
                    value = _leftHandOperand ^ _rightHandOperand;
                    break;
                case KeypadOperators.LeftShift:
                    value = _leftHandOperand << (int)_rightHandOperand;
                    break;
                case KeypadOperators.RightShift:
                    value = _leftHandOperand >> (int)_rightHandOperand;
                    break;
                case KeypadOperators.Modulo:
                    value = _leftHandOperand % _rightHandOperand;
                    break;
                case KeypadOperators.Divide:
                    value = _leftHandOperand / _rightHandOperand;
                    break;
                case KeypadOperators.Multiply:
                    value = _leftHandOperand * _rightHandOperand;
                    break;
                case KeypadOperators.Minus:
                    value = _leftHandOperand - _rightHandOperand;
                    break;
                case KeypadOperators.Plus:
                    value = _leftHandOperand + _rightHandOperand;
                    break;
            }

            _rightHandOperand = 0;
            DisplayValue = _leftHandOperand = value;
        }

        private void BaseNumberChanged()
        {
            _rightHandOperand = 0;
        }
    }
}
