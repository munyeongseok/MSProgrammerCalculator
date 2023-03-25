using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class BitwiseORExpression : BinaryOperatorExpression
    {
        public BitwiseORExpression(IExpression leftOperand, IExpression rightOperand)
            : base(CalculatorHelper.GetExpressionToken(Operators.BitwiseOR), CalculatorHelper.CreateOperatorDescriptor(Operators.BitwiseOR), leftOperand, rightOperand)
        {
        }
    }
}
