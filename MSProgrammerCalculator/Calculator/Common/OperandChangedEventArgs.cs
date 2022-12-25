using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class OperandChangedEventArgs : EventArgs
    {
        /// <summary>
        /// 현재 피연산자.
        /// </summary>
        public long CurrentOperand { get; }

        public OperandChangedEventArgs(long currentOperand)
        {
            CurrentOperand = currentOperand;
        }
    }
}
