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
            : base(leftOperand, rightOperand, 4, Associativity.LeftToRight)
        {
        }

        public override long Evaluate(CalculatorContext context)
        {
            //context.Result = context.Expression == null ? Operand : CalculatorHelper.BinaryOperation(Operators.Minus, context.Result, Operand);
            //context.Expression = CalculatorHelper.AppendExpression(Operators.Minus, context.Expression, Operand);

            return LeftOperand.Value - RightOperand.Value;
        }
    }
}
