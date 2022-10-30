using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public abstract class BinaryExpression : ICalculatorExpression
    {
        public double RightOperand { get; }

        protected BinaryExpression(double rightOperand)
        {
            RightOperand = rightOperand;
        }

        public abstract void Evaluate(CalculatorContext context);
    }
}
