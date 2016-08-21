using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Assignment_10_1
{
    public class Translator
    {
        public delegate void OutputStream(String text);
        public static void MakeTranslation(String input, OutputStream output)
        {
            try {                
                output.Invoke(Translator.TranslateInput(input));
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\nOperation completed.");
            }
            catch(Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }
        }
        private static String TranslateInput(String input)
        {
            String resultFormat = "Input: {0}\tResult: {1}";
            String result = input;
            Double doubleNumber;
            if (Double.TryParse(input, out doubleNumber))
                result = (doubleNumber * doubleNumber).ToString();
            return String.Format(resultFormat, input, result);
        }
        public static String GetInput()
        {
            String inputString;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Enter the value: ");
                Console.ForegroundColor = ConsoleColor.Green;
                inputString = Console.ReadLine().Trim();
                if (String.IsNullOrEmpty(inputString))
                    Translator.DisplayError("Wrong input. Try again.");
                else
                    break;
            }
            return inputString;
        }
        public static OutputStream GetOutput()
        {
            OutputStream outputFunction = null;
            String input, ops;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\nSelect the output device.");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("1. Screen");
            Console.WriteLine("2. File (./result.txt)");
            Console.WriteLine();
            int currentLineCursor = Console.CursorTop;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("Choose operation(s): ");
                Console.ForegroundColor = ConsoleColor.Green;
                input = Console.ReadLine();
                ops = new String(input.Distinct().ToArray());
                if (Regex.IsMatch(ops, @"[1-2]+$"))
                {
                    switch (input)
                    {
                        case "1":
                            outputFunction = (String text) => Console.WriteLine(text);
                            break;
                        case "2":
                            outputFunction = (String text) =>
                            {
                                using (StreamWriter file = new StreamWriter("result.txt"))
                                    file.WriteLine(text);
                            };
                            break;
                    }
                    Console.WriteLine();
                    break;
                }
                Translator.DisplayError("Wrong input. You should enter numbers between 1 and 2. " +
                    "Press any key to continue...");
                Console.WriteLine();
                Console.ReadKey();
                /* Clear prompt, wrong input and error message */
                Console.SetCursorPosition(0, currentLineCursor);
                Console.Write(new String(' ', 2 * Console.WindowWidth)); // Clear two lines
                Console.SetCursorPosition(0, currentLineCursor);
            }
            return outputFunction;
        }
        public static Boolean CheckForContinue()
        {
            String input;
            Boolean continueMode = true;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("\nDo you want to continue? (y/n) ");
                input = Console.ReadLine().Trim();
                if (input.Length == 1)
                {
                    if (input[0] == 'y' || input[0] == 'Y')
                        break;
                    else if (input[0] == 'n' || input[0] == 'N')
                    {
                        continueMode = false;
                        break;
                    }
                }
                Translator.DisplayError("Wrong input. Try again.");
            }
            return continueMode;
        }
        private static void DisplayError(String message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
        }
    }
}
