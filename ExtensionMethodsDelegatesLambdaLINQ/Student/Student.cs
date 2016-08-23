namespace Student
{
    using System.Collections.Generic;
    using System.Linq;

    public class Student
    {
        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public Student(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public Student(string firstName, string lastName, byte groupNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.GroupNumber = groupNumber;
        }

        public Student(string firstName, string lastName, string facultetNumb, string telNumb, string email, byte groupNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.FN = facultetNumb;
            this.Tel = telNumb;
            this.Email = email;
            this.Marks = new List<byte>();
            this.GroupNumber = groupNumber;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string FN { get; private set; }

        public string Tel { get; set; }

        public string Email { get; set; }

        public List<byte> Marks { get; set; }

        public byte GroupNumber { get; private set; }

        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }

        public int Age { get; private set; }

        public static Student[] FirstNameBeforeLast(Student[] collection)
        {
            var result = collection.Where(x => x.FirstName.CompareTo(x.LastName) < 0).ToArray();
            return result;
        }

        public override string ToString()
        {
            string separator = new string('*', 27);
            string studentAsStr = "{0}\r\nFaculty number: {1}\r\nTel.: {2}\r\nE-mail: {3}\r\nGroup №: {4}\r\n{5}";
            return string.Format(studentAsStr, this.FullName, this.FN, this.Tel, this.Email, this.GroupNumber, separator);
        }
    }
}