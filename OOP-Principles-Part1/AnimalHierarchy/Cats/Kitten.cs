namespace AnimalHierarchy.Cats
{
    using System;
    using Animals;

    public class Kitten : Cat
    {
        private const string KITTEN_SEX = "female";

        public Kitten(string name, double age)
            : base(name, KITTEN_SEX, age)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Mrrrr");
            Console.Beep(10985, 1000);
        }
    }
}
