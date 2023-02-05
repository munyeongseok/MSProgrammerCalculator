using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class OperatorDescriptor
    {
        public Operators Operator { get; }

        public int Precedence { get; }

        public Associativity Associativity { get; }

        public OperatorDescriptor(Operators op, int precedence, Associativity associativity)
        {
            Operator = op;
            Precedence = precedence;
            Associativity = associativity;
        }
    }
}
