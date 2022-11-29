using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class RightShiftExpression : BinaryOperatorExpression
    {
        public RightShiftExpression(IValueExpression leftOperand, IValueExpression rightOperand)
            : base(leftOperand, rightOperand, 5, Associativity.LeftToRight)
        {
        }

        public override long Evaluate(CalculatorContext context)
        {
            //context.Result = context.Expression == null ? Operand : CalculatorHelper.BinaryOperation(Operators.RightShift, context.Result, Operand);
            //context.Expression = CalculatorHelper.AppendExpression(Operators.RightShift, context.Expression, Operand);

            return LeftOperand.Value >> (int)RightOperand.Value;
        }
    }
}
