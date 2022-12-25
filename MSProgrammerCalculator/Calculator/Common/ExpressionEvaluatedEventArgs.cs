using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class ExpressionEvaluatedEventArgs : EventArgs
    {
        /// <summary>
        /// 현재 피연산자.
        /// </summary>
        public long CurrentOperand { get; }

        /// <summary>
        /// 현재 표현식.
        /// </summary>
        public string CurrentExpression { get; }

        public ExpressionEvaluatedEventArgs(long currentOperand, string currentExpression)
        {
            CurrentOperand = currentOperand;
            CurrentExpression = currentExpression;
        }
    }
}
