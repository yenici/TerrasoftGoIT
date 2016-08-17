using System;

namespace Assignment_09_2
{
    class Program
    {
        static void Main(string[] args)
        {
            String input;
            Boolean quit = false;
            while (!quit)
            {
                Console.Clear();
                Calculator calculator = new Calculator();
                calculator.Calculate();
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("\nDo you want to continue calculations? (y/n) ");
                    input = Console.ReadLine();
                    if (input.Length == 1)
                    {
                        if (input[0] == 'y' || input[0] == 'Y')
                            break;
                        else if (input[0] == 'n' || input[0] == 'N')
                        {
                            quit = true;
                            break;
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong input. Try again.");
                }
            }
        }
    }
}
