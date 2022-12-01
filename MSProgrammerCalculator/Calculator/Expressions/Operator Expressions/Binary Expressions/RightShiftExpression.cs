using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class RightShiftExpression : BinaryOperatorExpression
    {
        public RightShiftExpression(IValueExpression leftOperand, IValueExpression rightOperand)
            : base(leftOperand, rightOperand,
                  CalculatorHelper.GetPrecedence(Operators.RightShift),
                  CalculatorHelper.GetAssociativity(Operators.RightShift))
        {
        }

        public override long Evaluate(CalculatorContext context)
        {
            return LeftOperand.Value >> (int)RightOperand.Value;
        }
    }
}
