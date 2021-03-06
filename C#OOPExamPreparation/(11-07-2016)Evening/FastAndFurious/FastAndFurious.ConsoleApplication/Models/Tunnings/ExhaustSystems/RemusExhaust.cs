﻿using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Models.Tunnings.ExhaustSystems.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.ExhaustSystems
{
    public class RemusExhaust : Exhaust, IExhaust, ITunningPart, IAccelerateable, ITopSpeed, IWeightable, IValuable, IIdentifiable
    {
        private const decimal RemusExhaustPriceInUSADollars = 679m;
        private const int RemusExhaustWeightInGrams = 11500;
        private const int RemusExhaustAccelerationBonus = 8;
        private const int RemusExhaustTopSpeedBonus = 32;

        public RemusExhaust() : 
            base(
                RemusExhaustPriceInUSADollars,
                RemusExhaustWeightInGrams,
                RemusExhaustAccelerationBonus,
                RemusExhaustTopSpeedBonus,
                TunningGradeType.MidGrade,
                ExhaustType.StainlessSteel
                )
        {
        }
    }
}
