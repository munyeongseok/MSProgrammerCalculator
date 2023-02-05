using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public abstract class BinaryOperatorExpression : Expression, IBinaryOperatorExpression
    {
        public OperatorDescriptor OperatorDescriptor { get; }

        public IExpression LeftOperand { get; set; }

        public IExpression RightOperand { get; set; }

        protected BinaryOperatorExpression(string numericalExpressionToken, OperatorDescriptor operatorDescriptor, IExpression leftOperand, IExpression rightOperand)
            : base(numericalExpressionToken)
        {
            OperatorDescriptor = operatorDescriptor;
            LeftOperand = leftOperand;
            RightOperand = rightOperand;
        }
    }
}
