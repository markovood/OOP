namespace Person_CTS
{
    using System;

    public class Person
    {
        private string name;

        private int? age;

        public Person(string name)
        {
            this.Name = name;
            this.Age = null;
        }

        public Person(string name, int? age)
        {
            this.Name = name;
            this.Age = age;
        }
        
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ApplicationException("Name cannot be null or empty");
                }

                this.name = value;
            }
        }

        public int? Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (value < 0)
                {
                    throw new ApplicationException("Age cannot be negative...!");
                }

                this.age = value;
            }
        }

        public override string ToString()
        {
            return this.Age == null ? this.Name + " <unspecified>" : this.Name + " " + this.Age;
        }
    }
}
