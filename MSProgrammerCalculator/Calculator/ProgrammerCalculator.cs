using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class ProgrammerCalculator : ICalculator
    {
        private string expression;
        public string Expression
        {
            get => expression;
            private set => SetProperty(ref expression, value);
        }

        private long operand;
        public long Operand
        {
            get => operand;
            private set => SetProperty(ref operand, value);
        }

        private BaseNumber baseNumber;
        public BaseNumber BaseNumber
        {
            get => baseNumber;
            set => SetProperty(ref baseNumber, value, OnBaseNumberChanged);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private CalculatorContext _context;
        private OperandInputState _inputState;

        public ProgrammerCalculator()
        {
            Initialize();
        }

        public void Initialize()
        {
            _context = new CalculatorContext();
            _inputState = OperandInputState.Initialized;
            Expression = string.Empty;
            Operand = 0;
            BaseNumber = BaseNumber.Decimal;
        }

        private void OnBaseNumberChanged()
        {
            _inputState = OperandInputState.Initialized;
            EvaluateExpression();
        }

        public void EnqueueToken(Numbers number)
        {
            var last = _context.InputDeque.LastOrDefault();
            // 수식이 평가된 상태일 경우
            if (IsSubmit(last))
            {
                _context.Clear();
                Expression = string.Empty;
            }

            // 마지막 토큰이 단항 연산자일 경우
            if (IsUnaryOperator(last))
            {
                // 마지막 단항 연산자 제거
                _context.InputDeque.DequeueLast();
                EvaluateExpression();
                Operand = CalculatorHelper.InsertRightDigit(BaseNumber, 0, (long)number);
            }
            // 마지막 토큰이 닫힌 괄호이고, 입력 데크에 토큰이 2개 이상 추가된 상태일 경우 
            else if (IsCloseParenthesis(last) && _context.InputDeque.Count > 1)
            {
                // 마지막 닫힌 괄호 제거
                _context.InputDeque.DequeueLast();
                EvaluateExpression();
                Operand = CalculatorHelper.InsertRightDigit(BaseNumber, 0, (long)number);
            }
            else
            {
                var isNegative = Operand < 0;
                var newOperand = _inputState == OperandInputState.Inputted ? Math.Abs(Operand) : 0;
                newOperand = CalculatorHelper.InsertRightDigit(BaseNumber, newOperand, (long)number);
                newOperand = isNegative ? -newOperand : newOperand;
                Operand = newOperand;
            }

            _inputState = OperandInputState.Inputted;
        }

        public void EnqueueToken(Operators op)
        {
            switch (CalculatorHelper.GetOperatorType(op))
            {
                case OperatorType.Unary:
                    EnqueueUnaryOperator(op);
                    break;
                case OperatorType.Binary:
                    EnqueueBinaryOperator(op);
                    break;
                case OperatorType.Auxiliary:
                    EnqueueAuxiliaryOperator(op);
                    break;
            }
        }

        public void RemoveOperandRightDigit()
        {
            var isNegative = Operand < 0;
            var newOperand = Math.Abs(Operand);
            newOperand = CalculatorHelper.RemoveRightDigit(BaseNumber, newOperand);
            newOperand = isNegative ? -newOperand : newOperand;
            Operand = newOperand;
            _inputState = newOperand == 0 ? OperandInputState.Initialized : OperandInputState.Inputted;
        }

        public void Evaluate()
        {
            if (_context.InputDeque.Any())
            {
                EvaluateExpression();
                EvaluateOperand();
            }
        }

        private void EvaluateExpression()
        {
            var sb = new StringBuilder();
            foreach (var input in _context.InputDeque)
            {
                sb.Append(input.EvaluateExpression(BaseNumber));
                sb.Append(' ');
            }

            Expression = sb.ToString();
        }

        private void EvaluateOperand()
        {
            if (_context.UnmatchedParenthesisCount != 0)
            {
                return;
            }

            var clonedInputs = _context.InputDeque.Select(input => (IExpression)input.Clone());
            var rootExpression = CalculatorHelper.BuildRootExpression(clonedInputs);
            var result = rootExpression.EvaluateResult();
            var last = _context.InputDeque.LastOrDefault();
            // 수식이 평가된 상태일 경우
            if (IsSubmit(last))
            {
                Operand = result;
            }
            else if (rootExpression is BinaryOperatorExpression binaryOperator && binaryOperator.RightOperand != null)
            {
                Operand = binaryOperator.RightOperand.EvaluateResult();
            }
            else
            {
                Operand = result;
            }

            _inputState = OperandInputState.Initialized;
        }

        public void ClearInput()
        {
            if (Operand != 0)
            {
                Operand = 0;

                var last = _context.InputDeque.LastOrDefault();
                // 마지막 토큰이 닫힌 괄호이고, 수식이 평가된 상태가 아닐 경우
                if (IsCloseParenthesis(last) && !IsSubmit(last))
                {
                    // 마지막 닫힌 괄호 제거
                    _context.InputDeque.DequeueLast();
                    EvaluateExpression();
                }
            }
            else
            {
                _context.Clear();
                Expression = string.Empty;
            }
        }

        public void SubmitInput()
        {
            var last = _context.InputDeque.LastOrDefault();
            // 수식이 평가된 상태일 경우
            if (IsSubmit(last))
            {
                // 수식에 피연산자 하나만 존재할 경우 (예를 들어, "2 = ")
                if (_context.InputDeque.Count == 2 && IsOperand(_context.InputDeque.First()))
                {
                    return;
                }

                // Submit 토큰 제거
                _context.InputDeque.DequeueLast();

                IExpression leftOperand;
                IExpression rightOperand;
                IExpression binaryOperator;
                // 마지막 토큰이 단항 연산자일 경우
                if (IsUnaryOperator(_context.InputDeque.LastOrDefault()))
                {
                    // 수식에 단항 연산자 외의 토큰이 있지 않을 경우
                    if (_context.InputDeque.Count == 1)
                    {
                        _context.Clear();
                        _context.InputDeque.EnqueueLast(new OperandExpression(Operand));
                        _context.InputDeque.EnqueueLast(new SubmitExpression());
                        Evaluate();
                        return;
                    }
                    // 수식에 단항 연산자 외의 토큰이 있을 경우
                    else
                    {
                        var subRootExpression = BuildSubRootExpressionFromLast();
                        leftOperand = new OperandExpression(Operand);
                        rightOperand = new OperandExpression(subRootExpression.EvaluateResult());
                        binaryOperator = _context.InputDeque.DequeueLast();
                    }
                }
                // 마지막 토큰이 이항 연산자일 경우
                else
                {
                    leftOperand = new OperandExpression(Operand);
                    rightOperand = _context.InputDeque.DequeueLast();
                    binaryOperator = _context.InputDeque.DequeueLast();
                }

                _context.Clear();
                _context.InputDeque.EnqueueLast(leftOperand);
                _context.InputDeque.EnqueueLast(binaryOperator);
                _context.InputDeque.EnqueueLast(rightOperand);
                _context.InputDeque.EnqueueLast(new SubmitExpression());
            }
            else
            {
                // 입력 데크가 비었거나 마지막 토큰이 이항 연산자, 여는 괄호일 경우 피연산자 추가
                if (last == null || IsBinaryOperator(last) || IsOpenParenthesis(last))
                {
                    _context.InputDeque.EnqueueLast(new OperandExpression(Operand));
                }

                // 닫히지 않은 모든 괄호를 닫음
                CloseAllParenthesis();

                _context.InputDeque.EnqueueLast(new SubmitExpression());
            }

            Evaluate();
        }

        private IExpression BuildSubRootExpressionFromLast()
        {
            var deque = _context.InputDeque;
            if (deque.Any())
            {
                if (deque.Count == 1)
                {
                    return deque.DequeueFirst();
                }
                else if (IsOpenParenthesis(deque.Last()))
                {
                    throw new InvalidOperationException();
                }
                else if (IsCloseParenthesis(deque.Last()))
                {
                    throw new NotImplementedException();
                }
                else
                {
                    var stack = new Stack<IExpression>();
                    stack.Push(deque.DequeueLast());
                    while (deque.Any())
                    {
                        if (deque.Last() is BinaryOperatorExpression binaryOperator && binaryOperator.OperatorDescriptor.Precedence == 3)
                        {
                            stack.Push(deque.DequeueLast()); // 이항 연산자
                            stack.Push(deque.DequeueLast()); // 왼쪽 피연산자
                        }
                        else
                        {
                            break;
                        }
                    }

                    return CalculatorHelper.BuildRootExpression(stack);
                }
            }

            return null;
        }

        private void EnqueueUnaryOperator(Operators op)
        {
            if (op == Operators.Negate)
            {
                // 피연산자가 0일 경우 바로 리턴
                if (Operand == 0)
                {
                    return;
                }

                // 피연산자가 입력된 상태일 경우
                if (_inputState == OperandInputState.Inputted)
                {
                    Operand = -Operand;
                    return;
                }
            }

            var last = _context.InputDeque.LastOrDefault();
            // 수식이 평가된 상태일 경우
            if (IsSubmit(last))
            {
                // 입력 데크 클리어 후 이전 수식에서 평가된 값을 단항 연산자의 피연산자로 추가
                _context.Clear();
                _context.InputDeque.EnqueueLast(CalculatorHelper.CreateUnaryExpression(op, new OperandExpression(Operand)));
            }
            // 마지막 토큰이 닫는 괄호일 경우
            else if (IsCloseParenthesis(last))
            {
                // 괄호를 포함한 단항 연산자 추가
                _context.InputDeque.EnqueueLast(CalculatorHelper.CreateUnaryExpression(op, _context.InputDeque.DequeueLast()));
            }
            // 마지막 토큰이 단항 연산자일 경우
            else if (IsUnaryOperator(last))
            {
                _context.InputDeque.DequeueLast();
                _context.InputDeque.EnqueueLast(CalculatorHelper.CreateUnaryExpression(op, last));
            }
            else
            {
                // 피연산자를 포함한 단항 연산자 추가
                var unaryOperator = CalculatorHelper.CreateUnaryExpression(op, new OperandExpression(Operand));
                _context.InputDeque.EnqueueLast(unaryOperator);
                EvaluateExpression();
                Operand = unaryOperator.EvaluateResult();
                _inputState = OperandInputState.Initialized;
                return;
            }

            // 수식 평가
            Evaluate();

            _inputState = OperandInputState.Initialized;
        }

        private void EnqueueBinaryOperator(Operators op)
        {
            var last = _context.InputDeque.LastOrDefault();
            // 수식이 평가된 상태일 경우
            if (IsSubmit(last))
            {
                // 입력 데크 클리어 후 이전 수식에서 평가된 값을 왼쪽 피연산자로 추가
                _context.Clear();
                _context.InputDeque.EnqueueLast(new OperandExpression(Operand));
                _context.InputDeque.EnqueueLast(CalculatorHelper.CreateBinaryExpression(op));
            }
            // 피연산자 입력이 초기화된 상태이고 마지막 토큰이 이항 연산자일 경우
            else if (_inputState == OperandInputState.Initialized && last is BinaryOperatorExpression binaryOperator)
            {
                // 마지막 토큰인 이항 연산자와 다른 이항 연산자이면 연산자 교체
                if (binaryOperator.OperatorDescriptor.Operator != op)
                {
                    _context.InputDeque.DequeueLast();
                    _context.InputDeque.EnqueueLast(CalculatorHelper.CreateBinaryExpression(op));
                }
            }
            else
            {
                // 마지막 토큰이 닫는 괄호가 아니면 피연산자 추가
                if (!IsCloseParenthesis(last))
                {
                    _context.InputDeque.EnqueueLast(new OperandExpression(Operand));
                }

                // 이항 연산자 추가
                _context.InputDeque.EnqueueLast(CalculatorHelper.CreateBinaryExpression(op));
            }

            // 수식 평가
            Evaluate();

            _inputState = OperandInputState.Initialized;
        }

        private void EnqueueAuxiliaryOperator(Operators op)
        {
            switch (op)
            {
                case Operators.OpenParenthesis:
                    EnqueueOpenParenthesis();
                    break;
                case Operators.CloseParenthesis:
                    EnqueueCloseParenthesis();
                    break;
                case Operators.DecimalSeparator:
                    throw new NotSupportedException();
                case Operators.Backspace:
                    RemoveOperandRightDigit();
                    break;
                case Operators.Clear:
                    ClearInput();
                    break;
                case Operators.Submit:
                    SubmitInput();
                    break;
            }
        }

        private void EnqueueOpenParenthesis()
        {
            var last = _context.InputDeque.LastOrDefault();
            // 수식이 평가된 상태일 경우
            if (IsSubmit(last))
            {
                // 입력 데크 클리어 후 여는 괄호 추가
                _context.Clear();
                _context.InputDeque.EnqueueLast(new ParenthesisExpression());
                _context.UnmatchedParenthesisCount++;
                _inputState = OperandInputState.Inputted;
                EvaluateExpression();
                return;
            }
            // 마지막 토큰이 이항 연산자일 경우 피연산자 초기화
            else if (IsBinaryOperator(last))
            {
                Operand = 0;
                _inputState = OperandInputState.Initialized;
            }
            // 마지막 토큰이 NOT 연산자, 닫는 괄호일 경우 곱하기 연산자 추가
            else if (IsBitwiseNOT(last) || IsCloseParenthesis(last))
            {
                _context.InputDeque.EnqueueLast(CalculatorHelper.CreateBinaryExpression(Operators.Multiply));
            }
            // 마지막 토큰이 Negate 연산자일 경우 제거
            else if (IsNegate(last))
            {
                _context.InputDeque.DequeueLast();
            }

            // 여는 괄호 추가
            _context.InputDeque.EnqueueLast(new ParenthesisExpression());
            _context.UnmatchedParenthesisCount++;

            Evaluate();
        }

        private void EnqueueCloseParenthesis()
        {
            var last = _context.InputDeque.LastOrDefault();
            // 수식이 평가된 상태일 경우
            if (IsSubmit(last))
            {
                // 입력 데크 클리어
                _context.Clear();
                _inputState = OperandInputState.Inputted;
                EvaluateExpression();
                return;
            }
            else if (_context.UnmatchedParenthesisCount > 0)
            {
                // 마지막 토큰이 이항 연산자, 여는 괄호일 경우 피연산자 추가
                if (IsBinaryOperator(last) || IsOpenParenthesis(last))
                {
                    _context.InputDeque.EnqueueLast(new OperandExpression(Operand));
                }

                // 닫는 괄호 추가
                var stack = new Stack<IExpression>();
                while (!IsOpenParenthesis(_context.InputDeque.Last()))
                {
                    stack.Push(_context.InputDeque.DequeueLast());
                }
                var parenthesisExpression = (ParenthesisExpression)_context.InputDeque.Last();
                var subRootExpression = CalculatorHelper.BuildRootExpression(stack);
                parenthesisExpression.Operand = subRootExpression;
                parenthesisExpression.IsClosed = true;
                _context.UnmatchedParenthesisCount--;
            }

            Evaluate();
        }

        private void CloseAllParenthesis()
        {
            while (_context.UnmatchedParenthesisCount > 0)
            {
                EnqueueCloseParenthesis();
            }
        }

        private bool IsOperand(IExpression expression) => expression is OperandExpression;

        private bool IsUnaryOperator(IExpression expression) => expression is UnaryOperatorExpression;

        private bool IsBinaryOperator(IExpression expression) => expression is BinaryOperatorExpression;

        private bool IsOpenParenthesis(IExpression expression) => expression is ParenthesisExpression parenthesis && !parenthesis.IsClosed;

        private bool IsCloseParenthesis(IExpression expression) => expression is ParenthesisExpression parenthesis && parenthesis.IsClosed;

        private bool IsBitwiseNOT(IExpression expression) => expression is BitwiseNOTExpression;

        private bool IsNegate(IExpression expression) => expression is NegateExpression;

        private bool IsSubmit(IExpression expression) => expression is SubmitExpression;

        private bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            RaisePropertyChanged(propertyName);
            return true;
        }

        private bool SetProperty<T>(ref T storage, T value, Action onChanged, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            onChanged?.Invoke();
            RaisePropertyChanged(propertyName);
            return true;
        }

        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
