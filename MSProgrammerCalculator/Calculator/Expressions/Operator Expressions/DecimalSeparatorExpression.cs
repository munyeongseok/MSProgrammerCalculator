using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class DecimalSeparatorExpression : Expression, IOperatorExpression
    {
        public OperatorDescriptor OperatorDescriptor { get; }

        public DecimalSeparatorExpression()
            : base(".")
        {
            OperatorDescriptor = CalculatorHelper.CreateOperatorDescriptor(Operators.DecimalSeparator);
        }

        public override EvaluationResult Evaluate()
        {
            throw new NotSupportedException();
        }
    }
}
