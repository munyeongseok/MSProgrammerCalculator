using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class DecimalSeparatorExpression : IExpression, IOperator
    {
        public OperatorDescriptor OperatorDescriptor { get; }

        public DecimalSeparatorExpression()
        {
            OperatorDescriptor = CalculatorHelper.CreateOperatorDescriptor(Operators.DecimalSeparator);
        }

        public long EvaluateResult()
        {
            throw new NotSupportedException();
        }

        public string EvaluateExpression(BaseNumber _)
        {
            return CalculatorHelper.GetNumericalExpressionToken(Operators.DecimalSeparator);
        }

        public string GetToken(BaseNumber _)
        {
            return CalculatorHelper.GetNumericalExpressionToken(Operators.DecimalSeparator);
        }
    }
}
