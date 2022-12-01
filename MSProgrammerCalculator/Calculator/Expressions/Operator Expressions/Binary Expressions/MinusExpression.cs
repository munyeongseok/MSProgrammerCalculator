using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class MinusExpression : BinaryOperatorExpression
    {
        public MinusExpression(IValueExpression leftOperand, IValueExpression rightOperand)
            : base(leftOperand, rightOperand,
                  CalculatorHelper.GetPrecedence(Operators.Minus),
                  CalculatorHelper.GetAssociativity(Operators.Minus))
        {
        }

        public override long Evaluate(CalculatorContext context)
        {
            return LeftOperand.Value - RightOperand.Value;
        }
    }
}
