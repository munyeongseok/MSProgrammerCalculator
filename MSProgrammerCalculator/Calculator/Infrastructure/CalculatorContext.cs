using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class CalculatorContext
    {
        public Stack<ICalculatorExpression> Expressions { get; } = new Stack<ICalculatorExpression>();

        public double LeftOperand { get; set; }
    }
}
