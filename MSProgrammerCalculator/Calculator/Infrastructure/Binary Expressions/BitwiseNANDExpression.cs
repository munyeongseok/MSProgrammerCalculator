using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class BitwiseNANDExpression : BinaryExpression
    {
        public BitwiseNANDExpression(IExpression leftOperand, IExpression rightOperand)
            : base(leftOperand, rightOperand)
        {
        }

        public override long Evaluate(CalculatorContext context)
        {
            //context.Result = context.Expression == null ? Operand : CalculatorHelper.BinaryOperation(Operators.NAND, context.Result, Operand);
            //context.Expression = CalculatorHelper.AppendExpression(Operators.NAND, context.Expression, Operand);

            return ~(LeftOperand.Evaluate(context) & RightOperand.Evaluate(context));
        }
    }
}
