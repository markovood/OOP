using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyEcosystem
{
    public class Boar : Animal, ICarnivore, IHerbivore
    {
        private const int size = 4;
        private const int biteSize = 2;

        public Boar(string name, Point location) : 
            base(name, location, size)
        {
        }

        public int EatPlant(Plant plant)
        {
            if (plant != null)
            {
                // TODO: may be if(plant.GetEatenQuantity(biteSize) > 0) { this.Size++; }
                this.Size++;
                return plant.GetEatenQuantity(biteSize);
            }

            return 0;
        }

        public int TryEatAnimal(Animal animal)
        {
            if (animal == null)
            {
                return 0;
            }

            if (animal.Size <= this.Size)
            {
                return animal.GetMeatFromKillQuantity();
            }
            else
            {
                return 0;
            }
        }
    }
}
