using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public abstract class BinaryOperatorExpression : IBinaryOperatorExpression
    {
        public IExpression LeftOperand { get; set; }

        public IExpression RightOperand { get; set; }

        public int Precedence { get; }

        public Associativity Associativity { get; }

        protected BinaryOperatorExpression(IExpression leftOperand, IExpression rightOperand, int precedence, Associativity associativity)
        {
            LeftOperand = leftOperand;
            RightOperand = rightOperand;
            Precedence = precedence;
            Associativity = associativity;
        }

        public abstract EvaluationResult Evaluate();
    }
}
