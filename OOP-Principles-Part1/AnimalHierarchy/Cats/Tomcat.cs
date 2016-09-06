namespace AnimalHierarchy.Cats
{
    using System;
    using Animals;

    public class Tomcat : Cat
    {
        private const string TOMCAT_SEX = "male";

        public Tomcat(string name, double age)
            : base(name, TOMCAT_SEX, age)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Miauu");
            Console.Beep(3700, 1000);
        }
    }
}
