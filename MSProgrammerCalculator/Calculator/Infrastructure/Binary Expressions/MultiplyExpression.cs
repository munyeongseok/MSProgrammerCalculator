using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class MultiplyExpression : BinaryExpression
    {
        public MultiplyExpression(IExpression leftOperand, IExpression rightOperand)
            : base(leftOperand, rightOperand)
        {
        }

        public override long Evaluate(CalculatorContext context)
        {
            //context.Result = context.Expression == null ? Operand : CalculatorHelper.BinaryOperation(Operators.Multiply, context.Result, Operand);
            //context.Expression = CalculatorHelper.AppendExpression(Operators.Multiply, context.Expression, Operand);

            return LeftOperand.Evaluate(context) * RightOperand.Evaluate(context);
        }
    }
}
