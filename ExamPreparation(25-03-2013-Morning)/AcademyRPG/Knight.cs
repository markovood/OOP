using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class Knight : Character, IFighter
    {
        private const int KnightAttackPts = 100;
        private const int KnightDefensePts = 100;
        private const int KnightHitPts = 100;

        public Knight(string name, Point position, int owner) :
            base(name, position, owner)
        {
            this.AttackPoints = KnightAttackPts;
            this.DefensePoints = KnightDefensePts;
            this.HitPoints = KnightHitPts;
        }

        public int AttackPoints { get; private set; }

        public int DefensePoints { get; private set; }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != 0 && availableTargets[i].Owner != this.Owner)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
