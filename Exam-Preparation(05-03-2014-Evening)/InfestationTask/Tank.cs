using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class Tank : Unit
    {
        public const int TankBasePower = 25;
        public const int TankBaseHealth = 20;
        public const int TankBaseAggression = 25;
        public Tank(string id) : 
            base(id, UnitClassification.Mechanical, TankBaseHealth, TankBasePower, TankBaseAggression)
        {
        }
    }
}
