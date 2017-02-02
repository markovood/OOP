﻿using FastAndFurious.ConsoleApplication.Models.Tunnings.Intercoolers.Abstract;
using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Common.Enums;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Intercoolers
{
    public class ViperGenieIntercooler : Intercooler, IIntercooler, ITunningPart, IAccelerateable, ITopSpeed, IWeightable, IValuable, IIdentifiable
    {
        private const decimal ViperGenieIntercoolerPriceInUSADollars = 289m;
        private const int ViperGenieIntercoolerWeightInGrams = 5300;
        private const int ViperGenieIntercoolerAccelerationBonus = 0;
        private const int ViperGenieIntercoolerTopSpeedBonus = 25;

        public ViperGenieIntercooler() :
            base(
                ViperGenieIntercoolerPriceInUSADollars,
                ViperGenieIntercoolerWeightInGrams,
                ViperGenieIntercoolerAccelerationBonus,
                ViperGenieIntercoolerTopSpeedBonus,
                TunningGradeType.MidGrade,
                IntercoolerType.ChargeAirIntercooler
                )
        {
        }
    }
}
