using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dealership.Models.ConstantsExtended;
using Dealership.Common.Enums;
using Dealership.Contracts;
using Dealership.Common;

namespace Dealership.Models
{


    public class Motorcycle : Vehicles, IMotorcycle, IVehicle
    {
        private string category;

        public Motorcycle(string make, string model, decimal price, VehicleType type, string category) :
            base(make, model, price, type)
        {
            this.Category = category;
        }

        public string Category
        {
            get
            {
                return this.category;
            }
            private set
            {
                Validator.ValidateNull(
                    value,
                    string.Format(ExtendedConstants.nullErrorMsg, ExtendedConstants.parameterCategory));
                Validator.ValidateIntRange(
                    value.Length,
                    Constants.MinCategoryLength,
                    Constants.MaxCategoryLength, 
                    string.Format(Constants.StringMustBeBetweenMinAndMax,ExtendedConstants.parameterCategory, Constants.MinCategoryLength, Constants.MaxCategoryLength));

                this.category = value;
            }
        }
    }


}
