using FastAndFurious.ConsoleApplication.Models.Tunnings.Transmissions.Abstract;
using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Common.Enums;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Transmissions
{
    public class TWMPerformanceTransmission : Transmission, ITransmission, ITunningPart, IAccelerateable, ITopSpeed, IWeightable, IValuable, IIdentifiable
    {
        private const decimal TWMPerformanceTransmissionPriceInUSADollars = 1599m;
        private const int TWMPerformanceTransmissionWeightInGrams = 4799;
        private const int TWMPerformanceTransmissionAccelerationBonus = 15;
        private const int TWMPerformanceTransmissionTopSpeedBonus = 0;

        public TWMPerformanceTransmission() : 
            base(
                TWMPerformanceTransmissionPriceInUSADollars,
                TWMPerformanceTransmissionWeightInGrams,
                TWMPerformanceTransmissionAccelerationBonus,
                TWMPerformanceTransmissionTopSpeedBonus,
                TunningGradeType.LowGrade,
                TransmissionType.SemiManualShifter
                )
        {
        }
    }
}
