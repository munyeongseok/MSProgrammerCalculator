﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class BitwiseNANDExpression : BinaryOperatorExpression
    {
        public BitwiseNANDExpression() : this(null, null)
        {
        }

        public BitwiseNANDExpression(IOperandExpression leftOperand, IOperandExpression rightOperand)
            : base(leftOperand, rightOperand,
                  CalculatorHelper.GetPrecedence(Operators.BitwiseNAND),
                  CalculatorHelper.GetAssociativity(Operators.BitwiseNAND))
        {
        }

        public override long Evaluate(CalculationContext context)
        {
            return ~(LeftOperand.Evaluate(context) & RightOperand.Evaluate(context));
        }
    }
}
