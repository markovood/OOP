using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAcademy
{
    public abstract class Course : ICourse
    {
        private string name;
        private ICollection<string> program;

        public Course(string name, ITeacher teacher)
        {
            this.Name = name;
            this.Teacher = teacher;
            this.program = new List<string>();
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

        public ITeacher Teacher { get; set; }

        public void AddTopic(string topic)
        {
            this.program.Add(topic);
        }

        public override string ToString()
        {
            return string.Format(
                "{0}: Name={1};{2}{3}",
                this.GetType().Name,
                this.Name,
                this.Teacher != null ?
                    string.Format(" Teacher={0};", this.Teacher.Name) : 
                    string.Empty,
                this.program.Count > 0 ? 
                    string.Format(" Topics=[{0}];", string.Join(", ", this.program)) :
                    string.Empty);
        }
    }
}
