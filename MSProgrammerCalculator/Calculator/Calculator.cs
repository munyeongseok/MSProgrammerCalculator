using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calculator : ICalculator
    {
        public BaseNumber CurrentBaseNumber
        {
            get => _context.BaseNumber;
            set
            {
                if (_context.BaseNumber != value)
                {
                    _context.BaseNumber = value;
                    CurrentOperand = 0;
                }
            }
        }

        public long CurrentOperand
        {
            get => _context.Operand;
            private set
            {
                if (_context.Operand != value)
                {
                    _context.Operand = value;
                    OperandChanged?.Invoke(this, new OperandChangedEventArgs(CurrentOperand));
                }
            }
        }

        public string CurrentExpression
        {
            get => _context.Expression;
            private set
            {
                if (_context.Expression != value)
                {
                    _context.Expression = value;
                }
            }
        }
        
        public event EventHandler<OperandChangedEventArgs> OperandChanged; 

        public event EventHandler<ExpressionEvaluatedEventArgs> ExpressionEvaluated;

        private CalculationContext _context;
        private bool _operandInitialized;

        public Calculator(BaseNumber baseNumber = BaseNumber.Decimal)
            : this(new CalculationContext(baseNumber))
        {
        }

        public Calculator(CalculationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            _context = context;
            _operandInitialized = true;
        }

        public void Evaluate()
        {
            if (_context.InputQueue.Any())
            {
                _context.Operand = 0;
                _context.Expression = null;
                var infixExpressions = _context.InputQueue.ToList();
                var postfixExpressions = ShuntingYard.InfixToPostfix(infixExpressions);
                var rootExpression = EvaluatePostfix(postfixExpressions);
                var result = rootExpression.Evaluate(_context);
                ExpressionEvaluated?.Invoke(this, new ExpressionEvaluatedEventArgs(_context.Operand, _context.Expression));
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
                    binaryOperator.RightOperand = stack.Pop();
                    binaryOperator.LeftOperand = stack.Pop();
                    stack.Push(binaryOperator);
                }
            }

            return stack.Pop();
        }

        public void InsertNumber(Numbers number)
        {
            CurrentOperand = CalculatorHelper.InsertNumberAtRight(_context.BaseNumber, _context.Operand, (long)number);
            _operandInitialized = false;
        }

        public void RemoveNumber()
        {
            CurrentOperand = CalculatorHelper.RemoveNumberAtRight(_context.BaseNumber, _context.Operand);
            _operandInitialized = CurrentOperand == 0;
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
                if (_operandInitialized)
                {
                    return false;
                }
                
                if (_context.Expression == null)
                {
                    CurrentOperand = -CurrentOperand;
                    return false;
                }
            }

            var unaryOperatorEx = (IUnaryOperatorExpression)CalculatorHelper.CreateExpression(unaryOperator);
            if (_context.InputQueue.Any() && _context.InputQueue.Last() is IUnaryOperatorExpression)
            {
                _context.InputQueue.Enqueue(unaryOperatorEx);
            }
            else
            {
                var operandEx = new OperandExpression(CurrentOperand);
                _context.InputQueue.Enqueue(operandEx);
                _context.InputQueue.Enqueue(unaryOperatorEx);
            }

            return true;
        }

        private bool ProcessBinaryOperation(Operators binaryOperator)
        {
            

            return true;
        }

        private bool ProcessAuxiliaryOperation(Operators auxiliaryOperator)
        {


            return true;
        }
    }
}
