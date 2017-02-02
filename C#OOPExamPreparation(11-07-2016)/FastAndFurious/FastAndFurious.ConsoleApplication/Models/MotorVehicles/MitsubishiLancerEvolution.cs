using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Models.MotorVehicles.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.MotorVehicles
{
    public class MitsubishiLancerEvolution : MotorVehicle, IMotorVehicle, IWeightable, IValuable, IAccelerateable, ITopSpeed, IIdentifiable
    {
        private const decimal MitsubishiLancerEvolutionPriceInUSADollars = 56999m;
        private const int MitsubishiLancerEvolutionWeightInGrams = 1780000;
        private const int MitsubishiLancerEvolutionAccelerationBonus = 20;
        private const int MitsubishiLancerEvolutionTopSpeedBonus = 300;

        public MitsubishiLancerEvolution() :
            base(
                MitsubishiLancerEvolutionPriceInUSADollars,
                MitsubishiLancerEvolutionWeightInGrams,
                MitsubishiLancerEvolutionAccelerationBonus,
                MitsubishiLancerEvolutionTopSpeedBonus
                )
        {
        }
    }
}
