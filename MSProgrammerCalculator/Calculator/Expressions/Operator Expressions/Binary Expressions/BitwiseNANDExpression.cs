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

        public BitwiseNANDExpression(IOperandExpression leftOperand, IOperandExpression rightOperand)
            : base(CalculatorHelper.GetOperatorDescriptor(Operators.BitwiseNAND), leftOperand, rightOperand)
        {
        }

        public override EvaluationResult Evaluate()
        {
            return CalculatorHelper.CreateBinaryOperationResult(Operators.BitwiseNAND, LeftOperand, RightOperand);
        }
    }
}
