namespace ArmyOfCreatures.Extended.Specialties
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Logic.Battles;
    using Logic.Specialties;

    public class DoubleAttackWhenAttacking : Specialty
    {
        private int rounds;

        public DoubleAttackWhenAttacking(int numberOfRounds)
        {
            if (numberOfRounds <= 0)
            {
                throw new ArgumentOutOfRangeException("numberOfRounds", "The number of rounds should be greater than 0");
            }

            this.rounds = numberOfRounds;
        }

        public override void ApplyWhenAttacking(
            ICreaturesInBattle attackerWithSpecialty, 
            ICreaturesInBattle defender)
        {
            if (attackerWithSpecialty == null)
            {
                throw new ArgumentNullException("attackerWithSpecialty");
            }

            if (defender == null)
            {
                throw new ArgumentNullException("defender");
            }

            if (this.rounds <= 0)
            {
                // Effect expires after fixed number of rounds
                return;
            }

            attackerWithSpecialty.CurrentAttack *= 2;
            this.rounds--;
        }

        public override string ToString()
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                "{0}({1})", 
                base.ToString(), 
                this.rounds);
        }
    }
}
