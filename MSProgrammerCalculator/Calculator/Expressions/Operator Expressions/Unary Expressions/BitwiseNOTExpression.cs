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

        public BitwiseNOTExpression(IOperandExpression operand)
            : base(CalculatorHelper.GetOperatorDescriptor(Operators.BitwiseNOT), operand)
        {
        }

        public override EvaluationResult Evaluate()
        {
            return CalculatorHelper.CreateUnaryOperationResult(Operators.BitwiseNOT, Operand);
        }
    }
}
