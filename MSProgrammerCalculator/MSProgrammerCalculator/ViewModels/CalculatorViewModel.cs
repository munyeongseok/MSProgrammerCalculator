using MSProgrammerCalculator.Common;
using MSProgrammerCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSProgrammerCalculator.ViewModels
{
    public class CalculatorViewModel : BindableBase
    {
        private string numericalExpression;
        public string NumericalExpression
        {
            get => numericalExpression;
            set => SetProperty(ref numericalExpression, value);
        }

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

        private Stack<NumericalExpressionNode> _expressions = new Stack<NumericalExpressionNode>();
        private Operators _operator;
        private long _leftHandOperand;
        private long _rightHandOperand;
        private bool _isOperandChanged;

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
            switch ((Numbers)parameter)
            {
                case Numbers.Num0: InsertNumber(0); break;
                case Numbers.Num1: InsertNumber(1); break;
                case Numbers.Num2: InsertNumber(2); break;
                case Numbers.Num3: InsertNumber(3); break;
                case Numbers.Num4: InsertNumber(4); break;
                case Numbers.Num5: InsertNumber(5); break;
                case Numbers.Num6: InsertNumber(6); break;
                case Numbers.Num7: InsertNumber(7); break;
                case Numbers.Num8: InsertNumber(8); break;
                case Numbers.Num9: InsertNumber(9); break;
                case Numbers.NumA: InsertNumber(10); break;
                case Numbers.NumB: InsertNumber(11); break;
                case Numbers.NumC: InsertNumber(12); break;
                case Numbers.NumD: InsertNumber(13); break;
                case Numbers.NumE: InsertNumber(14); break;
                case Numbers.NumF: InsertNumber(15); break;
            }
        }

        private void KeypadUnaryOperatorButtonClicked(object parameter)
        {
            var keypadOperator = (Operators)parameter;
            if (_isOperandChanged)
            {
                InsertExpression(keypadOperator, _rightHandOperand);

                var value = _rightHandOperand;
                switch (keypadOperator)
                {
                    case Operators.NOT:
                        value = ~value;
                        break;
                    case Operators.Negate:
                        value = -value;
                        break;
                    default:
                        return;
                }

                DisplayValue = value;
                _isOperandChanged = false;
            }
        }

        private void KeypadBinaryOperatorButtonClicked(object parameter)
        {
            var keypadOperator = (Operators)parameter;
            if (_isOperandChanged)
            {
                InsertExpression(keypadOperator, _rightHandOperand);

                _operator = keypadOperator;
                _leftHandOperand = _rightHandOperand;
                _rightHandOperand = 0;
                _isOperandChanged = false;
            }
        }

        private void KeypadAuxiliaryOperatorButtonClicked(object parameter)
        {
            var keypadOperator = (Operators)parameter;
            switch (keypadOperator)
            {
                case Operators.Clear:
                    ClearNumber();
                    break;
                case Operators.BackSpace:
                    RemoveNumber();
                    break;
                case Operators.OpenParenthesis:
                    break;
                case Operators.CloseParenthesis:
                    break;
                case Operators.DecimalSeparator:
                    break;
                case Operators.Result:
                    SubmitResult();
                    break;
            }

            InsertExpression(keypadOperator, _rightHandOperand);
        }

        private void InsertExpression(Operators keypadOperator, long value)
        {
            if (_expressions.Any())
            {
                var topExNode = _expressions.Peek();
                if (topExNode.Operator == Operators.NOT)
                {
                    _expressions.Pop();

                    //if (_isOperandChanged)
                    //{
                    //    _expressions.Pop();
                    //}
                    //else
                    //{
                    //    _expressions
                    //}
                }
            }

            var newExNode = CreateExpressionNode(keypadOperator, value);
            if (newExNode != null)
            {
                _expressions.Push(newExNode);

                var sb = new StringBuilder();
                foreach (var exNode in _expressions)
                {
                    sb.Append(exNode.Expression);
                }
                NumericalExpression = sb.ToString();
            }
        }

        private NumericalExpressionNode CreateExpressionNode(Operators keypadOperator, long value)
        {
            string expression;
            switch (keypadOperator)
            {
                case Operators.AND:
                    expression = $"{value} AND ";
                    break;
                case Operators.OR:
                    expression = $"{value} OR ";
                    break;
                case Operators.NOT:
                    expression = $"NOT( {value} ) ";
                    break;
                case Operators.NAND:
                    expression = $"{value} NAND ";
                    break;
                case Operators.NOR:
                    expression = $"{value} NOR ";
                    break;
                case Operators.XOR:
                    expression = $"{value} XOR ";
                    break;
                case Operators.LeftShift:
                    expression = $"{value} Lsh ";
                    break;
                case Operators.RightShift:
                    expression = $"{value} Rsh ";
                    break;
                case Operators.Modulo:
                    expression = $"{value} % ";
                    break;
                case Operators.Divide:
                    expression = $"{value} ÷ ";
                    break;
                case Operators.Multiply:
                    expression = $"{value} × ";
                    break;
                case Operators.Minus:
                    expression = $"{value} - ";
                    break;
                case Operators.Plus:
                    expression = $"{value} + ";
                    break;
                case Operators.Result:
                    expression = $"{value} = ";
                    break;
                default:
                    return null;
            }

            return new NumericalExpressionNode(keypadOperator, expression);
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
            _isOperandChanged = true;
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
            _operator = Operators.None;
            DisplayValue = _leftHandOperand = _rightHandOperand = 0;
        }

        private void SubmitResult()
        {
            var value = 0L;
            switch (_operator)
            {
                case Operators.AND:
                    value = _leftHandOperand & _rightHandOperand;
                    break;
                case Operators.OR:
                    value = _leftHandOperand | _rightHandOperand;
                    break;
                case Operators.NAND:
                    value = ~(_leftHandOperand & _rightHandOperand);
                    break;
                case Operators.NOR:
                    value = ~(_leftHandOperand | _rightHandOperand);
                    break;
                case Operators.XOR:
                    value = _leftHandOperand ^ _rightHandOperand;
                    break;
                case Operators.LeftShift:
                    value = _leftHandOperand << (int)_rightHandOperand;
                    break;
                case Operators.RightShift:
                    value = _leftHandOperand >> (int)_rightHandOperand;
                    break;
                case Operators.Modulo:
                    value = _leftHandOperand % _rightHandOperand;
                    break;
                case Operators.Divide:
                    value = _leftHandOperand / _rightHandOperand;
                    break;
                case Operators.Multiply:
                    value = _leftHandOperand * _rightHandOperand;
                    break;
                case Operators.Minus:
                    value = _leftHandOperand - _rightHandOperand;
                    break;
                case Operators.Plus:
                    value = _leftHandOperand + _rightHandOperand;
                    break;
                default:
                    return;
            }

            DisplayValue = _leftHandOperand = value;
        }

        private void BaseNumberChanged()
        {
            _rightHandOperand = 0;
        }
    }
}
