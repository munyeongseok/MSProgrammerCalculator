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
        /// OperatorDescriptor를 생성합니다.
        /// </summary>
        /// <param name="op"></param>
        /// <returns></returns>
        public static OperatorDescriptor CreateOperatorDescriptor(Operators op)
        {
            return new OperatorDescriptor(op, GetPrecedence(op), GetAssociativity(op));
        }

        /// <summary>
        /// C Operator Precedence 기준.
        /// https://en.cppreference.com/w/c/language/operator_precedence
        /// </summary>
        /// <param name="op"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        private static int GetPrecedence(Operators op)
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
        private static Associativity GetAssociativity(Operators op)
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

        /// <summary>
        /// 연산자 타입을 가져옵니다.
        /// </summary>
        /// <param name="op"></param>
        /// <returns></returns>
        public static OperatorType GetOperatorType(Operators op)
        {
            switch (op)
            {
                case Operators.BitwiseNOT:
                case Operators.Negate:
                    return OperatorType.Unary;
                case Operators.BitwiseAND:
                case Operators.BitwiseOR:
                case Operators.BitwiseNAND:
                case Operators.BitwiseNOR:
                case Operators.BitwiseXOR:
                case Operators.LeftShift:
                case Operators.RightShift:
                case Operators.Modulo:
                case Operators.Divide:
                case Operators.Multiply:
                case Operators.Minus:
                case Operators.Plus:
                    return OperatorType.Binary;
                case Operators.Clear:
                case Operators.Backspace:
                case Operators.OpenParenthesis:
                case Operators.CloseParenthesis:
                case Operators.DecimalSeparator:
                case Operators.Submit:
                    return OperatorType.Auxiliary;
                default:
                    throw new ArgumentException();
            }
        }

        /// <summary>
        /// 숫자 표현식 토큰을 가져옵니다.
        /// </summary>
        /// <param name="op"></param>
        /// <returns></returns>
        public static string GetNumericalExpressionToken(Operators op)
        {
            switch (op)
            {
                // Unary Numerical Expression
                case Operators.BitwiseNOT:
                    return "NOT";
                case Operators.Negate:
                    return "negate";
                // Binary Numerical Expression
                case Operators.BitwiseAND:
                    return "AND";
                case Operators.BitwiseOR:
                    return "OR";
                case Operators.BitwiseNAND:
                    return "NAND";
                case Operators.BitwiseNOR:
                    return "NOR";
                case Operators.BitwiseXOR:
                    return "XOR";
                case Operators.LeftShift:
                    return "Lsh";
                case Operators.RightShift:
                    return "Rsh";
                case Operators.Modulo:
                    return "%";
                case Operators.Divide:
                    return "÷";
                case Operators.Multiply:
                    return "×";
                case Operators.Minus:
                    return "-";
                case Operators.Plus:
                    return "+";
                // Auxiliary Numerical Expression
                case Operators.OpenParenthesis:
                    return "(";
                case Operators.CloseParenthesis:
                    return ")";
                case Operators.DecimalSeparator:
                    return ".";
                case Operators.Submit:
                    return "=";
                default:
                    throw new ArgumentException();
            }
        }

        /// <summary>
        /// 숫자 표현식을 생성합니다.
        /// </summary>
        /// <param name="infixExpressions"></param>
        /// <param name="baseNumber"></param>
        /// <returns></returns>
        public static string CreateNumericalExpression(IEnumerable<IExpression> infixExpressions, BaseNumber baseNumber)
        {
            if (!infixExpressions.Any())
            {
                return string.Empty;
            }

            var tokens = new Stack<string>();
            foreach (var expression in infixExpressions)
            {
                var token = expression.GetToken(baseNumber);
                if (expression is UnaryOperatorExpression)
                {
                    var prevToken = tokens.Pop();
                    token = $"{token}( {prevToken} )";
                }

                tokens.Push(token);
            }

            var sb = new StringBuilder();
            foreach (var token in tokens.Reverse())
            {
                sb.Append($"{token} ");
            }

            return sb.ToString();
        }

        /// <summary>
        /// 연산자 Expression을 생성합니다.
        /// </summary>
        /// <param name="op"></param>
        /// <returns></returns>
        public static IExpression CreateExpression(Operators op)
        {
            switch (op)
            {
                case Operators.BitwiseAND:
                    return new BitwiseANDExpression(null, null);
                case Operators.BitwiseOR:
                    return new BitwiseORExpression(null, null);
                case Operators.BitwiseNOT:
                    return new BitwiseNOTExpression(null);
                case Operators.BitwiseNAND:
                    return new BitwiseNANDExpression(null, null);
                case Operators.BitwiseNOR:
                    return new BitwiseNORExpression(null, null);
                case Operators.BitwiseXOR:
                    return new BitwiseXORExpression(null, null);
                case Operators.LeftShift:
                    return new LeftShiftExpression(null, null);
                case Operators.RightShift:
                    return new RightShiftExpression(null, null);
                case Operators.Modulo:
                    return new ModuloExpression(null, null);
                case Operators.Divide:
                    return new DivideExpression(null, null);
                case Operators.Multiply:
                    return new MultiplyExpression(null, null);
                case Operators.Minus:
                    return new MinusExpression(null, null);
                case Operators.Plus:
                    return new PlusExpression(null, null);
                case Operators.Negate:
                    return new NegateExpression(null);
                case Operators.OpenParenthesis:
                    return new OpenParenthesisExpression();
                case Operators.CloseParenthesis:
                    return new CloseParenthesisExpression();
                case Operators.DecimalSeparator:
                    return new DecimalSeparatorExpression();
                default:
                    throw new ArgumentException();
            }
        }

        /// <summary>
        /// 중위 표현식을 조합하여 루트 표현식을 만듭니다.
        /// </summary>
        /// <param name="infixExpressions"></param>
        /// <returns></returns>
        public static IExpression BuildRootExpression(IEnumerable<IExpression> infixExpressions)
        {
            var stack = new Stack<IExpression>();
            var postfixExpressions = ShuntingYard.InfixToPostfix(infixExpressions);
            foreach (var expression in postfixExpressions)
            {
                if (expression is UnaryOperatorExpression unaryOperator)
                {
                    unaryOperator.Operand = stack.Pop();
                }
                else if (expression is BinaryOperatorExpression binaryOperator)
                {
                    binaryOperator.RightOperand = stack.Count >= 2 ? stack.Pop() : null;
                    binaryOperator.LeftOperand = stack.Pop();
                }

                stack.Push(expression);
            }

            return stack.Pop();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseNumber"></param>
        /// <param name="operand"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static long InsertNumberAtRight(BaseNumber baseNumber, long operand, long number)
        {
            switch (baseNumber)
            {
                case BaseNumber.Binary:
                    if ((operand & MSB1000) == 0)
                    {
                        operand = (operand << 1) + number;
                    }
                    break;
                case BaseNumber.Octal:
                    if ((operand & MSB1110) == 0)
                    {
                        operand = (operand << 3) + number;
                    }
                    break;
                case BaseNumber.Decimal:
                    try
                    {
                        operand = checked(operand * 10) + number;
                    }
                    catch (OverflowException)
                    {
                    }
                    break;
                case BaseNumber.Hexadecimal:
                    if ((operand & MSB1111) == 0)
                    {
                        operand = (operand << 4) + number;
                    }
                    break;
            }

            return operand;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseNumber"></param>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static long RemoveNumberAtRight(BaseNumber baseNumber, long operand)
        {
            switch (baseNumber)
            {
                case BaseNumber.Binary:
                    operand >>= 1;
                    break;
                case BaseNumber.Octal:
                    operand >>= 3;
                    break;
                case BaseNumber.Decimal:
                    operand /= 10;
                    break;
                case BaseNumber.Hexadecimal:
                    operand >>= 4;
                    break;
            }

            return operand;
        }

        /// <summary>
        /// 단항 연산 결과를 생성합니다.
        /// </summary>
        /// <param name="op"></param>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static long UnaryOperation(Operators op, IExpression operand)
        {
            if (operand == null)
            {
                throw new ArgumentNullException(nameof(operand));
            }

            return UnaryOperation(op, operand.EvaluateResult());
        }

        /// <summary>
        /// 이진 연산 결과를 생성합니다.
        /// </summary>
        /// <param name="op"></param>
        /// <param name="leftOperand"></param>
        /// <param name="rightOperand"></param>
        /// <returns></returns>
        public static long BinaryOperation(Operators op, IExpression leftOperand, IExpression rightOperand)
        {
            if (leftOperand == null)
            {
                throw new ArgumentNullException(nameof(leftOperand));
            }

            if (rightOperand == null)
            {
                return leftOperand.EvaluateResult();
            }

            return BinaryOperation(op, leftOperand.EvaluateResult(), rightOperand.EvaluateResult());
        }

        private static long UnaryOperation(Operators op, long operand)
        {
            switch (op)
            {
                case Operators.BitwiseNOT:
                    return ~operand;
                case Operators.Negate:
                    return -operand;
                default:
                    throw new InvalidOperationException();
            }
        }

        private static long BinaryOperation(Operators op, long leftOperand, long rightOperand)
        {
            switch (op)
            {
                case Operators.BitwiseAND:
                    return leftOperand & rightOperand;
                case Operators.BitwiseOR:
                    return leftOperand | rightOperand;
                case Operators.BitwiseNAND:
                    return ~(leftOperand & rightOperand);
                case Operators.BitwiseNOR:
                    return ~(leftOperand | rightOperand);
                case Operators.BitwiseXOR:
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
    }
}
