using System;

namespace Assignment_01_1
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Byte */
            Console.WriteLine("Type byte:\tdefault value {0}, min {1}, max {2}", new Byte(), Byte.MinValue, Byte.MaxValue);

            /* sByte */
            Console.WriteLine("Type sbyte:\tdefault value {0}, min {1}, max {2}", new SByte(), SByte.MinValue, SByte.MaxValue);

            /* Short */
            Console.WriteLine("Type short:\tdefault value {0}, min {1}, max {2}", new Int16(), Int16.MinValue, Int16.MaxValue);

            /* uShort */
            Console.WriteLine("Type ushort:\tdefault value {0}, min {1}, max {2}", new UInt16(), UInt16.MinValue, UInt16.MaxValue);

            /* Int */
            Console.WriteLine("Type int:\tdefault value {0}, min {1}, max {2}", new Int32(), Int32.MinValue, Int32.MaxValue);

            /* uInt */
            Console.WriteLine("Type uint:\tdefault value {0}, min {1}, max {2}", new UInt32(), UInt32.MinValue, UInt32.MaxValue);

            /* Long */
            Console.WriteLine("Type long:\tdefault value {0}, min {1}, max {2}", new Int64(), Int64.MinValue, Int64.MaxValue);

            /* uLong */
            Console.WriteLine("Type ulong:\tdefault value {0}, min {1}, max {2}", new UInt64(), UInt64.MinValue, UInt64.MaxValue);

            /* Float */
            Console.WriteLine("Type float:\tdefault value {0}, min {1}, max {2}", new Single(), Single.MinValue, Single.MaxValue);

            /* Double */
            Console.WriteLine("Type double:\tdefault value {0}, min {1}, max {2}", new Double(), Double.MinValue, Double.MaxValue);

            /* Decimal */
            Console.WriteLine("Type decimal:\tdefault value {0}, min {1}, max {2}", new Decimal(), Decimal.MinValue, Decimal.MaxValue);

            /* Boolean */
            Console.WriteLine("Type bool:\tdefault value {0}", new Boolean());

            /* Character */
            Console.WriteLine("Type char:\tdefault value '{0}'", new Char());
        }
    }
}
