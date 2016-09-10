using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_12_1.Utils
{
    class StandartMessage
    {
        public static void DisplayError(string message)
        {
            ConsoleColor currentColor = Console.ForegroundColor;
            int currentLineCursor = Console.CursorTop;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(message);
            Console.WriteLine("Press any key to continue...");
            Console.ForegroundColor = currentColor;
            Console.ReadKey();
            // Clear lines
            int spaceCount = (Console.CursorTop - currentLineCursor) * Console.WindowWidth;
            Console.SetCursorPosition(0, currentLineCursor);
            Console.Write(new String(' ', spaceCount));
            Console.SetCursorPosition(0, currentLineCursor);
        }
        public static bool DualChoice(string message)
        {
            bool result = false;
            string input;
            int currentLineCursor = Console.CursorTop;
            while (true)
            {
                Console.Write(message + " (y/n)?: ");
                input = Console.ReadLine();
                if (input.Length == 1)
                {
                    if (input == "y" || input == "Y")
                    {
                        result = true;
                        break;
                    }
                    if (input == "n" || input == "N")
                        break;
                }
                // Clear lines
                int spaceCount = (Console.CursorTop - currentLineCursor) * Console.WindowWidth;
                Console.SetCursorPosition(0, currentLineCursor);
                Console.Write(new String(' ', spaceCount));
                Console.SetCursorPosition(0, currentLineCursor);
            }
            return result;
        }
    }
}
