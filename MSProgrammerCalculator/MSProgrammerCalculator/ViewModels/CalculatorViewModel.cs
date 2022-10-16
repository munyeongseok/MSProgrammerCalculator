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

        public DelegateCommand KeypadNumberButtonClickCommand { get; private set; }
        public DelegateCommand KeypadUnaryOperatorButtonClickCommand { get; private set; }
        public DelegateCommand KeypadBinaryOperatorButtonClickCommand { get; private set; }
        public DelegateCommand KeypadAuxiliaryOperatorButtonClickCommand { get; private set; }

        private const long MSB1000 = unchecked((long)0b_1000000000000000_0000000000000000_0000000000000000_0000000000000000);
        private const long MSB1110 = unchecked((long)0b_1110000000000000_0000000000000000_0000000000000000_0000000000000000);
        private const long MSB1111 = unchecked((long)0b_1111000000000000_0000000000000000_0000000000000000_0000000000000000);
        private long _leftHandOperand;
        private long _rightHandOperand;
        private KeypadButtons _operator;

        public CalculatorViewModel()
        {
            KeypadNumberButtonClickCommand = new DelegateCommand(parameter => KeypadNumberButtonClicked(parameter));
            KeypadUnaryOperatorButtonClickCommand = new DelegateCommand(parameter => KeypadUnaryOperatorButtonClicked(parameter));
            KeypadBinaryOperatorButtonClickCommand = new DelegateCommand(parameter => KeypadBinaryOperatorButtonClicked(parameter));
            KeypadAuxiliaryOperatorButtonClickCommand = new DelegateCommand(parameter => KeypadAuxiliaryOperatorButtonClicked(parameter));
        }

        private void KeypadNumberButtonClicked(object parameter)
        {
            switch ((KeypadButtons)parameter)
            {
                case KeypadButtons.Num0: AddNumber(0); break;
                case KeypadButtons.Num1: AddNumber(1); break;
                case KeypadButtons.Num2: AddNumber(2); break;
                case KeypadButtons.Num3: AddNumber(3); break;
                case KeypadButtons.Num4: AddNumber(4); break;
                case KeypadButtons.Num5: AddNumber(5); break;
                case KeypadButtons.Num6: AddNumber(6); break;
                case KeypadButtons.Num7: AddNumber(7); break;
                case KeypadButtons.Num8: AddNumber(8); break;
                case KeypadButtons.Num9: AddNumber(9); break;
                case KeypadButtons.NumA: AddNumber(10); break;
                case KeypadButtons.NumB: AddNumber(11); break;
                case KeypadButtons.NumC: AddNumber(12); break;
                case KeypadButtons.NumD: AddNumber(13); break;
                case KeypadButtons.NumE: AddNumber(14); break;
                case KeypadButtons.NumF: AddNumber(15); break;
            }
        }

        private void KeypadUnaryOperatorButtonClicked(object parameter)
        {
            var value = _rightHandOperand;
            switch ((KeypadButtons)parameter)
            {
                case KeypadButtons.BitwiseNOT:
                    value = ~value;
                    break;
                case KeypadButtons.Negate:
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
                _operator = (KeypadButtons)parameter;
            }
        }

        private void KeypadAuxiliaryOperatorButtonClicked(object parameter)
        {
            switch ((KeypadButtons)parameter)
            {
                case KeypadButtons.Clear:
                case KeypadButtons.BackSpace:
                case KeypadButtons.OpenParenthesis:
                case KeypadButtons.CloseParenthesis:
                case KeypadButtons.DecimalSeparator:
                    break;
                case KeypadButtons.Result:
                    CalculateBinaryOperatorResult();
                    break;
            }
        }

        private void AddNumber(long number)
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

        private void CalculateBinaryOperatorResult()
        {
            var value = 0L;
            switch (_operator)
            {
                case KeypadButtons.BitwiseAND:
                    value = _leftHandOperand & _rightHandOperand;
                    break;
                case KeypadButtons.BitwiseOR:
                    value = _leftHandOperand | _rightHandOperand;
                    break;
                case KeypadButtons.BitwiseNAND:
                    value = ~(_leftHandOperand & _rightHandOperand);
                    break;
                case KeypadButtons.BitwiseNOR:
                    value = ~(_leftHandOperand | _rightHandOperand);
                    break;
                case KeypadButtons.BitwiseXOR:
                    value = _leftHandOperand ^ _rightHandOperand;
                    break;
                case KeypadButtons.LeftShift:
                    value = _leftHandOperand << (int)_rightHandOperand;
                    break;
                case KeypadButtons.RightShift:
                    value = _leftHandOperand >> (int)_rightHandOperand;
                    break;
                case KeypadButtons.Modulo:
                    value = _leftHandOperand % _rightHandOperand;
                    break;
                case KeypadButtons.Divide:
                    value = _leftHandOperand / _rightHandOperand;
                    break;
                case KeypadButtons.Multiply:
                    value = _leftHandOperand * _rightHandOperand;
                    break;
                case KeypadButtons.Minus:
                    value = _leftHandOperand - _rightHandOperand;
                    break;
                case KeypadButtons.Plus:
                    value = _leftHandOperand + _rightHandOperand;
                    break;
            }

            _rightHandOperand = 0;
            DisplayValue = _leftHandOperand = value;
        }

        private void SelectedBaseNumberChanged()
        {
            _rightHandOperand = 0;
        }
    }
}
