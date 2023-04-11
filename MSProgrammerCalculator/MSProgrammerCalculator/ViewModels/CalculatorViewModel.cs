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

        private string expression;
        public string Expression
        {
            get => expression;
            set => SetProperty(ref expression, value);
        }

        private BaseNumber selectedBaseNumber;
        public BaseNumber SelectedBaseNumber
        {
            get => selectedBaseNumber;
            set
            {
                if (SetProperty(ref selectedBaseNumber, value))
                {
                    _calculator.BaseNumber = selectedBaseNumber;
                }
            }
        }

        private string clearButtonContent = "C";
        public string ClearButtonContent
        {
            get => clearButtonContent;
            set => SetProperty(ref clearButtonContent, value);
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
            _calculator.PropertyChanged += (s, e) =>
            {
                switch (e.PropertyName)
                {
                    case nameof(ICalculator.BaseNumber):
                        break;
                    case nameof(ICalculator.Operand):
                        DisplayOperand = _calculator.Operand;
                        ClearButtonContent = _calculator.Operand == 0 ? "C" : "CE";
                        break;
                    case nameof(ICalculator.Expression):
                        Expression = _calculator.Expression;
                        break;
                }
            };
        }

        private void NumberButtonClick(Numbers number)
        {
            _calculator.EnqueueToken(number);
        }

        private void OperatorButtonClick(Operators op)
        {
            _calculator.EnqueueToken(op);
        }
    }
}
