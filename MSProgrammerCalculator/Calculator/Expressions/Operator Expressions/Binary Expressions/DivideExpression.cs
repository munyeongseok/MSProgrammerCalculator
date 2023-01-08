using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class DivideExpression : BinaryOperatorExpression
    {
        public DivideExpression() : this(null, null)
        {
        }

        public DivideExpression(IOperandExpression leftOperand, IOperandExpression rightOperand)
            : base(leftOperand, rightOperand,
                  CalculatorHelper.GetPrecedence(Operators.Divide),
                  CalculatorHelper.GetAssociativity(Operators.Divide))
        {
        }

        public override EvaluationResult Evaluate()
        {
            var leftResult = LeftOperand.Evaluate();
            var rightResult = RightOperand.Evaluate();
            return new EvaluationResult(leftResult.Result / rightResult.Result, string.Empty);
        }
    }
}
