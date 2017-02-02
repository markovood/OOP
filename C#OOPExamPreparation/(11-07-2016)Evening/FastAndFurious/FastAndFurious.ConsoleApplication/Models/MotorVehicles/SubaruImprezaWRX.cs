using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Models.MotorVehicles.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.MotorVehicles
{
    public class SubaruImprezaWRX : MotorVehicle, IMotorVehicle, IWeightable, IValuable, IAccelerateable, ITopSpeed, IIdentifiable
    {
        private const decimal SubaruImprezaWRXPriceInUSADollars = 55999m;
        private const int SubaruImprezaWRXWeightInGrams = 1560000;
        private const int SubaruImprezaWRXAccelerationBonus = 35;
        private const int SubaruImprezaWRXTopSpeedBonus = 260;

        public SubaruImprezaWRX() :
            base(
                SubaruImprezaWRXPriceInUSADollars,
                SubaruImprezaWRXWeightInGrams,
                SubaruImprezaWRXAccelerationBonus,
                SubaruImprezaWRXTopSpeedBonus
                )
        {
        }
    }
}
