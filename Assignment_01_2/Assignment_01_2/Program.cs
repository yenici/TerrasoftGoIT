using System;

namespace Assignment_01_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string hello = "Hello world";
            foreach(char c in hello)
            {
                Console.WriteLine("Char\t{0}:\tdec {1,5},\thex {2,4:x}", c, Convert.ToUInt32(c), Convert.ToUInt32(c));
            }
        }
    }
}
