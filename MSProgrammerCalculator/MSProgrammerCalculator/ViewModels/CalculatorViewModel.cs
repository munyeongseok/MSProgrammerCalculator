using Calculator;
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

        private long _currentOperand;
        private bool _currentOperandChanged;
        private CalculatorContext _currentContext;
        private readonly Calculator.Calculator _calculator = new Calculator.Calculator();

        public CalculatorViewModel()
        {
            InitializeCommands();
            InitializeValue();
        }

        private void InitializeCommands()
        {
            KeypadNumberButtonClickCommand = new DelegateCommand(parameter => KeypadNumberButtonClicked(parameter));
            KeypadUnaryOperatorButtonClickCommand = new DelegateCommand(parameter => KeypadUnaryOperatorButtonClicked(parameter));
            KeypadBinaryOperatorButtonClickCommand = new DelegateCommand(parameter => KeypadBinaryOperatorButtonClicked(parameter));
            KeypadAuxiliaryOperatorButtonClickCommand = new DelegateCommand(parameter => KeypadAuxiliaryOperatorButtonClicked(parameter));
        }

        private void InitializeValue()
        {
            _currentOperand = 0;
            _currentOperandChanged = true;
            _currentContext = new CalculatorContext();
            _calculator.SetContext(_currentContext);
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
            if (_currentOperandChanged)
            {
                _calculator.PushExpression(op, _currentOperand);
                _currentOperandChanged = false;

                //DisplayValue = Calculation.UnaryOperation(_rightHandOperand, op);
                //_isOperandChanged = false;
            }
        }

        private void KeypadBinaryOperatorButtonClicked(object parameter)
        {
            var op = (Operators)parameter;
            if (_currentOperandChanged)
            {
                _calculator.PushExpression(op, _currentOperand);
                SubmitResult();
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
        }

        private void InsertNumber(long number)
        {
            DisplayValue = _currentOperand = CalculationHelper.InsertNumberAtRight(SelectedBaseNumber, _currentOperand, number);
            _currentOperandChanged = true;
        }

        private void RemoveNumber()
        {
            if (_currentOperand != 0)
            {
                DisplayValue = _currentOperand = CalculationHelper.RemoveNumberAtRight(SelectedBaseNumber, _currentOperand);
            }
        }

        private void ClearNumber()
        {
            DisplayValue = _currentOperand = 0;
        }

        private void SubmitResult()
        {
            _currentOperand = 0;
            _currentOperandChanged = false;
            _calculator.Evaluate();

            NumericalExpression = _currentContext.Expression;
            DisplayValue = _currentContext.Result;
        }

        private void BaseNumberChanged()
        {
            _currentOperand = 0;
        }
    }
}
