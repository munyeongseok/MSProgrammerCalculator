using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class DecimalSeparatorExpression : Expression, IOperator
    {
        public OperatorDescriptor OperatorDescriptor { get; }

        public DecimalSeparatorExpression()
            : base(CalculatorHelper.GetNumericalExpressionToken(Operators.DecimalSeparator))
        {
            OperatorDescriptor = CalculatorHelper.CreateOperatorDescriptor(Operators.DecimalSeparator);
        }

        public override long Evaluate()
        {
            throw new NotSupportedException();
        }
    }
}
