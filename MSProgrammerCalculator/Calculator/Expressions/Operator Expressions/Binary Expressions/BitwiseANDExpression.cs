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
            : base(CalculatorHelper.GetExpressionToken(Operators.BitwiseAND), CalculatorHelper.CreateOperatorDescriptor(Operators.BitwiseAND), leftOperand, rightOperand)
        {
        }
    }
}
