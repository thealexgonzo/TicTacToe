using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.UI
{
    public enum Result
    {
        SymbolPlaced,
        XWins = 1,
        OWins = -1,
        Draw = 0,
        InvalidOverlap,
        InvalidOffGrid,
        Playing = -10
    }
}
