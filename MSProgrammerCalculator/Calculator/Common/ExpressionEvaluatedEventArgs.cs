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
        /// 피연산자.
        /// </summary>
        public long Operand { get; }

        /// <summary>
        /// 표현식.
        /// </summary>
        public string Expression { get; }

        public ExpressionEvaluatedEventArgs(long operand, string expression)
        {
            Operand = operand;
            Expression = expression;
        }
    }
}
