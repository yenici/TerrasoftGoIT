using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_07_01
{
    public class EmployeesList
    {
        private List<Employee> employees = new List<Employee>();
        public void StartMenu()
        {
            Byte key;
            Boolean quit = false;
            while (!quit)
            {
                Console.Clear();
                Console.WriteLine("+-----------------------+");
                Console.WriteLine("|   M A I N   M E N U   |");
                Console.WriteLine("+-----------------------+");
                Console.WriteLine("\n1. Add a regular employee.");
                Console.WriteLine("\n2. List regular employees and calculate salary.");
                Console.WriteLine("\n3. Add a trainee.");
                Console.WriteLine("\n4. List trainees and calculate salary.");
                Console.WriteLine("\n5. Quit.");
                Console.WriteLine("\nPress a key with an appropriate number...");
                if (Byte.TryParse(Console.ReadLine(), out key))
                {
                    switch (key)
                    {
                        case 1:
                            this.AddEmployee();
                            break;
                        case 2:
                            this.ListEmployees();
                            break;
                        case 3:
                            this.AddTrainee();
                            break;
                        case 4:
                            this.ListTrainees();
                            break;
                        case 5:
                            quit = true;
                            break;
                    }
                }
            }
        }
        private void AddEmployee()
        {
            Console.Clear();
            Console.WriteLine("Add a regular employee");
            Console.WriteLine("--------------------------------------------------\n");
            Console.Write("Enter the name: ");
            String name = Console.ReadLine();
            Console.WriteLine("Choose a position by entering a corresponding number:");
            Console.WriteLine("1. Worker");
            Console.WriteLine("2. Guard");
            Console.WriteLine("3. Doctor");
            Console.WriteLine("4. Psychologist");
            Byte position;
            while (true)
            {
                Console.Write("\nEnter the number: ");
                if (Byte.TryParse(Console.ReadLine(), out position))
                {
                    if (position > 0 && position < 5)
                    {
                        switch (position)
                        {
                            case 1:
                                this.employees.Add(new Worker(name));
                                break;
                            case 2:
                                this.employees.Add(new Guard(name));
                                break;
                            case 3:
                                this.employees.Add(new Doctor(name));
                                break;
                            case 4:
                                this.employees.Add(new Psychologist(name));
                                break;
                        }
                        Console.WriteLine("A new employee added.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    }
                }
                Console.CursorTop = Console.CursorTop - 2;
            }
        }
        public void ListEmployees()
        {
            int choosenItem;
            List<Employee> list = this.GetEmployees();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("List regular employees and calculate salary");
                Console.WriteLine("--------------------------------------------------\n");
                for (int i = 0; i < list.Count; i++)
                    Console.WriteLine("{0,2}. {1,-40} {2}", i + 1, list[i].Name, list[i].GetPositionName());
                Console.WriteLine("{0,2}. Quit", list.Count + 1);
                Console.Write("\nEnter an appropriate number: ");
                if (Int32.TryParse(Console.ReadLine(), out choosenItem))
                {
                    if (choosenItem > 0 && choosenItem <= list.Count + 1)
                    {
                        --choosenItem; // Reflect the choosen item to [0, listCount] scale
                        if (choosenItem == list.Count)
                        {
                            // 'Quit' item selected
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            list[choosenItem].SetSalaryParameters();
                            Console.Clear();
                            list[choosenItem].CalculateSalary(true);
                            Console.WriteLine("\nPress any key to continue...");
                            Console.ReadKey();
                        }
                    }
                }
            }
        }
        public void AddTrainee()
        {
            String name = "";
            int choosenEmployee;
            List<Employee> list = this.GetEmployees();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Add a trainee");
                Console.WriteLine("--------------------------------------------------\n");
                if (name.Length == 0)
                {
                    Console.Write("Enter the name: ");
                    name = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Trainee name: {0}", name);
                }
                Console.WriteLine("\nChoose an employee to add the trainee.");
                for (int i = 0; i < list.Count; i++)
                    Console.WriteLine("{0,2}. {1,-40} {2}", i + 1, list[i].Name, list[i].GetPositionName());
                Console.WriteLine("{0,2}. Quit", list.Count + 1);
                Console.Write("\nEnter an appropriate number: ");
                if (Int32.TryParse(Console.ReadLine(), out choosenEmployee))
                {
                    if (choosenEmployee > 0 && choosenEmployee <= list.Count + 1)
                    {
                        --choosenEmployee; // Reflect the choosen employee to [0, listCount] scale
                        if (choosenEmployee == list.Count)
                        {
                            break;
                        }
                        else
                        {
                            try
                            {
                                Employee trainee = Trainee.CreateTrainee(list[choosenEmployee], name);
                                this.employees.Add(trainee);
                                Console.WriteLine("A new trainee added.");
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            };
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadKey();
                            break;
                        }
                    }
                }
            }
        }
        public void ListTrainees()
        {
            int choosenTrainee;
            List<Employee> list = this.GetTrainees();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("List trainees and calculate salary");
                Console.WriteLine("--------------------------------------------------\n");
                for (int i = 0; i < list.Count; i++)
                    Console.WriteLine("{0,2}. {1,-40} {2}", i + 1, list[i].Name, list[i].GetPositionName());
                Console.WriteLine("{0,2}. Quit", list.Count + 1);
                Console.Write("\nEnter an appropriate number: ");
                if (Int32.TryParse(Console.ReadLine(), out choosenTrainee))
                {
                    if (choosenTrainee > 0 && choosenTrainee <= list.Count + 1)
                    {
                        --choosenTrainee; // Reflect the choosen employee to [0, listCount] scale
                        if (choosenTrainee == list.Count)
                        {
                            // 'Quit' item selected
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            list[choosenTrainee].SetSalaryParameters();
                            Console.Clear();
                            list[choosenTrainee].CalculateSalary(true);
                            Console.WriteLine("\nPress any key to continue...");
                            Console.ReadKey();
                        }
                    }
                }
            }
        }
        private List<Employee> GetEmployees()
        {
            var result = new List<Employee>();
            foreach (Employee employee in this.employees)
            {
                if (employee.Mentor == null)
                    result.Add(employee);
            }
            return result;
        }
        private List<Employee> GetTrainees()
        {
            var result = new List<Employee>();
            foreach (Employee employee in this.employees)
            {
                if (employee.Mentor != null)
                    result.Add(employee);
            }
            return result;
        }
        public void CreateFooList()
        {
            employees.Clear();
            employees.Add(new Worker("Roger Taylor"));
            employees.Add(new Guard("John Deacon"));
            employees.Add(new Doctor("Brian May"));
            employees.Add(new Psychologist("Freddie Mercury"));
            employees.Add(Trainee.CreateTrainee((Employee)employees.ElementAt(0), "Roger Taylor Jr."));
            employees.Add(Trainee.CreateTrainee((Employee)employees.ElementAt(1), "John Deacon Jr."));
            employees.Add(Trainee.CreateTrainee((Employee)employees.ElementAt(2), "Brian May Jr."));
            employees.Add(Trainee.CreateTrainee((Employee)employees.ElementAt(3), "Freddie Mercury Jr."));
            //Farrokh Bulsara
            //foreach (var item in employees)
            //{
            //    item.SetSalaryParameters();
            //    item.CalculateSalary(true);
            //}
        }
    }
}
