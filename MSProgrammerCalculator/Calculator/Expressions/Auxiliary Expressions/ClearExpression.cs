using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class ClearExpression : IExpression
    {
        public ClearExpression()
        {
        }

        //public override long Evaluate(CalculatorContext context)
        //{
        //    if (context.Operand != 0)
        //    {
        //        context.Operand = 0;
        //        context.OperandChanged = false;
        //        context.Result = 0;
        //    }
        //    else
        //    {
        //        context.Expression = "";
        //    }

        //    return -1;
        //}
    }
}
