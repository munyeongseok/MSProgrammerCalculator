using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class MinusExpression : BinaryOperatorExpression
    {
        public MinusExpression() : this(null, null)
        {
        }

        public MinusExpression(IOperandExpression leftOperand, IOperandExpression rightOperand)
            : base(leftOperand, rightOperand,
                  CalculatorHelper.GetPrecedence(Operators.Minus),
                  CalculatorHelper.GetAssociativity(Operators.Minus))
        {
        }

        public override long Evaluate(CalculationContext context)
        {
            return LeftOperand.Evaluate(context) - RightOperand.Evaluate(context);
        }
    }
}
