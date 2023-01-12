﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class BitwiseXORExpression : BinaryOperatorExpression
    {
        public BitwiseXORExpression() : this(null, null)
        {
        }

        public BitwiseXORExpression(IOperandExpression leftOperand, IOperandExpression rightOperand)
            : base(leftOperand, rightOperand,
                  CalculatorHelper.GetPrecedence(Operators.BitwiseXOR),
                  CalculatorHelper.GetAssociativity(Operators.BitwiseXOR))
        {
        }

        public override EvaluationResult Evaluate()
        {
            return CalculatorHelper.CreateBinaryOperationResult(Operators.BitwiseXOR, LeftOperand, RightOperand);
        }
    }
}
