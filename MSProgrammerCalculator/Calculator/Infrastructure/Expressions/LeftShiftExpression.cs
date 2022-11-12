using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class LeftShiftExpression : BinaryExpression
    {
        public LeftShiftExpression(long operand) : base(operand)
        {
        }

        public override void Evaluate(CalculatorContext context)
        {
            context.Result = CalculationHelper.BinaryOperation(Operators.LeftShift, (long)context.Result, Operand);
            context.Expression = CalculationHelper.AppendExpression(Operators.LeftShift, context.Expression, Operand);
        }
    }
}
