using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class NegateExpression : UnaryOperatorExpression
    {
        public NegateExpression(IExpression operand)
            : base(CalculatorHelper.GetNumericalExpressionToken(Operators.Negate), CalculatorHelper.CreateOperatorDescriptor(Operators.Negate), operand)
        {
        }

        public override long EvaluateResult()
        {
            return CalculatorHelper.UnaryOperation(Operators.Negate, Operand);
        }
    }
}
