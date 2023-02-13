using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class MinusExpression : BinaryOperatorExpression
    {
        public MinusExpression()
            : this(OperandExpression.Null, OperandExpression.Null)
        {
        }

        public MinusExpression(OperandExpression leftOperand, OperandExpression rightOperand)
            : base(CalculatorHelper.GetNumericalExpressionToken(Operators.Minus), CalculatorHelper.CreateOperatorDescriptor(Operators.Minus), leftOperand, rightOperand)
        {
        }

        public override long Evaluate()
        {
            return CalculatorHelper.BinaryOperation(Operators.Minus, LeftOperand, RightOperand);
        }
    }
}
