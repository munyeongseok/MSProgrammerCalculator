using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class MultiplyExpression : BinaryOperatorExpression
    {
        public MultiplyExpression(IExpression leftOperand, IExpression rightOperand)
            : base(CalculatorHelper.GetExpressionToken(Operators.Multiply), CalculatorHelper.CreateOperatorDescriptor(Operators.Multiply), leftOperand, rightOperand)
        {
        }
    }
}