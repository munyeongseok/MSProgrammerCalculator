using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class BitwiseANDExpression : BinaryOperatorExpression
    {
        public BitwiseANDExpression() : this(new OperandExpression(3), null)
        {
        }

        public BitwiseANDExpression(OperandExpression leftOperand, OperandExpression rightOperand)
            : base(CalculatorHelper.GetNumericalExpressionToken(Operators.BitwiseAND), CalculatorHelper.CreateOperatorDescriptor(Operators.BitwiseAND), leftOperand, rightOperand)
        {
        }

        public override long Evaluate()
        {
            return CalculatorHelper.BinaryOperation(Operators.BitwiseAND, LeftOperand, RightOperand);
        }
    }
}
