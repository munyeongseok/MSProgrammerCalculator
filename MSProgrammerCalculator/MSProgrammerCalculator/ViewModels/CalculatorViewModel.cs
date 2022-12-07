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

        private CalculationContext _context;
        private Calculator.Calculator _calculator;

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
            _context = new CalculationContext();
            _calculator = new Calculator.Calculator();
            _calculator.SetContext(_context);
        }

        private void KeypadNumberButtonClicked(object parameter)
        {
            _calculator.InsertNumber((Numbers)parameter);
            DisplayValue = _context.Operand;
        }

        private void KeypadUnaryOperatorButtonClicked(object parameter)
        {
            _calculator.PushUnaryExpression((Operators)parameter);
            _calculator.Evaluate();
            NumericalExpression = _context.Expression;
            DisplayValue = _context.Result;
        }

        private void KeypadBinaryOperatorButtonClicked(object parameter)
        {
            _calculator.PushBinaryExpression((Operators)parameter);
            _calculator.Evaluate();
            NumericalExpression = _context.Expression;
            DisplayValue = _context.Result;
        }

        private void KeypadAuxiliaryOperatorButtonClicked(object parameter)
        {
            _calculator.PushAuxiliaryExpression((Operators)parameter);
            _calculator.Evaluate();
            NumericalExpression = _context.Expression;
            DisplayValue = _context.Result;
        }
    }
}
