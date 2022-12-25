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
                ExpressionEvaluated?.Invoke(this, new ExpressionEvaluatedEventArgs(_context.Operand, _context.Expression));
            }
        }

        public void InsertNumber(Numbers number)
        {
            CurrentOperand = CalculatorHelper.InsertNumberAtRight(_context.BaseNumber, _context.Operand, (long)number);
        }

        public void RemoveNumber()
        {
            CurrentOperand = CalculatorHelper.RemoveNumberAtRight(_context.BaseNumber, _context.Operand);
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
