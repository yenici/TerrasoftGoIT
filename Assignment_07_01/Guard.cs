using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_07_01
{
    public class Guard : Employee
    {
        public static readonly Decimal nightHoursCoef = 2M;
        private Decimal premiumDayCoef;
        private Decimal premiumNightCoef;
        private ushort nightHours;
        public ushort NightHours
        {
            get { return nightHours; }
            set
            {
                if (value >= 0 && value <= this.WorkingHours)
                    this.nightHours = value;
                else
                    throw new Exception("Error. Guard class. The number of night hours" +
                        " should lay in interval [0, " + this.WorkingHours + "].");
            }
        }
        private ushort premiumNightHours;
        public ushort PremiumNightHours
        {
            get { return premiumNightHours; }
            set
            {
                if (value >= 0 && value <= Math.Min(this.PremiumHours, this.NightHours))
                    this.premiumNightHours = value;
                else
                    throw new Exception("Error. Guard class. The number of premium night hours" +
                        " should lay in interval [0, " +
                        Math.Min(this.PremiumHours, this.NightHours) + "].");
            }
        }
        public Guard(String name, Decimal premiumDayCoef = 2M, Decimal premiumNightCoef = 3M) : base(name)
        {
            this.premiumDayCoef = premiumDayCoef;
            this.premiumNightCoef = premiumNightCoef;
        }
        override public String GetPositionName()
        {
            if (this.Mentor != null)
                return "Trainee of " + this.Mentor.Name + ", " + this.Mentor.GetPositionName();
            else
                return "Guard";
        }
        override public Decimal CalculateSalary(Boolean print = false)
        {
            int premiumDay = this.PremiumHours - this.PremiumNightHours;
            int regularDay = this.WorkingHours - this.NightHours - premiumDay;
            Decimal regularNight = this.NightHours - this.PremiumNightHours + this.PremiumNightHours * this.premiumNightCoef;
            Decimal totalHours = regularDay + premiumDay * this.premiumDayCoef + regularNight * Guard.nightHoursCoef;
            Decimal salary = Decimal.Round(this.Wage * totalHours, 2);
            if (print)
            {
                this.DisplayHeader();
                Console.WriteLine("Working hours, total: {0,3}", this.WorkingHours);
                Console.WriteLine("  including:");
                Console.WriteLine("             Regular day hours: {0,3}", regularDay);
                Console.WriteLine("             Premium day hours: {0,3},   coefficient: {1,5:N1}", premiumDay, this.premiumDayCoef);
                Console.WriteLine("             --------------------------");
                Console.WriteLine("               Total day hours: {0,5:N1}", regularDay + premiumDay * this.premiumDayCoef);
                Console.WriteLine("\n           Regular night hours: {0,3}", this.NightHours - this.PremiumNightHours);
                Console.WriteLine("           Premium night hours: {0,3},   coefficient: {1,5:N1}", this.PremiumNightHours, this.premiumNightCoef);
                Console.WriteLine("             --------------------------");
                Console.WriteLine("             Total night hours: {0,5:N1}", regularNight);
                Console.WriteLine("             Night coefficient: {0,5:N1}", Guard.nightHoursCoef);
                Console.WriteLine(" Night hours in day equivalent: {0,5:N1}", regularNight * Guard.nightHoursCoef);
                Console.WriteLine("\n Total hours in day equivalent: {0,5:N1}", totalHours);
                Console.WriteLine("                                 x");
                Console.WriteLine("                       Wage, $: {0,6:N2}", this.Wage);
                Console.WriteLine("                     =======================");
                Console.WriteLine("                     Salary, $: {0,12:N2}", salary);
            }
            return salary;
        }
        override public void SetSalaryParameters()
        {
            base.SetSalaryParameters();
            try
            {
                this.NightHours = Employee.InputShort("\tEnter the amount of working hours at night [0, "
                    + this.WorkingHours +"]: ");
                this.PremiumNightHours =
                    Employee.InputShort("\tEnter the amount of premium hours at night [0, "
                    + Math.Min(this.PremiumHours, this.NightHours) + "]: ");
    }
            catch (Exception e)
            {
                Employee.DisplayError(e.Message);
            }
        }
    }
}
