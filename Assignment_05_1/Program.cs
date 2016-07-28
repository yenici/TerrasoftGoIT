using System;
using System.Collections.Generic;

namespace Assignment_05_1
{
    class Program
    {
        static void Main(string[] args)
        {
            ScoutCamp scoutCamp = new ScoutCamp();

            CreateFooActivitiesList();
            scoutCamp.AddFooData();

            scoutCamp.ShowMenu();
        }

        private static void CreateFooActivitiesList()
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
        }
    }
}
