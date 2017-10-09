using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class Giant : Character, IFighter, IGatherer
    {
        private const int GiantOwner = 0;
        private const int AttackPts = 150;
        private const int DefensePts = 80;
        private const int HitPts = 200;
        private const int bonusPoints = 100;
        private bool isBonusAdded;

        public Giant(string name, Point position) : 
            base(name, position, GiantOwner)
        {
            this.AttackPoints = AttackPts;
            this.DefensePoints = DefensePts;
            this.HitPoints = HitPts;
            this.isBonusAdded = false;
        }

        public int AttackPoints { get; private set; }

        public int DefensePoints { get; private set; }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Stone)
            {
                if (this.isBonusAdded)
                {
                    return true;
                }

                this.AttackPoints += bonusPoints;
                this.isBonusAdded = true;
                return true;
            }

            return false;
        }
    }
}
