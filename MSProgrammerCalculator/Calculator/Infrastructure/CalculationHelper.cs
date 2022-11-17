using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public static class CalculationHelper
    {
        private const long MSB1000 = unchecked((long)0b_1000000000000000_0000000000000000_0000000000000000_0000000000000000);
        private const long MSB1110 = unchecked((long)0b_1110000000000000_0000000000000000_0000000000000000_0000000000000000);
        private const long MSB1111 = unchecked((long)0b_1111000000000000_0000000000000000_0000000000000000_0000000000000000);

        public static long BinaryOperation(Operators op, long leftOperand, long rightOperand)
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

        public static long UnaryOperation(Operators op, long operand)
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

        public static ICalculatorExpression CreateUnaryExpression(Operators op, long operand, bool isNewOperand)
        {
            switch (op)
            {
                case Operators.NOT:
                    return new BitwiseNOTExpression(operand, isNewOperand);
                case Operators.Negate:
                    return new NegateExpression(operand, isNewOperand);
                default:
                    throw new ArgumentException();
            }
        }

        public static ICalculatorExpression CreateBinaryExpression(Operators op, long operand)
        {
            switch (op)
            {
                case Operators.AND:
                    return new BitwiseANDExpression(operand);
                case Operators.OR:
                    return new BitwiseORExpression(operand);
                case Operators.NAND:
                    return new BitwiseNANDExpression(operand);
                case Operators.NOR:
                    return new BitwiseNORExpression(operand);
                case Operators.XOR:
                    return new BitwiseXORExpression(operand);
                case Operators.LeftShift:
                    return new LeftShiftExpression(operand);
                case Operators.RightShift:
                    return new RightShiftExpression(operand);
                case Operators.Modulo:
                    return new ModuloExpression(operand);
                case Operators.Divide:
                    return new DivideExpression(operand);
                case Operators.Multiply:
                    return new MultiplyExpression(operand);
                case Operators.Minus:
                    return new MinusExpression(operand);
                case Operators.Plus:
                    return new PlusExpression(operand);
                default:
                    throw new ArgumentException();
            }
        }

        public static string AppendExpression(Operators op, string expression, long operand)
        {
            return AppendExpression(op, expression == null ? $"{operand}" : $"{expression}{operand}");
        }

        public static string AppendExpression(Operators op, string expression)
        {
            switch (op)
            {
                // Binary Expression
                case Operators.AND:
                    return $"{expression} AND ";
                case Operators.OR:
                    return $"{expression} OR ";
                case Operators.NAND:
                    return $"{expression} NAND ";
                case Operators.NOR:
                    return $"{expression} NOR ";
                case Operators.XOR:
                    return $"{expression} XOR ";
                case Operators.LeftShift:
                    return $"{expression} Lsh ";
                case Operators.RightShift:
                    return $"{expression} Rsh ";
                case Operators.Modulo:
                    return $"{expression} % ";
                case Operators.Divide:
                    return $"{expression} ÷ ";
                case Operators.Multiply:
                    return $"{expression} × ";
                case Operators.Minus:
                    return $"{expression} - ";
                case Operators.Plus:
                    return $"{expression} + ";
                // Unary Expression
                case Operators.NOT:
                    return $"NOT( {expression} )";
                case Operators.Negate:
                    return $"negate( {expression} )";
                // Auxiliary Expression
                case Operators.Result:
                    return $"{expression} = ";
                default:
                    throw new ArgumentException();
            }
        }

        public static long InsertNumberAtRight(BaseNumber baseNumber, long value, long number)
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

        public static long RemoveNumberAtRight(BaseNumber baseNumber, long value)
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
