using System;

namespace Assignment_02_2
{
    class Program
    {
        //  Используя основные операторы рассчитать:
        //      a.Площадь круга;
        //      b.Объем шара;
        //      c.Площадь прямоугольника;
        //      d.Объем прямоугольного параллелепипеда;
        //
        //  Данные о каждой фигуре вводятся с клавиатуры.
        //
        //  Результат вывести на экран.
        static void Main(string[] args)
        {
            ConsoleKeyInfo action = new ConsoleKeyInfo();
            while (action.KeyChar != '5')
            {
                Console.WriteLine("\n----------   M E N U   ----------");
                Console.WriteLine("Choose an action from the list:");
                Console.WriteLine("\t1 Calculate the area of a circle.");
                Console.WriteLine("\t2 Calculate the volume of a sphere.");
                Console.WriteLine("\t3 Calculate the area of a rectangle.");
                Console.WriteLine("\t4 Calculate the volume of a rectangular tank.");
                Console.WriteLine("\t5 Exit.\n");
                Console.WriteLine("Select your action by pressing a number.");
                action =  Console.ReadKey(false);
                switch (action.KeyChar)
                {
                    case '1':
                        Console.WriteLine("\nCalculating the area of a circle.");
                        Console.WriteLine("\tThe area of a circle is {0}", calcCircleArea());
                        break;
                    case '2':
                        Console.WriteLine("\nCalculating the volume of a sphere.");
                        Console.WriteLine("\tThe volume of a sphere is {0}", calcSphereVolume());
                        break;
                    case '3':
                        Console.WriteLine("\nCalculating the area of a rectangle.");
                        Console.WriteLine("\tThe area of a rectangle is {0}", calcRectangleArea());
                        break;
                    case '4':
                        Console.WriteLine("\nCalculating the volume of a rectangle tank.");
                        Console.WriteLine("\tThe volume of a rectangle tank is {0}", calcRectangleTankVolume());
                        break;
                    case '5':
                        break;
                    default:
                        Console.WriteLine("\nWrong input. Please make your choice again.");
                        break;
                }
            }
        }
        static double calcCircleArea(double radius = 0D)
        {
            if (radius <= 0D)
            {
                radius = getFigureDimension("Enter the radius of a circle");
            }
            return Math.PI * Math.Pow(radius, 2D);
        }
        static double calcSphereVolume(double radius = 0D)
        {
            if (radius <= 0D)
            {
                radius = getFigureDimension("Enter the radius of a sphere");
            }
            return 4D * Math.PI * Math.Pow(radius, 3D) / 3D;
        }
        static double calcRectangleArea(double length = 0D, double width = 0D)
        {
            Console.WriteLine("\nCalculating the area of a rectangle.");
            if (length <= 0)
            {
                length = getFigureDimension("Enter the length of a rectangle");
            }
            if (width <= 0)
            {
                width = getFigureDimension("Enter the width of a rectangle");
            }
            return length * width;
        }
        static double calcRectangleTankVolume(double length = 0D, double width = 0D, double height = 0D)
        {
            double area = calcRectangleArea(length, width);
            if (height <= 0)
            {
                height = getFigureDimension("Enter the height of a rectangle tank");
            }
            return area * height;
        }
        static double getFigureDimension(string message)
        {
            double dimension = 0D;
            Console.Write("\t{0}: ", message);
            if (!Double.TryParse(Console.ReadLine(), out dimension) || dimension < 0)
            {
                dimension = 0;
                Console.WriteLine("ERROR. Wrong input.");
            }
            return dimension;
        }

    }
}