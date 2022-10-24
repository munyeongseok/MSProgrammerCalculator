using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSProgrammerCalculator.Common
{
    public static class Calculation
    {
        private const long MSB1000 = unchecked((long)0b_1000000000000000_0000000000000000_0000000000000000_0000000000000000);
        private const long MSB1110 = unchecked((long)0b_1110000000000000_0000000000000000_0000000000000000_0000000000000000);
        private const long MSB1111 = unchecked((long)0b_1111000000000000_0000000000000000_0000000000000000_0000000000000000);

        public static long BinaryOperation(long leftOperand, long rightOperand, Operators op)
        {
            switch (op)
            {
                case Operators.AND:
                    return leftOperand & rightOperand;
                case Operators.OR:
                    return leftOperand | rightOperand;
                case Operators.NAND:
                    return ~(leftOperand & rightOperand);
                case Operators.NOR:
                    return ~(leftOperand | rightOperand);
                case Operators.XOR:
                    return leftOperand ^ rightOperand;
                case Operators.LeftShift:
                    return leftOperand << (int)rightOperand;
                case Operators.RightShift:
                    return leftOperand >> (int)rightOperand;
                case Operators.Modulo:
                    return leftOperand % rightOperand;
                case Operators.Divide:
                    return leftOperand / rightOperand;
                case Operators.Multiply:
                    return leftOperand * rightOperand;
                case Operators.Minus:
                    return leftOperand - rightOperand;
                case Operators.Plus:
                    return leftOperand + rightOperand;
                default:
                    throw new InvalidOperationException();
            }
        }

        public static long UnaryOperation(long operand, Operators op)
        {
            switch (op)
            {
                case Operators.NOT:
                    return ~operand;
                case Operators.Negate:
                    return -operand;
                default:
                    throw new InvalidOperationException();
            }
        }

        public static string CreateNumericalExpression(long value, Operators op)
        {
            switch (op)
            {
                case Operators.AND:
                    return $"{value} AND ";
                case Operators.OR:
                    return $"{value} OR ";
                case Operators.NOT:
                    return $"NOT( {value} ) ";
                case Operators.NAND:
                    return $"{value} NAND ";
                case Operators.NOR:
                    return $"{value} NOR ";
                case Operators.XOR:
                    return $"{value} XOR ";
                case Operators.LeftShift:
                    return $"{value} Lsh ";
                case Operators.RightShift:
                    return $"{value} Rsh ";
                case Operators.Modulo:
                    return $"{value} % ";
                case Operators.Divide:
                    return $"{value} ÷ ";
                case Operators.Multiply:
                    return $"{value} × ";
                case Operators.Minus:
                    return $"{value} - ";
                case Operators.Plus:
                    return $"{value} + ";
                case Operators.Result:
                    return $"{value} = ";
                default:
                    throw new InvalidOperationException();
            }
        }

        public static long InsertNumberAtRight(long value, long number, BaseNumber baseNumber)
        {
            switch (baseNumber)
            {
                case BaseNumber.Binary:
                    if ((value & MSB1000) == 0)
                    {
                        value = (value << 1) + number;
                    }
                    break;
                case BaseNumber.Octal:
                    if ((value & MSB1110) == 0)
                    {
                        value = (value << 3) + number;
                    }
                    break;
                case BaseNumber.Decimal:
                    try
                    {
                        value = checked(value * 10) + number;
                    }
                    catch (OverflowException)
                    {
                    }
                    break;
                case BaseNumber.Hexadecimal:
                    if ((value & MSB1111) == 0)
                    {
                        value = (value << 4) + number;
                    }
                    break;
            }

            return value;
        }

        public static long RemoveNumberAtRight(long value, BaseNumber baseNumber)
        {
            switch (baseNumber)
            {
                case BaseNumber.Binary:
                    value >>= 1;
                    break;
                case BaseNumber.Octal:
                    value >>= 3;
                    break;
                case BaseNumber.Decimal:
                    value /= 10;
                    break;
                case BaseNumber.Hexadecimal:
                    value >>= 4;
                    break;
            }

            return value;
        }
    }
}
