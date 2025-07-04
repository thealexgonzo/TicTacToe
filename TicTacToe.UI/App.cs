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
            GameManager manager = new GameManager();

            Console.WriteLine("Welcome to Tic-Tac-Toe!");

            IPlayer player1 = PlayerFactory.GetPlayerType($"\nPlayer 1 ({PlayerSymbols.X}) - Human or Computer? (H/C): ");
            IPlayer player2 = PlayerFactory.GetPlayerType($"\nPlayer 2 ({PlayerSymbols.O}) - Human or Computer? (H/C): ");

            PlayerSymbols currentPlayer = ConsoleIO.FirstPlayer();
            
            ConsoleIO.DisplayGridPositions();

            do
            {
                manager.PlaceSymbol(ConsoleIO.GetPlayerChoice(currentPlayer), currentPlayer);

                currentPlayer = manager.nextPlayer(currentPlayer);
                
                manager.DisplayRoundGrid();

            } while (true);
        }
    }
}
