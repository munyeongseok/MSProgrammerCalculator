using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class CloseParenthesisExpression : IOperatorExpression
    {
        public OperatorDescriptor OperatorDescriptor { get; }

        public CloseParenthesisExpression()
        {
            OperatorDescriptor = CalculatorHelper.GetOperatorDescriptor(Operators.CloseParenthesis);
        }

        public EvaluationResult Evaluate()
        {
            throw new NotImplementedException();
        }
    }
}
