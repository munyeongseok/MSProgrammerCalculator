using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class CalculatorContext
    {
        internal Deque<IExpression> InputDeque { get; set; }

        internal int UnmatchedParenthesisCount { get; set; }

        public CalculatorContext()
        {
            InputDeque = new Deque<IExpression>();
        }

        internal void Clear()
        {
            InputDeque.Clear();
            UnmatchedParenthesisCount = 0;
        }
    }
}
