using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class NegateExpression : UnaryExpression
    {
        public NegateExpression(long operand, bool isNewOperand) : base(operand, isNewOperand)
        {
        }

        public override void Evaluate(CalculatorContext context)
        {
            context.Result = CalculationHelper.UnaryOperation(Operators.Negate, Operand);
            context.Expression = "";
            // 소괄호 추가 후 확인
            //context.Expression = CalculationHelper.AppendExpression(Operators.Negate, IsNewOperand ? Operand.ToString() : context.Expression);
        }
    }
}
