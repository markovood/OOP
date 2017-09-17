using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class PowerCatalyst : Catalysts
    {
        private const int Power = 3;

        public PowerCatalyst() : 
            base(Power, 0, 0)
        {
        }
    }
}
