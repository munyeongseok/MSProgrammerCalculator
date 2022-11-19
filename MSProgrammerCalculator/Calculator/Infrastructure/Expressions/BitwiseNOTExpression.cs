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
            context.Result = CalculatorHelper.UnaryOperation(Operators.NOT, Operand);
            context.Expression = CalculatorHelper.AppendExpression(Operators.NOT, context.Expression == null ? Operand.ToString() : context.Expression);
        }
    }
}
