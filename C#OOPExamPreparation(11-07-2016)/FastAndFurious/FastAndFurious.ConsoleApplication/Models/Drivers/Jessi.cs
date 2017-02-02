using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Models.Drivers.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Drivers
{
    public class Jessi : Driver, IDriver, IIdentifiable
    {
        private const string name = "Jessi";
        private const GenderType gender = GenderType.Female;

        public Jessi() : 
            base(
                name,
                gender
                )
        {
        }
    }
}
