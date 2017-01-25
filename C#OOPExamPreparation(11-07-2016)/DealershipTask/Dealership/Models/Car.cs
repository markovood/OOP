using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dealership.Models.ConstantsExtended;
using Dealership.Contracts;
using Dealership.Common;
using Dealership.Common.Enums;

namespace Dealership.Models
{
    public class Car : Vehicles, ICar, IVehicle
    {
        private int seats;

        public Car(string make, string model, decimal price, VehicleType type, int numberOfSeats) :
            base(make, model, price, type)
        {
            this.Seats = numberOfSeats;
        }

        public int Seats
        {
            get
            {
                return this.seats;
            }
            private set
            {
                Validator.ValidateIntRange(
                    value, 
                    Constants.MinSeats, 
                    Constants.MaxSeats, 
                    string.Format(Constants.NumberMustBeBetweenMinAndMax,ExtendedConstants.parameterSeats, Constants.MinSeats, Constants.MaxSeats));

                this.seats = value;
            }
        }
    }
}
