using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class Queen : InfestableUnit
    {
        public const int QueenBasePower = 1;
        public const int QueenBaseHealth = 30;
        public const int QueenBaseAggression = 1;

        public Queen(string id) :
            base(id, UnitClassification.Psionic, QueenBaseHealth, QueenBasePower, QueenBaseAggression)
        {
        }
    }
}
