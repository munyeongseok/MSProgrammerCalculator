using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class BitwiseNORExpression : BinaryOperatorExpression
    {
        public BitwiseNORExpression(IExpression leftOperand, IExpression rightOperand)
            : base(CalculatorHelper.GetNumericalExpressionToken(Operators.BitwiseNOR), CalculatorHelper.CreateOperatorDescriptor(Operators.BitwiseNOR), leftOperand, rightOperand)
        {
        }

        public override long EvaluateResult()
        {
            return CalculatorHelper.BinaryOperation(Operators.BitwiseNOR, LeftOperand, RightOperand);
        }
    }
}
