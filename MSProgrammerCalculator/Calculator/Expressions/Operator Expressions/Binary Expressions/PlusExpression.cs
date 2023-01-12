using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class PlusExpression : BinaryOperatorExpression
    {
        public PlusExpression() : this(null, null)
        {
        }

        public PlusExpression(IOperandExpression leftOperand, IOperandExpression rightOperand)
            : base(leftOperand, rightOperand,
                  CalculatorHelper.GetPrecedence(Operators.Plus),
                  CalculatorHelper.GetAssociativity(Operators.Plus))
        {
        }

        public override EvaluationResult Evaluate()
        {
            return CalculatorHelper.CreateBinaryOperationResult(Operators.Plus, LeftOperand, RightOperand);
        }
    }
}
