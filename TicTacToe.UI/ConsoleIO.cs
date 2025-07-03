using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.UI
{
    public static class ConsoleIO
    {

        public static int GetPlayerChoice(string symbol)
        {
            int choice = 0;

            do
            {
                Console.WriteLine($"{symbol}, choose a position: ");

                if (int.TryParse(Console.ReadLine(), out choice) && choice > 0 && choice <= 9)
                {
                    return choice;
                }
                else
                {
                    Console.WriteLine("\nPlease choose a valid position between 1 and 9.");
                }
            } while (true);
        }

        public static int FirstPlayer()
        {
            Random _random = new Random();

            int firstPlayer = _random.Next(1, 3);

            if (firstPlayer == 1)
            {
                Console.WriteLine("\n\nX will go first!");
            }
            else if (firstPlayer == 2)
            {
                Console.WriteLine("\n\nO will go first!");
            }

            return firstPlayer;
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
    }
}
