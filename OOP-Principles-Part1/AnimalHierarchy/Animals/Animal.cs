namespace AnimalHierarchy.Animals
{
    using System;
    using System.Linq;
    using Interfaces;

    public abstract class Animal : ISound
    {
        private double age;

        private string name;

        private string sex;

        protected Animal(string name, string sex, double age)
        {
            this.Name = name;
            this.Sex = sex;
            this.Age = age;
        }

        public string Sex
        {
            get
            {
                return this.sex;
            }

            private set
            {
                if (value != "male" && value != "female")
                {
                    throw new ArgumentException("sex value is not valid, it can be only male/female".ToUpper());
                }

                this.sex = value;
            }
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
                    throw new ArgumentException("Name cannot be null or empty...".ToUpper());
                }

                this.name = value;
            }
        }

        public double Age
        {
            get
            {
                return this.age;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("age cannot be negative or 0...".ToUpper());
                }

                this.age = value;
            }
        }

        public static double AverageAge(Animal[] animalsCollection)
        {
            return animalsCollection.Average(animal => animal.Age);
        }

        public abstract void MakeSound();

        public override string ToString()
        {
            return string.Format("{0} {1}", this.GetType().Name, this.Name);
        }
    }
}