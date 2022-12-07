using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class DivideExpression : BinaryOperatorExpression
    {
        public DivideExpression() : this(null, null)
        {
        }

        public DivideExpression(IValueExpression leftOperand, IValueExpression rightOperand)
            : base(leftOperand, rightOperand,
                  CalculatorHelper.GetPrecedence(Operators.Divide),
                  CalculatorHelper.GetAssociativity(Operators.Divide))
        {
        }

        public override long Evaluate(CalculationContext context)
        {
            return LeftOperand.Evaluate(context) / RightOperand.Evaluate(context);
        }
    }
}
