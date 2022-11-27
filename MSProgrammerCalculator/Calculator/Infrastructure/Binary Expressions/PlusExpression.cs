using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class PlusExpression : BinaryExpression
    {
        public PlusExpression(IExpression leftOperand, IExpression rightOperand)
            : base(leftOperand, rightOperand)
        {
        }

        public override long Evaluate(CalculatorContext context)
        {
            //context.Result = context.Expression == null ? Operand : CalculatorHelper.BinaryOperation(Operators.Plus, context.Result, Operand);
            //context.Expression = CalculatorHelper.AppendExpression(Operators.Plus, context.Expression, Operand);

            return LeftOperand.Evaluate(context) + RightOperand.Evaluate(context);
        }
    }
}
