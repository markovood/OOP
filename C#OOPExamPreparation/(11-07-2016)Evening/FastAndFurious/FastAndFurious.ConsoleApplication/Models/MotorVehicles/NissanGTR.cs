using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Models.MotorVehicles.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.MotorVehicles
{
    public class NissanGTR : MotorVehicle, IMotorVehicle, IWeightable, IValuable, IAccelerateable, ITopSpeed, IIdentifiable
    {
        private const decimal NissanGTRPriceInUSADollars = 125000m;
        private const int NissanGTRWeightInGrams = 1850000;
        private const int NissanGTRAccelerationBonus = 45;
        private const int NissanGTRTopSpeedBonus = 300;

        public NissanGTR() :
            base(
                NissanGTRPriceInUSADollars,
                NissanGTRWeightInGrams,
                NissanGTRAccelerationBonus,
                NissanGTRTopSpeedBonus
                )
        {
        }
    }
}
