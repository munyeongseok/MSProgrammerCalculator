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

        public Calculator()
        {
        }

        public void SetContext(CalculatorContext context)
        {
            _context = context;
        }

        public void PushUnaryExpression(Operators op, long operand, bool isNewOperanad)
        {
            var expression = CalculationHelper.CreateUnaryExpression(op, operand, isNewOperanad);
            PushExpression(expression);
        }

        public void PushBinaryExpression(Operators op, long operand)
        {
            var expression = CalculationHelper.CreateBinaryExpression(op, operand);
            PushExpression(expression);
        }

        public void PushExpression(ICalculatorExpression expression)
        {
            if (expression != null)
            {
                _context.ExpressionStack.Push(expression);
            }
        }

        public void Evaluate()
        {
            if (_context != null)
            {
                while (_context.ExpressionStack.Any())
                {
                    var expression = _context.ExpressionStack.Pop();
                    expression.Evaluate(_context);
                }
            }
        }
    }
}
