using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class NegateExpression : UnaryExpression
    {
        public NegateExpression()
        {
        }

        public override void Evaluate(CalculatorContext context)
        {
            context.Result = CalculationHelper.UnaryOperation(Operators.Negate, context.Result);
            context.Expression = CalculationHelper.AppendExpression(Operators.Negate, context.Expression);
        }
    }
}
