namespace Student_CTS
{
    using System;
    using System.Text;

    public class Student : ICloneable, IComparable<Student>
    {
        public Student(string firstName, string middleName, string lastName, uint ssn)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.SSN = ssn;
            this.PermanentAddress = "<unspecified>";
            this.TelNumber = "<unspecified>";
            this.EMail = "<unspecified>";
            this.Course = 0;
            this.Specialty = Specialty.Unspecified;
            this.Faculty = Faculty.Unspecified;
            this.University = University.Unspecified;
        }

        public string FirstName { get; private set; }

        public string MiddleName { get; private set; }

        public string LastName { get; private set; }

        public uint SSN { get; private set; }

        public string PermanentAddress { get; set; }

        public string TelNumber { get; set; }

        public string EMail { get; set; }

        public byte Course { get; set; }

        public Specialty Specialty { get; set; }

        public University University { get; set; }

        public Faculty Faculty { get; set; }

        // according to Microsoft Guidelines for overriding '==' operator see
        // https://msdn.microsoft.com/en-us/library/ms173147(v=vs.90).aspx A common error in overloads of operator == is to use
        // (a == b), (a == null), or (b == null) to check for reference equality. This instead creates a call to the overloaded
        // operator ==, causing an infinite loop. Use ReferenceEquals or cast the type to Object, to avoid the loop.
        public static bool operator ==(Student a, Student b)
        {
            // If both are null, or both are same instance, return true.
            if (object.ReferenceEquals(a, b))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            // Return true if the fields match:
            return a.FirstName == b.FirstName &&
                    a.MiddleName == b.MiddleName &&
                    a.LastName == b.LastName &&
                    a.SSN == b.SSN;
        }

        public static bool operator !=(Student a, Student b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            // difference between casting with 'as' and '()' is that if the cast is unsuccessful the first one will return
            // 'null', and the second one will throw an exception
            var objAsStudent = obj as Student;
            if (objAsStudent == null) return false;

            if (this.FirstName != objAsStudent.FirstName) return false;
            if (this.MiddleName != objAsStudent.MiddleName) return false;
            if (this.LastName != objAsStudent.LastName) return false;

            return this.SSN == objAsStudent.SSN;
        }

        public override string ToString()
        {
            StringBuilder studentStr = new StringBuilder();

            studentStr.AppendLine(string.Format("{0} {1} {2}", this.FirstName, this.MiddleName, this.LastName));
            studentStr.AppendLine(string.Format("SSN: {0}", this.SSN));
            studentStr.AppendLine(string.Format("Address: {0}", this.PermanentAddress));
            studentStr.AppendLine(string.Format("Tel: {0}", this.TelNumber));
            studentStr.AppendLine(string.Format("E-Mail: {0}", this.EMail));
            studentStr.AppendLine(string.Format("Course: {0}", this.Course));
            studentStr.AppendLine(string.Format("University: {0}", this.University));
            studentStr.AppendLine(string.Format("Faculty: {0}", this.Faculty));
            studentStr.AppendLine(string.Format("Specialty: {0}", this.Specialty));

            return studentStr.ToString();
        }

        public override int GetHashCode()
        {
            // I could probably lose one of them(hash or seed), the point is to try to minimize the number of collisions - so
            // that an object {1,0,0} has a different hash to {0,1,0} and {0,0,1}
            int hash = 1;
            const int SEED = 17;    // could be any prime number

            // The hash code (nor the evaluation of Equals) should NOT change during the period the object is used as a key for
            // a collection. Therefore the fields which are used to calculate the hash code must be immutable, i.e unchangeable
            hash = (hash * SEED) + this.FirstName.GetHashCode();
            hash = (hash * SEED) + this.MiddleName.GetHashCode();
            hash = (hash * SEED) + this.LastName.GetHashCode();
            hash = (hash * SEED) + this.SSN.GetHashCode();

            return hash;
        }

        public object Clone()
        {
            var cloning = new Student(this.FirstName, this.MiddleName, this.LastName, this.SSN)
            {
                Course = this.Course,
                EMail = this.EMail,
                PermanentAddress = this.PermanentAddress,
                TelNumber = this.TelNumber,
                Faculty = this.Faculty,
                Specialty = this.Specialty,
                University = this.University
            };

            return cloning;
        }

        public int CompareTo(Student st)
        {
            var thisStudentFullName = this.FirstName + this.MiddleName + this.LastName;
            var otherStudentFullName = st.FirstName + st.MiddleName + st.LastName;

            return thisStudentFullName.CompareTo(otherStudentFullName) == 0 ? this.SSN.CompareTo(st.SSN) : thisStudentFullName.CompareTo(otherStudentFullName);
        }
    }
}
