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
        private int _openedParenthesisCount;

        public Calculator(BaseNumber baseNumber = BaseNumber.Decimal)
        {
            _context = new CalculatorContext();
            _userOperandInitialized = true;
            _openedParenthesisCount = 0;
            BaseNumber = baseNumber;
        }

        public void Evaluate()
        {
            if (_context.InputQueue.Any())
            {
                NumericalExpression = CalculatorHelper.CreateNumericalExpression(_context.InputQueue);

                if (_openedParenthesisCount == 0)
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
            }
            else
            {
                NumericalExpression = null;
            }
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
            _context.InputQueue.Enqueue(new OperandExpression(Operand));
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
                            _context.InputQueue.Enqueue(new OperandExpression(Operand));
                        }
                        _context.InputQueue.Enqueue(new CloseParenthesisExpression());
                        _openedParenthesisCount--;
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
