using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class RightShiftExpression : BinaryExpression
    {
        public RightShiftExpression(long operand) : base(operand)
        {
        }

        public override void Evaluate(CalculatorContext context)
        {
            context.Result = CalculationHelper.BinaryOperation(Operators.RightShift, (long)context.Result, Operand);
            context.Expression = CalculationHelper.AppendExpression(Operators.RightShift, context.Expression, Operand);
        }
    }
}
