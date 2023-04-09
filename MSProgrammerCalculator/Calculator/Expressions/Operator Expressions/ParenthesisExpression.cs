using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class ParenthesisExpression : IExpression, IOperator
    {
        public OperatorDescriptor OperatorDescriptor { get; }

        public IExpression Operand { get; set; }

        public bool IsClosed { get; set; }

        public ParenthesisExpression()
        {
            OperatorDescriptor = CalculatorHelper.CreateOperatorDescriptor(Operators.Parenthesis);
        }

        public long EvaluateResult()
        {
            return IsClosed ? Operand.EvaluateResult() : 0;
        }

        public string EvaluateExpression(BaseNumber baseNumber)
        {
            if (Operand == null)
            {
                return "(";
            }

            return $"( {Operand.EvaluateExpression(baseNumber)}{(IsClosed ? " )" : string.Empty)}";
        }

        public string GetToken(BaseNumber _)
        {
            throw new NotImplementedException();
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
