using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class RightShiftExpression : BinaryExpression
    {
        public RightShiftExpression(IExpression leftOperand, IExpression rightOperand)
            : base(leftOperand, rightOperand)
        {
        }

        public override long Evaluate(CalculatorContext context)
        {
            //context.Result = context.Expression == null ? Operand : CalculatorHelper.BinaryOperation(Operators.RightShift, context.Result, Operand);
            //context.Expression = CalculatorHelper.AppendExpression(Operators.RightShift, context.Expression, Operand);

            return LeftOperand.Evaluate(context) >> (int)RightOperand.Evaluate(context);
        }
    }
}
