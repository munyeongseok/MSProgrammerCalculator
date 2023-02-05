using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class CloseParenthesisExpression : Expression, IOperatorExpression
    {
        public OperatorDescriptor OperatorDescriptor { get; }

        public CloseParenthesisExpression()
            : base(")")
        {
            OperatorDescriptor = CalculatorHelper.CreateOperatorDescriptor(Operators.CloseParenthesis);
        }

        public override EvaluationResult Evaluate()
        {
            throw new NotSupportedException();
        }
    }
}
