using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyEcosystem
{
    public class Zombie : Animal
    {
        private const int size = 3;
        private const int meatSize = 10;

        public Zombie(string name, Point location) : 
            base(name, location, size)
        {
        }

        public override int GetMeatFromKillQuantity()
        {
            this.IsAlive = true;
            return meatSize;
        }
    }
}
