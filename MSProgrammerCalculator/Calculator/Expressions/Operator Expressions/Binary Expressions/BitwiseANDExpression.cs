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

        public BitwiseANDExpression(IOperandExpression leftOperand, IOperandExpression rightOperand)
            : base(CalculatorHelper.GetOperatorDescriptor(Operators.BitwiseAND), leftOperand, rightOperand)
        {
        }

        public override EvaluationResult Evaluate()
        {
            return CalculatorHelper.CreateBinaryOperationResult(Operators.BitwiseAND, LeftOperand, RightOperand);
        }
    }
}
