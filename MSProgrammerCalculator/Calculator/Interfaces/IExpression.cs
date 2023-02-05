using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public interface IExpression
    {
        string NumericalExpressionToken { get; }

        EvaluationResult Evaluate();
    }
}
