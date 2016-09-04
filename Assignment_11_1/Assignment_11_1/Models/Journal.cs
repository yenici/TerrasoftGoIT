using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_11_1.Models
{
    [Serializable]
    class Journal : IEnumerable<Pupil>
    {
        private static readonly string FILE_NAME = "ClassJournal.bin";
        private List<Pupil> pupilList = new List<Pupil>();
        public static void Save(Journal journal)
        {
            using (Stream stream = File.Open(FILE_NAME, FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, journal.pupilList);
            }
        }
        public static void Load(Journal journal)
        {
            using (Stream stream = File.Open(FILE_NAME, FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                journal.pupilList = (List<Pupil>)binaryFormatter.Deserialize(stream);
            }
        }
        public Pupil AddPupil(string name, int age)
        {
            Pupil pupil = null;
            if (pupilList == default(List<Pupil>))
                pupilList = new List<Pupil>();
            pupil = Pupil.CreatePupil(name, age);
            pupilList.Add(pupil);
            return pupil;
        }
        public Pupil[] GetPupils()
        {
            return this.pupilList.ToArray<Pupil>();
        }
        #region Iterators
        public IEnumerator<Pupil> GetEnumerator()
        {
            foreach (Pupil pupil in this.pupilList)
                yield return pupil;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public IEnumerable<Pupil> GetPupilsOlderThan(int minAge)
        {
            if (this.pupilList == default(List<Pupil>) || this.pupilList.Count == 0)
                yield break;
            else
                foreach (Pupil pupil in this.pupilList)
                    if (pupil.Age > minAge)
                        yield return pupil;
        }
        public IEnumerable<KeyValuePair<Pupil, float>> GetPupilsAvgGrade()
        {
            if (this.pupilList == default(List<Pupil>) || this.pupilList.Count == 0)
                yield break;
            else
                foreach (Pupil pupil in this.pupilList)
                    yield return new KeyValuePair<Pupil, float>(pupil, pupil.GetAverageGrade());
        }
        #endregion
    }
}
