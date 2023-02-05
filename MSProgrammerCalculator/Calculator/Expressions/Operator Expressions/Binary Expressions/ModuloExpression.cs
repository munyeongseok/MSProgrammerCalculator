using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class ModuloExpression : BinaryOperatorExpression
    {
        public ModuloExpression()
            : this(OperandExpression.Null, OperandExpression.Null)
        {
        }

        public ModuloExpression(IOperandExpression leftOperand, IOperandExpression rightOperand)
            : base(CalculatorHelper.GetNumericalExpressionToken(Operators.Modulo), CalculatorHelper.CreateOperatorDescriptor(Operators.Modulo), leftOperand, rightOperand)
        {
        }

        public override EvaluationResult Evaluate()
        {
            return CalculatorHelper.CreateBinaryOperationResult(Operators.Modulo, LeftOperand, RightOperand);
        }
    }
}
