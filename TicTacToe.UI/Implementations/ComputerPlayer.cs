using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.UI.Interfaces;
using TicTacToe.UI;

namespace TicTacToe.UI.Implementations
{
    public class ComputerPlayer : IPlayer
    {
        private Random _random = new Random();
        public PlayerSymbols symbol { get; set; }
        public bool IsHumanPlayer { get { return false; } }
        public bool IsMaximising { get; set; }
        
        private int FindBestMove(string[] board)
        {
            int bestScore = int.MinValue;
            int bestMove = -1;

            for (int i = 0; i < board.Length; i++)
            {
                if (board[i] == null || board[i] == " ")
                {
                    string backup = board[i];
                    board[i] = symbol == PlayerSymbols.X ? "X" : "O";

                    int score = MinMaxAlgorithm.MinMax(board, symbol != PlayerSymbols.X);

                    board[i] = backup;

                    if (score > bestScore)
                    {
                        bestScore = score;
                        bestMove = i;
                    }
                }
            }

            // Return human readable choice (1-9), not array index (0-8)
            return bestMove + 1;
        }
        public int PlayerChoice()
        {
            return FindBestMove(GameManager.Board);
        }
    }
}
