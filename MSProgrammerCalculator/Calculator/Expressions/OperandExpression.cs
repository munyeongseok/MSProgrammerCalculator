using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class OperandExpression : IOperandExpression
    {
        public static readonly OperandExpression Null = null;

        public long Operand { get; }

        public OperandExpression(long operand)
        {
            Operand = operand;
        }

        public EvaluationResult Evaluate()
        {
            return new EvaluationResult(Operand, string.Empty);
        }
    }
}
