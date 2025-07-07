using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.UI
{
    public static class ConsoleIO
    {
        public static int GetPlayerChoice(PlayerSymbols symbol)
        {
            int playerChoice = 0;

            do
            {
                Console.Write($"\n{symbol}, choose a position: ");
                if(int.TryParse(Console.ReadLine(), out playerChoice)) 
                {
                    return playerChoice;
                }
                else
                {
                    Console.WriteLine("Please enter a valid numeric value.");
                }
            } while (true);
        }

        public static void DisplayGridPositions()
        {
            Console.WriteLine("\nHere are the positions of the grid: \n");
            Console.WriteLine(" 1 | 2 | 3");
            Console.WriteLine("---+---+---");
            Console.WriteLine(" 4 | 5 | 6");
            Console.WriteLine("---+---+---");
            Console.WriteLine(" 7 | 8 | 9");
        }

        public static void DisplayEndOfGameResult(Result gameResult)
        {
            Console.WriteLine("\n");

            if(gameResult == Result.XWins)
            {
                Console.WriteLine("X wins!");
            }
            else if(gameResult == Result.OWins)
            {
                Console.WriteLine("O wins!");
            }
            else if(gameResult == Result.Draw)
            {
                Console.WriteLine("It's a draw.");
            }
        }

        public static bool PlayAgain()
        {
            do
            {
                Console.Write("\nWould you like to play again (yes/no)? ");
                string choice = Console.ReadLine().ToLower();

                if (choice == "yes")
                {
                    //Clear the board before starting a new game
                    for (int i = 0; i < GameManager.Board.Length; i++)
                    {
                        GameManager.Board[i] = null;
                    }

                    return true;
                }
                else if (choice == "no")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Please enter a valid choice (yes/no)");
                }
            } while (true);
        }
    }
}
