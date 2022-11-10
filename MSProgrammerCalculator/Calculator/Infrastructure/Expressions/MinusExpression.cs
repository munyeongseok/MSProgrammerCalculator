using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class MinusExpression : BinaryExpression
    {
        public MinusExpression(long operand) : base(operand)
        {
        }

        public override void Evaluate(CalculatorContext context, bool firstExpression)
        {
            context.Result = CalculationHelper.BinaryOperation(Operators.Minus, context.Result, Operand);
            context.Expression = CalculationHelper.AppendExpression(Operators.Minus, context.Expression, Operand);
        }
    }
}
