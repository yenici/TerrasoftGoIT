﻿using System;

namespace Assignment_12_1.Utils
{
    class AppMenu
    {
        private AppMenu() { }
        public static int ProcessMenu(string menuTitle, string[] menuItems)
        {
            if (menuItems.Length == 0)
                return 0;
            int maxIndex = menuItems.Length;
            int choice;
            AppMenu.DisplayMenu(menuTitle, menuItems);
            Console.WriteLine();
            int currentLineCursor = Console.CursorTop;
            while (true)
            {
                Console.Write("Enter the number of an action: ");
                if (int.TryParse(Console.ReadLine(), out choice))
                    if (choice > 0 && choice <= maxIndex)
                        break;
                StandartMessage.DisplayError(
                    string.Format("Wrong input. You should enter numbers between 1 and {0}.", maxIndex));
                ///* Clear prompt */
                Console.SetCursorPosition(0, currentLineCursor);
                Console.Write(new String(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, currentLineCursor);
            }
            return choice;
        }
        private static void DisplayMenu(string menuTitle, string[] menuItems)
        {
            Console.Clear();
            if (menuTitle.Length > 0)
            {
                Console.WriteLine(menuTitle);
                Console.WriteLine(new string('=', Console.WindowWidth - 1));
            }
            for (int i = 0; i < menuItems.Length; i++)
                Console.WriteLine("{0}. {1}", i + 1, menuItems[i]);
        }
    }
}
