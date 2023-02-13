using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class BitwiseNANDExpression : BinaryOperatorExpression
    {
        public BitwiseNANDExpression()
            : this(OperandExpression.Null, OperandExpression.Null)
        {
        }

        public BitwiseNANDExpression(OperandExpression leftOperand, OperandExpression rightOperand)
            : base(CalculatorHelper.GetNumericalExpressionToken(Operators.BitwiseNAND), CalculatorHelper.CreateOperatorDescriptor(Operators.BitwiseNAND), leftOperand, rightOperand)
        {
        }

        public override long Evaluate()
        {
            return CalculatorHelper.BinaryOperation(Operators.BitwiseNAND, LeftOperand, RightOperand);
        }
    }
}
