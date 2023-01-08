using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class MinusExpression : BinaryOperatorExpression
    {
        public MinusExpression() : this(null, null)
        {
        }

        public MinusExpression(IOperandExpression leftOperand, IOperandExpression rightOperand)
            : base(leftOperand, rightOperand,
                  CalculatorHelper.GetPrecedence(Operators.Minus),
                  CalculatorHelper.GetAssociativity(Operators.Minus))
        {
        }

        public override EvaluationResult Evaluate()
        {
            var leftResult = LeftOperand.Evaluate();
            var rightResult = RightOperand.Evaluate();
            return new EvaluationResult(leftResult.Result - rightResult.Result, string.Empty);
        }
    }
}
