﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class ClearExpression : IExpression
    {
        public ClearExpression()
        {
        }

        public long Evaluate(CalculationContext context)
        {
            throw new NotImplementedException();
        }
    }
}
