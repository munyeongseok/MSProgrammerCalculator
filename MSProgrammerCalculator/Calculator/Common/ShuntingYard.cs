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
            var outputQueue = new Queue<IExpression>();
            var operatorStack = new Stack<IOperatorExpression>();
            foreach (var expression in infixExpressions)
            {
                // 숫자일 경우 출력 큐에 추가
                if (expression is IOperandExpression)
                {
                    outputQueue.Enqueue(expression);
                }
                // 연산자일 경우
                else if (expression is IOperatorExpression currentOperator)
                {
                    // 닫는 괄호일 경우
                    if (currentOperator is CloseParenthesisExpression)
                    {
                        // 연산자 스택에서 여는 괄호가 나타날 때까지 연산자를 꺼내서 출력 큐에 추가
                        while (operatorStack.Any() && !(operatorStack.Peek() is OpenParenthesisExpression))
                        {
                            outputQueue.Enqueue(operatorStack.Pop());
                        }

                        // 연산자 스택에서 여는 괄호가 나타나면 여는 괄호 연산자를 제거
                        if (operatorStack.Any() && operatorStack.Peek() is OpenParenthesisExpression)
                        {
                            operatorStack.Pop();
                        }
                        else
                        {
                            throw new InvalidOperationException("Mismatched parentheses.");
                        }
                    }
                    // 닫는 괄호가 아닐 경우
                    else
                    {
                        while (operatorStack.Any())
                        {
                            var topOperator = operatorStack.Peek();
                            
                            // 연산자 스택의 맨 위의 연산자가 여는 괄호 연산자이면 break
                            if (topOperator is OpenParenthesisExpression)
                            {
                                break;
                            }

                            // 연산자 스택의 맨 위의 연산자의 우선순위가 현재 연산자의 우선순위보다 높거나,
                            // 우선순위가 같고 현재 연산자가 좌측 결합 연산자일 경우,
                            // 연산자 스택에서 연산자를 꺼내서 출력 큐에 추가
                            if (topOperator.OperatorDescriptor.Precedence < currentOperator.OperatorDescriptor.Precedence ||
                                topOperator.OperatorDescriptor.Precedence == currentOperator.OperatorDescriptor.Precedence &&
                                currentOperator.OperatorDescriptor.Associativity == Associativity.LeftToRight)
                            {
                                outputQueue.Enqueue(operatorStack.Pop());
                            }
                            // 그렇지 않으면 break
                            else
                            {
                                break;
                            }
                        }

                        // 연산자 스택에 연산자를 추가
                        operatorStack.Push(currentOperator);
                    }
                }
            }

            // 연산자 스택에 남은 연산자를 전부 꺼내서 출력 큐에 추가
            while (operatorStack.Any())
            {
                if (operatorStack.Peek() is OpenParenthesisExpression || operatorStack.Peek() is CloseParenthesisExpression)
                {
                    throw new InvalidOperationException("Mismatched parentheses.");
                }

                outputQueue.Enqueue(operatorStack.Pop());
            }

            return outputQueue;
        }
    }
}
