namespace AnimalHierarchy.Animals
{
    using System;

    public class Dog : Animal
    {
        public Dog(string name, string sex, double age)
            : base(name, sex, age)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("bau-bau");
            Console.Beep(767, 1500);
        }
    }
}