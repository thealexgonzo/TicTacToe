using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.UI.Interfaces;

namespace TicTacToe.UI
{
    public static class App
    {
        public static void Run()
        {
            do
            {
                // Game setup
                Console.Clear();

                Console.WriteLine("Welcome to Tic-Tac-Toe!");

                IPlayer player1 = PlayerFactory.GetPlayerType($"\nPlayer 1 (X) - Human or Computer? (H/C): ");
                IPlayer player2 = PlayerFactory.GetPlayerType($"\nPlayer 2 (O) - Human or Computer? (H/C): ");

                GameManager manager = new GameManager(player1, player2);

                IPlayer firstPlayer = manager.FirstPlayer();
                IPlayer currentPlayer = manager.nextPlayer(firstPlayer);

                ConsoleIO.DisplayGridPositions();

                // First player moves
                manager.PlaceSymbol(firstPlayer.PlayerChoice(), firstPlayer.symbol, firstPlayer);
                manager.DisplayRoundGrid();

                Result gameScore;

                // The game continues with the next players' move
                do
                {
                    Result round;

                    do
                    {
                        round = manager.PlaceSymbol(currentPlayer.PlayerChoice(), currentPlayer.symbol, currentPlayer);

                    } while (round != Result.SymbolPlaced);

                    manager.DisplayRoundGrid();

                    currentPlayer = manager.nextPlayer(currentPlayer);

                    gameScore = manager.determineResult();

                } while (gameScore == Result.Playing);

                ConsoleIO.DisplayEndOfGameResult(gameScore);

            } while (ConsoleIO.PlayAgain());
        }
    }
}
