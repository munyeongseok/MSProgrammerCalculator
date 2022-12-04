using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public static class ShuntingYard
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="infixExpressions"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static Queue<IExpression> InfixToPostfix(IEnumerable<IExpression> infixExpressions)
        {
            var outputs = new Queue<IExpression>();
            var operators = new Stack<IOperatorExpression>();
            foreach (var expression in infixExpressions)
            {
                // 숫자일 경우 출력 큐에 추가
                if (expression is IValueExpression)
                {
                    outputs.Enqueue(expression);
                }
                // 연산자일 경우
                else if (expression is IOperatorExpression currentOperator)
                {
                    // 닫는 괄호일 경우
                    if (currentOperator is CloseParenthesisExpression)
                    {
                        // 연산자 스택에서 여는 괄호가 나타날 때까지 연산자를 꺼내서 출력 큐에 추가
                        while (operators.Any() && !(operators.Peek() is OpenParenthesisExpression))
                        {
                            outputs.Enqueue(operators.Pop());
                        }

                        // 연산자 스택에서 여는 괄호가 나타나면 여는 괄호 연산자를 제거
                        if (operators.Any() && operators.Peek() is OpenParenthesisExpression)
                        {
                            operators.Pop();
                        }
                        else
                        {
                            throw new InvalidOperationException("Mismatched parentheses.");
                        }
                    }
                    else
                    {
                        // 연산자 스택의 맨 위의 연산자가 여는 괄호 연산자가 아니고,
                        // 연산자 스택의 맨 위의 연산자의 우선순위가 현재 연산자의 우선순위보다 높거나,
                        // 우선순위가 같고 현재 연산자가 좌측 결합 연산자일 경우,
                        // 연산자 스택에서 연산자를 꺼내서 출력 큐에 추가
                        while (operators.Any())
                        {
                            var topOperator = operators.Peek();
                            if (!(topOperator is OpenParenthesisExpression) &&
                                topOperator.Precedence < currentOperator.Precedence ||
                                topOperator.Precedence == currentOperator.Precedence && currentOperator.Associativity == Associativity.LeftToRight)
                            {
                                outputs.Enqueue(operators.Pop());
                            }
                            else
                            {
                                break;
                            }
                        }

                        // 연산자 스택에 연산자를 추가
                        operators.Push(currentOperator);
                    }
                }
            }

            // 연산자 스택에 남은 연산자를 전부 꺼내서 출력 큐에 추가
            while (operators.Any())
            {
                if (operators.Peek() is OpenParenthesisExpression || operators.Peek() is CloseParenthesisExpression)
                {
                    throw new InvalidOperationException("Mismatched parentheses.");
                }

                outputs.Enqueue(operators.Pop());
            }

            return outputs;
        }
    }
}
