using System;
using System.Collections.Generic;

namespace Assignment_05_1
{
    public class Scout
    {
        public String Name { get; set; }
        private Dictionary<String, Byte> Activities = new Dictionary<String, Byte>();

        public Scout(String name)
        {
            this.Name = name;
        }

        protected void AddActivity(String activity, Byte score)
        {
            if (!Activities.ContainsKey(activity))
            {
                if (score > 0 && score <= 100)
                {
                    Activities.Add(activity, score);
                }
                else
                {
                    throw new Exception("The score for the activity '" + activity
                        + "'should be between 0 and 100");
                }
            }
            else
            {
                throw new Exception("Scout " + Name + " already has the score for the activity "
                    + activity + ".");
            }
        }
        protected void Print(int number = 0)
        {
            if (number > 0)
            {
                Console.Write("{0,4}. {1, -30}", number, Name);
            }
            else
            {
                Console.Write("{1, -30}", Name);
            }
        }
        public List<String> PrintActivities()
        {
            int counter = 0;
            List<String> activities = new List<String>();
            foreach (String key in Activities.Keys)
            {
                Console.WriteLine("{0,4}. {1, -50} - {2,3}", ++counter, key, Activities[key]);
                activities.Add(key);
            }
            return activities;
        }

    }
}
