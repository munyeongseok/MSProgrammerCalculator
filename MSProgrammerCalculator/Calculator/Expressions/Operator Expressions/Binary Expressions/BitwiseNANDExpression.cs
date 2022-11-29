using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class BitwiseNANDExpression : BinaryOperatorExpression
    {
        public BitwiseNANDExpression(IValueExpression leftOperand, IValueExpression rightOperand)
            : base(leftOperand, rightOperand, 2, Associativity.RightToLeft)
        {
        }

        public override long Evaluate(CalculatorContext context)
        {
            //context.Result = context.Expression == null ? Operand : CalculatorHelper.BinaryOperation(Operators.NAND, context.Result, Operand);
            //context.Expression = CalculatorHelper.AppendExpression(Operators.NAND, context.Expression, Operand);

            return ~(LeftOperand.Value & RightOperand.Value);
        }
    }
}
