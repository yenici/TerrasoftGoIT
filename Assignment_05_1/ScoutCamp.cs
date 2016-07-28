using System;
using System.Collections.Generic;

namespace Assignment_05_1
{
    public class ScoutCamp
    {
        public static readonly byte ALL = 0;
        public static readonly Byte BOY = 1;
        public static readonly Byte GIRL = 2;

        private List<Scout> ScoutList = new List<Scout>();
        public void ShowMenu()
        {
            String menuItem;
            Byte item = 0;
            while (item != 5)
            {
                Console.Clear();
                Console.WriteLine("\tM E N U:");
                Console.WriteLine("1. Add a scout");
                Console.WriteLine("2. Work with activities");
                Console.WriteLine("3. Display scouts");
                Console.WriteLine("4. Calculations");
                Console.WriteLine("5. Exit");
                Console.Write("\nEnter a number (1 - 5): "); ;
                menuItem = Console.ReadLine();
                if (Byte.TryParse(menuItem, out item) && item > 0 && item <= 5)
                {
                    switch (item)
                    {
                        case 1:
                            AddNewScout();
                            break;
                        case 2:
                            ShowActivitiesMenu();
                            break;
                        case 3:
                            ShowDisplayScoutsMenu();
                            break;
                        case 4:
                            break;
                        case 5:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Wrong input. Please enter a number corresponding to a list item.");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                }
            }
        }
        private void AddNewScout()
        {
            String name = "";
            Byte genderCode = 0;
            Console.Clear();
            Console.WriteLine("Add a scout >\n");
            while (name.Length <3)
            {
                Console.Write("\nEnter scout's name: ");
                name = Console.ReadLine();
                if (name.Length < 3)
                {
                    Console.WriteLine("The length of the scout's name should be more that two symbols. ");
                }
            }
            while (genderCode != ScoutCamp.BOY && genderCode != ScoutCamp.GIRL)
            {
                Console.Write("Enter scout's gender ('1' - for a boy, '2' - for a girl): ");
                Byte.TryParse(Console.ReadLine(), out genderCode);
                if (genderCode != ScoutCamp.BOY && genderCode != ScoutCamp.GIRL)
                {
                    Console.WriteLine("Wrong input. Please enter '1' or '2'.");
                }
            }
            if (genderCode == ScoutCamp.BOY)
            {
                ScoutList.Add(new BoyScout(name));
            }
            else
            {
                ScoutList.Add(new GirlScout(name));
            }
            Console.WriteLine("\nNew scout added. Press any key to continue.");
            Console.ReadKey();
        }
        private void ShowActivitiesMenu()
        {
            int scoutIndex = 0;
            int scoutCount;
            Scout scout;
            scoutCount = DisplayScouts(ScoutCamp.ALL, "Work with activities >\n");
            if (scoutCount > 0)
            {
                while (scoutIndex < 1 || scoutIndex > scoutCount )
                {
                    Console.Write("\nEnter a number of a scout you want to work with (1-{0}): ", scoutCount);
                    Int32.TryParse(Console.ReadLine(), out scoutIndex);
                }
                try
                {
                    scout = GetScoutByIndex(scoutIndex - 1);
                    Console.Clear();
                    Console.WriteLine("Scout: {0,-30}", scout.Name);
                    scout.PrintActivities();
                    Console.ReadKey();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("You have no scout to work with.");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
        }
        private void ShowDisplayScoutsMenu()
        {
            String menuItem;
            Byte item = 0;
            while (item != 4)
            {
                Console.Clear();
                Console.WriteLine("Display scouts >\n");
                Console.WriteLine("1. Display all scouts");
                Console.WriteLine("2. Display girls");
                Console.WriteLine("3. Display boys");
                Console.WriteLine("4. Exit");
                Console.Write("\nEnter a number (1 - 4): "); ;
                menuItem = Console.ReadLine();
                if (Byte.TryParse(menuItem, out item) && item > 0 && item <= 4)
                {
                    switch (item)
                    {
                        case 1:
                            DisplayScouts(ScoutCamp.ALL, "Display scouts > Display all scouts\n");
                            break;
                        case 2:
                            DisplayScouts(ScoutCamp.GIRL, "Display scouts > Display girls\n");
                            break;
                        case 3:
                            DisplayScouts(ScoutCamp.BOY, "Display scouts > Display boys\n");
                            break;
                        case 4:
                            break;
                    }
                    if (item >= 1 && item <= 3)
                    {
                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Wrong input. Please enter a number corresponding to a list item.");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                }
            }
        }
        private int DisplayScouts(Byte mode = 0, String message = "")
        {
            Console.Clear();
            Console.WriteLine(message);
            Console.WriteLine("\tScouts in the camp: ");
            int counter = 0;
            for (int i = 0 ; i < ScoutList.Count; i++)
            {
                BoyScout boy = ScoutList[i] as BoyScout;
                GirlScout girl = ScoutList[i] as GirlScout;
                if (mode == ScoutCamp.BOY)
                {
                    if (boy == null)
                    {
                        girl = null;
                    }
                    else
                    {
                        counter++;
                    }                    
                }
                else if(mode == ScoutCamp.GIRL)
                {
                    if (girl == null)
                    {
                        boy = null;
                    }
                    else
                    {
                        counter++;
                    }
                }
                else
                {
                    counter++;
                }
                boy?.Print(counter);
                girl?.Print(counter);
            }
            return counter;
        }
        private Scout GetScoutByIndex(int index)
        {
            if (index >= 0 && index < ScoutList.Count)
            {
                return ScoutList[index];
            }
            else
            {
                throw new Exception("No scout found by index " + index);
            }
            
        }
        public void AddFooData()
        {
            BoyScout tomHanks = new BoyScout("Tom Hanks");
            ScoutList.Add(tomHanks);
            tomHanks.AddActivity("Football", 100)
                .AddActivity("Volleyball", 30)
                .AddActivity("Tennis", 75);

            //ScoutList.Add(new BoyScout("Tom Hanks"));

            ScoutList.Add(new BoyScout("Brad Pitt"));
            ScoutList.Add(new GirlScout("Jannifer Aniston"));
            ScoutList.Add(new GirlScout("Cameron Diaz"));
            ScoutList.Add(new BoyScout("Jack Nicholson"));
            ScoutList.Add(new GirlScout("Kate Winslet"));
            ScoutList.Add(new BoyScout("Robert De Niro"));
        }
    }

}
