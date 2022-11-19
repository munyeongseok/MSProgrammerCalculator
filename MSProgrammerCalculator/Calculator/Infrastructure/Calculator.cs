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

        public void SetBaseNumber(BaseNumber baseNumber)
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

        public void ClearNumber()
        {
            // Operand 초기화 외에 추가 작업 필요
            _context.Operand = 0;
        }

        public void PushUnaryExpression(Operators op)
        {
            var operand = _context.OperandChanged ? _context.Operand : _context.Result;
            var expression = CalculatorHelper.CreateExpression(op, operand);
            PushExpression(expression);
        }

        public void PushBinaryExpression(Operators op)
        {
            if (_context.OperandChanged)
            {
                var operand = _context.Operand;
                var expression = CalculatorHelper.CreateExpression(op, operand);
                PushExpression(expression);
            }
        }

        public void PushExpression(ICalculatorExpression expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            _context.ExpressionStack.Push(expression);
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

                _context.Operand = 0;
                _context.OperandChanged = false;
            }
        }
    }
}
