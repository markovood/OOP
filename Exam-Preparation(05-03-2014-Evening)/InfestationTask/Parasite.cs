using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class Parasite : Unit
    {
        public const int ParasiteBasePower = 1;
        public const int ParasiteBaseHealth = 1;
        public const int ParasiteBaseAggression = 1;
        
        public Parasite(string id) :
            base(id, UnitClassification.Biological, ParasiteBaseHealth, ParasiteBasePower, ParasiteBaseAggression)
        {
        }
    }
}
