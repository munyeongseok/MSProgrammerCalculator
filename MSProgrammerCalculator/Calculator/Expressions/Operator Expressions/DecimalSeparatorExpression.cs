using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class DecimalSeparatorExpression : IOperatorExpression
    {
        public OperatorDescriptor OperatorDescriptor { get; }

        public DecimalSeparatorExpression()
        {
            OperatorDescriptor = CalculatorHelper.GetOperatorDescriptor(Operators.DecimalSeparator);
        }

        public EvaluationResult Evaluate()
        {
            throw new NotImplementedException();
        }
    }
}
