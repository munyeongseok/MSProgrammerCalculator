using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public abstract class Expression : IExpression
    {
        public string NumericalExpressionToken { get; }

        protected Expression(string numericalExpressionToken)
        {
            NumericalExpressionToken = numericalExpressionToken;
        }

        public abstract long Evaluate();
    }
}
