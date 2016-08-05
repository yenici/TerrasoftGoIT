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
            Employee[] employees = new Employee[] { new Doctor(), new Psychologist(), new Guard(), new Worker() };
            foreach(var employee in employees)
            {
                employee.CalculatePay();
            }
            Console.WriteLine("=======================================================");
            IPayment[] payment = new IPayment[] { new Doctor(), new Psychologist(), new Guard(), new Worker(),
                new Trainee(new Doctor()), new Trainee(new Guard())};
            foreach (var employee in payment)
            {
                employee.CalculatePay();
            }
        }
    }
    interface IPayment
    {
        Decimal CalculatePay();
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
    public class Employee: IPayment
    {
        public String Name { get; set; }
        public decimal Wage { get; set; }
        public byte Experience { get; set; }
        public ushort WorkingHours { get; set; }
        public virtual Decimal CalculatePay()
        {
            Console.WriteLine("\t\tEmployee.CalculatePay");
            return Wage * WorkingHours;
        }
    }
    public class Doctor : Employee, IPayment
    {
        public Decimal Bonus { get; set; }
        public ushort PatientsCount { get; set; }
        override public Decimal CalculatePay()
        {
            Console.WriteLine("\tDoctor.CalculatePay");
            return base.CalculatePay() + this.Bonus * this.PatientsCount;
        }
    }
    public class Psychologist : Employee, IPayment
    {
        public static readonly ushort PatientsLimit;
        public ushort PatientsCount { get; set; }
        override public Decimal CalculatePay()
        {
            Console.WriteLine("\tPsychologist.CalculatePay");
            return base.CalculatePay();
        }
    }
    public class Guard : Employee, IPayment
    {
        public static readonly Decimal NightlyRate = 2;
        public byte NightHours { get; set; }
        override public Decimal CalculatePay()
        {
            Console.WriteLine("\tGuard.CalculatePay");
            return base.CalculatePay() + base.Wage * this.NightHours * (NightlyRate - 1M);
        }
    }
    public class Worker : Employee, IPayment
    {
        public ushort OvertimeHours { get; set; }
        override public Decimal CalculatePay()
        {
            Console.WriteLine("\tWorker.CalculatePay");
            return 0M;
        }
    }

    public sealed class Trainee: IPayment
    {
        private Employee master;
        public Trainee(Employee master)
        {
            this.master = master;
        }
        public Decimal CalculatePay()
        {
            Console.WriteLine("Trainee.CalculatePay");
            return master.CalculatePay();
        }
    }
}
