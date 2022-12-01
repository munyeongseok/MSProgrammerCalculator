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
            : base(leftOperand, rightOperand,
                  CalculatorHelper.GetPrecedence(Operators.Modulo),
                  CalculatorHelper.GetAssociativity(Operators.Modulo))
        {
        }

        public override long Evaluate(CalculatorContext context)
        {
            return LeftOperand.Value % RightOperand.Value;
        }
    }
}
