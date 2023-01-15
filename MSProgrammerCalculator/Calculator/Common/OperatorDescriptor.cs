using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class OperatorDescriptor
    {
        public int Precedence { get; }

        public Associativity Associativity { get; }

        public OperatorDescriptor(int precedence, Associativity associativity)
        {
            Precedence = precedence;
            Associativity = associativity;
        }
    }
}
