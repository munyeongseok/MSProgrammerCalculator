﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class BitwiseORExpression : BinaryOperatorExpression
    {
        public BitwiseORExpression(IValueExpression leftOperand, IValueExpression rightOperand)
            : base(leftOperand, rightOperand,
                  CalculatorHelper.GetPrecedence(Operators.BitwiseOR),
                  CalculatorHelper.GetAssociativity(Operators.BitwiseOR))
        {
        }

        public override long Evaluate(CalculatorContext context)
        {
            return LeftOperand.Value | RightOperand.Value;
        }
    }
}
