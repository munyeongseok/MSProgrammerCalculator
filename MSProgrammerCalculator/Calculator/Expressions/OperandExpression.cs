using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class OperandExpression : IExpression
    {
        public static readonly OperandExpression Null = null;

        public long Operand { get; }

        public OperandExpression(long operand)
        {
            Operand = operand;
        }

        public long Evaluate()
        {
            return Operand;
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
    }
}
