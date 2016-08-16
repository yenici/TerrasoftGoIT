using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_07_01
{
    public abstract class Employee
    {
        private static ushort idCounter = 1;
        public ushort Id { get; private set; }
        public String Name { get; set; }
        private Decimal wage;
        public Decimal Wage {
            get { return this.wage; }
            set
            {
                if (value > 0)
                    this.wage = Decimal.Round(value, 2);
                else
                    throw new Exception("Error. Employee class. The value of a wage" +
                        " should be greater than zero.");
            }
        }
        public byte Experience { get; set; }
        private ushort workingHours;
        public ushort WorkingHours {
            get { return this.workingHours; }
            set
            {
                if (value >= 0)
                    this.workingHours = value;
                else
                    throw new Exception("Error. Employee class. The number of working hours" +
                        " should be greater or equal than zero.");
            }
        }
        private ushort premiumHours;
        public ushort PremiumHours
        {
            get { return premiumHours; }
            set
            {
                if (value >= 0 && value <= this.WorkingHours)
                    this.premiumHours = value;
                else
                    throw new Exception("Error. Employee class. The number of premium hours" +
                        " should be in [0, " + this.WorkingHours + "].");
            }
        }
        public Employee Mentor { get; set; }
        public Employee(String name)
        {
            this.Id = Employee.idCounter++;
            this.Name = name;
        }
        abstract public String GetPositionName();
        public abstract Decimal CalculateSalary(Boolean print);
        virtual public void SetSalaryParameters()
        {
            this.DisplayHeader();
            try
            {
                this.Wage = Employee.InputDecimal("Enter the wage: ");
                this.WorkingHours = Employee.InputShort("Enter the amount of working hours (total): ");
                Console.WriteLine("\t\tincluding:");
                this.PremiumHours =
                    Employee.InputShort("\tEnter the amount of premium hours [0, "
                    + this.WorkingHours + "]: ");
            }
            catch (Exception e) {
                Employee.DisplayError(e.Message);
            }
        }
        protected void DisplayHeader()
        {
            Console.WriteLine(new String('=', 80));
            Console.WriteLine("Id: {0,4}\tName: {1}", this.Id, this.Name);
            Console.WriteLine("Position: {0}", this.GetPositionName());
            Console.WriteLine(new String('-', 80));
        }
        protected static ushort InputShort(String message)
        {
            ushort value;
            while (true)
            {
                Console.Write(message);
                if (UInt16.TryParse(Console.ReadLine(), out value))
                    break;
                else
                    Console.WriteLine("Wrong input. Try again.");
            }
            return value;
        }
        protected static Decimal InputDecimal(String message)
        {
            Decimal value;
            while (true)
            {
                Console.Write(message);
                if (Decimal.TryParse(Console.ReadLine(), out value))
                    break;
                else
                    Console.WriteLine("Wrong input. Try again.");
            }
            return value;
        }
        protected static void DisplayError(String message)
        {
            Console.WriteLine(message);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
