using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class ParenthesisExpression : AuxiliaryExpression
    {
        public Stack<IExpression> Expressions { get; }

        public ParenthesisExpression()
        {
            Expressions = new Stack<IExpression>();
        }

        public void PushExpression(IExpression expression)
        {
            Expressions.Push(expression);
        }

        public override long Evaluate(CalculatorContext context)
        {
            return -1;
        }
    }
}
