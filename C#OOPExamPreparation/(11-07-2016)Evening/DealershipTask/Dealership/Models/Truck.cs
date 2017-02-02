using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dealership.Models.ConstantsExtended;
using Dealership.Common;
using Dealership.Common.Enums;
using Dealership.Contracts;

namespace Dealership.Models
{
    public class Truck : Vehicles, ITruck, IVehicle
    {
        private int weightCapacity;

        public Truck(string make, string model, decimal price, VehicleType type, int capacity) :
            base(make, model, price, type)
        {
            this.WeightCapacity = capacity;
        }

        public int WeightCapacity
        {
            get
            {
                return this.weightCapacity;
            }
            private set
            {
                Validator.ValidateIntRange(
                    value,
                    Constants.MinCapacity,
                    Constants.MaxCapacity,
                    string.Format(Constants.NumberMustBeBetweenMinAndMax, ExtendedConstants.parameterWeight, Constants.MinCapacity, Constants.MaxCapacity));

                this.weightCapacity = value;
            }
        }
    }


}
