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
                    _operandInputted = false;
                    NumericalExpression = CalculatorHelper.CreateNumericalExpression(_context.InputQueue, BaseNumber);
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

        public bool IsInputSubmitted
        {
            get => _context.InputQueue.LastOrDefault() is SubmitExpression;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private CalculatorContext _context;
        private bool _operandInputted = false;

        public Calculator(BaseNumber baseNumber = BaseNumber.Decimal)
        {
            _context = new CalculatorContext();
            BaseNumber = baseNumber;
        }

        public void Evaluate()
        {
            if (_context.InputQueue.Any())
            {
                NumericalExpression = CalculatorHelper.CreateNumericalExpression(_context.InputQueue, BaseNumber);

                if (_context.UnmatchedParenthesisCount == 0)
                {
                    var infixExpressions = _context.InputQueue.ToList();
                    var postfixExpressions = ShuntingYard.InfixToPostfix(infixExpressions);
                    var rootExpression = EvaluatePostfix(postfixExpressions);
                    var result = rootExpression.Evaluate();
                    Operand = result;
                    _operandInputted = false;
                }
            }
        }

        private IExpression EvaluatePostfix(IEnumerable<IExpression> postfixExpressions)
        {
            var stack = new Stack<IExpression>();
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

        public void InsertNumber(Numbers number)
        {
            if (IsInputSubmitted)
            {
                _context.Clear();
                NumericalExpression = null;
            }

            var isNegative = Operand < 0;
            var newOperand = _operandInputted ? Math.Abs(Operand) : 0;
            newOperand = CalculatorHelper.InsertNumberAtRight(BaseNumber, newOperand, (long)number);
            newOperand = isNegative ? -newOperand : newOperand;

            Operand = newOperand;
            _operandInputted = true;
        }

        public void RemoveNumber()
        {
            var isNegative = Operand < 0;
            var newOperand = Math.Abs(Operand);
            newOperand = CalculatorHelper.RemoveNumberAtRight(BaseNumber, newOperand);
            newOperand = isNegative ? -newOperand : newOperand;

            Operand = newOperand;
            _operandInputted = newOperand != 0;
        }

        public void ClearInput()
        {
            if (Operand != 0)
            {
                Operand = 0;

                if (!IsInputSubmitted && _context.UnmatchedParenthesisCount != 0)
                {
                    _context.InputQueue = new Queue<IExpression>(RemoveLastMatchedExpression(_context.InputQueue));
                    NumericalExpression = CalculatorHelper.CreateNumericalExpression(_context.InputQueue, BaseNumber);
                }
            }
            else
            {
                _context.Clear();
                NumericalExpression = null;
            }
        }

        public void SubmitInput()
        {
            if (!IsInputSubmitted)
            {
                // 입력 큐가 비었거나 마지막 토큰이 여는 괄호, 이항 연산자일 경우 피연산자 추가
                var last = _context.InputQueue.LastOrDefault();
                if (last == null ||
                    last is OpenParenthesisExpression ||
                    last is BinaryOperatorExpression)
                {
                    _context.InputQueue.Enqueue(new OperandExpression(Operand));
                }

                // 닫는 괄호 추가
                while (_context.UnmatchedParenthesisCount > 0)
                {
                    _context.InputQueue.Enqueue(new CloseParenthesisExpression());
                    _context.UnmatchedParenthesisCount--;
                }

                _context.InputQueue.Enqueue(new SubmitExpression());
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
                    return EnqueueUnaryOperator(op);
                case OperatorType.Binary:
                    return EnqueueBinaryOperator(op);
                case OperatorType.Auxiliary:
                    return EnqueueAuxiliaryOperator(op); 
            }

            return false;
        }

        private bool EnqueueUnaryOperator(Operators unaryOperator)
        {
            if (unaryOperator == Operators.Negate)
            {
                if (Operand == 0)
                {
                    return false;
                }

                if (_operandInputted)
                {
                    Operand = -Operand;
                    return false;
                }
            }

            // 코드 개선 필요
            if (_context.InputQueue.LastOrDefault() is UnaryOperatorExpression)
            {
                var count = 0;
                foreach (var expression in _context.InputQueue.Reverse())
                {
                    if (expression is UnaryOperatorExpression)
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }

                var temp = new List<IExpression>(_context.InputQueue.Take(_context.InputQueue.Count - count));
                temp.Add(CalculatorHelper.CreateExpression(unaryOperator));
                _context.InputQueue = new Queue<IExpression>(temp.Concat(_context.InputQueue.Skip(_context.InputQueue.Count - count)));
            }
            else
            {
                _context.InputQueue.Enqueue(new OperandExpression(Operand));
                _context.InputQueue.Enqueue(CalculatorHelper.CreateExpression(unaryOperator));
            }

            return true;
        }

        private bool EnqueueBinaryOperator(Operators binaryOperator)
        {
            if (_operandInputted)
            {
                // Input Queue에 추가된 마지막 토큰이 닫는 괄호가 아닐 경우에만 피연산자 추가
                if (!(_context.InputQueue.LastOrDefault() is CloseParenthesisExpression))
                {
                    _context.InputQueue.Enqueue(new OperandExpression(Operand));
                }
            }
            else
            {
                // Input Queue에 추가된 마지막 토큰이 이항 연산자이면 제거
                if (_context.InputQueue.LastOrDefault() is BinaryOperatorExpression)
                {
                    _context.InputQueue = new Queue<IExpression>(_context.InputQueue.Take(_context.InputQueue.Count - 1));
                }
            }

            // Input Queue에 이항 연산자 추가
            _context.InputQueue.Enqueue(CalculatorHelper.CreateExpression(binaryOperator));

            return true;
        }

        private bool EnqueueAuxiliaryOperator(Operators auxiliaryOperator)
        {
            switch (auxiliaryOperator)
            {
                case Operators.OpenParenthesis:
                    var last = _context.InputQueue.LastOrDefault();
                    // 마지막 토큰이 이항 연산자일 경우 피연산자 초기화
                    if (last is BinaryOperatorExpression)
                    {
                        Operand = 0;
                        _operandInputted = false;
                    }
                    // 마지막 토큰이 피연산자, NOT 연산자, 닫는 괄호일 경우 곱하기 연산자 추가
                    else if (last is OperandExpression ||
                        last is BitwiseNOTExpression ||
                        last is CloseParenthesisExpression)
                    {
                        _context.InputQueue.Enqueue(new MultiplyExpression());
                    }
                    // 마지막 토큰이 Negate 연산자일 경우 피연산자와 Negate 연산자 제거
                    else if (last is NegateExpression)
                    {
                        _context.InputQueue = new Queue<IExpression>(_context.InputQueue.Take(_context.InputQueue.Count - 2));
                        NumericalExpression = CalculatorHelper.CreateNumericalExpression(_context.InputQueue, BaseNumber);
                    }
                    _context.InputQueue.Enqueue(new OpenParenthesisExpression());
                    _context.UnmatchedParenthesisCount++;
                    break;
                case Operators.CloseParenthesis:
                    if (_context.UnmatchedParenthesisCount > 0)
                    {
                        if (_context.InputQueue.LastOrDefault() is OpenParenthesisExpression)
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
                    SubmitInput();
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
