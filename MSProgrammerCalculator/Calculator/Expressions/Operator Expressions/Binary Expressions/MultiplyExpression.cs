using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class MultiplyExpression : BinaryOperatorExpression
    {
        public MultiplyExpression() : this(null, null)
        {
        }

        public MultiplyExpression(IValueExpression leftOperand, IValueExpression rightOperand)
            : base(leftOperand, rightOperand,
                  CalculatorHelper.GetPrecedence(Operators.Multiply),
                  CalculatorHelper.GetAssociativity(Operators.Multiply))
        {
        }

        public override long Evaluate(CalculatorContext context)
        {
            return LeftOperand.Evaluate(context) * RightOperand.Evaluate(context);
        }
    }
}