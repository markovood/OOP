using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class HealthCatalyst : Catalysts
    {
        private const int Health = 3;

        public HealthCatalyst() : 
            base(0, Health, 0)
        {
        }
    }
}
