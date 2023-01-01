using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class BitwiseNOTExpression : UnaryOperatorExpression
    {
        public BitwiseNOTExpression() : this(null)
        {
        }

        public BitwiseNOTExpression(IOperandExpression operand)
            : base(operand,
                  CalculatorHelper.GetPrecedence(Operators.BitwiseNOT),
                  CalculatorHelper.GetAssociativity(Operators.BitwiseNOT))
        {
        }

        public override long Evaluate(CalculationContext context)
        {
            var operand = Operand.Evaluate(context);
            var newOperand = ~operand;
            context.Operand = newOperand;
            context.Expression = CalculatorHelper.AppendUnaryExpression(Operators.BitwiseNOT, context.Expression, operand);

            return newOperand;
        }
    }
}
