using System;
using System.Collections.Generic;

namespace Assignment_05_1
{
    public class BoyScout:Scout
    {
        private static HashSet<String> BoysActivities = new HashSet<String>();
        public BoyScout(String name): base(name)
        { }

        public static void AddBoysActivity(String activity)
        {
            BoysActivities.Add(activity);
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
