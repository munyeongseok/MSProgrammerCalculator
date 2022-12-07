using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class LeftShiftExpression : BinaryOperatorExpression
    {
        public LeftShiftExpression() : this(null, null)
        {
        }

        public LeftShiftExpression(IValueExpression leftOperand, IValueExpression rightOperand)
            : base(leftOperand, rightOperand,
                  CalculatorHelper.GetPrecedence(Operators.LeftShift),
                  CalculatorHelper.GetAssociativity(Operators.LeftShift))
        {
        }

        public override long Evaluate(CalculationContext context)
        {
            return LeftOperand.Evaluate(context) << (int)RightOperand.Evaluate(context);
        }
    }
}
