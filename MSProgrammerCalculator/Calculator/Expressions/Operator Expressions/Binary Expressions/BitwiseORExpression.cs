using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class BitwiseORExpression : BinaryOperatorExpression
    {
        public BitwiseORExpression()
            : this(OperandExpression.Null, OperandExpression.Null)
        {
        }

        public BitwiseORExpression(IOperandExpression leftOperand, IOperandExpression rightOperand)
            : base(CalculatorHelper.GetNumericalExpressionToken(Operators.BitwiseOR), CalculatorHelper.CreateOperatorDescriptor(Operators.BitwiseOR), leftOperand, rightOperand)
        {
        }

        public override EvaluationResult Evaluate()
        {
            return CalculatorHelper.CreateBinaryOperationResult(Operators.BitwiseOR, LeftOperand, RightOperand);
        }
    }
}
