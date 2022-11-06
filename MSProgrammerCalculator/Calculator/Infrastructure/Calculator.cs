﻿using System;
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

        public void PushExpression(Operators op, long operand)
        {
            var expression = CalculationHelper.CreateExpression(op, operand);
            PushExpression(expression);
        }

        public void PushExpression(ICalculatorExpression expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }
            if (_context == null)
            {
                throw new NullReferenceException("Context is null.");
            }

            _context.Expressions.Push(expression);
        }

        public void PopExpression()
        {
            if (_context == null)
            {
                throw new NullReferenceException("Context is null.");
            }

            if (_context.Expressions.Any())
            {
                _context.Expressions.Pop();
            }
        }

        public void Evaluate()
        {
            if (_context == null)
            {
                throw new NullReferenceException("Context is null.");
            }

            while (_context.Expressions.Any())
            {
                var currentExpression = _context.Expressions.Pop();
                currentExpression.Evaluate(_context);
            }
        }
    }
}