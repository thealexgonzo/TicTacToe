using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.UI.Interfaces;
using TicTacToe.UI;

namespace TicTacToe.UI.Implementations
{
    public class HumanPlayer : IPlayer
    {
        public PlayerSymbols symbol { get; set; }

        public int PlayerChoice()
        {
            return ConsoleIO.GetPlayerChoice(symbol);
        }
    }
}
