using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class DivideExpression : BinaryOperatorExpression
    {
        public DivideExpression(IExpression leftOperand, IExpression rightOperand)
            : base(CalculatorHelper.GetNumericalExpressionToken(Operators.Divide), CalculatorHelper.CreateOperatorDescriptor(Operators.Divide), leftOperand, rightOperand)
        {
        }
    }
}
