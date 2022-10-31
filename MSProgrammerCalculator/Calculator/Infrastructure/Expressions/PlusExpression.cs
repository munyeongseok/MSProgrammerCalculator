using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class PlusExpression : BinaryExpression
    {
        public PlusExpression(long operand) : base(operand)
        {
        }

        public override void Evaluate(CalculatorContext context)
        {
            context.Result = CalculationHelper.BinaryOperation(Operators.Plus, context.Result, Operand);
            context.Expression = context.Expression == null ?
                CalculationHelper.AppendExpression(Operators.Plus, context.Result.ToString()) :
                CalculationHelper.AppendExpression(Operators.Plus, context.Expression);

            // 여기 부분 연산자 붙는 거 어떻게 할지 생각해보기
            // 테스트 코드는 CalculatorViewModel 생성자에 있음
        }
    }
}
