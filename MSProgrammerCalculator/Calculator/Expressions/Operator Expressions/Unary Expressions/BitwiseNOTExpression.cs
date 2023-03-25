using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class BitwiseNOTExpression : UnaryOperatorExpression
    {
        public BitwiseNOTExpression(IExpression operand)
            : base(CalculatorHelper.GetNumericalExpressionToken(Operators.BitwiseNOT), CalculatorHelper.CreateOperatorDescriptor(Operators.BitwiseNOT), operand)
        {
        }

        public override long EvaluateResult()
        {
            return CalculatorHelper.UnaryOperation(Operators.BitwiseNOT, Operand);
        }
    }
}
