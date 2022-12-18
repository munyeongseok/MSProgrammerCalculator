using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calculator : ICalculator
    {
        public long CurrentDisplayValue => _context.Result;

        public string CurrentNumericalExpression => _context.Expression;

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
            }
        }

        public void ChangeBaseNumber(BaseNumber baseNumber)
        {
            _context.BaseNumber = baseNumber;
            _context.Operand = 0;
        }
        public void InsertNumber(Numbers number)
        {
            _context.Operand = CalculatorHelper.InsertNumberAtRight(_context.BaseNumber, _context.Operand, (long)number);
            _context.OperandChanged = true;
        }

        public void RemoveNumber()
        {
            _context.Operand = CalculatorHelper.RemoveNumberAtRight(_context.BaseNumber, _context.Operand);
            _context.OperandChanged = true;
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
