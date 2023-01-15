using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class OpenParenthesisExpression : IOperatorExpression
    {
        public OperatorDescriptor OperatorDescriptor { get; }

        public OpenParenthesisExpression()
        {
            OperatorDescriptor = CalculatorHelper.GetOperatorDescriptor(Operators.OpenParenthesis);
        }

        public EvaluationResult Evaluate()
        {
            throw new NotImplementedException();
        }
    }
}
