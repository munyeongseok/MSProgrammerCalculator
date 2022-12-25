using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class CalculationContext
    {
        internal Queue<IExpression> InputQueue { get; }

        internal Queue<IExpression> OutputQueue { get; }

        internal Stack<IOperatorExpression> OperatorStack { get; }

        public BaseNumber BaseNumber { get; internal set; }

        public long CurrentOperand { get; internal set; }

        public string CurrentExpression { get; internal set; }

        public CalculationContext()
            : this(BaseNumber.Unknown)
        {
        }

        public CalculationContext(BaseNumber baseNumber)
        {
            InputQueue = new Queue<IExpression>();
            OutputQueue = new Queue<IExpression>();
            OperatorStack = new Stack<IOperatorExpression>();
            BaseNumber = baseNumber;
        }
    }
}
