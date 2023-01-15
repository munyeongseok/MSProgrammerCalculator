using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class CalculatorContext
    {
        public Queue<IExpression> InputQueue { get; }

        public Queue<IExpression> OutputQueue { get; }

        public Stack<IOperatorExpression> OperatorStack { get; }

        public CalculatorContext()
        {
            InputQueue = new Queue<IExpression>();
            OutputQueue = new Queue<IExpression>();
            OperatorStack = new Stack<IOperatorExpression>();
        }
    }
}
