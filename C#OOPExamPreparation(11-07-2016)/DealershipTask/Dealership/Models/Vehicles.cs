using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dealership.Contracts;
using Dealership.Common;
using Dealership.Common.Enums;
using Dealership.Models.ConstantsExtended;

namespace Dealership.Models
{
    public abstract class Vehicles : IVehicle
    {
        private string make;
        private string model;
        private decimal price;
        private VehicleType type;
        private int wheels;

        protected Vehicles(string make, string model, decimal price, VehicleType type)
        {
            this.Comments = new List<IComment>();
            this.Make = make;
            this.Model = model;
            this.Price = price;
            this.Type = type;

            switch (type)
            {
                case VehicleType.Motorcycle:
                    this.Wheels = (int)VehicleType.Motorcycle;
                    break;
                case VehicleType.Car:
                    this.Wheels = (int)VehicleType.Car;
                    break;
                case VehicleType.Truck:
                    this.Wheels = (int)VehicleType.Truck;
                    break;
            }
        }

        public IList<IComment> Comments { get; set; }

        public string Make
        {
            get
            {
                return this.make;
            }
            protected set
            {
                Validator.ValidateNull(
                    value,
                    string.Format(ExtendedConstants.nullErrorMsg, ExtendedConstants.parameterMake));
                Validator.ValidateIntRange(
                    value.Length,
                    Constants.MinMakeLength,
                    Constants.MaxMakeLength,
                    string.Format(Constants.StringMustBeBetweenMinAndMax, ExtendedConstants.parameterMake, Constants.MinMakeLength, Constants.MaxMakeLength));

                this.make = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            protected set
            {
                Validator.ValidateNull(
                    value,
                    string.Format(ExtendedConstants.nullErrorMsg, ExtendedConstants.parameterModel));
                Validator.ValidateIntRange(
                    value.Length,
                    Constants.MinModelLength,
                    Constants.MaxModelLength,
                    string.Format(Constants.StringMustBeBetweenMinAndMax, ExtendedConstants.parameterModel, Constants.MinModelLength, Constants.MaxModelLength));

                this.model = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            protected set
            {
                Validator.ValidateDecimalRange(
                    value,
                    Constants.MinPrice,
                    Constants.MaxPrice,
                    string.Format(Constants.NumberMustBeBetweenMinAndMax, ExtendedConstants.parameterPrice, Constants.MinPrice, Constants.MaxPrice));

                this.price = value;
            }
        }

        public VehicleType Type
        {
            get
            {
                return this.type;
            }
            private set
            {
                this.type = value;
            }
        }

        public int Wheels
        {
            get
            {
                return this.wheels;
            }
            protected set
            {
                Validator.ValidateIntRange(
                    value,
                    Constants.MinWheels,
                    Constants.MaxWheels,
                    string.Format(Constants.NumberMustBeBetweenMinAndMax, ExtendedConstants.parameterWheels, Constants.MinWheels, Constants.MaxWheels));

                this.wheels = value;
            }
        }

        public override string ToString()
        {
            StringBuilder printout = new StringBuilder();

            printout.AppendFormat("{0}:", this.Type.ToString()).AppendLine();
            printout.AppendFormat("  Make: {0}", this.Make).AppendLine();
            printout.AppendFormat("  Model: {0}", this.Model).AppendLine();
            printout.AppendFormat("  Wheels: {0}", this.Wheels).AppendLine();
            printout.AppendFormat("  Price: ${0}", this.Price).AppendLine();
            switch (this.Type)
            {
                case VehicleType.Motorcycle:
                    var vehicleAsMotorcycle = this as Motorcycle;
                    printout.AppendFormat("  Category: {0}", vehicleAsMotorcycle.Category).AppendLine();
                    break;
                case VehicleType.Car:
                    var vehicleAsCar = this as Car;
                    printout.AppendFormat("  Seats: {0}", vehicleAsCar.Seats).AppendLine();
                    break;
                case VehicleType.Truck:
                    var vehicleAsTruck = this as Truck;
                    printout.AppendFormat("  Weight Capacity: {0}t", vehicleAsTruck.WeightCapacity).AppendLine();
                    break;
            }

            printout.Append(this.Comments.Count > 0 ? AddCommentsToPrintout() : "    --NO COMMENTS--");

            return printout.ToString();
        }

        private string AddCommentsToPrintout()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("    --COMMENTS--");
            foreach (var comment in this.Comments)
            {
                sb.AppendLine(comment.ToString());
            }

            sb.Append("    --COMMENTS--");

            return sb.ToString();
        }
    }
}
