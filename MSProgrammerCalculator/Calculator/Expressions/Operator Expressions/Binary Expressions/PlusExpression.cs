using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class PlusExpression : BinaryOperatorExpression
    {
        public PlusExpression() : this(null, null)
        {
        }

        public PlusExpression(IValueExpression leftOperand, IValueExpression rightOperand)
            : base(leftOperand, rightOperand,
                  CalculatorHelper.GetPrecedence(Operators.Plus),
                  CalculatorHelper.GetAssociativity(Operators.Plus))
        {
        }

        public override long Evaluate(CalculatorContext context)
        {
            return LeftOperand.Evaluate(context) + RightOperand.Evaluate(context);
        }
    }
}
