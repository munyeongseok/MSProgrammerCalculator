using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class BitwiseNOTExpression : UnaryOperatorExpression
    {
        public BitwiseNOTExpression()
            : this(OperandExpression.Null)
        {
        }

        public BitwiseNOTExpression(OperandExpression operand)
            : base(CalculatorHelper.GetNumericalExpressionToken(Operators.BitwiseNOT), CalculatorHelper.CreateOperatorDescriptor(Operators.BitwiseNOT), operand)
        {
        }

        public override long Evaluate()
        {
            return CalculatorHelper.UnaryOperation(Operators.BitwiseNOT, Operand);
        }
    }
}
