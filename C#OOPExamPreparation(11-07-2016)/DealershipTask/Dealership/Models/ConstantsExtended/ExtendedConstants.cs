using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Models.ConstantsExtended
{
    public class ExtendedConstants
    {
        public const string nullErrorMsg = "{0} cannot be NULL!";

        // User.cs
        public const string parameterUsername = "Username";
        public const string parameterPassword = "Password";
        public const string parameterFirstname = "Firstname";
        public const string parameterLastname = "Lastname";

        // Vehicle.cs
        public const string parameterMake = "Make";
        public const string parameterModel = "Model";
        public const string parameterPrice = "Price";
        public const string parameterWheels = "Wheels";

        // Car.cs
        public const string parameterSeats = "Seats";

        // Motorcycle.cs
        public const string parameterCategory = "Category";

        // Truck.cs
        public const string parameterWeight = "Weight capacity";

        // Comment.cs
        public const string parameterContent = "Content";
    }
}
