using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_04_1
{

    // Реализовать калькулятор.
    // Пользователь вводит информацию в такой последовательности:
    //  первое число;
    //  операция;
    //  следующее число;
    //  операция;
    //  и так далее.
    // При каждом вводе следующего числа программа выводит полученный результат.
    // Существуют следующие операции: +, –, /, *, %, ^ (возведение в степень).
    //
    // Реализовать в виде методов:
    //  - все операции;
    //  - ввод типа операции и проверка на допустимые символы;
    //  - подсчет результата.

    class Program
    {
        private const String VERSION = "v1.0.0";

        private const Char ALPHABET_DECIMAL_POINT = '.';
        private const String ALPHABET_OPERATIONS = "+-*/%^";

        public static void Main(string[] args)
        {
            Double _dResult = 0D, _dLeftOperand, _dRightOperand;
            Char _cOperation;
            Char _cContinue = 'y';

            printGgreetings();
            while(_cContinue == 'y')
            {
                Console.WriteLine();
                _dLeftOperand = readOperand();
                _cOperation = readOperation();
                _dRightOperand = readOperand();
                _dResult = calculate(_cOperation, _dLeftOperand, _dRightOperand);
                Console.WriteLine("\t{0} {1} {2} = {3}", _dLeftOperand, _cOperation, _dRightOperand, _dResult);
                Console.Write("\nDo you want to make another calculation (y/n)?");
                _cContinue = Console.ReadKey().KeyChar;
            }
        }
        private static void printGgreetings()
        {
            Console.WriteLine("Simple calculator {0}\n", VERSION);
            Console.WriteLine("Available operations:");
            Console.WriteLine("\t'+' - addition");
            Console.WriteLine("\t'-' - subtraction");
            Console.WriteLine("\t'/' - division");
            Console.WriteLine("\t'*' - multiplication");
            Console.WriteLine("\t'%' - modulus");
            Console.WriteLine("\t'^' - exponentiation");
        }

        private static Char readOperation()
        {
            ConsoleKeyInfo KeyPressed;
            while (true)
            {
                Console.Write("Enter an operation: ");
                KeyPressed = Console.ReadKey();
                if (ALPHABET_OPERATIONS.IndexOf(KeyPressed.KeyChar) >= 0)
                {
                    break;
                }
                else
                {
                    Console.Write("\nWrong input.\tAvailable operations: ");
                    Console.WriteLine(String.Join(", ", ALPHABET_OPERATIONS.ToCharArray()));
                }
            }
            return KeyPressed.KeyChar;
        }

        private static Double readOperand()
        {
            String _sInput = "";
            Double _dNumber;
            ConsoleKeyInfo KeyPressed;
            Console.Write("\nEnter a number: ");
            while (true)
            {
                KeyPressed = Console.ReadKey(true);
                if (KeyPressed.Key == ConsoleKey.Enter) break;
                if (KeyPressed.Key == ConsoleKey.Backspace && _sInput.Length > 0)
                {
                    Console.Write("\b \b");
                    _sInput = _sInput.Substring(0, _sInput.Length - 1);
                }
                if (Char.IsDigit(KeyPressed.KeyChar))
                {
                    Console.Write(KeyPressed.KeyChar);
                    _sInput += KeyPressed.KeyChar;
                }
                if (ALPHABET_DECIMAL_POINT == KeyPressed.KeyChar && _sInput.IndexOf(ALPHABET_DECIMAL_POINT) < 0)
                {
                    Console.Write(KeyPressed.KeyChar);
                    _sInput += KeyPressed.KeyChar;
                }
            }
            Console.WriteLine();
            Double.TryParse(_sInput, out _dNumber);
            return _dNumber;
        }

        private static Double calculate(Char _cOperation, Double _dLeftOperand, Double _dRightOperand)
        {
            Double _dResult = 0D;
            switch(_cOperation)
            {
                case '+':
                    _dResult = doAddition(_dLeftOperand,  _dRightOperand);
                    break;
                case '-':
                    _dResult = doSubtraction(_dLeftOperand, _dRightOperand);
                    break;
                case '*':
                    _dResult = doMultiplication(_dLeftOperand, _dRightOperand);
                    break;
                case '/':
                    _dResult = doDivision(_dLeftOperand, _dRightOperand);
                    break;
                case '%':
                    _dResult = doModulus(_dLeftOperand, _dRightOperand);
                    break;
                case '^':
                    _dResult = doExponentiation(_dLeftOperand, _dRightOperand);
                    break;
            }
            return _dResult;
        }

        private static Double doAddition(Double _dLeftOperand, Double _dRightOperand)
        {
            return _dLeftOperand + _dRightOperand;
        }
        private static Double doSubtraction(Double _dLeftOperand, Double _dRightOperand)
        {
            return _dLeftOperand - _dRightOperand;
        }
        private static Double doDivision(Double _dLeftOperand, Double _dRightOperand)
        {
            return _dLeftOperand / _dRightOperand;
        }
        private static Double doMultiplication(Double _dLeftOperand, Double _dRightOperand)
        {
            return _dLeftOperand * _dRightOperand;
        }
        private static Double doModulus(Double _dLeftOperand, Double _dRightOperand)
        {
            return _dLeftOperand % _dRightOperand;
        }
        private static Double doExponentiation(Double _dLeftOperand, Double _dRightOperand)
        {
            return Math.Pow(_dLeftOperand,_dRightOperand);
        }

    }
}
