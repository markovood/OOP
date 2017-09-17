using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class Queen : Unit
    {
        public const int QueenBasePower = 1;
        public const int QueenBaseHealth = 30;
        public const int QueenBaseAggression = 1;

        public Queen(string id) :
            base(id, UnitClassification.Psionic, QueenBaseHealth, QueenBasePower, QueenBaseAggression)
        {
        }

        public override Interaction DecideInteraction(IEnumerable<UnitInfo> units)
        {
            // TODO: make InfestableUnit : Unit class with overridden DecideInteraction, GetOptimalAttackableUnit, CanAttackUnit
            // TODO: make Queen & Parasite inherit from InfestableUnit
        }
    }
}
