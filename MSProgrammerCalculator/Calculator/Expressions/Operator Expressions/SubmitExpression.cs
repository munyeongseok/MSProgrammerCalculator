using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class SubmitExpression : IExpression
    {
        public SubmitExpression()
        {
        }

        public long Evaluate()
        {
            throw new NotSupportedException();
        }

        public string GetToken(BaseNumber _)
        {
            return CalculatorHelper.GetNumericalExpressionToken(Operators.Submit);
        }
    }
}
