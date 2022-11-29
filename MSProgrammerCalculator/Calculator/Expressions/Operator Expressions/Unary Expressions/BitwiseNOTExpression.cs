using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class BitwiseNOTExpression : UnaryOperatorExpression
    {
        public BitwiseNOTExpression(IValueExpression operand)
            : base(operand, 2, Associativity.RightToLeft)
        {
        }

        public override long Evaluate(CalculatorContext context)
        {
            //context.Result = CalculatorHelper.UnaryOperation(Operators.NOT, Operand);
            //context.Expression = CalculatorHelper.AppendExpression(Operators.NOT, context.Expression == null ? Operand.ToString() : context.Expression);

            return ~Operand.Value;
        }
    }
}
