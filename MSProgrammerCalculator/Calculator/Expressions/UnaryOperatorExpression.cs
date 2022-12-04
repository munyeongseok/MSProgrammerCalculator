using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public abstract class UnaryOperatorExpression : IUnaryOperatorExpression
    {
        public IExpression Operand { get; set; }

        public int Precedence { get; }

        public Associativity Associativity { get; }

        protected UnaryOperatorExpression(IExpression operand, int precedence, Associativity associativity)
        {
            Operand = operand;
            Precedence = precedence;
            Associativity = associativity;
        }

        public abstract long Evaluate(CalculatorContext context);
    }
}
