﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class BitwiseNORExpression : BinaryExpression
    {
        public BitwiseNORExpression(long operand) : base(operand)
        {
        }

        public override void Evaluate(CalculatorContext context)
        {
            context.Result = context.Expression == null ? Operand : CalculatorHelper.BinaryOperation(Operators.NOR, context.Result, Operand);
            context.Expression = CalculatorHelper.AppendExpression(Operators.NOR, context.Expression, Operand);
        }
    }
}
