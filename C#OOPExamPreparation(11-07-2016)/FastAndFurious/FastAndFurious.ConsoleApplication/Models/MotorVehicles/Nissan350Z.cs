using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Models.MotorVehicles.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.MotorVehicles
{
    public class Nissan350Z : MotorVehicle, IMotorVehicle, IWeightable, IValuable, IAccelerateable, ITopSpeed, IIdentifiable
    {
        private const decimal Nissan350ZPriceInUSADollars = 25999m;
        private const int Nissan350ZWeightInGrams = 1280000;
        private const int Nissan350ZAccelerationBonus = 55;
        private const int Nissan350ZTopSpeedBonus = 220;

        public Nissan350Z() :
            base(
                Nissan350ZPriceInUSADollars,
                Nissan350ZWeightInGrams,
                Nissan350ZAccelerationBonus,
                Nissan350ZTopSpeedBonus
                )
        {
        }
    }
}
