using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class NegateExpression : UnaryExpression
    {
        public NegateExpression(IExpression operand)
            : base(operand)
        {
        }

        public override long Evaluate(CalculatorContext context)
        {
            //context.Result = CalculatorHelper.UnaryOperation(Operators.Negate, Operand);
            //context.Expression = "";
            //// 소괄호 추가 후 확인
            ////context.Expression = CalculatorHelper.AppendExpression(Operators.Negate, context.Expression == null ? Operand.ToString() : context.Expression);
            
            return -Operand.Evaluate(context);
        }
    }
}
