﻿using System;
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
            // Setup the players
            _player1 = p1;
            _player2 = p2;

            _player1.symbol = PlayerSymbols.X;
            _player2.symbol = PlayerSymbols.O;

            //_player1.IsMaxing = true;
            //_player2.IsMaxing = false;

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
                if (currentPlayer.IsHumanPlayer)
                {
                    Console.WriteLine("You can't place your symbol on a non-empty space.");
                }
                return Result.InvalidOverlap;
            }
            else if (position >= 1 && position <= 9)
            {
                Board[position - 1] = playerSymbol.ToString();

                if (!currentPlayer.IsHumanPlayer)
                {
                    Console.Write($"\n{playerSymbol} chooses {position}.");
                }

                return Result.SymbolPlaced;
            }
            else
            {
                return Result.Playing;
            }
        }

        public IPlayer FirstPlayer()
        {
            Random _random = new Random();

            int firstPlayer = _random.Next(1, 3);

            if (firstPlayer == 1)
            {
                return _player1;
            }
            else
            {
                return _player2;
            }
        }

        public IPlayer NextPlayer(IPlayer currentPlayer)
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

        public static Result CheckForWinner()
        {
            string[,] winConditions = new string[,]
            {   
            // This is a 2D array, each {...} is a row and each valule in a row is a column.
            { Board[0], Board[1], Board[2] },
            { Board[3], Board[4], Board[5] },
            { Board[6], Board[7], Board[8] },
            { Board[0], Board[3], Board[6] },
            { Board[1], Board[4], Board[7] },
            { Board[2], Board[5], Board[8] },
            { Board[0], Board[4], Board[8] },
            { Board[2], Board[4], Board[6] }
            };

            for (int i = 0; i < 8; i++)
            {
                // Check that all values in the row are equal - X or O
                if (winConditions[i, 0] != " " &&
                    winConditions[i, 0] == winConditions[i, 1] &&
                    winConditions[i, 1] == winConditions[i, 2])
                {
                    return winConditions[i, 0] == "X" ? Result.XWins : Result.OWins;
                }
            }

            if (!Board.Contains(" ") && !Board.Contains(null))
            {
                return Result.Draw;
            }

            return Result.Playing;
        }
    }
}
