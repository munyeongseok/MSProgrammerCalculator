using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public abstract class UnaryExpression : ICalculatorExpression
    {
        public long Operand { get; }

        public bool IsNewOperand { get; }

        protected UnaryExpression(long operand, bool isNewOperand)
        {
            Operand = operand;
            IsNewOperand = isNewOperand;
        }

        public abstract void Evaluate(CalculatorContext context);
    }
}
