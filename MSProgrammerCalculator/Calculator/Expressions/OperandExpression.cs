using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class OperandExpression : IExpression
    {
        public long Operand { get; }

        public OperandExpression(long operand)
        {
            Operand = operand;
        }

        public long EvaluateResult()
        {
            return Operand;
        }

        public string EvaluateExpression(BaseNumber baseNumber)
        {
            switch (baseNumber)
            {
                case BaseNumber.Binary:
                    return Convert.ToString(Operand, 2);
                case BaseNumber.Octal:
                    return Convert.ToString(Operand, 8);
                case BaseNumber.Decimal:
                    return Operand.ToString();
                case BaseNumber.Hexadecimal:
                    return Convert.ToString(Operand, 16).ToUpper();
            }

            throw new ArgumentException();
        }

        public string GetToken(BaseNumber baseNumber = BaseNumber.Decimal)
        {
            switch (baseNumber)
            {
                case BaseNumber.Binary:
                    return Convert.ToString(Operand, 2);
                case BaseNumber.Octal:
                    return Convert.ToString(Operand, 8);
                case BaseNumber.Decimal:
                    return Operand.ToString();
                case BaseNumber.Hexadecimal:
                    return Convert.ToString(Operand, 16).ToUpper();
            }

            throw new ArgumentException();
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
