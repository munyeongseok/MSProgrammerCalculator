using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public abstract class BinaryOperatorExpression : IBinaryOperatorExpression
    {
        public IValueExpression LeftOperand { get; }

        public IValueExpression RightOperand { get; }

        public int Precedence { get; }

        public Associativity Associativity { get; }

        protected BinaryOperatorExpression(IValueExpression leftOperand, IValueExpression rightOperand, int precedence, Associativity associativity)
        {
            LeftOperand = leftOperand;
            RightOperand = rightOperand;
            Precedence = precedence;
            Associativity = associativity;
        }

        public abstract long Evaluate(CalculatorContext context);
    }
}
