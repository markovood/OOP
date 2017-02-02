using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Models.Drivers.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Drivers
{
    public class Mia : Driver, IDriver, IIdentifiable
    {
        private const string name = "Mia";
        private const GenderType gender = GenderType.Female;

        public Mia() : 
            base(
                name,
                gender
                )
        {
        }
    }
}
