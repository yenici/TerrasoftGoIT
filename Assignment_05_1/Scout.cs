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
        public void RemoveActivity(String activity)
        {
            if (Activities.ContainsKey(activity))
            {
                Activities.Remove(activity);
            }
            else
            {
                throw new Exception("The activity " + activity +" is not found in " + Name + "'s activity list. ");
            }
        }
        public float GetAvgScore()
        {
            float avg = 0F;
            foreach (Byte score in Activities.Values)
            {
                avg += score;
            }
            return Activities.Count == 0? 0F: avg / Activities.Count;
        }
        public int GetTotalScore()
        {
            int total = 0;
            foreach (Byte score in Activities.Values)
            {
                total += score;
            }
            return total;
        }
        public int GetActivitiesCount()
        {
            return Activities.Count;
        }
        protected void Print(int number = 0)
        {
            if (number > 0)
            {
                Console.Write("{0,4}. {1, -30}\t{2, 3}\t{3,4}\t{4,5:N1}\t",
                    number, Name, Activities.Count, GetTotalScore(), GetAvgScore());
            }
            else
            {
                Console.Write("{0, -30}\t{1, 3}\t{2,4}\t{3,5:N1}\t",
                    Name, Activities.Count, GetTotalScore(), GetAvgScore());
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
