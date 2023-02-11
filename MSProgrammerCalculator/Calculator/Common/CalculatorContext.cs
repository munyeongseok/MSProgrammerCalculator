using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class CalculatorContext
    {
        internal Queue<IExpression> InputQueue { get; }

        internal Queue<IExpression> OutputQueue { get; }

        internal Stack<IOperatorExpression> OperatorStack { get; }

        public CalculatorContext()
        {
            InputQueue = new Queue<IExpression>();
            OutputQueue = new Queue<IExpression>();
            OperatorStack = new Stack<IOperatorExpression>();
        }

        internal void Clear()
        {
            InputQueue.Clear();
            OutputQueue.Clear();
            OperatorStack.Clear();
        }
    }
}
