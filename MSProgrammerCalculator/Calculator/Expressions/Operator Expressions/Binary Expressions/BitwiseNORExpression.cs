﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class BitwiseNORExpression : BinaryOperatorExpression
    {
        public BitwiseNORExpression(IExpression leftOperand, IExpression rightOperand)
            : base(CalculatorHelper.GetExpressionToken(Operators.BitwiseNOR), CalculatorHelper.CreateOperatorDescriptor(Operators.BitwiseNOR), leftOperand, rightOperand)
        {
        }
    }
}
