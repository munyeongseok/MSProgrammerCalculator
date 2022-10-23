using MSProgrammerCalculator.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSProgrammerCalculator.Models
{
    public class NumericalExpressionNode
    {
        public Operators Operator { get; set; }

        public string Expression { get; set; }

        public NumericalExpressionNode(Operators keypadOperator, string expression)
        {
            Operator = keypadOperator;
            Expression = expression;
        }
    }
}
