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

        public long EvaluateResult()
        {
            throw new NotSupportedException();
        }

        public string EvaluateExpression(BaseNumber _)
        {
            return CalculatorHelper.GetExpressionToken(Operators.Submit);
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
