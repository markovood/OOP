namespace StudentsAndWorkers
{
    using System;

    public class Student : Human
    {
        private const int MIN_GRADE = 2, MAX_GRADE = 6;

        private int grade;

        public Student(string fistName, string lastName, int grade)
            : base(fistName, lastName)
        {
            this.Grade = grade;
        }

        public int Grade
        {
            get
            {
                return this.grade;
            }

            set
            {
                if (value < MIN_GRADE || value > MAX_GRADE)
                {
                    throw new ArgumentException("Grade's values are always between 2 and 6 inclusively");
                }

                this.grade = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.FirstName, this.LastName);
        }
    }
}