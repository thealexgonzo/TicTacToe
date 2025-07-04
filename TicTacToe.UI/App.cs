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
            do
            {
                Console.Clear();

                GameManager manager = new GameManager();

                Console.WriteLine("Welcome to Tic-Tac-Toe!");

                IPlayer player1 = PlayerFactory.GetPlayerType($"\nPlayer 1 ({PlayerSymbols.X}) - Human or Computer? (H/C): ");
                player1.symbol = PlayerSymbols.X;
                IPlayer player2 = PlayerFactory.GetPlayerType($"\nPlayer 2 ({PlayerSymbols.O}) - Human or Computer? (H/C): ");
                player2.symbol = PlayerSymbols.O;

                IPlayer currentPlayer;

                if(ConsoleIO.FirstPlayer() == PlayerSymbols.X)
                {
                    currentPlayer = player1;
                }
                else
                {
                    currentPlayer = player2;
                }

                ConsoleIO.DisplayGridPositions();

                Result winner;

                do
                {

                    Result round;

                    do
                    {
                        round = manager.PlaceSymbol(currentPlayer.PlayerChoice(), currentPlayer.symbol);

                    } while (round != Result.SymbolPlaced);

                    currentPlayer.symbol = manager.nextPlayer(currentPlayer.symbol);

                    manager.DisplayRoundGrid();

                    winner = manager.determineWinner();

                } while (winner == Result.SymbolPlaced);

                ConsoleIO.DisplayEndOfGameResult(winner);

            } while (ConsoleIO.PlayAgain());
        }
    }
}
