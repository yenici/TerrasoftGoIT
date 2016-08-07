using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_07_01
{
    public class Psychologist : Employee
    {
        public static readonly Decimal extraPatientsCoefficient = 1.2M;
        private Decimal premiumCoef;
        private ushort extraPatients;
        public ushort ExtraPatients
        {
            get { return this.extraPatients; }
            set
            {
                if (value >= 0)
                    this.extraPatients = value;
                else
                    throw new Exception("Error. Psychologist class. The number of extra patients" +
                        " should be greater or equal than zero.");
            }
        }
        public Psychologist(String name, Decimal premiumCoef = 2M) : base(name)
        {
            this.premiumCoef = premiumCoef;
        }
        override public String GetPositionName()
        {
            if (this.Mentor != null)
                return "Trainee of " + this.Mentor.Name + ", " + this.Mentor.GetPositionName();
            else
                return "Psychologist";
        }
        override public Decimal CalculateSalary(Boolean print = false)
        {
            double coefficient = System.Convert.ToDouble(Psychologist.extraPatientsCoefficient);
            Decimal salary = Decimal.Round(this.Wage * (this.WorkingHours + (this.premiumCoef - 1) * this.PremiumHours) *
                (Decimal)Math.Pow(coefficient, this.ExtraPatients), 2);
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
                Console.WriteLine("\n       Extra patients: {0,3}", this.ExtraPatients);
                Console.WriteLine("  Coef for patient, $: {0,6:N2}", Psychologist.extraPatientsCoefficient);
                Console.WriteLine("       Coefficient, $: {0,6:N2}", Math.Pow(coefficient, this.ExtraPatients));
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
                this.ExtraPatients = Employee.InputShort("Enter the number of extra patients: ");
            }
            catch (Exception e)
            {
                Employee.DisplayError(e.Message);
            }
        }
    }
}
