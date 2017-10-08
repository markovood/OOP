using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAcademy
{
    public class Teacher : ITeacher
    {
        private string name;
        private ICollection<ICourse> courses;

        public Teacher(string name)
        {
            this.Name = name;
            this.courses = new List<ICourse>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("name");
                }

                this.name = value;
            }
        }

        public void AddCourse(ICourse course)
        {
            this.courses.Add(course);
        }

        public override string ToString()
        {
            string courses;
            if (this.courses.Count > 0)
            {
                string[] coursesNames = this.courses.Select(c => c.Name).ToArray();
                courses = string.Format("; Courses=[{0}]", string.Join(", ", coursesNames));
            }
            else
            {
                courses = string.Empty;
            }

            return string.Format(
                "Teacher: Name={0}{1}",
                this.Name,
                courses);
        }
    }
}
