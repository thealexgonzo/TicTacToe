using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.UI.Implementations;
using TicTacToe.UI.Interfaces;

namespace TicTacToe.UI
{
    public class GameManager
    {
        private string[] board = new string[9];

        public IPlayer _player1 { get; private set; }
        public IPlayer _player2 { get; private set; }

        public GameManager(IPlayer p1, IPlayer p2)
        {
            _player1 = p1;
            _player2 = p2;
        }

        private void PrepareBoard()
        {
            for (int i = 0; i < board.Length; i++)
            {
                if (board[i] == null)
                {
                    board[i] = " ";
                }
            }
        }

        public Result PlaceSymbol(int position, PlayerSymbols playerSymbol)
        {
            PrepareBoard();

            if (position < 1 || position > 9)
            {
                Console.WriteLine("That position is off the grid, please choose an empty space between 1 and 9.");
                return Result.InvalidOffGrid;
            }
            else if (board[position - 1] != " ")
            {
                Console.WriteLine("You can't place your symbol on a non-empty space.");
                return Result.InvalidOverlap;
            }
            else
            {
                board[position - 1] = playerSymbol.ToString();
                return Result.SymbolPlaced;
            }
        }

        public void DisplayRoundGrid()
        { 
            Console.WriteLine("\n");
            Console.WriteLine($" {board[0]} | {board[1]} | {board[2]}");
            Console.WriteLine($"---+---+---");
            Console.WriteLine($" {board[3]} | {board[4]} | {board[5]}");
            Console.WriteLine($"---+---+---");
            Console.WriteLine($" {board[6]} | {board[7]} | {board[8]}");
        }

        public IPlayer nextPlayer(IPlayer currentPlayer)
        {
            if(currentPlayer == _player1)
            {
                return _player2;
            }
            else
            {
                return _player1;
            }
        }

        public Result determineWinner()
        {
            if ((board[0] == "X" && board[1] == "X" && board[2] == "X") ||
                (board[3] == "X" && board[4] == "X" && board[5] == "X") ||
                (board[6] == "X" && board[7] == "X" && board[8] == "X") ||
                (board[0] == "X" && board[4] == "X" && board[8] == "X") ||
                (board[2] == "X" && board[4] == "X" && board[6] == "X") ||
                (board[0] == "X" && board[3] == "X" && board[6] == "X") ||
                (board[1] == "X" && board[4] == "X" && board[7] == "X") ||
                (board[2] == "X" && board[5] == "X" && board[8] == "X")) 
            {
                return Result.XWins;
            }
            else if((board[0] == "O" && board[1] == "O" && board[2] == "O") ||
                (board[3] == "O" && board[4] == "O" && board[5] == "O") ||
                (board[6] == "O" && board[7] == "O" && board[8] == "O") ||
                (board[0] == "O" && board[4] == "O" && board[8] == "O") ||
                (board[2] == "O" && board[4] == "O" && board[6] == "O") ||
                (board[0] == "O" && board[3] == "O" && board[6] == "O") ||
                (board[1] == "O" && board[4] == "O" && board[7] == "O") ||
                (board[2] == "O" && board[5] == "O" && board[8] == "O"))
            {
                return Result.OWins;
            }
            else if(!board.Contains(" "))
            {
                return Result.Draw;
            }

            return Result.SymbolPlaced;
        }
    }
}
