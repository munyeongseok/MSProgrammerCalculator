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

        protected UnaryOperatorExpression(string expressionToken, OperatorDescriptor operatorDescriptor, IExpression operand)
        {
            _token = expressionToken;
            OperatorDescriptor = operatorDescriptor;
            Operand = operand;
        }

        public long EvaluateResult()
        {
            return CalculatorHelper.UnaryOperation(OperatorDescriptor.Operator, Operand);
        }

        public string EvaluateExpression(BaseNumber baseNumber)
        {
            if (Operand == null)
            {
                return string.Empty;
            }

            var expression = Operand.EvaluateExpression(baseNumber);
            return Operand is ParenthesisExpression ? $"{_token}{expression}" : $"{_token}( {expression} )";
        }

        public string GetToken(BaseNumber _)
        {
            return _token;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
