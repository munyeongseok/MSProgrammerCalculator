﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public interface IOperator : IExpression
    {
        OperatorDescriptor OperatorDescriptor { get; }
    }
}
