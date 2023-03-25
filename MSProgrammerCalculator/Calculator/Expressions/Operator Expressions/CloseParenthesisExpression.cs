using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class CloseParenthesisExpression : IExpression, IOperator
    {
        public OperatorDescriptor OperatorDescriptor { get; }

        public CloseParenthesisExpression()
        {
            OperatorDescriptor = CalculatorHelper.CreateOperatorDescriptor(Operators.CloseParenthesis);
        }

        public long EvaluateResult()
        {
            throw new NotSupportedException();
        }

        public string EvaluateExpression(BaseNumber _)
        {
            return CalculatorHelper.GetNumericalExpressionToken(Operators.CloseParenthesis);
        }

        public string GetToken(BaseNumber _)
        {
            return CalculatorHelper.GetNumericalExpressionToken(Operators.CloseParenthesis);
        }
    }
}
