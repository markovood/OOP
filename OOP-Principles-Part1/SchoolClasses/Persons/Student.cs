namespace SchoolClasses.Persons
{
    using System;
    using SchoolClasses.Interfaces;

    public class Student : Person, ICommentable
    {
        private int classNumber;
        private string comments;

        public Student(string name)
            : base(name)
        {
        }

        public int ClassNumber
        {
            get
            {
                return this.classNumber;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Class number cannot be negative or 0");
                }

                this.classNumber = value;
            }
        }

        public string Comments
        {
            get
            {
                return string.IsNullOrWhiteSpace(this.comments) ? "empty" : this.comments;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Cannot assign null or empty!!!");
                }

                this.comments = value;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
