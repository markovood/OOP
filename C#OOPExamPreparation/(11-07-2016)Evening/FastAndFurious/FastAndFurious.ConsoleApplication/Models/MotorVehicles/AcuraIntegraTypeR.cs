using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Models.MotorVehicles.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.MotorVehicles
{
    public class AcuraIntegraTypeR : MotorVehicle, IMotorVehicle, IWeightable, IValuable, IAccelerateable, ITopSpeed, IIdentifiable
    {
        private const decimal AcuraIntegraTypeRPriceInUSADollars = 24999m;
        private const int AcuraIntegraTypeRWeightInGrams = 1700000;
        private const int AcuraIntegraTypeRAccelerationBonus = 15;
        private const int AcuraIntegraTypeRTopSpeedBonus = 200;

        public AcuraIntegraTypeR() :
            base(
                AcuraIntegraTypeRPriceInUSADollars,
                AcuraIntegraTypeRWeightInGrams,
                AcuraIntegraTypeRAccelerationBonus,
                AcuraIntegraTypeRTopSpeedBonus
                )
        {
        }
    }
}
