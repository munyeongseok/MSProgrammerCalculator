using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class CalculatorContext
    {
        internal Stack<ICalculatorExpression> ExpressionStack { get; } = new Stack<ICalculatorExpression>();

        public BaseNumber BaseNumber { get; internal set; }

        public long Operand { get; internal set; }

        public bool OperandChanged { get; internal set; }

        public long Result { get; internal set; }

        public string Expression { get; internal set; }
    }
}
