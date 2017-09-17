using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class Marine : Human
    {
        public Marine(string id) :
            base(id)
        {
            this.AddSupplement(new WeaponrySkill());
        }

        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            UnitInfo optimalAttackableUnit = new UnitInfo(null, UnitClassification.Unknown, 0, int.MaxValue, 0);
            
            if (attackableUnits.Count() > 1)
            {
                // If there is more than one such target, the marine picks the one with the highest Health
                optimalAttackableUnit = attackableUnits.OrderByDescending(x => x.Health).First();
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
    }
}
