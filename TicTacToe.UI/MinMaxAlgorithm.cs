using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.UI
{
    public static class MinMaxAlgorithm
    {
        public static Result CheckSimulationWinner(string[] board)
        {
            string[,] winConditions = new string[,]
            {   
            // This is a 2D array, each {...} is a row and each valule in a row is a column.
            { board[0], board[1], board[2] },
            { board[3], board[4], board[5] },
            { board[6], board[7], board[8] },
            { board[0], board[3], board[6] },
            { board[1], board[4], board[7] },
            { board[2], board[5], board[8] },
            { board[0], board[4], board[8] },
            { board[2], board[4], board[6] }
            };

            for (int i = 0; i < 8; i++)
            {
                // Check that all values in the row are equal - X or O
                if (winConditions[i, 0] != " " &&
                    winConditions[i, 0] == winConditions[i, 1] &&
                    winConditions[i, 1] == winConditions[i, 2])
                {
                    return winConditions[i, 0] == PlayerSymbols.X.ToString() ? Result.XWins : Result.OWins;
                }
            }

            if (!board.Contains(" "))
            {
                return Result.Draw;
            }

            return Result.Playing;
        }
        public static int MinMax(string[] board, bool isMaximising)
        {
            Result result = CheckSimulationWinner(board);
            if (result == Result.XWins) return 1;
            if (result == Result.OWins) return -1;
            if (result == Result.Draw) return 0;

            if (isMaximising)
            {
                int bestScore = int.MinValue;

                for (int i = 0; i < board.Length; i++)
                {
                    if (board[i] == " ")
                    {
                        string backUp = board[i];

                        board[i] = "X";
                        
                        int score = MinMax(board, false);

                        bestScore = Math.Max(score, bestScore);
                        //undo move;
                        board[i] = backUp;
                    }
                }

                return bestScore;
            } 
            else
            {
                int bestScore = int.MaxValue;

                for (int i = 0; i < board.Length; i++)
                {
                    if (board[i] == " ")
                    {
                        string backUp = board[i];

                        board[i] = "O";

                        int score = MinMax(board, true);

                        bestScore = Math.Min(score, bestScore);
                        //undo move;
                        board[i] = backUp;
                    }
                }

                return bestScore;
            }
        }
    }
}
