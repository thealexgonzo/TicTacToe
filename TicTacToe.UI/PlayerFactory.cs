using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.UI.Interfaces;
using TicTacToe.UI;
using System.Reflection.Metadata.Ecma335;
using TicTacToe.UI.Implementations;

namespace TicTacToe.UI
{
    public static class PlayerFactory
    {
        public static IPlayer GetPlayerType(string prompt)
        {
            string playerType;

            do
            {
                Console.Write(prompt);
                playerType = Console.ReadKey().Key.ToString().ToUpper();

                if (playerType == "H" || playerType == "C")
                {
                    if(playerType == "H")
                    {
                        return new HumanPlayer();
                    }
                    else if(playerType == "C")
                    {
                        return new ComputerPlayer();
                    }
                }
                else
                {
                    Console.WriteLine("\nPlease enter a valid choice, (H)uman or (C)omputer.");
                }
            } while (true);
        }
    }
}
