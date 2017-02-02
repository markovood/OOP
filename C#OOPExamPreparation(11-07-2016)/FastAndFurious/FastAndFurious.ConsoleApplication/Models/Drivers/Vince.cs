using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Models.Drivers.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Drivers
{
    public class Vince : Driver, IDriver, IIdentifiable
    {
        private const string name = "Vince";
        private const GenderType gender = GenderType.Male;

        public Vince() : 
            base(
                name,
                gender
                )
        {
        }
    }
}
