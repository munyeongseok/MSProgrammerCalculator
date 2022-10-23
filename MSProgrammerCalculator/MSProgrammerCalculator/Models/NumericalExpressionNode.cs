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
        public KeypadOperators Operator { get; set; }

        public string Expression { get; set; }

        public NumericalExpressionNode(KeypadOperators keypadOperator, string expression)
        {
            Operator = keypadOperator;
            Expression = expression;
        }
    }
}
