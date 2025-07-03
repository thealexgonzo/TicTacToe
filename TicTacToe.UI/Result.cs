using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.UI
{
    public enum Result
    {
        SymbolPlace,
        XWins,
        OWins,
        Draw,
        InvalidOverlap,
        InvalidOffGrid
    }
}
