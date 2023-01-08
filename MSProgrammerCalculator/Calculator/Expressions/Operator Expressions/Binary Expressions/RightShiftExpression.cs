using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class RightShiftExpression : BinaryOperatorExpression
    {
        public RightShiftExpression() : this(null, null)
        {
        }

        public RightShiftExpression(IOperandExpression leftOperand, IOperandExpression rightOperand)
            : base(leftOperand, rightOperand,
                  CalculatorHelper.GetPrecedence(Operators.RightShift),
                  CalculatorHelper.GetAssociativity(Operators.RightShift))
        {
        }

        public override EvaluationResult Evaluate()
        {
            var leftResult = LeftOperand.Evaluate();
            var rightResult = RightOperand.Evaluate();
            return new EvaluationResult(leftResult.Result >> (int)rightResult.Result, string.Empty);
        }
    }
}
