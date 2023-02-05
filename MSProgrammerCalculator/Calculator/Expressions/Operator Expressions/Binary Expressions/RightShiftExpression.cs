using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class RightShiftExpression : BinaryOperatorExpression
    {
        public RightShiftExpression()
            : this(OperandExpression.Null, OperandExpression.Null)
        {
        }

        public RightShiftExpression(IOperandExpression leftOperand, IOperandExpression rightOperand)
            : base(CalculatorHelper.GetNumericalExpressionToken(Operators.RightShift), CalculatorHelper.CreateOperatorDescriptor(Operators.RightShift), leftOperand, rightOperand)
        {
        }

        public override EvaluationResult Evaluate()
        {
            return CalculatorHelper.CreateBinaryOperationResult(Operators.RightShift, LeftOperand, RightOperand);
        }
    }
}
