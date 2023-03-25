﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class ModuloExpression : BinaryOperatorExpression
    {
        public ModuloExpression(IExpression leftOperand, IExpression rightOperand)
            : base(CalculatorHelper.GetNumericalExpressionToken(Operators.Modulo), CalculatorHelper.CreateOperatorDescriptor(Operators.Modulo), leftOperand, rightOperand)
        {
        }

        public override long EvaluateResult()
        {
            return CalculatorHelper.BinaryOperation(Operators.Modulo, LeftOperand, RightOperand);
        }
    }
}
