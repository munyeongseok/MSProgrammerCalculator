using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class BitwiseNORExpression : BinaryOperatorExpression
    {
        public BitwiseNORExpression(IValueExpression leftOperand, IValueExpression rightOperand)
            : base(leftOperand, rightOperand, 10, Associativity.LeftToRight)
        {
        }

        public override long Evaluate(CalculatorContext context)
        {
            //context.Result = context.Expression == null ? Operand : CalculatorHelper.BinaryOperation(Operators.NOR, context.Result, Operand);
            //context.Expression = CalculatorHelper.AppendExpression(Operators.NOR, context.Expression, Operand);

            return ~(LeftOperand.Value | RightOperand.Value);
        }
    }
}
