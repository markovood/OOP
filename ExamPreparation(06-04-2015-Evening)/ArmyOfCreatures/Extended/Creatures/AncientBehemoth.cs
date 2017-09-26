namespace ArmyOfCreatures.Extended.Creatures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Logic.Creatures;
    using Logic.Specialties;

    public class AncientBehemoth : Creature
    {
        public AncientBehemoth() : 
            base(19, 19, 40, 300)
        {
            this.AddSpecialty(new ReduceEnemyDefenseByPercentage(80m));
            this.AddSpecialty(new DoubleDefenseWhenDefending(5));
        }
    }
}
