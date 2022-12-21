using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class BitwiseNORExpression : BinaryOperatorExpression
    {
        public BitwiseNORExpression() : this(null, null)
        {
        }

        public BitwiseNORExpression(IOperandExpression leftOperand, IOperandExpression rightOperand)
            : base(leftOperand, rightOperand,
                  CalculatorHelper.GetPrecedence(Operators.BitwiseNOR),
                  CalculatorHelper.GetAssociativity(Operators.BitwiseNOR))
        {
        }

        public override long Evaluate(CalculationContext context)
        {
            return ~(LeftOperand.Evaluate(context) | RightOperand.Evaluate(context));
        }
    }
}
