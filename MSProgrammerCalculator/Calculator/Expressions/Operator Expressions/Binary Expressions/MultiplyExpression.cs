using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class MultiplyExpression : BinaryOperatorExpression
    {
        public MultiplyExpression()
            : this(OperandExpression.Null, OperandExpression.Null)
        {
        }

        public MultiplyExpression(IOperandExpression leftOperand, IOperandExpression rightOperand)
            : base(CalculatorHelper.GetNumericalExpressionToken(Operators.Multiply), CalculatorHelper.CreateOperatorDescriptor(Operators.Multiply), leftOperand, rightOperand)
        {
        }

        public override long Evaluate()
        {
            return CalculatorHelper.BinaryOperation(Operators.Multiply, LeftOperand, RightOperand);
        }
    }
}