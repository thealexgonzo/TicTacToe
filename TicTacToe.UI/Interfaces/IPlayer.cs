using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.UI.Interfaces
{
    public interface IPlayer
    {
        PlayerSymbols symbol { get; set; }      
        bool IsHumanPlayer { get; }
        bool IsMaxing { get; }
        int PlayerChoice();
    }
}
