﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class CloseParenthesisExpression : Expression, IOperatorExpression
    {
        public OperatorDescriptor OperatorDescriptor { get; }

        public CloseParenthesisExpression()
            : base(CalculatorHelper.GetNumericalExpressionToken(Operators.CloseParenthesis))
        {
            OperatorDescriptor = CalculatorHelper.CreateOperatorDescriptor(Operators.CloseParenthesis);
        }

        public override EvaluationResult Evaluate()
        {
            throw new NotSupportedException();
        }
    }
}
