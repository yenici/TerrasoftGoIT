using System;
using Assignment_11_1.Models;
using Assignment_11_1.Utils;

namespace Assignment_11_1
{
    class JournalView
    {
        public static void Start(Journal journal)
        {
            int action = 0;
            while (action != 7)
            {
                action = YMenu.ProcessMenu("Main menu", new string[]
                {
                    "Add pupil",
                    "Work with grades",
                    "Show pupils filtered by their age",
                    "Show pupils' average grades",
                    "Load data",
                    "Save data",
                    "Quit"
                });
                switch(action)
                {
                    case 1:
                        JournalView.AddPupilAction(journal);
                        break;
                    case 2:
                        JournalView.WorkWithGradesAction(journal);
                        break;
                    case 3:
                        JournalView.ShowFilteredPupilsAction(journal);
                        break;
                    case 4:
                        JournalView.ShowAvgGradesAction(journal);
                        break;
                    case 5:
                        JournalView.LoadDataAction(journal);
                        break;
                    case 6:
                        JournalView.SaveDataAction(journal);
                        break;
                    case 7:
                        break;
                }
            }
        }
        private static void AddPupilAction(Journal journal)
        {
            string name, inputAge;
            int age;
            Pupil pupil;
            Console.Clear();
            Console.WriteLine("Adding new pupil.");
            Console.WriteLine("=================");
            Console.Write("Enter pupil name: ");
            name = Console.ReadLine();
            Console.Write("Enter pupil age (between {0} and {1}): ",
                Pupil.PUPIL_MIN_AGE, Pupil.PUPIL_MAX_AGE);
            inputAge = Console.ReadLine();
            if (!int.TryParse(inputAge, out age))
                age = 0;
            try
            {
                pupil = journal.AddPupil(name, age);
                Console.WriteLine("\nPupil {0} successfully added.", pupil.Name);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            catch(Exception e)
            {
                StandartMessage.DisplayError(e.Message);
            }
        }
        private static void WorkWithGradesAction(Journal journal)
        {
            Pupil[] pupils = journal.GetPupils();
            string[] pupilItems = new string[pupils.Length];
            int maxIndex = pupils.Length + 1;
            int choice, currentLineCursor;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Work with grades.");
                Console.WriteLine("=================");
                Console.WriteLine(" No.                   Name                     Age");
                Console.WriteLine("---------------------------------------------------");
                for (int i = 0; i < pupils.Length; i++)
                    Console.WriteLine("{0,3}. {1, -40}   {2, 2}", i + 1, pupils[i].Name, pupils[i].Age);
                Console.WriteLine("\n{0,3}. Quit", pupils.Length + 1);
                currentLineCursor = Console.CursorTop;
                while (true)
                {
                    Console.Write("Choose a pupil to work with: ");
                    if (int.TryParse(Console.ReadLine(), out choice))
                        if (choice > 0 && choice <= maxIndex)
                            break;
                    StandartMessage.DisplayError(
                        string.Format("Wrong input. You should enter numbers between 1 and {0}.", maxIndex));
                    ///* Clear prompt */
                    Console.SetCursorPosition(0, currentLineCursor);
                    Console.Write(new String(' ', Console.WindowWidth));
                    Console.SetCursorPosition(0, currentLineCursor);
                }
                if (choice == maxIndex)
                    break;
                JournalView.AddGradesAction(pupils[choice - 1]);
            }
        }
        private static void AddGradesAction(Pupil pupil)
        {
            string gradeName, gradeString;
            byte gradeValue;
            bool finish = false;
            while (!finish)
            {
                Console.Clear();
                Console.WriteLine("Work with grades > {0}", pupil.Name);
                Console.WriteLine("===================" + new string('=', pupil.Name.Length));
                Console.WriteLine("\tG r a d e s:");
                foreach (var grade in pupil.GetPupilGrades())
                    Console.WriteLine("{0,-30} ... {1,2}", grade.Key, grade.Value);
                Console.Write("\nEnter a grade name: ");
                gradeName = Console.ReadLine();
                Console.Write("Enter a grade value (from {0} to {1}): ", Grades.GRADE_MIN, Grades.GRADE_MAX);
                gradeString = Console.ReadLine();
                byte.TryParse(gradeString, out gradeValue);
                try
                {
                    pupil.AddGrade(gradeName, gradeValue);
                }
                catch (Exception e)
                {
                    StandartMessage.DisplayError(e.Message);
                }
                finish = !StandartMessage.DualChoice("\nContinue adding grades");
            }
        }
        private static void ShowFilteredPupilsAction(Journal journal)
        {
            string inputAge;
            int age;
            Console.Clear();
            Console.WriteLine("Show pupils filtered by their age.");
            Console.WriteLine("==================================");
            Console.Write("Enter the age: ");
            inputAge = Console.ReadLine();
            if (int.TryParse(inputAge, out age))
            {
                Console.WriteLine(" ID                   Name                     Age");
                Console.WriteLine("---------------------------------------------------");
                foreach (Pupil pupil in journal.GetPupilsOlderThan(age))
                {
                    Console.WriteLine("{0, 3}. {1, -40}   {2, 2}", pupil.Id, pupil.Name, pupil.Age);
                    Console.WriteLine("\t\tG r a d e s:");
                    foreach (var grade in pupil.GetPupilGrades())
                        Console.WriteLine("\t{0, -30} ... {1, 2}", grade.Key, grade.Value);
                }
                Console.Write("\nPress any key to continue...");
                Console.ReadKey();
            }
            else
            {
                StandartMessage.DisplayError("The age is incorrect.");
            }
        }
        private static void ShowAvgGradesAction(Journal journal)
        {
            Console.Clear();
            Console.WriteLine("Show pupils' average grades.");
            Console.WriteLine("============================");
            Console.WriteLine("                  Name                   Age  Avg. grade");
            Console.WriteLine("--------------------------------------------------------");
            foreach (var item in journal.GetPupilsAvgGrade())
                Console.WriteLine("{0,-40}  {1, 2}    {2, 5:N2}", item.Key.Name, item.Key.Age, item.Value);
            Console.Write("\nPress any key to continue...");
            Console.ReadKey();
        }
        private static void LoadDataAction(Journal journal)
        {
            Console.Clear();
            Console.WriteLine("Load data.");
            Console.WriteLine("==========");
            try
            {
                Journal.Load(journal);
                Console.WriteLine("Data loaded successfully.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                StandartMessage.DisplayError(e.Message);
            }
        }
        private static void SaveDataAction(Journal journal)
        {
            Console.Clear();
            Console.WriteLine("Save data.");
            Console.WriteLine("==========");
            try
            {
                Journal.Save(journal);
                Console.WriteLine("Data stored successfully.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                StandartMessage.DisplayError(e.Message);
            }
        }
    }
}
