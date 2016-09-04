using System;
using System.Text;
using Assignment_11_1.Models;

namespace Assignment_11_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            JournalView.Start(new Journal());
        }
    }
}
