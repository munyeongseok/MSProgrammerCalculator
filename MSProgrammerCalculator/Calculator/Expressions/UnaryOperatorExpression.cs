using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public abstract class UnaryOperatorExpression : IUnaryOperatorExpression
    {
        public OperatorDescriptor OperatorDescriptor { get; }

        public IExpression Operand { get; set; }

        protected UnaryOperatorExpression(OperatorDescriptor operatorDescriptor, IExpression operand)
        {
            OperatorDescriptor = operatorDescriptor;
            Operand = operand;
        }

        public abstract EvaluationResult Evaluate();
    }
}
