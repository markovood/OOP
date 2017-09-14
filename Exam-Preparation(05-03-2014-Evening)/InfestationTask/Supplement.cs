using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public abstract class Supplement : ISupplement
    {
        public int AggressionEffect { get; protected set; }

        public int HealthEffect { get; protected set; }

        public int PowerEffect { get; protected set; }

        public void ReactTo(ISupplement otherSupplement)
        {
        }
    }
}
