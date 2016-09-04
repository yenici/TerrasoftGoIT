using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_11_1.Models
{
    [Serializable]
    class Grades: IEnumerable<KeyValuePair<string, byte>>
    {
        public static readonly byte GRADE_NAME_MAX_LENGTH = 30;
        public static readonly byte GRADE_MIN = 0;
        public static readonly byte GRADE_MAX = 12;
        private Dictionary<string, byte> gradesLog;
        public int Count
        {
            get
            {
                if (this.gradesLog == default(Dictionary<string, byte>))
                    return 0;
                return this.gradesLog.Count;
            }
        }
        public Grades()
        {
            this.gradesLog = new Dictionary<string, byte>();
        }
        public IEnumerator<KeyValuePair<string, byte>> GetEnumerator()
        {
            foreach (var grade in this.gradesLog)
                yield return grade;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void AddGrade(string name, byte grade)
        {
            if (grade < Grades.GRADE_MIN || grade > Grades.GRADE_MAX)
                throw new Exception(
                    String.Format("Incorrect grade {0}. The grade should be between {1} and {2}",
                    grade, Grades.GRADE_MIN, Grades.GRADE_MAX));
            if (name.Trim().Length == 0 || name.Trim().Length > Grades.GRADE_NAME_MAX_LENGTH)
                throw new Exception(string.Format(
                    "Incorrect grade name. The grade should have a length between 1 and {0}.",
                    Grades.GRADE_NAME_MAX_LENGTH));
            this.gradesLog.Add(name.Trim(), grade);
        }
    }
}
