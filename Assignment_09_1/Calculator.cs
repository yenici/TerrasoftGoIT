using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Assignment_09_1
{
    public delegate Decimal MathOperations(Decimal a, Decimal b);
    public class Calculator
    {
        public Decimal Register1 { get; set; }
        public Decimal Register2 { get; set; }
        private event MathOperations CalculateEvent;
        public void StartCalculation()
        {
            this.Register1 = GetOperand("Enter the first  argument: ");
            this.Register2 = GetOperand("Enter the second argument: ");
            GetOperations();
            Console.ForegroundColor = ConsoleColor.Yellow;
            this.Calculate();
        }
        public void Calculate()
        {
            if (CalculateEvent != default(MathOperations))
                CalculateEvent.Invoke(this.Register1, this.Register2);
        }
        public Decimal GetOperand(String message)
        {
            int currentLineCursor = Console.CursorTop;
            Decimal operand;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write(message);
                Console.ForegroundColor = ConsoleColor.Green;
                if (Decimal.TryParse(Console.ReadLine(), out operand))
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
        public void GetOperations()
        {
            String input, ops;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\nSelect operations by entering corresponding numbers.");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Division");
            Console.WriteLine("4. Multiplication");
            int currentLineCursor = Console.CursorTop;
            while(true)
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
                                this.CalculateEvent += Calculator.Add;
                                break;
                            case '2':
                                this.CalculateEvent += Calculator.Subtract;
                                break;
                            case '3':
                                this.CalculateEvent += Calculator.Divide;
                                break;
                            case '4':
                                this.CalculateEvent += Calculator.Multiply;
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
        }
        public static Decimal Add(Decimal a, Decimal b)
        {
            Decimal result = Decimal.Add(a, b);
            Console.WriteLine(" {0} + {1} = {2}", a, b, result);
            return result;
        }
        public static Decimal Subtract(Decimal a, Decimal b)
        {
            Decimal result = Decimal.Subtract(a, b);
            Console.WriteLine(" {0} - {1} = {2}", a, b, result);
            return result;
        }
        public static Decimal Divide(Decimal a, Decimal b)
        {
            Decimal result = Decimal.Divide(a, b);
            Console.WriteLine(" {0} / {1} = {2}", a, b, result);
            return result;
        }
        public static Decimal Multiply(Decimal a, Decimal b)
        {
            Decimal result = Decimal.Multiply(a, b);
            Console.WriteLine(" {0} * {1} = {2}", a, b, result);
            return result;
        }
    }
}
