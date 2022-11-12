using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class BitwiseNANDExpression : BinaryExpression
    {
        public BitwiseNANDExpression(long operand) : base(operand)
        {
        }

        public override void Evaluate(CalculatorContext context)
        {
            context.Result = context.Result == null ? Operand : CalculationHelper.BinaryOperation(Operators.NAND, (long)context.Result, Operand);
            context.Expression = CalculationHelper.AppendExpression(Operators.NAND, context.Expression, Operand);
        }
    }
}
