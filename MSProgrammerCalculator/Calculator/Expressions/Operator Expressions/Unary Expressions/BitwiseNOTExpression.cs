using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class BitwiseNOTExpression : UnaryOperatorExpression
    {
        public BitwiseNOTExpression(IValueExpression operand)
            : base(operand,
                  CalculatorHelper.GetPrecedence(Operators.BitwiseNOT),
                  CalculatorHelper.GetAssociativity(Operators.BitwiseNOT))
        {
        }

        public override long Evaluate(CalculatorContext context)
        {
            return ~Operand.Value;
        }
    }
}
