using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calculator
    {
        private CalculatorContext _context;
        private bool _firstExpression;
        private readonly Stack<ICalculatorExpression> _expressions;

        public Calculator()
        {
            _expressions = new Stack<ICalculatorExpression>();
        }

        public void SetContext(CalculatorContext context)
        {
            _context = context;
            _firstExpression = true;
            _expressions.Clear();
        }

        public void PushExpression(Operators op, long operand)
        {
            var expression = CalculationHelper.CreateExpression(op, operand);
            PushExpression(expression);
        }

        public void PushExpression(ICalculatorExpression expression)
        {
            if (expression != null)
            {
                _expressions.Push(expression);
            }
        }

        public void PopExpression()
        {
            if (_expressions.Any())
            {
                _expressions.Pop();
            }
        }

        public void Evaluate()
        {
            if (_context != null)
            {
                while (_expressions.Any())
                {
                    var expression = _expressions.Pop();
                    expression.Evaluate(_context, _firstExpression);
                    _firstExpression = false;
                }
            }
        }
    }
}
