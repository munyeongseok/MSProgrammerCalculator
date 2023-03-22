﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class PlusExpression : BinaryOperatorExpression
    {
        public PlusExpression()
            : this(OperandExpression.Null, OperandExpression.Null)
        {
        }

        public PlusExpression(IExpression leftOperand, IExpression rightOperand)
            : base(CalculatorHelper.GetNumericalExpressionToken(Operators.Plus), CalculatorHelper.CreateOperatorDescriptor(Operators.Plus), leftOperand, rightOperand)
        {
        }

        public override long Evaluate()
        {
            return CalculatorHelper.BinaryOperation(Operators.Plus, LeftOperand, RightOperand);
        }
    }
}
