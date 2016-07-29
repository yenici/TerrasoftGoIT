using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_05_1
{
    public class ScoutCamp
    {
        public static readonly Byte ALL = 0;
        public static readonly Byte BOY = 1;
        public static readonly Byte GIRL = 2;

        public static readonly Boolean ACTIVE = true;
        public static readonly Boolean LAZY = false;

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
                            ShowCalculationMenu();
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
                    ShowScoutActivities(scout);
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
        private void ShowScoutActivities(Scout scout)
        {
            List<String> scoutActivities;
            Boolean exit = false;
            int action;
            while (!exit)
            {
                scoutActivities = TypeScoutActivities(scout);
                Console.Write("Enter a number in accordance to your choice: ");
                Int32.TryParse(Console.ReadLine(), out action);
                if (action <= 0 || action > scoutActivities.Count + 2)
                {
                    Console.WriteLine("Wrong input.");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                }
                else if (action > 0 && action <= scoutActivities.Count)
                {
                    try
                    {
                        scout.RemoveActivity(scoutActivities[action - 1]);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                    }
                } else if (action == scoutActivities.Count + 1)
                {
                    AddNewScoutActivity(scout, scoutActivities);
                } else
                {
                    exit = true;
                }
            }
        }
        private List<String> TypeScoutActivities(Scout scout)
        {
            List<String> scoutActivities;
            Console.Clear();
            Console.WriteLine("Work with activities > {0,-30}\n", scout.Name);
            scoutActivities = scout.PrintActivities();
            Console.WriteLine("\n{0,4}. Add an activity", scoutActivities.Count + 1);
            Console.WriteLine("{0,4}. Exit\n", scoutActivities.Count + 2);
            if (scoutActivities.Count > 0)
            {
                Console.WriteLine("Enter a number form 1 to {0} to remove an activity.", scoutActivities.Count);
            }
            return scoutActivities;
        }
        private void AddNewScoutActivity(Scout scout, List<String> scoutActivities)
        {
            List<String> activities;
            Boolean exit = false;
            int activity = 0;
            Byte score = 0;
            if (scout is BoyScout)
            {
                activities = BoyScout.FilterBoysActivities(scoutActivities);
            }
            else
            {
                activities = GirlScout.FilterGirlsActivities(scoutActivities);
            }
            if (activities.Count > 0)
            {
                Console.WriteLine("\nAdding new activity.");
                for (int i = 0; i < activities.Count; i++)
                {
                    Console.WriteLine("{0,4}. {1,-50}", i + 1, activities[i]);
                }
                while (!exit)
                {
                    Console.Write("Enter a number to add activity: ");
                    Int32.TryParse(Console.ReadLine(), out activity);
                    if (activity > 0 && activity <= activities.Count)
                    {
                        exit = true;
                    }
                    else
                    {
                        Console.WriteLine("Wrong input.");
                        Console.Write("Press any key to continue.");
                    }
                }
                exit = false;
                while (!exit)
                {
                    Console.Write("Enter a score for the activity (1 - 100): ");
                    Byte.TryParse(Console.ReadLine(), out score);
                    if (score > 0 && score <= 100)
                    {
                        exit = true;
                    }
                    else
                    {
                        Console.WriteLine("Wrong input.");
                        Console.Write("Press any key to continue.");
                    }
                }
                try
                {
                    if (scout is BoyScout)
                    {
                        ((BoyScout)scout).AddActivity(activities[activity - 1], score);
                    }
                    else
                    {
                        ((GirlScout)scout).AddActivity(activities[activity - 1], score);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.Write("Press any key to continue.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("All possible activities are added.");
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
        private void ShowCalculationMenu()
        {
            Console.Clear();
            Console.WriteLine("Calculation >\n");
            Console.WriteLine("1. The average score of a camp:\t{0,6:N2}",
                CalculateCampAvg());

            Console.WriteLine("\n2. The best scout (has the highest average score):");
            Scout bestGirl = CalculateHighestAvg(ScoutCamp.GIRL);
            Scout bestBoy = CalculateHighestAvg(ScoutCamp.BOY);
            Scout best = CalculateHighestAvg(ScoutCamp.ALL);
            if (bestGirl != null)
                Console.WriteLine("\tGirls: {0, -30}\t{1,6:N2}", bestGirl.Name, bestGirl.GetAvgScore());
            if (bestBoy != null)
                Console.WriteLine("\t Boys: {0, -30}\t{1,6:N2}", bestBoy.Name, bestBoy.GetAvgScore());
            if (best != null)
                Console.WriteLine("\tTotal: {0, -30}\t{1,6:N2}", best.Name, best.GetAvgScore());

            Console.WriteLine("\n3. The most successfull scout (has the highest total score):");
            bestGirl = CalculateHighestTotal(ScoutCamp.GIRL);
            bestBoy = CalculateHighestTotal(ScoutCamp.BOY);
            best = CalculateHighestTotal(ScoutCamp.ALL);
            if (bestGirl != null)
                Console.WriteLine("\tGirls: {0, -30}\t{1,4}", bestGirl.Name, bestGirl.GetTotalScore());
            if (bestBoy != null)
                Console.WriteLine("\t Boys: {0, -30}\t{1,4}", bestBoy.Name, bestBoy.GetTotalScore());
            if (best != null)
                Console.WriteLine("\tTotal: {0, -30}\t{1,4}", best.Name, best.GetTotalScore());

            Console.WriteLine("\n4. The most active scout (has the biggest count of activities):");
            bestGirl = CalculateActive(ScoutCamp.GIRL, ScoutCamp.ACTIVE);
            bestBoy = CalculateActive(ScoutCamp.BOY, ScoutCamp.ACTIVE);
            best = CalculateActive(ScoutCamp.ALL, ScoutCamp.ACTIVE);
            if (bestGirl != null)
                Console.WriteLine("\tGirls: {0, -30}\t{1,2}", bestGirl.Name, bestGirl.GetActivitiesCount());
            if (bestBoy != null)
                Console.WriteLine("\t Boys: {0, -30}\t{1,2}", bestBoy.Name, bestBoy.GetActivitiesCount());
            if (best != null)
                Console.WriteLine("\tTotal: {0, -30}\t{1,2}", best.Name, best.GetActivitiesCount());

            Console.WriteLine("\n5. The laziest scout:");
            bestGirl = CalculateActive(ScoutCamp.GIRL, ScoutCamp.LAZY);
            bestBoy = CalculateActive(ScoutCamp.BOY, ScoutCamp.LAZY);
            best = CalculateActive(ScoutCamp.ALL, ScoutCamp.LAZY);
            if (bestGirl != null)
                Console.WriteLine("\tGirls: {0, -30}\t{1,2}", bestGirl.Name, bestGirl.GetActivitiesCount());
            if (bestBoy != null)
                Console.WriteLine("\t Boys: {0, -30}\t{1,2}", bestBoy.Name, bestBoy.GetActivitiesCount());
            if (best != null)
                Console.WriteLine("\tTotal: {0, -30}\t{1,2}", best.Name, best.GetActivitiesCount());

            Console.Write("\nPress any key to continue.");
            Console.ReadKey();
        }
        public float CalculateCampAvg()
        {
            float avg = 0F;
            foreach (Scout scout in ScoutList)
            {
                avg += scout.GetAvgScore();
            }
            return ScoutList.Count == 0? 0F: avg / ScoutList.Count;
        }
        public Scout CalculateHighestAvg(Byte mode)
        {
            Scout bestScout = null;
            float avg = 0;
            foreach (Scout scout in ScoutList)
            {
                if (mode == ScoutCamp.BOY && scout is GirlScout)
                {
                    continue;
                }
                if (mode == ScoutCamp.GIRL && scout is BoyScout)
                {
                    continue;
                }
                if (bestScout == null)
                {
                    bestScout = scout;
                    avg = bestScout.GetAvgScore();
                }
                else
                {
                    if (scout.GetAvgScore() > avg)
                    {
                        bestScout = scout;
                        avg = bestScout.GetAvgScore();
                    }
                }
            }
            return bestScout;
        }
        public Scout CalculateHighestTotal(Byte mode)
        {
            Scout bestScout = null;
            int total = 0;
            foreach (Scout scout in ScoutList)
            {
                if (mode == ScoutCamp.BOY && scout is GirlScout)
                {
                    continue;
                }
                if (mode == ScoutCamp.GIRL && scout is BoyScout)
                {
                    continue;
                }
                if (bestScout == null)
                {
                    bestScout = scout;
                    total = bestScout.GetTotalScore();
                }
                else
                {
                    if (scout.GetTotalScore() > total)
                    {
                        bestScout = scout;
                        total = bestScout.GetTotalScore();
                    }
                }
            }
            return bestScout;
        }
        public Scout CalculateActive(Byte mode, Boolean best)
        {
            Scout bestScout = null;
            int count = 0;
            foreach (Scout scout in ScoutList)
            {
                if (mode == ScoutCamp.BOY && scout is GirlScout)
                {
                    continue;
                }
                if (mode == ScoutCamp.GIRL && scout is BoyScout)
                {
                    continue;
                }
                if (bestScout == null)
                {
                    bestScout = scout;
                    count = bestScout.GetActivitiesCount();
                }
                else
                {
                    if (best)
                    {
                        if (scout.GetActivitiesCount() > count)
                        {
                            bestScout = scout;
                            count = bestScout.GetActivitiesCount();
                        }
                    }
                    else
                    {
                        if (scout.GetActivitiesCount() < count)
                        {
                            bestScout = scout;
                            count = bestScout.GetActivitiesCount();
                        }
                    }
                }
            }
            return bestScout;
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

            BoyScout.AddBoysActivity("Soccer");
            BoyScout.AddBoysActivity("Football");
            BoyScout.AddBoysActivity("Basketball");
            BoyScout.AddBoysActivity("Box");
            BoyScout.AddBoysActivity("Hockey");
            BoyScout.AddBoysActivity("Volleyball");
            BoyScout.AddBoysActivity("Tennis");
            GirlScout.AddGirlsActivity("Volleyball");
            GirlScout.AddGirlsActivity("Tennis");
            GirlScout.AddGirlsActivity("Swimming");
            GirlScout.AddGirlsActivity("Gymnastics");

            BoyScout tomHanks = new BoyScout("Tom Hanks");
            ScoutList.Add(tomHanks);
            tomHanks.AddActivity("Football", 100)
                .AddActivity("Volleyball", 30)
                .AddActivity("Tennis", 75);

            BoyScout bradPitt = new BoyScout("Brad Pitt");
            ScoutList.Add(bradPitt);
            bradPitt.AddActivity("Soccer", 90)
                .AddActivity("Basketball", 95)
                .AddActivity("Box", 80)
                .AddActivity("Tennis", 85);

            GirlScout jenniferAniston = new GirlScout("Jennifer Aniston");
            ScoutList.Add(jenniferAniston);
            jenniferAniston.AddActivity("Gymnastics", 95)
                .AddActivity("Tennis", 85)
                .AddActivity("Swimming", 70);

            GirlScout cameronDiaz = new GirlScout("Cameron Diaz");
            ScoutList.Add(cameronDiaz);
            cameronDiaz.AddActivity("Gymnastics", 90)
                .AddActivity("Tennis", 50); ;

            BoyScout jackNicholson = new BoyScout("Jack Nicholson");
            ScoutList.Add(jackNicholson);
            jackNicholson.AddActivity("Tennis", 100)
                .AddActivity("Volleyball", 50);

            GirlScout kateWinslet = new GirlScout("Kate Winslet");
            ScoutList.Add(kateWinslet);
            kateWinslet.AddActivity("Gymnastics", 85)
                .AddActivity("Tennis", 95)
                .AddActivity("Volleyball", 70)
                .AddActivity("Swimming", 100);

            BoyScout robertDeNiro = new BoyScout("Robert De Niro");
            ScoutList.Add(robertDeNiro);
            robertDeNiro.AddActivity("Hockey", 100);
        }
    }

}
