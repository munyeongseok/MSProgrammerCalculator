using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class BitwiseANDExpression : BinaryOperatorExpression
    {
        public BitwiseANDExpression(IExpression leftOperand, IExpression rightOperand)
            : base(CalculatorHelper.GetNumericalExpressionToken(Operators.BitwiseAND), CalculatorHelper.CreateOperatorDescriptor(Operators.BitwiseAND), leftOperand, rightOperand)
        {
        }

        public override long EvaluateResult()
        {
            return CalculatorHelper.BinaryOperation(Operators.BitwiseAND, LeftOperand, RightOperand);
        }
    }
}
