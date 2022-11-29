using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class ModuloExpression : BinaryOperatorExpression
    {
        public ModuloExpression(IValueExpression leftOperand, IValueExpression rightOperand)
            : base(leftOperand, rightOperand, 3, Associativity.LeftToRight)
        {
        }

        public override long Evaluate(CalculatorContext context)
        {
            //context.Result = context.Expression == null ? Operand : CalculatorHelper.BinaryOperation(Operators.Modulo, context.Result, Operand);
            //context.Expression = CalculatorHelper.AppendExpression(Operators.Modulo, context.Expression, Operand);

            return LeftOperand.Value % RightOperand.Value;
        }
    }
}
