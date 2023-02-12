using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calculator : ICalculator
    {
        private BaseNumber baseNumber;
        public BaseNumber BaseNumber
        {
            get => baseNumber;
            set
            {
                if (baseNumber != value)
                {
                    baseNumber = value;
                    Operand = 0;
                    NotifyPropertyChanged();
                }
            }
        }

        private long operand;
        public long Operand
        {
            get => operand;
            private set
            {
                if (operand != value)
                {
                    operand = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string numericalExpression;
        public string NumericalExpression
        {
            get => numericalExpression;
            private set
            {
                if (numericalExpression != value)
                {
                    numericalExpression = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private CalculatorContext _context;
        private bool _userOperandInitialized;

        public Calculator(BaseNumber baseNumber = BaseNumber.Decimal)
        {
            _context = new CalculatorContext();
            _userOperandInitialized = true;
            BaseNumber = baseNumber;
        }

        public void Evaluate()
        {
            if (_context.InputQueue.Any())
            {
                NumericalExpression = CalculatorHelper.CreateNumericalExpression(_context.InputQueue);

                if (_context.UnmatchedParenthesisCount == 0)
                {
                    var infixExpressions = _context.InputQueue.ToList();
                    var postfixExpressions = ShuntingYard.InfixToPostfix(infixExpressions);
                    var rootExpression = EvaluatePostfix(postfixExpressions);
                    var result = rootExpression.Evaluate();
                    Operand = result;
                    _userOperandInitialized = true;
                }
            }
        }

        private IExpression EvaluatePostfix(IEnumerable<IExpression> postfixExpressions)
        {
            var stack = new Stack<IExpression>();
            foreach (var expression in postfixExpressions)
            {
                if (expression is IUnaryOperatorExpression unaryOperator)
                {
                    unaryOperator.Operand = stack.Pop();
                }
                else if (expression is IBinaryOperatorExpression binaryOperator)
                {
                    binaryOperator.RightOperand = stack.Count >= 2 ? stack.Pop() : null;
                    binaryOperator.LeftOperand = stack.Pop();
                }

                stack.Push(expression);
            }

            return stack.Pop();
        }

        public void InsertNumber(Numbers number)
        {
            var isNegative = Operand < 0;
            var newOperand = _userOperandInitialized ? 0 : Math.Abs(Operand);
            newOperand = CalculatorHelper.InsertNumberAtRight(BaseNumber, newOperand, (long)number);
            newOperand = isNegative ? -newOperand : newOperand;

            Operand = newOperand;
            _userOperandInitialized = false;
        }

        public void RemoveNumber()
        {
            var isNegative = Operand < 0;
            var newOperand = Math.Abs(Operand);
            newOperand = CalculatorHelper.RemoveNumberAtRight(BaseNumber, newOperand);
            newOperand = isNegative ? -newOperand : newOperand;

            Operand = newOperand;
            _userOperandInitialized = newOperand == 0;
        }

        public void ClearInput()
        {
            if (Operand != 0)
            {
                Operand = 0;
                if (_context.UnmatchedParenthesisCount != 0)
                {
                    _context.InputQueue = new Queue<IExpression>(RemoveLastMatchedExpression(_context.InputQueue));
                    NumericalExpression = CalculatorHelper.CreateNumericalExpression(_context.InputQueue);
                }
            }
            else
            {
                _context.Clear();
                NumericalExpression = null;
            }
        }

        private IEnumerable<IExpression> RemoveLastMatchedExpression(IEnumerable<IExpression> expressions)
        {
            var count = 0;
            var lastMatchedCount = 0;
            var reversedExpressions = expressions.Reverse();
            foreach (var expression in reversedExpressions)
            {
                lastMatchedCount++;

                if (expression is CloseParenthesisExpression)
                {
                    count++;
                }
                else if (expression is OpenParenthesisExpression)
                {
                    count--;

                    if (count == 0)
                    {
                        break;
                    }
                }
            }

            return expressions.Take(expressions.Count() - lastMatchedCount);
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
                if (Operand == 0)
                {
                    return false;
                }

                if (!_userOperandInitialized)
                {
                    Operand = -Operand;
                    return false;
                }
            }

            if (_context.InputQueue.Any() && _context.InputQueue.Last() is IUnaryOperatorExpression)
            {
                _context.InputQueue.Enqueue(CalculatorHelper.CreateExpression(unaryOperator));
            }
            else
            {
                _context.InputQueue.Enqueue(new OperandExpression(Operand));
                _context.InputQueue.Enqueue(CalculatorHelper.CreateExpression(unaryOperator));
            }

            return true;
        }

        private bool ProcessBinaryOperation(Operators binaryOperator)
        {
            // Input Queue에 추가된 마지막 Expression이 닫는 괄호가 아닐 경우에만 OperandExpression 추가
            if (!(_context.InputQueue.Any() && _context.InputQueue.Last() is CloseParenthesisExpression))
            {
                _context.InputQueue.Enqueue(new OperandExpression(Operand));
            }

            _context.InputQueue.Enqueue(CalculatorHelper.CreateExpression(binaryOperator));

            return true;
        }

        private bool ProcessAuxiliaryOperation(Operators auxiliaryOperator)
        {
            switch (auxiliaryOperator)
            {
                case Operators.OpenParenthesis:
                    if (_context.InputQueue.Any())
                    {
                        var last = _context.InputQueue.Last();
                        // 마지막 Expression이 이항 연산자일 경우 Operand 초기화
                        if (last is BinaryOperatorExpression)
                        {
                            Operand = 0;
                            _userOperandInitialized = true;
                        }
                        // 마지막 Expression이 피연산자이거나 닫는 괄호일 경우 곱하기 연산자 추가
                        if (last is OperandExpression || last is CloseParenthesisExpression)
                        {
                            _context.InputQueue.Enqueue(new MultiplyExpression());
                        }
                    }
                    _context.InputQueue.Enqueue(new OpenParenthesisExpression());
                    _context.UnmatchedParenthesisCount++;
                    break;
                case Operators.CloseParenthesis:
                    if (_context.UnmatchedParenthesisCount > 0)
                    {
                        if (_context.InputQueue.Any() && _context.InputQueue.Last() is OpenParenthesisExpression)
                        {
                            _context.InputQueue.Enqueue(new OperandExpression(Operand));
                        }
                        _context.InputQueue.Enqueue(new CloseParenthesisExpression());
                        _context.UnmatchedParenthesisCount--;
                    }
                    break;
                case Operators.DecimalSeparator:
                    break;
                case Operators.Backspace:
                    RemoveNumber();
                    return false;
                case Operators.Clear:
                    ClearInput();
                    return false;
                case Operators.Submit:
                    throw new NotImplementedException();
                    break;
                default:
                    return false;
            }

            return true;
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
