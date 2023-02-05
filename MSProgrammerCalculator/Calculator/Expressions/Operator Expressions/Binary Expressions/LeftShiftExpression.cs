using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class LeftShiftExpression : BinaryOperatorExpression
    {
        public LeftShiftExpression()
            : this(OperandExpression.Null, OperandExpression.Null)
        {
        }

        public LeftShiftExpression(IOperandExpression leftOperand, IOperandExpression rightOperand)
            : base(CalculatorHelper.GetNumericalExpressionToken(Operators.LeftShift), CalculatorHelper.CreateOperatorDescriptor(Operators.LeftShift), leftOperand, rightOperand)
        {
        }

        public override EvaluationResult Evaluate()
        {
            return CalculatorHelper.CreateBinaryOperationResult(Operators.LeftShift, LeftOperand, RightOperand);
        }
    }
}
