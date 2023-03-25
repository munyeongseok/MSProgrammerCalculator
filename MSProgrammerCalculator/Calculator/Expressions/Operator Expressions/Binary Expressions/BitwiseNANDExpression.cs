using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class BitwiseNANDExpression : BinaryOperatorExpression
    {
        public BitwiseNANDExpression(IExpression leftOperand, IExpression rightOperand)
            : base(CalculatorHelper.GetExpressionToken(Operators.BitwiseNAND), CalculatorHelper.CreateOperatorDescriptor(Operators.BitwiseNAND), leftOperand, rightOperand)
        {
        }
    }
}
