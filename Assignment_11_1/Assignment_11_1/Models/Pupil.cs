using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_11_1.Models
{
    class Pupil
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Dictionary<string, byte> Grades { get; set; }
        public Pupil(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public Pupil()
        {
        }
        public float GetAverageGrade()
        {
            if (Grades.Count > 0)
            {
                float gradesSum = 0;
                foreach (var grade in Grades)
                    gradesSum += grade.Value;
                return gradesSum / Grades.Count;
            }
            else
            {
                return 0f;
            }
        }

    }
}
