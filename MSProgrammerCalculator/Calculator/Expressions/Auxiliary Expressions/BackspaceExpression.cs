using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class BackspaceExpression : IExpression
    {
        public BackspaceExpression()
        {
        }

        public long Evaluate(CalculationContext context)
        {
            throw new NotImplementedException();
        }
    }
}
