using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class SubmitExpression : AuxiliaryExpression
    {
        public SubmitExpression()
        {
        }

        public override long Evaluate(CalculatorContext context)
        {
            return -1;
        }
    }
}
