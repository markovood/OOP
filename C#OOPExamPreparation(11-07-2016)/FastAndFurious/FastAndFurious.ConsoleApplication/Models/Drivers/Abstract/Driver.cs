using System;
using System.Collections.Generic;
using System.Linq;
using FastAndFurious.ConsoleApplication.Common.Constants;
using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Common.Utils;
using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Models.Common;

namespace FastAndFurious.ConsoleApplication.Models.Drivers.Abstract
{
    public abstract class Driver : IdentifiedSubject, IDriver
    {
        private string name;
        private GenderType gender;
        private ICollection<IMotorVehicle> vehicles;
        private IMotorVehicle activeVehicle;

        public Driver(string name, GenderType gender)
        {
            this.name = name;
            this.gender = gender;
            this.vehicles = new List<IMotorVehicle>();
            this.activeVehicle = null;
        }

        public IMotorVehicle ActiveVehicle
        {
            get
            {
                return this.activeVehicle;
            }
        }

        public GenderType Gender
        {
            get { return this.gender; }
        }

        public string Name
        {
            get { return this.name; }
        }

        public IEnumerable<IMotorVehicle> Vehicles
        {
            get
            {
                return this.vehicles;
            }
        }

        public void AddVehicle(IMotorVehicle vehicle)
        {
            Validator.ValidateNull(vehicle, GlobalConstants.CannotAddNullObjectsToCollectionExceptionMessage);

            // drivers are allowed to drive only one car at a time
            Validator.ValidateCollectionIDs(
                this.Vehicles,
                vehicle,
                GlobalConstants.DriverCannotBeAssignedAsOwnerToVehicleMoreThanOnceExceptionMessage,
                vehicle.GetType().BaseType.Name
                );

            this.vehicles.Add(vehicle);
        }

        public bool RemoveVehicle(IMotorVehicle vehicle)
        {
            return this.vehicles.Remove(vehicle);
        }

        public void SetActiveVehicle(IMotorVehicle vehicle)
        {
            if (vehicle == null)
            {
                throw new ArgumentNullException(GlobalConstants.CannotSetNullObjectAsActiveVehicleExceptionMessage);
            }
            
            if (vehicle.InRace)
            {
                throw new ArgumentException(GlobalConstants.CannotSetForeignVehicleAsActiveExceptionMessage);
            }

            this.activeVehicle = vehicle;
        }
    }
}
