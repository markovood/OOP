using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyEcosystem
{
    public class Grass : Plant
    {
        private const int size = 2;

        public Grass(Point location) : 
            base(location, size)
        {
        }

        public override void Update(int time)
        {
            if (this.IsAlive)
            {
                // grow by 1 at each time unit
                this.Size += time;
            }
        }
    }
}
