using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public enum Operators
    {
        None,
        AND,
        OR,
        NOT,
        NAND,
        NOR,
        XOR,
        LeftShift,
        RightShift,
        Modulo,
        Divide,
        Multiply,
        Minus,
        Plus,
        Negate,
        Clear,
        BackSpace,
        OpenParenthesis,
        CloseParenthesis,
        DecimalSeparator,
        Result
    }
}
