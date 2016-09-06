namespace SchoolClasses
{
    using System;
    using SchoolClasses.Interfaces;

    public class Discipline : ICommentable
    {
        private string comments;

        public Discipline(string name)
        {
            this.Name = name;
        }

        public Discipline(string name, int numberOfLectures)
        {
            this.Name = name;
            this.NumbOfLectures = numberOfLectures;
        }

        public Discipline(string name, int numberOfLectures, int numberOfExercises)
        {
            this.Name = name;
            this.NumbOfLectures = numberOfLectures;
            this.NumbOfExercises = numberOfExercises;
        }

        public string Name { get; set; }

        public int NumbOfLectures { get; set; }

        public int NumbOfExercises { get; set; }

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
            return string.Format("{0} --> {1} lectures", this.Name, this.NumbOfLectures);
        }
    }
}