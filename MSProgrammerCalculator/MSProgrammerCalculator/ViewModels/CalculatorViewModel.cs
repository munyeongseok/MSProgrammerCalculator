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
                    _calculator.SetBaseNumber(selectedBaseNumber);
                }
            }
        }

        public DelegateCommand KeypadNumberButtonClickCommand { get; private set; }
        public DelegateCommand KeypadUnaryOperatorButtonClickCommand { get; private set; }
        public DelegateCommand KeypadBinaryOperatorButtonClickCommand { get; private set; }
        public DelegateCommand KeypadAuxiliaryOperatorButtonClickCommand { get; private set; }

        private CalculatorContext _currentContext;
        private readonly Calculator.Calculator _calculator = new Calculator.Calculator();

        public CalculatorViewModel()
        {
            InitializeCommands();
            InitializeCalculator();
        }

        private void InitializeCommands()
        {
            KeypadNumberButtonClickCommand = new DelegateCommand(parameter => KeypadNumberButtonClicked(parameter));
            KeypadUnaryOperatorButtonClickCommand = new DelegateCommand(parameter => KeypadUnaryOperatorButtonClicked(parameter));
            KeypadBinaryOperatorButtonClickCommand = new DelegateCommand(parameter => KeypadBinaryOperatorButtonClicked(parameter));
            KeypadAuxiliaryOperatorButtonClickCommand = new DelegateCommand(parameter => KeypadAuxiliaryOperatorButtonClicked(parameter));
        }

        private void InitializeCalculator()
        {
            _currentContext = new CalculatorContext();
            _calculator.SetContext(_currentContext);
        }

        private void KeypadNumberButtonClicked(object parameter)
        {
            _calculator.InsertNumber((Numbers)parameter);
            DisplayValue = _currentContext.Operand;
        }

        private void KeypadUnaryOperatorButtonClicked(object parameter)
        {
            _calculator.PushUnaryExpression((Operators)parameter);
            _calculator.Evaluate();
            NumericalExpression = _currentContext.Expression;
            DisplayValue = _currentContext.Result;
        }

        private void KeypadBinaryOperatorButtonClicked(object parameter)
        {
            _calculator.PushBinaryExpression((Operators)parameter);
            _calculator.Evaluate();
            NumericalExpression = _currentContext.Expression;
            DisplayValue = _currentContext.Result;
        }

        private void KeypadAuxiliaryOperatorButtonClicked(object parameter)
        {
            switch ((Operators)parameter)
            {
                case Operators.Clear:
                    _calculator.ClearNumber();
                    DisplayValue = 0;
                    break;
                case Operators.BackSpace:
                    _calculator.RemoveNumber();
                    DisplayValue = _currentContext.Operand;
                    break;
                case Operators.OpenParenthesis:
                    break;
                case Operators.CloseParenthesis:
                    break;
                case Operators.DecimalSeparator:
                    break;
                case Operators.Result:
                    _calculator.Evaluate();
                    NumericalExpression = _currentContext.Expression;
                    DisplayValue = _currentContext.Result;
                    break;
            }
        }
    }
}
