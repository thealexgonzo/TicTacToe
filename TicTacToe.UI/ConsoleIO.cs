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

        public static PlayerSymbols FirstPlayer()
        {
            Random _random = new Random();

            int firstPlayer = _random.Next(1, 3);

            if (firstPlayer == 1)
            {
                Console.WriteLine($"\n\n{PlayerSymbols.X} will go first!");
                return PlayerSymbols.X;
            }
            else
            {
                Console.WriteLine($"\n\n{PlayerSymbols.O} will go first!");
                return PlayerSymbols.O;
            }
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
