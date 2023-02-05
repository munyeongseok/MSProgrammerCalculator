using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class OperandExpression : Expression, IOperandExpression
    {
        public static readonly OperandExpression Null = null;

        public long Operand { get; }

        public OperandExpression(long operand)
            : base(operand.ToString())
        {
            Operand = operand;
        }

        public override long Evaluate()
        {
            return Operand;
        }
    }
}
