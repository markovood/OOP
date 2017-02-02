using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Models.MotorVehicles.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.MotorVehicles
{
    public class MitsubishiEclipse : MotorVehicle, IMotorVehicle, IWeightable, IValuable, IAccelerateable, ITopSpeed, IIdentifiable
    {
        private const decimal MitsubishiEclipsePriceInUSADollars = 29999m;
        private const int MitsubishiEclipseWeightInGrams = 1400000;
        private const int MitsubishiEclipseAccelerationBonus = 24;
        private const int MitsubishiEclipseTopSpeedBonus = 230;

        public MitsubishiEclipse() :
            base(
                MitsubishiEclipsePriceInUSADollars,
                MitsubishiEclipseWeightInGrams,
                MitsubishiEclipseAccelerationBonus,
                MitsubishiEclipseTopSpeedBonus
                )
        {
        }
    }
}
