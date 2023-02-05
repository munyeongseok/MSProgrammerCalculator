using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class EvaluationResult
    {
        public long Result { get; }

        public string NumericalExpression { get; }

        public EvaluationResult(long result, string numericalExpression)
        {
            Result = result;
            NumericalExpression = numericalExpression;
        }
    }
}
