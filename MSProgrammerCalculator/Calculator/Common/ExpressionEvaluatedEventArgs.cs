using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class ExpressionEvaluatedEventArgs : EventArgs
    {
        public long Result { get; }

        public string NumericalExpression { get; }

        public ExpressionEvaluatedEventArgs(long result, string numericalExpression)
        {
            Result = result;
            NumericalExpression = numericalExpression;
        }
    }
}
