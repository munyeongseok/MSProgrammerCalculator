using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class NegateExpression : UnaryOperatorExpression
    {
        public NegateExpression() : this(null)
        {
        }

        public NegateExpression(IOperandExpression operand)
            : base(operand,
                  CalculatorHelper.GetPrecedence(Operators.Negate),
                  CalculatorHelper.GetAssociativity(Operators.Negate))
        {
        }

        public override long Evaluate(CalculationContext context)
        {
            return -Operand.Evaluate(context);
        }
    }
}
