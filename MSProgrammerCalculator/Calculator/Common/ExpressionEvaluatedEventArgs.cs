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

        public string Expression { get; }

        public ExpressionEvaluatedEventArgs(long result, string expression)
        {
            Result = result;
            Expression = expression;
        }
    }
}
