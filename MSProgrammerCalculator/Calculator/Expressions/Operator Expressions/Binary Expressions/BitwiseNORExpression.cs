using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class BitwiseNORExpression : BinaryOperatorExpression
    {
        public BitwiseNORExpression(IValueExpression leftOperand, IValueExpression rightOperand)
            : base(leftOperand, rightOperand,
                  CalculatorHelper.GetPrecedence(Operators.BitwiseNOR),
                  CalculatorHelper.GetAssociativity(Operators.BitwiseNOR))
        {
        }

        public override long Evaluate(CalculatorContext context)
        {
            return ~(LeftOperand.Value | RightOperand.Value);
        }
    }
}
