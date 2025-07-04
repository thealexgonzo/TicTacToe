using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.UI
{
    public class GameManager
    {
        private string[] board = new string[9];

        public Result PlaceSymbol(int position, PlayerSymbols playerSymbol)
        {
            for (int i = 0; i < board.Length; i++)
            {
                if (board[i] == null)
                {
                    board[i] = " ";
                }
            }

            if (board[position - 1] != " ")
            {
                return Result.InvalidOverlap;
            }
            else if (position < 1 || position > 9)
            {
                return Result.InvalidOffGrid;
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

        public PlayerSymbols nextPlayer(PlayerSymbols currentPlayer)
        {
            if(currentPlayer == PlayerSymbols.X)
            {
                return PlayerSymbols.O;
            }
            else
            {
                return PlayerSymbols.X;
            }
        }
    }
}
