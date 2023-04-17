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
    public class Calculator : ICalculator
    {
        private string expression;
        public string Expression
        {
            get => expression;
            private set
            {
                if (expression != value)
                {
                    expression = value;
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

        private BaseNumber baseNumber;
        public BaseNumber BaseNumber
        {
            get => baseNumber;
            set
            {
                if (baseNumber != value)
                {
                    baseNumber = value;
                    _operandInputState = OperandInputState.Initialized;
                    EvaluateExpression();
                    NotifyPropertyChanged();
                }
            }
        }

        public bool IsSubmitted
        {
            get => _context.InputDeque.LastOrDefault() is SubmitExpression;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private CalculatorContext _context;
        private OperandInputState _operandInputState;

        public Calculator()
        {
            Initialize();
        }

        public void Initialize()
        {
            _context = new CalculatorContext();
            _operandInputState = OperandInputState.Initialized;
            Expression = string.Empty;
            Operand = 0;
            BaseNumber = BaseNumber.Decimal;
        }

        public void EnqueueToken(Numbers number)
        {
            if (IsSubmitted)
            {
                _context.Clear();
                Expression = string.Empty;
            }

            // 피연산자 입력이 초기화된 상태이고, 입력 데크 마지막 요소가 단항 연산자일 경우 마지막 단항 연산자 제거
            if (_operandInputState == OperandInputState.Initialized && _context.InputDeque.LastOrDefault() is UnaryOperatorExpression)
            {
                _context.InputDeque.DequeueLast();
                EvaluateExpression();
                Operand = CalculatorHelper.InsertNumberAtRight(BaseNumber, 0, (long)number);
            }
            else
            {
                var isNegative = Operand < 0;
                var newOperand = _operandInputState == OperandInputState.Inputted ? Math.Abs(Operand) : 0;
                newOperand = CalculatorHelper.InsertNumberAtRight(BaseNumber, newOperand, (long)number);
                newOperand = isNegative ? -newOperand : newOperand;
                Operand = newOperand;
            }

            _operandInputState = OperandInputState.Inputted;
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

        public void RemoveLastNumberToken()
        {
            var isNegative = Operand < 0;
            var newOperand = Math.Abs(Operand);
            newOperand = CalculatorHelper.RemoveNumberAtRight(BaseNumber, newOperand);
            newOperand = isNegative ? -newOperand : newOperand;

            Operand = newOperand;
            _operandInputState = newOperand == 0 ? OperandInputState.Initialized : OperandInputState.Inputted;
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
            if (last is SubmitExpression)
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

            _operandInputState = OperandInputState.Initialized;
        }

        public void ClearInput()
        {
            if (Operand != 0)
            {
                if (!IsSubmitted)
                {
                    RemoveLastMatchedExpression();
                    EvaluateExpression();
                }

                Operand = 0;
            }
            else
            {
                _context.Clear();
                Expression = string.Empty;
            }
        }

        public void SubmitInput()
        {
            if (IsSubmitted)
            {
                // Submit 토큰 제거
                _context.InputDeque.DequeueLast();

                // 피연산자 하나만 있을 경우
                if (_context.InputDeque.Count == 1 && _context.InputDeque.First() is OperandExpression operand)
                {
                    _context.InputDeque.Clear();
                    _context.InputDeque.EnqueueLast(operand);
                    _context.InputDeque.EnqueueLast(new SubmitExpression());
                    EvaluateExpression();
                    EvaluateOperand();
                    return;
                }

                IExpression leftOperand;
                IExpression rightOperand;
                IExpression binaryOperator;
                var last = _context.InputDeque.LastOrDefault();
                // 마지막 토큰이 단항 연산자일 경우
                if (last is UnaryOperatorExpression)
                {
                    // 수식에 단항 연산자 외의 토큰이 있지 않을 경우
                    if (_context.InputDeque.Count == 1)
                    {
                        _context.InputDeque.Clear();
                        _context.InputDeque.EnqueueLast(new OperandExpression(Operand));
                        _context.InputDeque.EnqueueLast(new SubmitExpression());
                        EvaluateExpression();
                        EvaluateOperand();
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

                _context.InputDeque.Clear();
                _context.InputDeque.EnqueueLast(leftOperand);
                _context.InputDeque.EnqueueLast(binaryOperator);
                _context.InputDeque.EnqueueLast(rightOperand);
                _context.InputDeque.EnqueueLast(new SubmitExpression());
            }
            else
            {
                // 입력 데크가 비었거나 마지막 토큰이 이항 연산자, 여는 괄호일 경우 피연산자 추가
                var last = _context.InputDeque.LastOrDefault();
                if (last == null || last is BinaryOperatorExpression || CalculatorHelper.IsOpenParenthesis(last))
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
                else if (deque.Last() is ParenthesisExpression parenthesis)
                {
                    if (parenthesis.IsClosed)
                    {
                        throw new NotImplementedException();
                    }
                    else
                    {
                        throw new InvalidOperationException();
                    }
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

        private void RemoveLastMatchedExpression()
        {
            if (_context.UnmatchedParenthesisCount != 0)
            {
                return;
            }

            if (!(CalculatorHelper.IsCloseParenthesis(_context.InputDeque.LastOrDefault())))
            {
                return;
            }
            
            while (true)
            {
                var last = _context.InputDeque.DequeueLast();
                if (CalculatorHelper.IsOpenParenthesis(last))
                {
                    break;
                }
            }
        }

        private void EnqueueUnaryOperator(Operators op)
        {
            if (op == Operators.Negate)
            {
                if (Operand == 0)
                {
                    return;
                }

                // 피연산자가 입력된 상태일 경우
                if (_operandInputState == OperandInputState.Inputted)
                {
                    Operand = -Operand;
                    return;
                }
            }

            var last = _context.InputDeque.LastOrDefault();
            // 수식이 평가된 상태일 경우
            if (last is SubmitExpression)
            {
                // 입력 데크 클리어 후 이전 수식에서 평가된 값을 단항 연산자의 피연산자로 추가
                _context.InputDeque.Clear();
                _context.InputDeque.EnqueueLast(CalculatorHelper.CreateUnaryExpression(op, new OperandExpression(Operand)));
            }
            // 마지막 토큰이 닫는 괄호일 경우
            else if (CalculatorHelper.IsCloseParenthesis(last))
            {
                // 괄호를 포함한 단항 연산자 추가
                _context.InputDeque.EnqueueLast(CalculatorHelper.CreateUnaryExpression(op, _context.InputDeque.DequeueLast()));
            }
            // 마지막 토큰이 단항 연산자일 경우
            else if (last is UnaryOperatorExpression)
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
                _operandInputState = OperandInputState.Initialized;
                return;
            }

            _operandInputState = OperandInputState.Initialized;
            Evaluate();
        }

        private void EnqueueBinaryOperator(Operators op)
        {
            var last = _context.InputDeque.LastOrDefault();
            // 수식이 평가된 상태일 경우
            if (last is SubmitExpression)
            {
                // 입력 데크 클리어 후 이전 수식에서 평가된 값을 왼쪽 피연산자로 추가
                _context.InputDeque.Clear();
                _context.InputDeque.EnqueueLast(new OperandExpression(Operand));
            }
            // 피연산자 입력이 초기화된 상태일 경우
            else if (_operandInputState == OperandInputState.Initialized)
            {
                if (last is BinaryOperatorExpression binaryOperator)
                {
                    // 마지막 토큰인 이항 연산자와 같은 이항 연산자이면 리턴
                    if (binaryOperator.OperatorDescriptor.Operator == op)
                    {
                        return;
                    }
                    // 그렇지 않으면 연산자만 교체
                    else
                    {
                        _context.InputDeque.DequeueLast();
                        _context.InputDeque.EnqueueLast(CalculatorHelper.CreateBinaryExpression(op));
                        Evaluate();
                        return;
                    }
                }
            }
            // 마지막 토큰이 닫는 괄호가 아니면 피연산자 추가
            else if (!(CalculatorHelper.IsCloseParenthesis(last)))
            {
                _context.InputDeque.EnqueueLast(new OperandExpression(Operand));
            }

            // 이항 연산자 추가
            _context.InputDeque.EnqueueLast(CalculatorHelper.CreateBinaryExpression(op));

            _operandInputState = OperandInputState.Initialized;
            Evaluate();
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
                    RemoveLastNumberToken();
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
            if (last is SubmitExpression)
            {
                // 입력 데크 클리어 후 여는 괄호 추가
                _context.InputDeque.Clear();
                _context.InputDeque.EnqueueLast(new ParenthesisExpression());
                _context.UnmatchedParenthesisCount++;
                _operandInputState = OperandInputState.Inputted;
                EvaluateExpression();
                return;
            }

            // 마지막 토큰이 이항 연산자일 경우 피연산자 초기화
            if (last is BinaryOperatorExpression)
            {
                Operand = 0;
                _operandInputState = OperandInputState.Initialized;
            }
            // 마지막 토큰이 NOT 연산자, 닫는 괄호일 경우 곱하기 연산자 추가
            else if (last is BitwiseNOTExpression || CalculatorHelper.IsCloseParenthesis(last))
            {
                _context.InputDeque.EnqueueLast(CalculatorHelper.CreateBinaryExpression(Operators.Multiply));
            }
            // 마지막 토큰이 Negate 연산자일 경우 제거
            else if (last is NegateExpression)
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
            if (last is SubmitExpression)
            {
                // 입력 데크 클리어
                _context.InputDeque.Clear();
                _operandInputState = OperandInputState.Inputted;
                EvaluateExpression();
                return;
            }
            
            if (_context.UnmatchedParenthesisCount > 0)
            {
                // 마지막 토큰이 이항 연산자, 여는 괄호일 경우 피연산자 추가
                if (last is BinaryOperatorExpression || CalculatorHelper.IsOpenParenthesis(last))
                {
                    _context.InputDeque.EnqueueLast(new OperandExpression(Operand));
                }

                // 닫는 괄호 추가
                var stack = new Stack<IExpression>();
                while (!CalculatorHelper.IsOpenParenthesis(_context.InputDeque.Last()))
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

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
