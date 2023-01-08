using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class CurrentOperandChangedEventArgs : EventArgs
    {
        /// <summary>
        /// 피연산자.
        /// </summary>
        public long Operand { get; }

        public CurrentOperandChangedEventArgs(long operand)
        {
            Operand = operand;
        }
    }
}
