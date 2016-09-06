namespace SchoolClasses.Persons
{
    using System;
    using System.Collections.Generic;
    using SchoolClasses.Interfaces;

    public class Teacher : Person, ICommentable
    {
        private string comments;

        public Teacher(string name)
            : base(name)
        {
            this.Disciplines = new List<Discipline>();
        }

        public List<Discipline> Disciplines { get; set; }

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
    }
}