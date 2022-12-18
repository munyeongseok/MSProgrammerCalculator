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
        private long displayValue;
        public long DisplayValue
        {
            get => displayValue;
            set => SetProperty(ref displayValue, value);
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
                    _calculator.ChangeBaseNumber(selectedBaseNumber);
                }
            }
        }

        public DelegateCommand<Numbers> NumberButtonClickCommand { get; private set; }
        public DelegateCommand<Operators> OperatorButtonClickCommand { get; private set; }

        private readonly ICalculator _calculator = new Calculator.Calculator();

        public CalculatorViewModel()
        {
            NumberButtonClickCommand = new DelegateCommand<Numbers>(parameter => NumberButtonClick(parameter));
            OperatorButtonClickCommand = new DelegateCommand<Operators>(parameter => OperatorButtonClick(parameter));
        }

        private void NumberButtonClick(Numbers number)
        {
            _calculator.InsertNumber(number);
            DisplayValue = _calculator.CurrentDisplayValue;
        }

        private void OperatorButtonClick(Operators op)
        {
            _calculator.TryEnqueueExpression(op);
            _calculator.Evaluate();
            DisplayValue = _calculator.CurrentDisplayValue;
            NumericalExpression = _calculator.CurrentNumericalExpression;
        }
    }
}
