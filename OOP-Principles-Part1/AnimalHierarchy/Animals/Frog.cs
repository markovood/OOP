namespace AnimalHierarchy.Animals
{
    using System;

    public class Frog : Animal
    {
        public Frog(string name, string sex, double age)
            : base(name, sex, age)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("kvak-kvak");
            Console.Beep(1000, 1500);
        }
    }
}