using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class AddExpression : BinaryExpression
    {
        public AddExpression(double operand) : base(operand)
        {
        }

        public override void Evaluate(CalculatorContext context)
        {
            context.LeftOperand = context.LeftOperand + RightOperand;
        }
    }
}
