﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class BitwiseANDExpression : BinaryOperatorExpression
    {
        public BitwiseANDExpression(IValueExpression leftOperand, IValueExpression rightOperand)
            : base(leftOperand, rightOperand,
                  CalculatorHelper.GetPrecedence(Operators.BitwiseAND),
                  CalculatorHelper.GetAssociativity(Operators.BitwiseAND))
        {
        }

        public override long Evaluate(CalculatorContext context)
        {
            return LeftOperand.Value & RightOperand.Value;
        }
    }
}