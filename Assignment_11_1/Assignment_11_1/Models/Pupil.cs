using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_11_1.Models
{
    [Serializable]
    class Pupil
    {
        private static uint id = 0;
        public static readonly byte PUPIL_MIN_AGE = 6;
        public static readonly byte PUPIL_MAX_AGE = 90;
        public uint Id { get; private set; }
        public string Name { get; set; }
        public int Age { get; set; }
        private Grades grades;
        private Pupil() { }
        public static Pupil CreatePupil(string name, int age)
        {
            if (name.Trim().Length <= 0)
                throw new Exception("Incorrect pupil's name. The name should not be an empty string.");
            if (age < Pupil.PUPIL_MIN_AGE || age > Pupil.PUPIL_MAX_AGE)
                throw new Exception(string.Format(
                    "Incorrect age {0}. The age should be between {1} and {2}.",
                    age, Pupil.PUPIL_MIN_AGE, Pupil.PUPIL_MAX_AGE));
            return new Models.Pupil()
            {
                Id = ++Pupil.id,
                Name = name,
                Age = age,
                grades = new Grades()
            };
        }
        public void AddGrade(string name, byte grade)
        {
            this.grades.AddGrade(name, grade);
        }
        public IEnumerable<KeyValuePair<string, byte>> GetPupilGrades()
        {
            foreach (KeyValuePair<string, byte> grade in this.grades)
                yield return grade;
        }
        public float GetAverageGrade()
        {
            if (grades.Count > 0)
            {
                float gradesSum = 0;
                foreach (var grade in this.grades)
                    gradesSum += grade.Value;
                return gradesSum / grades.Count;
            }
            else
            {
                return 0f;
            }
        }
    }
}
