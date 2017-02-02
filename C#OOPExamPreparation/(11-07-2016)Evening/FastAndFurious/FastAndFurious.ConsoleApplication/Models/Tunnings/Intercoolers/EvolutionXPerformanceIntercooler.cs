using FastAndFurious.ConsoleApplication.Models.Tunnings.Intercoolers.Abstract;
using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Common.Enums;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Intercoolers
{
    public class EvolutionXPerformanceIntercooler : Intercooler, IIntercooler, ITunningPart, IAccelerateable, ITopSpeed, IWeightable, IValuable, IIdentifiable
    {
        private const decimal EvolutionXPerformanceIntercoolerPriceInUSADollars = 499m;
        private const int EvolutionXPerformanceIntercoolerWeightInGrams = 4500;
        private const int EvolutionXPerformanceIntercoolerAccelerationBonus = -5;
        private const int EvolutionXPerformanceIntercoolerTopSpeedBonus = 40;

        public EvolutionXPerformanceIntercooler() :
            base(
                EvolutionXPerformanceIntercoolerPriceInUSADollars,
                EvolutionXPerformanceIntercoolerWeightInGrams,
                EvolutionXPerformanceIntercoolerAccelerationBonus,
                EvolutionXPerformanceIntercoolerTopSpeedBonus,
                TunningGradeType.HighGrade,
                IntercoolerType.AirToLiquidIntercooler
                )
        {
        }
    }
}
