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
        private string expression;
        public string Expression
        {
            get => expression;
            set => SetProperty(ref expression, value);
        }

        private long displayOperand;
        public long DisplayOperand
        {
            get => displayOperand;
            set => SetProperty(ref displayOperand, value);
        }

        private string errorMessage;
        public string ErrorMessage
        {
            get => errorMessage;
            set => SetProperty(ref errorMessage, value);
        }

        private BaseNumber selectedBaseNumber;
        public BaseNumber SelectedBaseNumber
        {
            get => selectedBaseNumber;
            set
            {
                if (SetProperty(ref selectedBaseNumber, value))
                {
                    _programmerCalculator.BaseNumber = selectedBaseNumber;
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

        private readonly ICalculator _programmerCalculator = new ProgrammerCalculator();

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
            _programmerCalculator.PropertyChanged += (s, e) =>
            {
                switch (e.PropertyName)
                {
                    case nameof(ICalculator.BaseNumber):
                        break;
                    case nameof(ICalculator.Operand):
                        DisplayOperand = _programmerCalculator.Operand;
                        ClearButtonContent = _programmerCalculator.Operand == 0 ? "C" : "CE";
                        break;
                    case nameof(ICalculator.Expression):
                        Expression = _programmerCalculator.Expression;
                        break;
                }
            };
        }

        private void NumberButtonClick(Numbers number)
        {
            InitializeCalculatorIfErrorOccurred();

            _programmerCalculator.EnqueueToken(number);
        }

        private void OperatorButtonClick(Operators op)
        {
            InitializeCalculatorIfErrorOccurred();

            try
            {
                _programmerCalculator.EnqueueToken(op);
            }
            catch (DivideByZeroException)
            {
                ErrorMessage = "0으로 나눌 수 없습니다.";
            }
            catch (Exception)
            {
                ErrorMessage = "정의되지 않은 결과입니다.";
            }
        }

        private void InitializeCalculatorIfErrorOccurred()
        {
            if (!string.IsNullOrWhiteSpace(ErrorMessage))
            {
                ErrorMessage = string.Empty;

                _programmerCalculator.Initialize();
            }
        }
    }
}
