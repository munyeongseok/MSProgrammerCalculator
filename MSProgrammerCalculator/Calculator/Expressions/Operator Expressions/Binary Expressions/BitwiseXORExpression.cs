using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class BitwiseXORExpression : BinaryOperatorExpression
    {
        public BitwiseXORExpression() : this(null, null)
        {
        }

        public BitwiseXORExpression(IValueExpression leftOperand, IValueExpression rightOperand)
            : base(leftOperand, rightOperand,
                  CalculatorHelper.GetPrecedence(Operators.BitwiseXOR),
                  CalculatorHelper.GetAssociativity(Operators.BitwiseXOR))
        {
        }

        public override long Evaluate(CalculatorContext context)
        {
            return LeftOperand.Evaluate(context) ^ RightOperand.Evaluate(context);
        }
    }
}
