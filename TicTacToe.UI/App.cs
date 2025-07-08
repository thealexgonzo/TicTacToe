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
                ConsoleIO.DisplayFirstPlayer(firstPlayer);

                IPlayer currentPlayer = manager.NextPlayer(firstPlayer);

                ConsoleIO.DisplayGridPositions();

                // First player moves
                Result firstChoice;
                do
                {
                    firstChoice = manager.PlaceSymbol(firstPlayer.PlayerChoice(), firstPlayer.symbol, firstPlayer);
                } while (firstChoice != Result.SymbolPlaced);
                
                ConsoleIO.DisplayGameBoard(GameManager.Board);

                Result gameScore;
                // The game continues with the next players' move
                do
                {
                    Result currentPlayerChoice;
                    do
                    {
                        currentPlayerChoice = manager.PlaceSymbol(currentPlayer.PlayerChoice(), currentPlayer.symbol, currentPlayer);
                    } while (currentPlayerChoice != Result.SymbolPlaced);

                    ConsoleIO.DisplayGameBoard(GameManager.Board);
                    currentPlayer = manager.NextPlayer(currentPlayer);

                    gameScore = GameManager.CheckForWinner();
                } while (gameScore == Result.Playing);

                ConsoleIO.DisplayEndOfGameResult(gameScore);
            } while (ConsoleIO.PlayAgain());
        }
    }
}
