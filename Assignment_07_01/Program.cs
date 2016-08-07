using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_07_01
{
    class Program
    {
        static void Main(string[] args)
        {
            //Employee[] employees = new Employee[] { new Doctor(), new Psychologist(), new Security(), new Worker() };
            //foreach(var employee in employees)
            //{
            //    employee.CalculateSalary();
            //}
            //Console.WriteLine("=======================================================");
            //ISalary[] payment = new ISalary[] { new Doctor(), new Psychologist(), new Security(), new Worker(),
            //    new Trainee(new Doctor()), new Trainee(new Security())};
            //foreach (var employee in payment)
            //{
            //    employee.CalculateSalary();
            //}
            EmployeesList employees = new EmployeesList();
            employees.CreateFooList();
            employees.StartMenu();
        }
    }
    enum Employees
    {
        Employee,
        Trainee,
        Doctor,
        Psychologist,
        Guard,
        Worker
    }

}
