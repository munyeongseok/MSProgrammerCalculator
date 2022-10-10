using MSProgrammerCalculator.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSProgrammerCalculator.ViewModels
{
    public class CalculatorViewModel
    {
        public DelegateCommand NumericKeypadButtonClickCommand { get; private set; }

        public CalculatorViewModel()
        {
            NumericKeypadButtonClickCommand = new DelegateCommand(parameter => NumericKeypadButtonClicked(parameter));
        }

        private void NumericKeypadButtonClicked(object parameter)
        {
            System.Diagnostics.Debug.WriteLine(parameter.ToString());

            switch ((NumericKeypadKeys)parameter)
            {
                case NumericKeypadKeys.Num0: break;
                case NumericKeypadKeys.Num1: break;
                case NumericKeypadKeys.Num2: break;
                case NumericKeypadKeys.Num3: break;
                case NumericKeypadKeys.Num4: break;
                case NumericKeypadKeys.Num5: break;
                case NumericKeypadKeys.Num6: break;
                case NumericKeypadKeys.Num7: break;
                case NumericKeypadKeys.Num8: break;
                case NumericKeypadKeys.Num9: break;
                case NumericKeypadKeys.NumA: break;
                case NumericKeypadKeys.NumB: break;
                case NumericKeypadKeys.NumC: break;
                case NumericKeypadKeys.NumD: break;
                case NumericKeypadKeys.NumE: break;
                case NumericKeypadKeys.NumF: break;
                case NumericKeypadKeys.OpLeftShift: break;
                case NumericKeypadKeys.OpRightShift: break;
                case NumericKeypadKeys.OpModulo: break;
                case NumericKeypadKeys.OpDivide: break;
                case NumericKeypadKeys.OpMultiply: break;
                case NumericKeypadKeys.OpMinus: break;
                case NumericKeypadKeys.OpPlus: break;
                case NumericKeypadKeys.OpNegate: break;
                case NumericKeypadKeys.OpClear: break;
                case NumericKeypadKeys.OpBackSpace: break;
                case NumericKeypadKeys.OpOpenParenthesis: break;
                case NumericKeypadKeys.OpCloseParenthesis: break;
                case NumericKeypadKeys.OpDecimalSeparator: break;
                case NumericKeypadKeys.OpResult: break;
            }
        }
    }
}
