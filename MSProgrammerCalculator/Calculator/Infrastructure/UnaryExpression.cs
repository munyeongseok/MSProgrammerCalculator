using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public abstract class UnaryExpression : IExpression
    {
        public IExpression Operand { get; }

        protected UnaryExpression(IExpression operand)
        {
            Operand = operand;
        }

        public abstract long Evaluate(CalculatorContext context);
    }
}
