using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSProgrammerCalculator.MyCalculator
{
    internal interface ICalculatorExpression
    {
        void Evaluate(CalculatorContext context);
    }
}
