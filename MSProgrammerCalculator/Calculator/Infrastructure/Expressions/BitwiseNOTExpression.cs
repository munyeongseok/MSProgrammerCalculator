using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class BitwiseNOTExpression : UnaryExpression
    {
        public BitwiseNOTExpression()
        {
        }

        public override void Evaluate(CalculatorContext context)
        {
            context.Result = CalculationHelper.UnaryOperation(Operators.NOT, context.Result);
            context.Expression = CalculationHelper.AppendExpression(Operators.NOT, context.Expression);
        }
    }
}
