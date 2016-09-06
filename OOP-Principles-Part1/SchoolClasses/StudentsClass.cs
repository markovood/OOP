namespace SchoolClasses
{
    using System;
    using System.Collections.Generic;
    using SchoolClasses.Interfaces;
    using SchoolClasses.Persons;

    public class StudentsClass : ICommentable
    {
        private string id;

        private string comments;

        public StudentsClass(string id)
        {
            this.ID = id;
            this.Students = new List<Student>();
            this.Teachers = new List<Teacher>();
        }

        public string ID
        {
            get
            {
                return this.id;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException();
                }

                this.id = value;
            }
        }

        public List<Student> Students { get; set; }

        public List<Teacher> Teachers { get; set; }

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
            return string.Format("Class {0}", this.ID);
        }
    }
}