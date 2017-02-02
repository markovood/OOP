using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Models.Drivers.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Drivers
{
    public class DominicRendeto : Driver, IDriver, IIdentifiable
    {
        private const string name = "Dominic Rendeto";
        private const GenderType gender = GenderType.Male;

        public DominicRendeto() : 
            base(
                name,
                gender
                )
        {
        }
    }
}
