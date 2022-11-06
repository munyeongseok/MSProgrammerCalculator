using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class CalculatorContext
    {
        internal Stack<ICalculatorExpression> Expressions { get; } = new Stack<ICalculatorExpression>();

        public long Result { get; internal set; }

        public string Expression { get; internal set; }

        internal Operators CurrentOperator { get; set; }
    }
}
