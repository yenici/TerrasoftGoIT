using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_10_1
{
    class Programm
    {
        static void Main(string[] args)
        {
            Boolean quit = false;
            while (!quit)
            {
                Console.Clear();
                Translator.MakeTranslation(Translator.GetInput(), Translator.GetOutput());
                quit = !Translator.CheckForContinue();
            }
        }
    }
}
