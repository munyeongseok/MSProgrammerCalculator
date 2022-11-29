using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public interface IBinaryOperatorExpression : IOperatorExpression
    {
        IValueExpression LeftOperand { get; }

        IValueExpression RightOperand { get; }
    }
}
