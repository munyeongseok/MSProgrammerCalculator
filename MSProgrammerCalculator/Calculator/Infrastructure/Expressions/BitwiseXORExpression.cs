using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class BitwiseXORExpression : BinaryExpression
    {
        public BitwiseXORExpression(long operand) : base(operand)
        {
        }

        public override void Evaluate(CalculatorContext context)
        {
            context.Result = CalculationHelper.BinaryOperation(Operators.XOR, (long)context.Result, Operand);
            context.Expression = CalculationHelper.AppendExpression(Operators.XOR, context.Expression, Operand);
        }
    }
}
