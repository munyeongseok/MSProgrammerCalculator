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

        //public override long Evaluate(CalculatorContext context)
        //{
        //    context.Operand = CalculatorHelper.RemoveNumberAtRight(context.BaseNumber, context.Operand);
        //    context.OperandChanged = true;

        //    return -1;
        //}
    }
}
