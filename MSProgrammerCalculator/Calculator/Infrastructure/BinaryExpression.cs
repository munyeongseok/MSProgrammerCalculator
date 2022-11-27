using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public abstract class BinaryExpression : IExpression
    {
        public IExpression LeftOperand { get; }

        public IExpression RightOperand { get; }

        protected BinaryExpression(IExpression leftOperand, IExpression rightOperand)
        {
            LeftOperand = leftOperand;
            RightOperand = rightOperand;
        }

        public abstract long Evaluate(CalculatorContext context);
    }
}
