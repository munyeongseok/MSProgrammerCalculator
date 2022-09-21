using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSProgrammerCalculator.Common
{
    public class BitKeypadValueChangedEventArgs : EventArgs
    {
        public long Value { get; }

        public BitKeypadValueChangedEventArgs(long value)
        {
            Value = value;
        }
    }
}
