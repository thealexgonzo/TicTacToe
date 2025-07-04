using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.UI.Interfaces;

namespace TicTacToe.UI.Implementations
{
    public class ComputerPlayer : IPlayer
    {
        private Random _random = new Random();
        public PlayerSymbols symbol { get; set; }

        public int PlayerChoice()
        {
            return _random.Next(1, 10);
        }
    }
}
