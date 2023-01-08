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
            if (RightOperand == null)
            {
                var leftResult = LeftOperand.Evaluate();
                var newResult = leftResult.Result;
                var newExpression = leftResult.Expression != null ?
                    $"{leftResult.Expression} + " :
                    $"{leftResult.Result} + ";
                return new EvaluationResult(newResult, newExpression);
            }
            else
            {
                var leftResult = LeftOperand.Evaluate();
                var rightResult = RightOperand.Evaluate();
                var newResult = leftResult.Result + rightResult.Result;
                var leftExpression = leftResult.Expression != null ?
                    $"{leftResult.Expression}" :
                    $"{leftResult.Result}";
                var rightExpression = rightResult.Expression != null ?
                    $"{rightResult.Expression}" :
                    $"{rightResult.Result}";
                var newExpression = $"{leftExpression} + {rightExpression}";
                return new EvaluationResult(newResult, newExpression);
            }
        }
    }
}
