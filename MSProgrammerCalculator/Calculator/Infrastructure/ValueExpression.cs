using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class ValueExpression : IExpression
    {
        public long Value { get; }

        public ValueExpression(long operand)
        {
            Value = operand;
        }

        public long Evaluate(CalculatorContext context)
        {
            return Value;
        }
    }
}
