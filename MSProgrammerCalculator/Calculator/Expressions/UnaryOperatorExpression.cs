using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public abstract class UnaryOperatorExpression : Expression, IUnaryOperatorExpression
    {
        public OperatorDescriptor OperatorDescriptor { get; }

        public IExpression Operand { get; set; }

        protected UnaryOperatorExpression(string numericalExpressionToken, OperatorDescriptor operatorDescriptor, IExpression operand)
            : base(numericalExpressionToken)
        {
            OperatorDescriptor = operatorDescriptor;
            Operand = operand;
        }
    }
}
