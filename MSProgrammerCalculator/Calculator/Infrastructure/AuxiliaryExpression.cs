using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public abstract class AuxiliaryExpression : ICalculatorExpression
    {
        public abstract void Evaluate(CalculatorContext context);
    }
}
