using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class MultiplyExpression : BinaryExpression
    {
        public MultiplyExpression(long operand) : base(operand)
        {
        }

        public override void Evaluate(CalculatorContext context)
        {
            context.Result = CalculationHelper.BinaryOperation(Operators.Multiply, context.Result, Operand);
            context.Expression = CalculationHelper.AppendExpression(Operators.Multiply, context.Expression, Operand);
        }
    }
}
