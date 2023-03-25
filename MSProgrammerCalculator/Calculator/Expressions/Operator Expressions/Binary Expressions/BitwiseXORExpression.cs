using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class BitwiseXORExpression : BinaryOperatorExpression
    {
        public BitwiseXORExpression(IExpression leftOperand, IExpression rightOperand)
            : base(CalculatorHelper.GetExpressionToken(Operators.BitwiseXOR), CalculatorHelper.CreateOperatorDescriptor(Operators.BitwiseXOR), leftOperand, rightOperand)
        {
        }
    }
}
