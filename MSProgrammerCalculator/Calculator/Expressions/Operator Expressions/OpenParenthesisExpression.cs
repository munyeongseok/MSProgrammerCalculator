using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class OpenParenthesisExpression : Expression, IOperatorExpression
    {
        public OperatorDescriptor OperatorDescriptor { get; }

        public OpenParenthesisExpression()
            : base(CalculatorHelper.GetNumericalExpressionToken(Operators.OpenParenthesis))
        {
            OperatorDescriptor = CalculatorHelper.CreateOperatorDescriptor(Operators.OpenParenthesis);
        }

        public override long Evaluate()
        {
            throw new NotSupportedException();
        }
    }
}
