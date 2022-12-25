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
            private set
            {
                if (_context.BaseNumber != value)
                {
                    _context.BaseNumber = value;
                }
            }
        }

        public long CurrentOperand
        {
            get => _context.CurrentOperand;
            private set
            {
                if (_context.CurrentOperand != value)
                {
                    _context.CurrentOperand = value;
                    OperandChanged?.Invoke(this, new OperandChangedEventArgs(value));
                }
            }
        }

        public string CurrentExpression
        {
            get => _context.CurrentExpression;
            private set
            {
                if (_context.CurrentExpression != value)
                {
                    _context.CurrentExpression = value;
                }
            }
        }
        
        public event EventHandler<OperandChangedEventArgs> OperandChanged; 

        public event EventHandler<ExpressionEvaluatedEventArgs> ExpressionEvaluated;

        private CalculationContext _context;

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
        }

        public void Evaluate()
        {
            if (_context.InputQueue.Any())
            {
                var infixExpressions = _context.InputQueue.ToList();
                var postfixExpressions = ShuntingYard.InfixToPostfix(infixExpressions);
                var rootExpression = ShuntingYard.EvaluatePostfix(postfixExpressions);
                var result = rootExpression.Evaluate(null);
                ExpressionEvaluated?.Invoke(this, new ExpressionEvaluatedEventArgs(_context.CurrentOperand, _context.CurrentExpression));
            }
        }

        public void ChangeBaseNumber(BaseNumber baseNumber)
        {
            CurrentBaseNumber = baseNumber;
            CurrentOperand = 0;
        }
        public void InsertNumber(Numbers number)
        {
            CurrentOperand = CalculatorHelper.InsertNumberAtRight(_context.BaseNumber, _context.CurrentOperand, (long)number);
        }

        public void RemoveNumber()
        {
            CurrentOperand = CalculatorHelper.RemoveNumberAtRight(_context.BaseNumber, _context.CurrentOperand);
        }

        public bool TryEnqueueExpression(Operators op)
        {
            var expression = CalculatorHelper.CreateExpression(op);
            if (expression != null)
            {
                _context.InputQueue.Enqueue(expression);
                return true;
            }
            return false;
        }
    }
}
