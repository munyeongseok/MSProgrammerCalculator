using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class BitwiseNANDExpression : BinaryOperatorExpression
    {
        public BitwiseNANDExpression(IValueExpression leftOperand, IValueExpression rightOperand)
            : base(leftOperand, rightOperand,
                  CalculatorHelper.GetPrecedence(Operators.BitwiseNAND),
                  CalculatorHelper.GetAssociativity(Operators.BitwiseNAND))
        {
        }

        public override long Evaluate(CalculatorContext context)
        {
            return ~(LeftOperand.Value & RightOperand.Value);
        }
    }
}
