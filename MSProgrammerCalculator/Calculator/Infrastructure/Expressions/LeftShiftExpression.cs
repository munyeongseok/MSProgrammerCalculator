﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class LeftShiftExpression : BinaryExpression
    {
        public LeftShiftExpression(long operand) : base(operand)
        {
        }

        public override void Evaluate(CalculatorContext context)
        {
            context.Result = context.Expression == null ? Operand : CalculatorHelper.BinaryOperation(Operators.LeftShift, context.Result, Operand);
            context.Expression = CalculatorHelper.AppendExpression(Operators.LeftShift, context.Expression, Operand);
        }
    }
}
