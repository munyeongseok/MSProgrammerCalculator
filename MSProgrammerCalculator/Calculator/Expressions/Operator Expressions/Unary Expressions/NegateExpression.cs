using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class NegateExpression : UnaryOperatorExpression
    {
        public NegateExpression()
            : this(OperandExpression.Null)
        {
        }

        public NegateExpression(OperandExpression operand)
            : base(CalculatorHelper.GetNumericalExpressionToken(Operators.Negate), CalculatorHelper.CreateOperatorDescriptor(Operators.Negate), operand)
        {
        }

        public override long Evaluate()
        {
            return CalculatorHelper.UnaryOperation(Operators.Negate, Operand);
        }
    }
}
