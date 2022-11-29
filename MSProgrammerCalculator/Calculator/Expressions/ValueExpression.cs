using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class ValueExpression : IValueExpression
    {
        public long Value { get; }

        public ValueExpression(long value)
        {
            Value = value;
        }
    }
}
