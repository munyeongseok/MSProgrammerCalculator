using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class ModuloExpression : BinaryExpression
    {
        public ModuloExpression(long operand) : base(operand)
        {
        }

        public override void Evaluate(CalculatorContext context, bool firstExpression)
        {
            context.Result = CalculationHelper.BinaryOperation(Operators.Modulo, context.Result, Operand);
            context.Expression = CalculationHelper.AppendExpression(Operators.Modulo, context.Expression, Operand);
        }
    }
}
