using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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
                    UpdateExpression();
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

        public bool IsInputSubmitted
        {
            get => _context.InputDeque.LastOrDefault() is SubmitExpression;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private CalculatorContext _context;
        private bool _operandInputted = false;

        public Calculator(BaseNumber baseNumber = BaseNumber.Decimal)
        {
            _context = new CalculatorContext();
            BaseNumber = baseNumber;
        }

        public void EnqueueToken(Numbers number)
        {
            if (IsInputSubmitted)
            {
                _context.Clear();
                Expression = string.Empty;
            }

            var isNegative = Operand < 0;
            var newOperand = _operandInputted ? Math.Abs(Operand) : 0;
            newOperand = CalculatorHelper.InsertNumberAtRight(BaseNumber, newOperand, (long)number);
            newOperand = isNegative ? -newOperand : newOperand;

            Operand = newOperand;
            _operandInputted = true;
        }

        public bool EnqueueToken(Operators op)
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

        public void RemoveLastNumberToken()
        {
            var isNegative = Operand < 0;
            var newOperand = Math.Abs(Operand);
            newOperand = CalculatorHelper.RemoveNumberAtRight(BaseNumber, newOperand);
            newOperand = isNegative ? -newOperand : newOperand;

            Operand = newOperand;
            _operandInputted = newOperand != 0;
        }

        public void Evaluate()
        {
            if (_context.InputDeque.Any())
            {
                UpdateExpression();
                UpdateOperand();
            }
        }

        private void UpdateExpression()
        {
            var sb = new StringBuilder();
            foreach (var input in _context.InputDeque)
            {
                sb.Append(input.EvaluateExpression(BaseNumber));
                sb.Append(' ');
            }

            Expression = sb.ToString();
        }

        private void UpdateOperand()
        {
            if (_context.UnmatchedParenthesisCount != 0)
            {
                return;
            }

            var clonedInputDeque = _context.InputDeque.Select(input => (IExpression)input.Clone());
            var rootExpression = CalculatorHelper.BuildRootExpression(clonedInputDeque);
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

            _operandInputted = false;
        }

        public void ClearInput()
        {
            if (Operand != 0)
            {
                if (!IsInputSubmitted)
                {
                    RemoveLastMatchedExpression();
                    UpdateExpression();
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
            if (!IsInputSubmitted)
            {
                var last = _context.InputDeque.LastOrDefault();
                // 입력 데크가 비었거나 마지막 토큰이 여는 괄호, 이항 연산자일 경우 피연산자 추가
                if (last == null || last is OpenParenthesisExpression || last is BinaryOperatorExpression)
                {
                    _context.InputDeque.EnqueueLast(new OperandExpression(Operand));
                }

                // 닫히지 않은 모든 괄호를 닫음
                CloseAllParenthesis();

                _context.InputDeque.EnqueueLast(new SubmitExpression());
            }
        }

        private void RemoveLastMatchedExpression()
        {
            if (_context.UnmatchedParenthesisCount != 0)
            {
                return;
            }

            if (!(_context.InputDeque.LastOrDefault() is CloseParenthesisExpression))
            {
                return;
            }
            
            while (true)
            {
                var last = _context.InputDeque.DequeueLast();
                if (last is OpenParenthesisExpression)
                {
                    break;
                }
            }
        }

        private bool EnqueueUnaryOperator(Operators op)
        {
            if (op == Operators.Negate)
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

            var last = _context.InputDeque.LastOrDefault();
            // 마지막 토큰이 단항 연산자일 경우
            if (last is UnaryOperatorExpression)
            {
                _context.InputDeque.DequeueLast();
                _context.InputDeque.EnqueueLast(CalculatorHelper.CreateUnaryExpression(op, last));
            }
            // 마지막 토큰이 닫는 괄호일 경우
            else if (last is CloseParenthesisExpression)
            {
                throw new NotImplementedException();
            }
            else
            {
                // 단항 연산자 추가
                _context.InputDeque.EnqueueLast(CalculatorHelper.CreateUnaryExpression(op, new OperandExpression(Operand)));
            }

            return true;
        }

        private bool EnqueueBinaryOperator(Operators op)
        {
            var last = _context.InputDeque.LastOrDefault();
            // 피연산자가 입력되지 않았을 경우
            if (!_operandInputted)
            {
                if (last is BinaryOperatorExpression binaryOperator)
                {
                    // 마지막 토큰인 이항 연산자와 같은 이항 연산자이면 리턴
                    if (binaryOperator.OperatorDescriptor.Operator == op)
                    {
                        return false;
                    }
                    // 그렇지 않으면 연산자만 교체
                    else
                    {
                        _context.InputDeque.DequeueLast();
                        _context.InputDeque.EnqueueLast(CalculatorHelper.CreateBinaryExpression(op));
                        return true;
                    }
                }
            }

            // 마지막 토큰이 닫는 괄호가 아니면 피연산자 추가
            if (!(last is CloseParenthesisExpression))
            {
                _context.InputDeque.EnqueueLast(new OperandExpression(Operand));
            }

            // 이항 연산자 추가
            _context.InputDeque.EnqueueLast(CalculatorHelper.CreateBinaryExpression(op));

            _operandInputted = false;
            return true;
        }

        private bool EnqueueAuxiliaryOperator(Operators op)
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
                    break;
                case Operators.Backspace:
                    RemoveLastNumberToken();
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

        private void EnqueueOpenParenthesis()
        {
            var last = _context.InputDeque.LastOrDefault();
            // 마지막 토큰이 이항 연산자일 경우 피연산자 초기화
            if (last is BinaryOperatorExpression)
            {
                Operand = 0;
                _operandInputted = false;
            }
            // 마지막 토큰이 NOT 연산자, 닫는 괄호일 경우 곱하기 연산자 추가
            else if (last is BitwiseNOTExpression || last is CloseParenthesisExpression)
            {
                _context.InputDeque.EnqueueLast(CalculatorHelper.CreateBinaryExpression(Operators.Multiply));
            }
            // 마지막 토큰이 Negate 연산자일 경우 제거
            else if (last is NegateExpression)
            {
                _context.InputDeque.DequeueLast();
            }

            // 여는 괄호 추가
            _context.InputDeque.EnqueueLast(new OpenParenthesisExpression());
            _context.UnmatchedParenthesisCount++;
        }

        private void EnqueueCloseParenthesis()
        {
            if (_context.UnmatchedParenthesisCount <= 0)
            {
                return;
            }

            var last = _context.InputDeque.LastOrDefault();
            // 마지막 토큰이 여는 괄호, 이항 연산자일 경우 피연산자 추가
            if (last is OpenParenthesisExpression || last is BinaryOperatorExpression)
            {
                _context.InputDeque.EnqueueLast(new OperandExpression(Operand));
            }

            // 닫는 괄호 추가
            _context.InputDeque.EnqueueLast(new CloseParenthesisExpression());
            _context.UnmatchedParenthesisCount--;
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
