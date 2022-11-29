using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class BitwiseORExpression : BinaryOperatorExpression
    {
        public BitwiseORExpression(IValueExpression leftOperand, IValueExpression rightOperand)
            : base(leftOperand, rightOperand, 10, Associativity.LeftToRight)
        {
        }

        public override long Evaluate(CalculatorContext context)
        {
            //.Result = context.Expression == null ? Operand : CalculatorHelper.BinaryOperation(Operators.OR, context.Result, Operand);
            //context.Expression = CalculatorHelper.AppendExpression(Operators.OR, context.Expression, Operand);

            return LeftOperand.Value | RightOperand.Value;
        }
    }
}
