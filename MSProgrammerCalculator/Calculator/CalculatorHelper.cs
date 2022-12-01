using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal static class CalculatorHelper
    {
        private const long MSB1000 = unchecked((long)0b_1000000000000000_0000000000000000_0000000000000000_0000000000000000);
        private const long MSB1110 = unchecked((long)0b_1110000000000000_0000000000000000_0000000000000000_0000000000000000);
        private const long MSB1111 = unchecked((long)0b_1111000000000000_0000000000000000_0000000000000000_0000000000000000);

        /// <summary>
        /// C Operator Precedence 기준.
        /// https://en.cppreference.com/w/c/language/operator_precedence
        /// </summary>
        /// <param name="op"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static int GetPrecedence(Operators op)
        {
            switch (op)
            {
                case Operators.OpenParenthesis:
                case Operators.CloseParenthesis:
                case Operators.DecimalSeparator:
                    return 1;
                case Operators.Negate:
                case Operators.BitwiseNOT:
                    return 2;
                case Operators.Multiply:
                case Operators.Divide:
                case Operators.Modulo:
                    return 3;
                case Operators.Plus:
                case Operators.Minus:
                    return 4;
                case Operators.LeftShift:
                case Operators.RightShift:
                    return 5;
                case Operators.BitwiseAND:
                case Operators.BitwiseNAND:
                    return 8;
                case Operators.BitwiseXOR:
                    return 9;
                case Operators.BitwiseOR:
                case Operators.BitwiseNOR:
                    return 10;
                default:
                    throw new ArgumentException();
            }
        }

        /// <summary>
        /// C Operator Precedence 기준.
        /// https://en.cppreference.com/w/c/language/operator_precedence
        /// </summary>
        /// <param name="op"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static Associativity GetAssociativity(Operators op)
        {
            switch (op)
            {
                case Operators.OpenParenthesis:
                case Operators.CloseParenthesis:
                case Operators.DecimalSeparator:
                    return Associativity.LeftToRight;
                case Operators.Negate:
                case Operators.BitwiseNOT:
                    return Associativity.RightToLeft;
                case Operators.Multiply:
                case Operators.Divide:
                case Operators.Modulo:
                case Operators.Plus:
                case Operators.Minus:
                case Operators.LeftShift:
                case Operators.RightShift:
                case Operators.BitwiseAND:
                case Operators.BitwiseNAND:
                case Operators.BitwiseXOR:
                case Operators.BitwiseOR:
                case Operators.BitwiseNOR:
                    return Associativity.LeftToRight;
                default:
                    throw new ArgumentException();
            }
        }

        public static IExpression CreateUnaryExpression(Operators op, long operand)
        {
            var operandExpression = new ValueExpression(operand);
            switch (op)
            {
                case Operators.BitwiseNOT:
                    return new BitwiseNOTExpression(operandExpression);
                case Operators.Negate:
                    return new NegateExpression(operandExpression);
                default:
                    throw new ArgumentException();
            }
        }

        public static IExpression CreateBinaryExpression(Operators op, long leftOperand, long rightOperand)
        {
            var leftOperandExpression = new ValueExpression(leftOperand);
            var rightOperandExpression = new ValueExpression(rightOperand);
            switch (op)
            {
                case Operators.BitwiseAND:
                    return new BitwiseANDExpression(leftOperandExpression, rightOperandExpression);
                case Operators.BitwiseOR:
                    return new BitwiseORExpression(leftOperandExpression, rightOperandExpression);
                case Operators.BitwiseNAND:
                    return new BitwiseNANDExpression(leftOperandExpression, rightOperandExpression);
                case Operators.BitwiseNOR:
                    return new BitwiseNORExpression(leftOperandExpression, rightOperandExpression);
                case Operators.BitwiseXOR:
                    return new BitwiseXORExpression(leftOperandExpression, rightOperandExpression);
                case Operators.LeftShift:
                    return new LeftShiftExpression(leftOperandExpression, rightOperandExpression);
                case Operators.RightShift:
                    return new RightShiftExpression(leftOperandExpression, rightOperandExpression);
                case Operators.Modulo:
                    return new ModuloExpression(leftOperandExpression, rightOperandExpression);
                case Operators.Divide:
                    return new DivideExpression(leftOperandExpression, rightOperandExpression);
                case Operators.Multiply:
                    return new MultiplyExpression(leftOperandExpression, rightOperandExpression);
                case Operators.Minus:
                    return new MinusExpression(leftOperandExpression, rightOperandExpression);
                case Operators.Plus:
                    return new PlusExpression(leftOperandExpression, rightOperandExpression);
                default:
                    throw new ArgumentException();
            }
        }

        public static IExpression CreateAuxiliaryExpression(Operators op)
        {
            switch (op)
            {
                case Operators.Clear:
                    return new ClearExpression();
                case Operators.Backspace:
                    return new BackspaceExpression();
                case Operators.OpenParenthesis:
                case Operators.CloseParenthesis:
                    return new OpenParenthesisExpression();
                case Operators.DecimalSeparator:
                    return new DecimalSeparatorExpression();
                case Operators.Submit:
                    return new SubmitExpression();
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
                // Unary Expression
                case Operators.BitwiseNOT:
                    return $"NOT( {expression} )";
                case Operators.Negate:
                    return $"negate( {expression} )";
                // Binary Expression
                case Operators.BitwiseAND:
                    return $"{expression} AND ";
                case Operators.BitwiseOR:
                    return $"{expression} OR ";
                case Operators.BitwiseNAND:
                    return $"{expression} NAND ";
                case Operators.BitwiseNOR:
                    return $"{expression} NOR ";
                case Operators.BitwiseXOR:
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
                // Auxiliary Expression
                case Operators.Submit:
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
