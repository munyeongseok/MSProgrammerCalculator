using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class RightShiftExpression : BinaryOperatorExpression
    {
        public RightShiftExpression(IExpression leftOperand, IExpression rightOperand)
            : base(CalculatorHelper.GetNumericalExpressionToken(Operators.RightShift), CalculatorHelper.CreateOperatorDescriptor(Operators.RightShift), leftOperand, rightOperand)
        {
        }
    }
}
