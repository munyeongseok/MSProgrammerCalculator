using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class NegateExpression : UnaryOperatorExpression
    {
        public NegateExpression(IValueExpression operand)
            : base(operand,
                  CalculatorHelper.GetPrecedence(Operators.Negate),
                  CalculatorHelper.GetAssociativity(Operators.Negate))
        {
        }

        public override long Evaluate(CalculatorContext context)
        {
            return -Operand.Value;
        }
    }
}
