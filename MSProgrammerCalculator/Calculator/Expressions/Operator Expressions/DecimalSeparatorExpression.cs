using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class DecimalSeparatorExpression : IOperatorExpression
    {
        public int Precedence { get; }

        public Associativity Associativity { get; }

        public DecimalSeparatorExpression()
        {
            Precedence = CalculatorHelper.GetPrecedence(Operators.DecimalSeparator);
            Associativity = CalculatorHelper.GetAssociativity(Operators.DecimalSeparator);
        }

        public EvaluationResult Evaluate()
        {
            throw new NotImplementedException();
        }
    }
}
