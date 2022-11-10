using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public abstract class UnaryExpression : ICalculatorExpression
    {
        public long Operand { get; }

        protected UnaryExpression(long operand)
        {
            Operand = operand;
        }

        public abstract void Evaluate(CalculatorContext context, bool firstExpression);
    }
}
