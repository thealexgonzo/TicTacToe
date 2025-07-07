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
        public static string[] Board { get; private set; } = new string[9];

        public IPlayer _player1 { get; private set; }
        public IPlayer _player2 { get; private set; }

        public GameManager(IPlayer p1, IPlayer p2)
        {
            _player1 = p1;
            _player2 = p2;

            _player1.symbol = PlayerSymbols.X;
            _player2.symbol = PlayerSymbols.O;

            // Setup Board display formatting
            for (int i = 0; i < Board.Length; i++)
            {
                if (Board[i] == null)
                {
                    Board[i] = " ";
                }
            }
        }

        public Result PlaceSymbol(int position, PlayerSymbols playerSymbol, IPlayer currentPlayer)
        {

            if (position < 1 || position > 9)
            {
                Console.WriteLine("That position is off the grid, please choose an empty space between 1 and 9.");
                return Result.InvalidOffGrid;
            }
            else if (Board[position - 1] != " ")
            {
                if(currentPlayer.playerTypeFlag == 'H')
                {
                    Console.WriteLine("You can't place your symbol on a non-empty space.");
                }
                return Result.InvalidOverlap;
            }
            else
            {
                Board[position - 1] = playerSymbol.ToString();
                
                if(currentPlayer.playerTypeFlag == 'C')
                {
                    Console.Write($"\n{playerSymbol} chooses {position}.");
                }

                return Result.SymbolPlaced;
            }
        }

        public void DisplayRoundGrid()
        { 
            Console.WriteLine("\n");
            Console.WriteLine($" {Board[0]} | {Board[1]} | {Board[2]}");
            Console.WriteLine($"---+---+---");
            Console.WriteLine($" {Board[3]} | {Board[4]} | {Board[5]}");
            Console.WriteLine($"---+---+---");
            Console.WriteLine($" {Board[6]} | {Board[7]} | {Board[8]}");
        }
        public IPlayer FirstPlayer()
        {
            Random _random = new Random();

            int firstPlayer = _random.Next(1, 3);

            if (firstPlayer == 1)
            {
                Console.WriteLine($"\n\n{PlayerSymbols.X} will go first!");
                return _player1;
            }
            else
            {
                Console.WriteLine($"\n\n{PlayerSymbols.O} will go first!");
                return _player2;
            }
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
            if ((Board[0] == "X" && Board[1] == "X" && Board[2] == "X") ||
                (Board[3] == "X" && Board[4] == "X" && Board[5] == "X") ||
                (Board[6] == "X" && Board[7] == "X" && Board[8] == "X") ||
                (Board[0] == "X" && Board[4] == "X" && Board[8] == "X") ||
                (Board[2] == "X" && Board[4] == "X" && Board[6] == "X") ||
                (Board[0] == "X" && Board[3] == "X" && Board[6] == "X") ||
                (Board[1] == "X" && Board[4] == "X" && Board[7] == "X") ||
                (Board[2] == "X" && Board[5] == "X" && Board[8] == "X")) 
            {
                return Result.XWins;
            }
            else if((Board[0] == "O" && Board[1] == "O" && Board[2] == "O") ||
                (Board[3] == "O" && Board[4] == "O" && Board[5] == "O") ||
                (Board[6] == "O" && Board[7] == "O" && Board[8] == "O") ||
                (Board[0] == "O" && Board[4] == "O" && Board[8] == "O") ||
                (Board[2] == "O" && Board[4] == "O" && Board[6] == "O") ||
                (Board[0] == "O" && Board[3] == "O" && Board[6] == "O") ||
                (Board[1] == "O" && Board[4] == "O" && Board[7] == "O") ||
                (Board[2] == "O" && Board[5] == "O" && Board[8] == "O"))
            {
                return Result.OWins;
            }
            else if(!Board.Contains(" "))
            {
                return Result.Draw;
            }

            return Result.Playing;
        }
    }
}
