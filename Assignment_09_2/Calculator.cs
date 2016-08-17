using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Assignment_09_2
{
    public class Calculator
    {
        public void Calculate()
        {
            LongNumber operand1 = GetOperand("Enter the first  argument: ");
            LongNumber operand2 = GetOperand("Enter the second argument: ");
            MathOperations mathOperations = GetOperations();
            Console.ForegroundColor = ConsoleColor.Yellow;
            mathOperations.Invoke(operand1, operand2);
        }
        public LongNumber GetOperand(String message)
        {
            int currentLineCursor = Console.CursorTop;
            LongNumber operand;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write(message);
                Console.ForegroundColor = ConsoleColor.Green;
                if (LongNumber.TryParse(Console.ReadLine(), out operand))
                    break;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong input. You should enter a number. Press any key to continue...");
                Console.ReadKey();
                /* Clear prompt, wrong input and error message */
                Console.SetCursorPosition(0, currentLineCursor);
                Console.Write(new String(' ', 2 * Console.WindowWidth)); // Clear two lines
                Console.SetCursorPosition(0, currentLineCursor);
            }
            return operand;
        }
        public MathOperations GetOperations()
        {
            MathOperations operations = null;
            String input, ops;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\nSelect operations by entering corresponding numbers.");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Integer Division");
            Console.WriteLine("4. Multiplication");
            int currentLineCursor = Console.CursorTop;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("Choose operation(s): ");
                Console.ForegroundColor = ConsoleColor.Green;
                input = Console.ReadLine();
                ops = new String(input.Distinct().ToArray());
                if (Regex.IsMatch(ops, @"[1-4]+$"))
                {
                    foreach (Char op in ops)
                        switch (op)
                        {
                            case '1':
                                operations += Calculator.Add;
                                break;
                            case '2':
                                operations += Calculator.Subtract;
                                break;
                            case '3':
                                operations += Calculator.Divide;
                                break;
                            case '4':
                                operations += Calculator.Multiply;
                                break;
                        }
                    Console.WriteLine();
                    break;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong input. You should enter numbers between 1 and 4. Press any key to continue...");
                Console.ReadKey();
                /* Clear prompt, wrong input and error message */
                Console.SetCursorPosition(0, currentLineCursor);
                Console.Write(new String(' ', 2 * Console.WindowWidth)); // Clear two lines
                Console.SetCursorPosition(0, currentLineCursor);
            }
            return operations;
        }
        public static LongNumber Add(LongNumber a, LongNumber b)
        {
            LongNumber result = LongNumber.Add(a, b);
            Console.WriteLine(" {0} + {1} = {2}", a, b, result);
            return result;
        }
        public static LongNumber Subtract(LongNumber a, LongNumber b)
        {
            LongNumber result = LongNumber.Subtract(a, b);
            Console.WriteLine(" {0} - {1} = {2}", a, b, result);
            return result;
        }
        public static LongNumber Divide(LongNumber a, LongNumber b)
        {
            LongNumber result = LongNumber.Divide(a, b);
            Console.WriteLine(" {0} / {1} = {2}", a, b, result);
            return result;
        }
        public static LongNumber Multiply(LongNumber a, LongNumber b)
        {
            LongNumber result = LongNumber.Multiply(a, b);
            Console.WriteLine(" {0} * {1} = {2}", a, b, result);
            return result;
        }
    }
    public delegate LongNumber MathOperations(LongNumber a, LongNumber b);
}
