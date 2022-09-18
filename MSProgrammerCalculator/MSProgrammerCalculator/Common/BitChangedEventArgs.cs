using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSProgrammerCalculator.Common
{
    public class BitChangedEventArgs : EventArgs
    {
        public string Bit { get; }

        public BitChangedEventArgs(string bit)
        {
            Bit = bit;
        }
    }
}
