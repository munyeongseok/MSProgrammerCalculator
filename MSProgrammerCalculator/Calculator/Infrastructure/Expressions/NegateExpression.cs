using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class NegateExpression : UnaryExpression
    {
        public NegateExpression(long operand) : base(operand)
        {
        }

        public override void Evaluate(CalculatorContext context, bool firstExpression)
        {
            context.Result = CalculationHelper.UnaryOperation(Operators.Negate, Operand);
            context.Expression = $"{context.Expression}{CalculationHelper.AppendExpression(Operators.Negate, Operand.ToString())}";
        }
    }
}
