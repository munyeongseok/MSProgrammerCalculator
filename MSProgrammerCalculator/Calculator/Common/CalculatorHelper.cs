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
        /// <returns></returns>
        public static string CreateNumericalExpression(IEnumerable<IExpression> infixExpressions)
        {
            if (!infixExpressions.Any())
            {
                return string.Empty;
            }

            var tokens = new Stack<string>();
            foreach (var expression in infixExpressions)
            {
                var token = expression.NumericalExpressionToken;
                if (expression is IUnaryOperatorExpression)
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
                    return new BitwiseANDExpression();
                case Operators.BitwiseOR:
                    return new BitwiseORExpression();
                case Operators.BitwiseNOT:
                    return new BitwiseNOTExpression();
                case Operators.BitwiseNAND:
                    return new BitwiseNANDExpression();
                case Operators.BitwiseNOR:
                    return new BitwiseNORExpression();
                case Operators.BitwiseXOR:
                    return new BitwiseXORExpression();
                case Operators.LeftShift:
                    return new LeftShiftExpression();
                case Operators.RightShift:
                    return new RightShiftExpression();
                case Operators.Modulo:
                    return new ModuloExpression();
                case Operators.Divide:
                    return new DivideExpression();
                case Operators.Multiply:
                    return new MultiplyExpression();
                case Operators.Minus:
                    return new MinusExpression();
                case Operators.Plus:
                    return new PlusExpression();
                case Operators.Negate:
                    return new NegateExpression();
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
        public static EvaluationResult CreateUnaryOperationResult(Operators op, IExpression operand)
        {
            if (operand == null)
            {
                throw new ArgumentNullException(nameof(operand));
            }

            var result = operand.Evaluate();
            var newResult = UnaryOperation(op, result.Result);
            var newNumericalExpression = AppendNumericalExpression(op, GetNumericalExpression(result));
            return new EvaluationResult(newResult, newNumericalExpression);
        }

        /// <summary>
        /// 이진 연산 결과를 생성합니다.
        /// </summary>
        /// <param name="op"></param>
        /// <param name="leftOperand"></param>
        /// <param name="rightOperand"></param>
        /// <returns></returns>
        public static EvaluationResult CreateBinaryOperationResult(Operators op, IExpression leftOperand, IExpression rightOperand)
        {
            if (leftOperand == null)
            {
                throw new ArgumentNullException(nameof(leftOperand));
            }

            var newResult = 0L;
            var newNumericalExpression = "";
            if (rightOperand == null)
            {
                var leftResult = leftOperand.Evaluate();
                newResult = leftResult.Result;
                newNumericalExpression = AppendNumericalExpression(op, GetNumericalExpression(leftResult));
            }
            else
            {
                var leftResult = leftOperand.Evaluate();
                var rightResult = rightOperand.Evaluate();
                newResult = BinaryOperation(op, leftResult.Result, rightResult.Result);
                newNumericalExpression = AppendNumericalExpression(op, GetNumericalExpression(leftResult), GetNumericalExpression(rightResult));
            }

            return new EvaluationResult(newResult, newNumericalExpression);
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

        private static string GetNumericalExpression(EvaluationResult result)
        {
            return string.IsNullOrEmpty(result.NumericalExpression) ? result.Result.ToString() : result.NumericalExpression;
        }

        private static string AppendNumericalExpression(Operators op, string leftNumericalExpression, string rightNumericalExpression)
        {
            return $"{AppendNumericalExpression(op, leftNumericalExpression)}{rightNumericalExpression}";
        }

        private static string AppendNumericalExpression(Operators op, string numericalExpression)
        {
            switch (op)
            {
                // Unary Numerical Expression
                case Operators.BitwiseNOT:
                    return $"NOT( {numericalExpression} )";
                case Operators.Negate:
                    return $"negate( {numericalExpression} )";
                // Binary Numerical Expression
                case Operators.BitwiseAND:
                    return $"{numericalExpression} AND ";
                case Operators.BitwiseOR:
                    return $"{numericalExpression} OR ";
                case Operators.BitwiseNAND:
                    return $"{numericalExpression} NAND ";
                case Operators.BitwiseNOR:
                    return $"{numericalExpression} NOR ";
                case Operators.BitwiseXOR:
                    return $"{numericalExpression} XOR ";
                case Operators.LeftShift:
                    return $"{numericalExpression} Lsh ";
                case Operators.RightShift:
                    return $"{numericalExpression} Rsh ";
                case Operators.Modulo:
                    return $"{numericalExpression} % ";
                case Operators.Divide:
                    return $"{numericalExpression} ÷ ";
                case Operators.Multiply:
                    return $"{numericalExpression} × ";
                case Operators.Minus:
                    return $"{numericalExpression} - ";
                case Operators.Plus:
                    return $"{numericalExpression} + ";
                // Auxiliary Numerical Expression
                case Operators.Submit:
                    return $"{numericalExpression} = ";
                default:
                    throw new ArgumentException();
            }
        }
    }
}
