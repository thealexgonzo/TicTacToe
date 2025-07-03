using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.UI.Interfaces;

namespace TicTacToe.UI
{
    public static class App
    {
        public static void Run()
        {
            Console.WriteLine("Welcome to Tic-Tac-Toe!");

            IPlayer player1 = PlayerFactory.GetPlayerType("\nPlayer 1 (X) - Human or Computer? (H/C): ");
            IPlayer player2 = PlayerFactory.GetPlayerType("\nPlayer 2 (O) - Human or Computer? (H/C): ");

            int firstPlayer = ConsoleIO.FirstPlayer();



            ConsoleIO.DisplayGridPositions();


        }
    }
}
