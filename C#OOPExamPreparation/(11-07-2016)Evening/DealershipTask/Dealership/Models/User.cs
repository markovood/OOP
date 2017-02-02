using System;
using System.Collections.Generic;
using Dealership.Common.Enums;
using Dealership.Contracts;
using Dealership.Models.ConstantsExtended;
using Dealership.Common;
using System.Text;

namespace Dealership.Models
{
    public class User : IUser
    {
        private string firstName;
        private string lastName;
        private string userName;
        private string password;
        private Role role;
        private List<IVehicle> vehicles;

        public User(string username, string firstName, string lastName, string password, string role)
        {
            this.Username = username;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Password = password;
            switch (role.ToLower())
            {
                case "normal":
                    this.Role = Role.Normal;
                    break;
                case "vip":
                    this.Role = Role.VIP;
                    break;
                case "admin":
                    this.Role = Role.Admin;
                    break;
                default:
                    throw new ArgumentException("Role can be: normal, vip or admin");
            }

            this.vehicles = new List<IVehicle>();
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            protected set
            {
                Validator.ValidateNull(
                    value,
                    string.Format(ExtendedConstants.nullErrorMsg, ExtendedConstants.parameterFirstname));
                Validator.ValidateIntRange(
                    value.Length,
                    Constants.MinNameLength,
                    Constants.MaxNameLength,
                    string.Format(Constants.StringMustBeBetweenMinAndMax, ExtendedConstants.parameterFirstname, Constants.MinNameLength, Constants.MaxNameLength));

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            protected set
            {
                Validator.ValidateNull(
                    value,
                    string.Format(ExtendedConstants.nullErrorMsg, ExtendedConstants.parameterLastname));
                Validator.ValidateIntRange(
                    value.Length,
                    Constants.MinNameLength,
                    Constants.MaxNameLength,
                    string.Format(Constants.StringMustBeBetweenMinAndMax, ExtendedConstants.parameterLastname, Constants.MinNameLength, Constants.MaxNameLength));

                this.lastName = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }
            private set
            {
                Validator.ValidateNull(
                    value,
                    string.Format(Constants.InvalidSymbols, ExtendedConstants.parameterPassword));
                Validator.ValidateSymbols(
                    value,
                    Constants.PasswordPattern,
                    string.Format(Constants.InvalidSymbols, ExtendedConstants.parameterPassword));
                Validator.ValidateIntRange(
                    value.Length,
                    Constants.MinPasswordLength,
                    Constants.MaxPasswordLength,
                    string.Format(Constants.StringMustBeBetweenMinAndMax, ExtendedConstants.parameterPassword, Constants.MinPasswordLength, Constants.MaxPasswordLength));

                this.password = value;
            }
        }

        public Role Role
        {
            get
            {
                return this.role;
            }
            private set
            {
                this.role = value;
            }
        }

        public string Username
        {
            get
            {
                return this.userName;
            }
            private set
            {
                Validator.ValidateNull(
                    value,
                    string.Format(ExtendedConstants.nullErrorMsg, ExtendedConstants.parameterUsername));
                Validator.ValidateIntRange(
                    value.Length,
                    Constants.MinNameLength,
                    Constants.MaxNameLength,
                    string.Format(Constants.StringMustBeBetweenMinAndMax, ExtendedConstants.parameterUsername, Constants.MinNameLength, Constants.MaxNameLength));
                Validator.ValidateSymbols(
                    value,
                    Constants.UsernamePattern,
                    string.Format(Constants.InvalidSymbols, ExtendedConstants.parameterUsername));

                this.userName = value;
            }
        }

        public IList<IVehicle> Vehicles
        {
            get
            {
                return new List<IVehicle>(vehicles);
            }
        }

        public void AddComment(IComment commentToAdd, IVehicle vehicleToAddComment)
        {
            Validator.ValidateNull(commentToAdd, Constants.CommentCannotBeNull);
            Validator.ValidateNull(vehicleToAddComment, Constants.VehicleCannotBeNull);

            vehicleToAddComment.Comments.Add(commentToAdd);
        }

        public void AddVehicle(IVehicle vehicle)
        {
            Validator.ValidateNull(vehicle, Constants.VehicleCannotBeNull);

            if (this.Role == Role.Admin)
            {
                throw new ArgumentException(Constants.AdminCannotAddVehicles);
            }

            if (this.Role != Role.VIP && vehicles.Count >= 5)
            {
                throw new ArgumentException(string.Format(Constants.NotAnVipUserVehiclesAdd, Constants.MaxVehiclesToAdd));
            }

            this.vehicles.Add(vehicle);
        }

        public string PrintVehicles()
        {
            int serialNumber = 1;
            var printout = new StringBuilder();
            printout.AppendFormat("--USER {0}--", this.Username);

            if (this.vehicles.Count > 0)
            {
                foreach (var item in this.vehicles)
                {
                    printout.AppendLine();
                    printout.AppendFormat("{0}. {1}", serialNumber, item.ToString());
                    serialNumber++;
                }
            }
            else
            {
                printout.AppendFormat("{0}--NO VEHICLES--", Environment.NewLine);
            }

            return printout.ToString();
        }

        public void RemoveComment(IComment commentToRemove, IVehicle vehicleToRemoveComment)
        {
            if (commentToRemove.Author != this.Username)
            {
                throw new ArgumentException(Constants.YouAreNotTheAuthor);
            }

            vehicleToRemoveComment.Comments.Remove(commentToRemove);
        }

        public void RemoveVehicle(IVehicle vehicle)
        {
            this.vehicles.Remove(vehicle);
        }

        public override string ToString()
        {
            return string.Format(Constants.UserToString + ", Role: {3}", this.Username, this.FirstName, this.LastName, this.Role);
        }
    }


}
