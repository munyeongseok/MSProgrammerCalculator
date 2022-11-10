using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public abstract class BinaryExpression : ICalculatorExpression
    {
        public long Operand { get; }

        protected BinaryExpression(long operand)
        {
            Operand = operand;
        }

        public abstract void Evaluate(CalculatorContext context, bool firstExpression);
    }
}
