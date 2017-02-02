using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Models.MotorVehicles.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.MotorVehicles
{
    public class NissanSkylineR34 : MotorVehicle, IMotorVehicle, IWeightable, IValuable, IAccelerateable, ITopSpeed, IIdentifiable
    {
        private const decimal NissanSkylineR34PriceInUSADollars = 45999m;
        private const int NissanSkylineR34WeightInGrams = 1850000;
        private const int NissanSkylineR34AccelerationBonus = 50;
        private const int NissanSkylineR34TopSpeedBonus = 280;

        public NissanSkylineR34() :
            base(
                NissanSkylineR34PriceInUSADollars,
                NissanSkylineR34WeightInGrams,
                NissanSkylineR34AccelerationBonus,
                NissanSkylineR34TopSpeedBonus
                )
        {
        }
    }
}
