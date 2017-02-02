using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Models.Tunnings.ExhaustSystems.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.ExhaustSystems
{
    public class BorlaExhaust : Exhaust, IExhaust, ITunningPart, IAccelerateable, ITopSpeed, IWeightable, IValuable, IIdentifiable
    {
        private const decimal BorlaExhaustPriceInUSADollars = 1299m;
        private const int BorlaExhaustWeightInGrams = 14600;
        private const int BorlaExhaustAccelerationBonus = 12;
        private const int BorlaExhaustTopSpeedBonus = 40;

        public BorlaExhaust() :
            base(
                BorlaExhaustPriceInUSADollars,
                BorlaExhaustWeightInGrams,
                BorlaExhaustAccelerationBonus,
                BorlaExhaustTopSpeedBonus,
                TunningGradeType.HighGrade,
                ExhaustType.CeramicCoated
                )
        {
        }
    }
}
