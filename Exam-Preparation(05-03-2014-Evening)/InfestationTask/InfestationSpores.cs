using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class InfestationSpores : Supplement
    {
        public const int Power = -1;
        public const int Aggression = 20;

        public InfestationSpores()
        {
            this.PowerEffect = Power;
            this.AggressionEffect = Aggression;
        }

        public override void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement is InfestationSpores)
            {
                this.PowerEffect = 0;
                this.AggressionEffect = 0;
            }
        }
    }
}
