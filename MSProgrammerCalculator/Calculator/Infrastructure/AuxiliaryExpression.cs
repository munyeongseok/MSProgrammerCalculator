﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public abstract class AuxiliaryExpression : IExpression
    {
        public abstract long Evaluate(CalculatorContext context);
    }
}
