using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class BitwiseORExpression : BinaryExpression
    {
        public BitwiseORExpression(long operand) : base(operand)
        {
        }

        public override void Evaluate(CalculatorContext context)
        {
            context.Result = CalculationHelper.BinaryOperation(Operators.OR, context.Result, Operand);
            context.Expression = CalculationHelper.AppendExpression(Operators.OR, context.Expression, Operand);
        }
    }
}
