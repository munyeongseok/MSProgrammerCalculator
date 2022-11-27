﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class BitwiseANDExpression : BinaryExpression
    {
        public BitwiseANDExpression(IExpression leftOperand, IExpression rightOperand)
            : base(leftOperand, rightOperand)
        {
        }

        public override long Evaluate(CalculatorContext context)
        {
            //context.Result = context.Expression == null ? Operand : CalculatorHelper.BinaryOperation(Operators.AND, context.Result, Operand);
            //context.Expression = CalculatorHelper.AppendExpression(Operators.AND, context.Expression, Operand);

            return LeftOperand.Evaluate(context) & RightOperand.Evaluate(context);
        }
    }
}
