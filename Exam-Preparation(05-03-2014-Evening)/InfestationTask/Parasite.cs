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

        public override Interaction DecideInteraction(IEnumerable<UnitInfo> units)
        {
            IEnumerable<UnitInfo> attackableUnits = units.Where((unit) => this.CanAttackUnit(unit));

            UnitInfo optimalAttackableUnit = GetOptimalAttackableUnit(attackableUnits);

            if (optimalAttackableUnit.Id != null)
            {
                return new Interaction(new UnitInfo(this), optimalAttackableUnit, InteractionType.Infest);
            }

            return Interaction.PassiveInteraction;
        }

        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            UnitInfo optimalAttackableUnit = new UnitInfo(null, UnitClassification.Unknown, 0, int.MaxValue, 0);

            if (attackableUnits.Count() > 1)
            {
                // If there are multiple such units, the Parasite picks the one with the least Health
                optimalAttackableUnit = attackableUnits.OrderBy(x => x.Health).First();
                return optimalAttackableUnit;
            }
            else if (attackableUnits.Count() == 1)
            {
                return attackableUnits.First();
            }
            else
            {
                return optimalAttackableUnit;
            }
        }

        protected override bool CanAttackUnit(UnitInfo unit)
        {
            bool attackUnit = false;
            if (this.Id != unit.Id)
            {
                attackUnit = true;
            }

            return attackUnit;
        }
    }
}
