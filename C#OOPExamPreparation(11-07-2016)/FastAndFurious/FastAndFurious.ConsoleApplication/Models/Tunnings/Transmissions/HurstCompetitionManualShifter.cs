using FastAndFurious.ConsoleApplication.Models.Tunnings.Transmissions.Abstract;
using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Common.Enums;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Transmissions
{
    public class HurstCompetitionManualShifter : Transmission, ITransmission, ITunningPart, IAccelerateable, ITopSpeed, IWeightable, IValuable, IIdentifiable
    {
        private const decimal HurstCompetitionManualShifterPriceInUSADollars = 1999m;
        private const int HurstCompetitionManualShifterWeightInGrams = 6000;
        private const int HurstCompetitionManualShifterAccelerationBonus = 20;
        private const int HurstCompetitionManualShifterTopSpeedBonus = 0;

        public HurstCompetitionManualShifter() : 
            base(
                HurstCompetitionManualShifterPriceInUSADollars,
                HurstCompetitionManualShifterWeightInGrams,
                HurstCompetitionManualShifterAccelerationBonus,
                HurstCompetitionManualShifterTopSpeedBonus,
                TunningGradeType.MidGrade,
                TransmissionType.StockShifter
                )
        {
        }
    }
}
