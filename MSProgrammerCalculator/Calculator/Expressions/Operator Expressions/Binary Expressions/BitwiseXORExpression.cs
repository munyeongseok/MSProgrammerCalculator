using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class BitwiseXORExpression : BinaryOperatorExpression
    {
        public BitwiseXORExpression()
            : this(OperandExpression.Null, OperandExpression.Null)
        {
        }

        public BitwiseXORExpression(OperandExpression leftOperand, OperandExpression rightOperand)
            : base(CalculatorHelper.GetNumericalExpressionToken(Operators.BitwiseXOR), CalculatorHelper.CreateOperatorDescriptor(Operators.BitwiseXOR), leftOperand, rightOperand)
        {
        }

        public override long Evaluate()
        {
            return CalculatorHelper.BinaryOperation(Operators.BitwiseXOR, LeftOperand, RightOperand);
        }
    }
}
