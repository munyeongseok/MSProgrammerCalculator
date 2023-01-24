﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calculator : ICalculator
    {
        private BaseNumber currentBaseNumber;
        public BaseNumber CurrentBaseNumber
        {
            get => currentBaseNumber;
            set
            {
                if (currentBaseNumber != value)
                {
                    currentBaseNumber = value;
                    CurrentOperand = 0;
                }
            }
        }

        private long currentOperand;
        public long CurrentOperand
        {
            get => currentOperand;
            private set
            {
                if (currentOperand != value)
                {
                    currentOperand = value;
                    CurrentOperandChanged?.Invoke(this, new CurrentOperandChangedEventArgs(currentOperand));
                }
            }
        }

        private string currentExpression;
        public string CurrentExpression
        {
            get => currentExpression;
            private set
            {
                if (currentExpression != value)
                {
                    currentExpression = value;
                }
            }
        }
        
        public event EventHandler<CurrentOperandChangedEventArgs> CurrentOperandChanged; 

        public event EventHandler<ExpressionEvaluatedEventArgs> ExpressionEvaluated;

        private CalculatorContext _context;
        private bool _userOperandInitialized;
        private int _openedParenthesisCount;

        public Calculator(BaseNumber baseNumber = BaseNumber.Decimal)
        {
            _context = new CalculatorContext();
            _userOperandInitialized = true;
            _openedParenthesisCount = 0;
            CurrentBaseNumber = baseNumber;
        }

        public void Evaluate()
        {
            if (_context.InputQueue.Any() && _openedParenthesisCount == 0)
            {
                var infixExpressions = _context.InputQueue.ToList();
                var postfixExpressions = ShuntingYard.InfixToPostfix(infixExpressions);
                var rootExpression = EvaluatePostfix(postfixExpressions);
                var result = rootExpression.Evaluate();

                _userOperandInitialized = true;
                CurrentOperand = result.Result;
                ExpressionEvaluated?.Invoke(this, new ExpressionEvaluatedEventArgs(result.Result, result.Expression));
            }
        }

        private IExpression EvaluatePostfix(IEnumerable<IExpression> postfixExpressions)
        {
            var stack = new Stack<IExpression>();
            foreach (var expression in postfixExpressions)
            {
                if (expression is IOperandExpression)
                {
                    stack.Push(expression);
                }
                else if (expression is IUnaryOperatorExpression unaryOperator)
                {
                    unaryOperator.Operand = stack.Pop();
                    stack.Push(unaryOperator);
                }
                else if (expression is IBinaryOperatorExpression binaryOperator)
                {
                    if (stack.Count >= 2)
                    {
                        binaryOperator.RightOperand = stack.Pop();
                    }
                    binaryOperator.LeftOperand = stack.Pop();
                    stack.Push(binaryOperator);
                }
            }

            return stack.Pop();
        }

        public void InsertNumber(Numbers number)
        {
            CurrentOperand = CalculatorHelper.InsertNumberAtRight(CurrentBaseNumber, _userOperandInitialized ? 0 : CurrentOperand, (long)number);
            _userOperandInitialized = false;
        }

        public void RemoveNumber()
        {
            CurrentOperand = CalculatorHelper.RemoveNumberAtRight(CurrentBaseNumber, CurrentOperand);
            _userOperandInitialized = CurrentOperand == 0;
        }

        public bool TryEnqueueToken(Operators op)
        {
            switch (CalculatorHelper.GetOperatorType(op))
            {
                case OperatorType.Unary:
                    return ProcessUnaryOperation(op);
                case OperatorType.Binary:
                    return ProcessBinaryOperation(op);
                case OperatorType.Auxiliary:
                    return ProcessAuxiliaryOperation(op); 
            }

            return false;
        }

        private bool ProcessUnaryOperation(Operators unaryOperator)
        {
            if (unaryOperator == Operators.Negate)
            {
                if (_userOperandInitialized)
                {
                    return false;
                }
                
                if (CurrentExpression == null)
                {
                    CurrentOperand = -CurrentOperand;
                    return false;
                }
            }

            if (_context.InputQueue.Any() && _context.InputQueue.Last() is IUnaryOperatorExpression)
            {
                _context.InputQueue.Enqueue(CalculatorHelper.CreateExpression(unaryOperator));
            }
            else
            {
                _context.InputQueue.Enqueue(new OperandExpression(CurrentOperand));
                _context.InputQueue.Enqueue(CalculatorHelper.CreateExpression(unaryOperator));
            }

            return true;
        }

        private bool ProcessBinaryOperation(Operators binaryOperator)
        {
            _context.InputQueue.Enqueue(new OperandExpression(CurrentOperand));
            _context.InputQueue.Enqueue(CalculatorHelper.CreateExpression(binaryOperator));

            return true;
        }

        private bool ProcessAuxiliaryOperation(Operators auxiliaryOperator)
        {
            switch (auxiliaryOperator)
            {
                case Operators.OpenParenthesis:
                    if (_context.InputQueue.Any() && (_context.InputQueue.Last() is OperandExpression || _context.InputQueue.Last() is CloseParenthesisExpression))
                    {
                        _context.InputQueue.Enqueue(new MultiplyExpression());   
                    }
                    _context.InputQueue.Enqueue(new OpenParenthesisExpression());
                    _openedParenthesisCount++;
                    break;
                case Operators.CloseParenthesis:
                    if (_openedParenthesisCount > 0)
                    {
                        if (_context.InputQueue.Any() && _context.InputQueue.Last() is OpenParenthesisExpression)
                        {
                            _context.InputQueue.Enqueue(new OperandExpression(CurrentOperand));
                        }
                        _context.InputQueue.Enqueue(new CloseParenthesisExpression());
                        _openedParenthesisCount--;
                    }
                    break;
                case Operators.DecimalSeparator:
                    break;
                default:
                    return false;
            }

            return true;
        }
    }
}
