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

        public void PushUnaryExpression(Operators op)
        {
            var operand = _context.OperandChanged ? _context.Operand : _context.Result;
            var expression = CalculatorHelper.CreateUnaryExpression(op, operand);
            PushExpression(expression);
        }

        public void PushBinaryExpression(Operators op)
        {
            if (_context.OperandChanged)
            {
                var leftOperand = _context.Operand;
                var rightOperanad = _context.Result;
                var expression = CalculatorHelper.CreateBinaryExpression(op, leftOperand, rightOperanad);
                PushExpression(expression);
            }
        }

        public void PushAuxiliaryExpression(Operators op)
        {
            var expression = CalculatorHelper.CreateAuxiliaryExpression(op);
            PushExpression(expression);
        }

        public void PushExpression(IExpression expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            _context.Expressions.Push(expression);
        }

        public void Evaluate()
        {
            if (_context != null)
            {
                //while (_context.Expressions.Any())
                //{
                //    var expression = _context.Expressions.Pop();
                //    expression.Evaluate(_context);
                //}

                //_context.Operand = 0;
                //_context.OperandChanged = false;
            }
        }
    }
}
