namespace SchoolClasses
{
    using System.Collections.Generic;

    public class School
    {
        public School()
        {
            this.Classes = new List<StudentsClass>();
        }

        public List<StudentsClass> Classes { get; private set; }
    }
}