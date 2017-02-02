using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Models.Drivers.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Drivers
{
    public class LetiSpaghetti : Driver, IDriver, IIdentifiable
    {
        private const string name = "Leti Spaghetti";
        private const GenderType gender = GenderType.Female;

        public LetiSpaghetti() : 
            base(
                name,
                gender
                )
        {
        }
    }
}
