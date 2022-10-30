using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSProgrammerCalculator.MyCalculator
{
    public abstract class UnaryExpression : ICalculatorExpression
    {
        protected UnaryExpression()
        {
        }

        public abstract void Evaluate(CalculatorContext context);
    }
}
