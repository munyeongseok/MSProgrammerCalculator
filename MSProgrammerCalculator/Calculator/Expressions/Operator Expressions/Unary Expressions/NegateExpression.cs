﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class NegateExpression : UnaryOperatorExpression
    {
        public NegateExpression(IExpression operand)
            : base(CalculatorHelper.GetExpressionToken(Operators.Negate), CalculatorHelper.CreateOperatorDescriptor(Operators.Negate), operand)
        {
        }
    }
}
