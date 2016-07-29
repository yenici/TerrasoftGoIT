using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_05_1
{
    class GirlScout:Scout
    {
        private static List<String> GirlsActivities = new List<String>();
        public GirlScout(String name): base(name)
        { }
        public static void AddGirlsActivity(String activity)
        {
            GirlsActivities.Add(activity);
        }
        public static List<String> FilterGirlsActivities(List<String> activities)
        {
            return GirlScout.GirlsActivities.Except(activities).ToList();
        }
        new public GirlScout AddActivity(String activity, Byte score)
        {
            if (GirlScout.GirlsActivities.Contains(activity))
            {
                base.AddActivity(activity, score);
            }
            else
            {
                throw new Exception("Activity '" + activity + "' is not in the list of girl's activities.");
            }
            return this;
        }
        new public void Print(int number = 0)
        {
            base.Print(number);
            Console.WriteLine("Girl");
        }
    }
}
