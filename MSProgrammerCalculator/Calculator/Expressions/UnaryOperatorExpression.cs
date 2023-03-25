using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public abstract class UnaryOperatorExpression : IExpression, IOperator
    {
        public OperatorDescriptor OperatorDescriptor { get; }

        public IExpression Operand { get; set; }

        private readonly string _token;

        protected UnaryOperatorExpression(string numericalExpressionToken, OperatorDescriptor operatorDescriptor, IExpression operand)
        {
            _token = numericalExpressionToken;
            OperatorDescriptor = operatorDescriptor;
            Operand = operand;
        }

        public abstract long EvaluateResult();

        public string EvaluateExpression(BaseNumber baseNumber)
        {
            return $"{_token}( {Operand.EvaluateExpression(baseNumber)} )";
        }

        public string GetToken(BaseNumber _)
        {
            return _token;
        }
    }
}
