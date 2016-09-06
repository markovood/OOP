namespace StudentsAndWorkers
{
    using System;

    public class Worker : Human
    {
        private decimal weekSalary;

        private int workHoursPerDay;

        public Worker(string firstName, string lastName, int weekSalary)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = 8;   // a standard working day
        }

        public Worker(string firstName, string lastName, int weekSalary, int workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal WeekSalary
        {
            get
            {
                return this.weekSalary;
            }

            set
            {
                if (value <= 0m)
                {
                    throw new ArgumentException("Week salary cannot be negative or 0...");
                }

                this.weekSalary = value;
            }
        }

        public int WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Work hours value cannot be less than or equal to 0...");
                }

                this.workHoursPerDay = value;
            }
        }

        public decimal MoneyPerHour()
        {
            int workingWeek = 5;
            decimal moneyPerDay = this.WeekSalary / workingWeek;
            decimal moneyPerHour = moneyPerDay / this.WorkHoursPerDay;

            return moneyPerHour;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} - {2:F2}lv/hour", this.FirstName, this.LastName, this.MoneyPerHour());
        }
    }
}