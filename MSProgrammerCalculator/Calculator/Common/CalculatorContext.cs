using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class CalculatorContext
    {
        internal Queue<IExpression> InputQueue { get; set; }

        internal int UnmatchedParenthesisCount { get; set; }

        public CalculatorContext()
        {
            InputQueue = new Queue<IExpression>();
        }

        internal void Clear()
        {
            InputQueue.Clear();
            UnmatchedParenthesisCount = 0;
        }
    }
}
