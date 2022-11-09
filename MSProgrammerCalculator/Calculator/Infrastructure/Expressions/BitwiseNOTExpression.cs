using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class BitwiseNOTExpression : UnaryExpression
    {
        public BitwiseNOTExpression(long operand) : base(operand)
        {
        }

        public override void Evaluate(CalculatorContext context)
        {
            context.Result = CalculationHelper.UnaryOperation(Operators.NOT, Operand);
            context.Expression = $"{context.Expression}{CalculationHelper.AppendExpression(Operators.NOT, Operand.ToString())}";
        }
    }
}
