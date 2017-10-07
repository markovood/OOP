using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyEcosystem
{
    public class Lion : Animal, ICarnivore
    {
        private const int size = 6;

        public Lion(string name, Point location) : 
            base(name, location, size)
        {
        }

        public int TryEatAnimal(Animal animal)
        {
            if (animal == null)
            {
                return 0;
            }

            if (animal.Size > this.Size * 2)
            {
                return 0;
            }
            else
            {
                this.Size++;
                return animal.GetMeatFromKillQuantity();
            }
        }
    }
}
