using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class Queen : InfestableUnit
    {
        private const int QueenBasePower = 1;
        private const int QueenBaseHealth = 30;
        private const int QueenBaseAggression = 1;

        public Queen(string id) :
            base(id, UnitClassification.Psionic, QueenBaseHealth, QueenBasePower, QueenBaseAggression)
        {
        }
    }
}
