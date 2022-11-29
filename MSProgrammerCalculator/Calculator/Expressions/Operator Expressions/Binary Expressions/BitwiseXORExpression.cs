using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class BitwiseXORExpression : BinaryOperatorExpression
    {
        public BitwiseXORExpression(IValueExpression leftOperand, IValueExpression rightOperand)
            : base(leftOperand, rightOperand, 9, Associativity.LeftToRight)
        {
        }

        public override long Evaluate(CalculatorContext context)
        {
            //context.Result = context.Expression == null ? Operand : CalculatorHelper.BinaryOperation(Operators.XOR, context.Result, Operand);
            //context.Expression = CalculatorHelper.AppendExpression(Operators.XOR, context.Expression, Operand);

            return LeftOperand.Value ^ RightOperand.Value;
        }
    }
}
