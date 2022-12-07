using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class CalculationContext
    {
        internal Queue<IExpression> InputQueue { get; } = new Queue<IExpression>();

        internal Queue<IExpression> OutputQueue { get; } = new Queue<IExpression>();

        internal Stack<IOperatorExpression> OperatorStack { get; } = new Stack<IOperatorExpression>();

        internal Stack<IExpression> Expressions { get; } = new Stack<IExpression>();

        public BaseNumber BaseNumber { get; internal set; }

        public long Operand { get; internal set; }

        public bool OperandChanged { get; internal set; }

        public long Result { get; internal set; }

        public string Expression { get; internal set; }
    }
}
