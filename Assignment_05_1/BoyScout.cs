using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_05_1
{
    public class BoyScout:Scout
    {
        private static List<String> BoysActivities = new List<String>();
        public BoyScout(String name): base(name)
        { }

        public static void AddBoysActivity(String activity)
        {
            BoysActivities.Add(activity);
        }
        public static List<String> FilterBoysActivities(List<String> activities)
        {
            return BoyScout.BoysActivities.Except(activities).ToList();
        }
        new public BoyScout AddActivity(String activity, Byte score)
        {
            if (BoyScout.BoysActivities.Contains(activity))
            {
                base.AddActivity(activity, score);
            }
            else
            {
                throw new Exception("Activity '" + activity + "' is not in the list of boy's activities.");
            }
            return this;
        }
        new public void Print(int number = 0)
        {
            base.Print(number);
            Console.WriteLine("Boy");
        }

    }
}
