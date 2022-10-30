using Calculator;
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

        private Stack<NumericalExpressionNode> _expressions = new Stack<NumericalExpressionNode>();
        private Operators _operator;
        private long _leftHandOperand;
        private long _rightHandOperand;
        private bool _isOperandChanged;

        public CalculatorViewModel()
        {
            InitializeCommands();

            var calculatorContext = new CalculatorContext();
            var calculator = new Calculator.Calculator();
            calculator.SetContext(calculatorContext);
            calculator.PushExpression(new AddExpression(9));
            calculator.Evaluate();
            var result1 = calculatorContext.LeftOperand;
            calculator.PushExpression(new AddExpression(10));
            calculator.Evaluate();
            var result2 = calculatorContext.LeftOperand;
            calculator.PushExpression(new AddExpression(-4));
            calculator.PushExpression(new AddExpression(-5));
            calculator.Evaluate();
            var result3 = calculatorContext.LeftOperand;
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
            var op = (Operators)parameter;
            if (_isOperandChanged)
            {
                InsertExpression(op, _rightHandOperand);

                DisplayValue = Calculation.UnaryOperation(_rightHandOperand, op);
                _isOperandChanged = false;
            }
        }

        private void KeypadBinaryOperatorButtonClicked(object parameter)
        {
            var op = (Operators)parameter;
            if (_isOperandChanged)
            {
                InsertExpression(op, _rightHandOperand);

                _operator = op;
                _leftHandOperand = _rightHandOperand;
                _rightHandOperand = 0;
                _isOperandChanged = false;
            }
        }

        private void KeypadAuxiliaryOperatorButtonClicked(object parameter)
        {
            var op = (Operators)parameter;
            switch (op)
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

            InsertExpression(op, _rightHandOperand);
        }

        private void InsertExpression(Operators op, long value)
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

            var newExNode = CreateExpressionNode(op, value);
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

        private NumericalExpressionNode CreateExpressionNode(Operators op, long value)
        {
            var expression = Calculation.CreateNumericalExpression(value, op);
            return new NumericalExpressionNode(op, expression);
        }

        private void InsertNumber(long number)
        {
            DisplayValue = _rightHandOperand = Calculation.InsertNumberAtRight(_rightHandOperand, number, SelectedBaseNumber);
            _isOperandChanged = true;
        }

        private void RemoveNumber()
        {
            if (_rightHandOperand != 0)
            {
                DisplayValue = _leftHandOperand = _rightHandOperand = Calculation.RemoveNumberAtRight(_rightHandOperand, SelectedBaseNumber);
            }
        }

        private void ClearNumber()
        {
            _operator = Operators.None;
            DisplayValue = _leftHandOperand = _rightHandOperand = 0;
        }

        private void SubmitResult()
        {
            var result = Calculation.BinaryOperation(_leftHandOperand, _rightHandOperand, _operator);
            DisplayValue = _leftHandOperand = result;
        }

        private void BaseNumberChanged()
        {
            _rightHandOperand = 0;
        }
    }
}
