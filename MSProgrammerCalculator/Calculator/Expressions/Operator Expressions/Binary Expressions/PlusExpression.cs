using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class PlusExpression : BinaryOperatorExpression
    {
        public PlusExpression(IExpression leftOperand, IExpression rightOperand)
            : base(CalculatorHelper.GetExpressionToken(Operators.Plus), CalculatorHelper.CreateOperatorDescriptor(Operators.Plus), leftOperand, rightOperand)
        {
        }
    }
}
