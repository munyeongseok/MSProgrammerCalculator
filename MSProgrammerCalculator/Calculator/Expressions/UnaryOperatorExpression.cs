using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public abstract class UnaryOperatorExpression : IUnaryOperatorExpression
    {
        public IValueExpression Operand { get; }

        public int Precedence { get; }

        public Associativity Associativity { get; }

        protected UnaryOperatorExpression(IValueExpression operand, int precedence, Associativity associativity)
        {
            Operand = operand;
            Precedence = precedence;
            Associativity = associativity;
        }

        public abstract long Evaluate(CalculatorContext context);
    }
}
