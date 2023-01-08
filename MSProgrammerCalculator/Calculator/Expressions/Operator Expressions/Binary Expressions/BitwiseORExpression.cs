using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class BitwiseORExpression : BinaryOperatorExpression
    {
        public BitwiseORExpression() : this(null, null)
        {
        }

        public BitwiseORExpression(IOperandExpression leftOperand, IOperandExpression rightOperand)
            : base(leftOperand, rightOperand,
                  CalculatorHelper.GetPrecedence(Operators.BitwiseOR),
                  CalculatorHelper.GetAssociativity(Operators.BitwiseOR))
        {
        }

        public override EvaluationResult Evaluate()
        {
            var leftResult = LeftOperand.Evaluate();
            var rightResult = RightOperand.Evaluate();
            return new EvaluationResult(leftResult.Result | rightResult.Result, string.Empty);
        }
    }
}
