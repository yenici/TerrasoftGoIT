using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_11_1.Models
{
    class Journal
    {
        public List<Pupil> Pupils { get; set; }
        public IEnumerable<float> GetAvgGrade()
        {
            foreach (Pupil pupil in this.Pupils)
                yield return pupil.GetAverageGrade();
        }
        public IEnumerable<Pupil> GetAge(int age)
        {
            foreach (Pupil pupil in this.Pupils)
                if (pupil.Age > age)
                    yield return pupil;
        }
    }
}
