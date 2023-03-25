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

        protected BinaryOperatorExpression(string numericalExpressionToken, OperatorDescriptor operatorDescriptor, IExpression leftOperand, IExpression rightOperand)
        {
            _token = numericalExpressionToken;
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
            return $"{LeftOperand.EvaluateExpression(baseNumber)} {_token} {RightOperand.EvaluateExpression(baseNumber)}";
        }

        public string GetToken(BaseNumber _)
        {
            return _token;
        }
    }
}
