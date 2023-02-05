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

        public NegateExpression(IOperandExpression operand)
            : base(CalculatorHelper.GetNumericalExpressionToken(Operators.Negate), CalculatorHelper.CreateOperatorDescriptor(Operators.Negate), operand)
        {
        }

        public override EvaluationResult Evaluate()
        {
            return CalculatorHelper.CreateUnaryOperationResult(Operators.Negate, Operand);
        }
    }
}
