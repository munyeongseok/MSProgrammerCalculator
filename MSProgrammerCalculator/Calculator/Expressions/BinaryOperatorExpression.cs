using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public abstract class BinaryOperatorExpression : IExpression, IOperator
    {
        public OperatorDescriptor OperatorDescriptor { get; }

        public IExpression LeftOperand { get; set; }

        public IExpression RightOperand { get; set; }

        private readonly string _token;

        protected BinaryOperatorExpression(string expressionToken, OperatorDescriptor operatorDescriptor, IExpression leftOperand, IExpression rightOperand)
        {
            _token = expressionToken;
            OperatorDescriptor = operatorDescriptor;
            LeftOperand = leftOperand;
            RightOperand = rightOperand;
        }

        public long EvaluateResult()
        {
            return CalculatorHelper.BinaryOperation(OperatorDescriptor.Operator, LeftOperand, RightOperand);
        }

        public string EvaluateExpression(BaseNumber baseNumber)
        {
            var leftExpression = LeftOperand != null ? $"{LeftOperand.EvaluateExpression(baseNumber)} " : string.Empty;
            var rightExpression = RightOperand != null ? $" {RightOperand.EvaluateExpression(baseNumber)}" : string.Empty;
            return $"{leftExpression}{_token}{rightExpression}";
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
