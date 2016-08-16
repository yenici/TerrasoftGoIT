using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_07_01
{
    public class Doctor : Employee
    {
        private Decimal premiumCoef;
        private Decimal bonus;
        public Decimal Bonus {
            get { return this.bonus; }
            set
            {
                if (value >= 0)
                    this.bonus = value;
                else
                    throw new Exception("Doctor class. The bonus should be greater or equal than zero.");
            }
        }
        private ushort patientsHealed;
        public ushort PatientsHealed {
            get { return this.patientsHealed; }
            set
            {
                if (value >= 0)
                    this.patientsHealed = value;
                else
                    throw new Exception("Error. Doctor class. The number of healed patients" +
                        " should be greater or equal than zero.");
            }
        }
        public Doctor(String name, Decimal premiumCoef = 3M) : base(name)
        {
            this.premiumCoef = premiumCoef;
        }
        override public String GetPositionName()
        {
            if (this.Mentor != null)
                return "Trainee of " + this.Mentor.Name + ", " + this.Mentor.GetPositionName();
            else
                return "Doctor";
        }
        override public Decimal CalculateSalary(Boolean print = false)
        {
            Decimal salary = Decimal.Round(this.Wage * (this.WorkingHours +
                (this.premiumCoef - 1) * this.PremiumHours), 2) +
                Decimal.Round(this.Bonus * this.PatientsHealed, 2);
            if (print)
            {
                this.DisplayHeader();
                Console.WriteLine("Working hours, total: {0,3}", this.WorkingHours);
                Console.WriteLine("  including:");
                Console.WriteLine("       Regular hours: {0,3}", this.WorkingHours - this.PremiumHours);
                Console.WriteLine("       Premium hours: {0,3},   coefficient: {1,5:N1}", this.PremiumHours, this.premiumCoef);
                Console.WriteLine("   --------------------------");
                Decimal totalHours = this.WorkingHours + (this.premiumCoef - 1) * this.PremiumHours;
                Console.WriteLine("    Total paid hours: {0,6:N2}", totalHours);
                Console.WriteLine("                     x");
                Console.WriteLine("             Wage, $: {0,6:N2}", this.Wage);
                Console.WriteLine(" ----------------------------");
                Console.WriteLine(" Paid hours, $: {0,12:N2}", this.Wage * totalHours);
                Console.WriteLine("\n      Healed patients: {0,3}", this.PatientsHealed);
                Console.WriteLine(" Bonus for patient, $: {0,6:N2}", this.Bonus);
                Console.WriteLine(" ----------------------------");
                Console.WriteLine("Bonus total, $: {0,12:N2}", this.Bonus * this.PatientsHealed);
                Console.WriteLine(" ============================");
                Console.WriteLine("     Salary, $: {0,12:N2}", salary);
            }
            return salary;
        }
        override public void SetSalaryParameters()
        {
            base.SetSalaryParameters();
            try
            {
                this.PatientsHealed = Employee.InputShort("Enter the number of healed patients: ");
                if (this.PatientsHealed > 0)
                    this.Bonus = Employee.InputDecimal("Enter the value of a bonus for a healed patient: ");
            }
            catch (Exception e)
            {
                Employee.DisplayError(e.Message);
            }
        }
    }
}
