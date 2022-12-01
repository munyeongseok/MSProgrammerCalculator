using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class DivideExpression : BinaryOperatorExpression
    {
        public DivideExpression(IValueExpression leftOperand, IValueExpression rightOperand)
            : base(leftOperand, rightOperand,
                  CalculatorHelper.GetPrecedence(Operators.Divide),
                  CalculatorHelper.GetAssociativity(Operators.Divide))
        {
        }

        public override long Evaluate(CalculatorContext context)
        {
            return LeftOperand.Value / RightOperand.Value;
        }
    }
}
