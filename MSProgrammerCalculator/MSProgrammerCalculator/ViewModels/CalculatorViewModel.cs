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
        private long displayOperand;
        public long DisplayOperand
        {
            get => displayOperand;
            set => SetProperty(ref displayOperand, value);
        }

        private string numericalExpression;
        public string NumericalExpression
        {
            get => numericalExpression;
            set => SetProperty(ref numericalExpression, value);
        }

        private BaseNumber selectedBaseNumber;
        public BaseNumber SelectedBaseNumber
        {
            get => selectedBaseNumber;
            set
            {
                if (SetProperty(ref selectedBaseNumber, value))
                {
                    _calculator.CurrentBaseNumber = selectedBaseNumber;
                }
            }
        }

        public DelegateCommand<Numbers> NumberButtonClickCommand { get; private set; }
        public DelegateCommand<Operators> OperatorButtonClickCommand { get; private set; }

        private readonly ICalculator _calculator = new Calculator.Calculator();

        public CalculatorViewModel()
        {
            InitializeCommands();
            SubscribeCalculatorEvents();
        }

        private void InitializeCommands()
        {
            NumberButtonClickCommand = new DelegateCommand<Numbers>(parameter => NumberButtonClick(parameter));
            OperatorButtonClickCommand = new DelegateCommand<Operators>(parameter => OperatorButtonClick(parameter));
        }

        private void SubscribeCalculatorEvents()
        {
            _calculator.OperandChanged += (s, e) =>
            {
                DisplayOperand = e.Operand;
            };

            _calculator.ExpressionEvaluated += (s, e) =>
            {
                DisplayOperand = e.Operand;
                NumericalExpression = e.Expression;
            };
        }

        private void NumberButtonClick(Numbers number)
        {
            _calculator.InsertNumber(number);
        }

        private void OperatorButtonClick(Operators op)
        {
            if (_calculator.TryEnqueueToken(op))
            {
                _calculator.Evaluate();
            }
        }
    }
}
