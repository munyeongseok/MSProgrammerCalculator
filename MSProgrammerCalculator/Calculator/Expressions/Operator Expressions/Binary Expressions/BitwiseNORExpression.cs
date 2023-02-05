using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class BitwiseNORExpression : BinaryOperatorExpression
    {
        public BitwiseNORExpression()
            : this(OperandExpression.Null, OperandExpression.Null)
        {
        }

        public BitwiseNORExpression(IOperandExpression leftOperand, IOperandExpression rightOperand)
            : base(CalculatorHelper.GetNumericalExpressionToken(Operators.BitwiseNOR), CalculatorHelper.CreateOperatorDescriptor(Operators.BitwiseNOR), leftOperand, rightOperand)
        {
        }

        public override EvaluationResult Evaluate()
        {
            return CalculatorHelper.CreateBinaryOperationResult(Operators.BitwiseNOR, LeftOperand, RightOperand);
        }
    }
}
