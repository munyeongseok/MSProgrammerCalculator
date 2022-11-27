using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class CalculatorContext
    {
        internal Stack<IExpression> Expressions { get; } = new Stack<IExpression>();

        public BaseNumber BaseNumber { get; internal set; }

        public long Operand { get; internal set; }

        public bool OperandChanged { get; internal set; }

        public long Result { get; internal set; }

        public string Expression { get; internal set; }
    }
}
