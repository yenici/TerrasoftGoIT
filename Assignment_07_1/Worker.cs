using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_07_01
{
    public class Worker : Employee
    {
        private static readonly Decimal overtimeCoef = 1.5M;
        private Decimal premiumCoef;
        private ushort overtimeHours;
        public ushort OvertimeHours {
            get { return this.overtimeHours; }
            set
            {
                if (value >= 0 && value <= this.WorkingHours)
                    this.overtimeHours = value;
                else
                    throw new Exception("Error. Worker class. The number of overtime hours" +
                        " should lay in interval [0, " + this.WorkingHours + "].");
            }
        }
        public Worker(String name, Decimal premiumCoef = 4M) : base(name)
        {
            this.premiumCoef = premiumCoef;
        }
        override public String GetPositionName()
        {
            if (this.Mentor != null)
                return "Trainee of " + this.Mentor.Name + ", " + this.Mentor.GetPositionName();
            else
                return "Worker";
        }
        override public Decimal CalculateSalary(Boolean print = false)
        {
            Decimal salary = Decimal.Round(this.Wage *
                (this.WorkingHours + (this.premiumCoef - 1) * this.PremiumHours +
                (Worker.overtimeCoef - 1) * this.OvertimeHours), 2);
            if (print)
            {
                this.DisplayHeader();
                Console.WriteLine("Working hours, total: {0,3}", this.WorkingHours);
                Console.WriteLine("  including:");
                Console.WriteLine("       Regular hours: {0,3}", this.WorkingHours - this.PremiumHours - this.OvertimeHours);
                Console.WriteLine("       Premium hours: {0,3},   coefficient: {1,5:N1}", this.PremiumHours, this.premiumCoef);
                Console.WriteLine("      Overtime hours: {0,3},   coefficient: {1,5:N1}", this.OvertimeHours, Worker.overtimeCoef);
                Console.WriteLine("   --------------------------");
                Decimal totalHours = this.WorkingHours + (this.premiumCoef - 1) * this.PremiumHours + (Worker.overtimeCoef - 1) * this.OvertimeHours;
                Console.WriteLine("    Total paid hours: {0,6:N2}", totalHours);
                Console.WriteLine("                     x");
                Console.WriteLine("             Wage, $: {0,6:N2}", this.Wage);
                Console.WriteLine("   ==========================");
                Console.WriteLine("     Salary, $: {0,12:N2}", salary);
            }
            return salary;
        }
        override public void SetSalaryParameters()
        {
            base.SetSalaryParameters();
            try
            {
                this.OvertimeHours = Employee.InputShort("\tEnter the amount of overtime working hours: ");
            }
            catch (Exception e)
            {
                Employee.DisplayError(e.Message);
            }
        }
    }
}
