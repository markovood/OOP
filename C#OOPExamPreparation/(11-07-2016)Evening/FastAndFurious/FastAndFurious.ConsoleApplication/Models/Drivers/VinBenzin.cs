using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Models.Drivers.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Drivers
{
    public class VinBenzin : Driver, IDriver, IIdentifiable
    {
        private const string name = "Vin Benzin";
        private const GenderType gender = GenderType.Male;

        public VinBenzin() : 
            base(
                name,
                gender
                )
        {
        }
    }
}
