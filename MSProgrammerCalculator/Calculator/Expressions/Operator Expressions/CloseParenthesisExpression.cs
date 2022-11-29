using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class CloseParenthesisExpression : IOperatorExpression
    {
        public int Precedence { get; }

        public Associativity Associativity { get; }

        public CloseParenthesisExpression()
        {
            Precedence = 1;
            Associativity = Associativity.LeftToRight;
        }

        public long Evaluate(CalculatorContext context)
        {
            throw new NotImplementedException();
        }
    }
}
