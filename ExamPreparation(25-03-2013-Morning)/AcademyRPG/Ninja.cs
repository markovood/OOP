using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class Ninja : Character, IFighter, IGatherer
    {
        private const int AttackPts = 0;
        private const int DefensePts = int.MaxValue;
        private const int HitPts = 1;

        public Ninja(string name, Point position, int owner) :
            base(name, position, owner)
        {
            this.AttackPoints = AttackPts;
            this.HitPoints = HitPts;
        }

        public int AttackPoints { get; private set; }

        public int DefensePoints
        {
            get
            {
                return DefensePts;
            }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            availableTargets.OrderByDescending(t => t.HitPoints).ToList();

            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != 0 && availableTargets[i].Owner != this.Owner)
                {
                    return i;
                }
            }

            return -1;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Lumber)
            {
                this.AttackPoints += resource.Quantity;
                return true;
            }

            if (resource.Type == ResourceType.Stone)
            {
                this.AttackPoints += resource.Quantity * 2;
                return true;
            }

            return false;
        }
    }
}
