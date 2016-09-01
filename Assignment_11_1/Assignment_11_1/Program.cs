using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_11_1.Models;

namespace Assignment_11_1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Initialization
            Journal journal = new Journal()
            {
               Pupils = new List<Pupil>
               {
                    new  Pupil()
                    {
                        Name = "First Name",
                        Age =16,
                        Grades = new Dictionary<string, byte>()
                        {
                            { "Algebra", 5 },
                            { "Chemestry", 4 },
                            { "Physics", 3}
                        }
                    },
                    new  Pupil()
                    {
                        Name = "Second Name",
                        Age =17,
                        Grades = new Dictionary<string, byte>()
                        {
                            { "Algebra", 3 },
                            { "Chemestry", 3 },
                            { "Biology", 4}
                        }
                    },
                    new  Pupil()
                    {
                        Name = "Third Name",
                        Age =18,
                        Grades = new Dictionary<string, byte>()
                        {
                            { "Algebra", 5 },
                            { "Chemestry", 5 },
                            { "Philology", 5}
                        }
                    }
               }
            };
            #endregion
            Console.WriteLine(new string('-', 80));
            foreach(var pupil in journal.Pupils)
            {
                Console.WriteLine("  Name: {0}\n   Age: {1}\nGrades:", pupil.Name, pupil.Age);
                foreach(var grade in pupil.Grades)
                {
                    Console.WriteLine("\t{0} - {1}", grade.Key, grade.Value);
                }
            }
            Console.WriteLine(new string('-', 80));
            IEnumerable<float> avg = journal.GetAvgGrade();
            foreach (var i in avg)
                Console.WriteLine(i);
            Console.WriteLine(new string('-', 80));
            IEnumerable<Pupil> age = journal.GetAge(16);
            foreach (var pupil in age)
            {
                Console.WriteLine("  Name: {0}\n   Age: {1}\nGrades:", pupil.Name, pupil.Age);
                foreach (var grade in pupil.Grades)
                {
                    Console.WriteLine("\t{0} - {1}", grade.Key, grade.Value);
                }
            }
        }
    }
}
