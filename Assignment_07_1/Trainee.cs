using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_07_01
{
    sealed public class Trainee
    {
        private Trainee() { }
        public static Employee CreateTrainee(Employee mentor, String name)
        {
            Employee position;
            if (mentor.Mentor != null)
                throw new Exception("Error. Trainee class. Trainee could not be a mentor.");
            if (mentor is Worker)
                position = new Worker(name, 1.5M);
            else if (mentor is Guard)
                position = new Guard(name, 1.5M, 1.5M);
            else if (mentor is Doctor)
                position = new Doctor(name, 1.5M);
            else if (mentor is Psychologist)
                position = new Psychologist(name, 1.5M);
            else
                throw new Exception("Error. Trainee class. Mentor's class is undefined.");
            position.Mentor = mentor;
            return position;
        }
    }
}
