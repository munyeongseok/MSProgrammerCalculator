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
            var leftResult = LeftOperand.Evaluate();
            var rightResult = RightOperand.Evaluate();
            return new EvaluationResult(leftResult.Result + rightResult.Result, string.Empty);
        }
    }
}
