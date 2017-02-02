using System;
using System.Collections.Generic;
using System.Linq;
using FastAndFurious.ConsoleApplication.Models.Common;
using FastAndFurious.ConsoleApplication.Common.Constants;
using FastAndFurious.ConsoleApplication.Common.Utils;
using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Common.Exceptions;

namespace FastAndFurious.ConsoleApplication.Models.MotorVehicles.Abstract
{
    public abstract class MotorVehicle : IdentifiedSubject, IMotorVehicle, IWeightable, IValuable, IAccelerateable, ITopSpeed, IIdentifiable
    {
        private bool inRace;
        private decimal price;
        private int weight;
        private int acceleration;
        private int topSpeed;
        private List<ITunningPart> tunningParts;

        public MotorVehicle(decimal price, int weight, int acceleration, int topSpeed)
        {
            this.InRace = false;
            this.price = price;
            this.weight = weight;
            this.acceleration = acceleration;
            this.topSpeed = topSpeed;
            this.tunningParts = new List<ITunningPart>();
        }

        public decimal Price
        {
            get
            {
                return this.price + this.TunningParts.Sum(x => x.Price);
            }
        }

        public int Weight
        {
            get
            {
                return this.weight + this.TunningParts.Sum(x => x.Weight);
            }
        }

        public int Acceleration
        {
            get
            {
                return this.acceleration + this.TunningParts.Sum(x => x.Acceleration);
            }
        }
        public int TopSpeed
        {
            get
            {
                return this.topSpeed + this.TunningParts.Sum(x => x.TopSpeed);
            }
        }
        public IEnumerable<ITunningPart> TunningParts
        {
            get
            {
                return new List<ITunningPart>(this.tunningParts);
            }
        }

        public bool InRace
        {
            get
            {
                return this.inRace;
            }

            set
            {
                this.inRace = value;
            }
        }

        public void AddTunning(ITunningPart part)
        {
            Validator.ValidateNull(part, GlobalConstants.CannotAddNullObjectsToCollectionExceptionMessage);

            // you cannot add more than 1 type of tunning part per car
            Validator.ValidateTypeDuplication(
                this.TunningParts,
                part,
                GlobalConstants.CannotAddMultiplePartsOfTheSameTypeToVehicleExceptionMessage,
                part.GetType().Name
                );

            // cannot add the same part twice
            Validator.ValidateCollectionIDs(
                this.TunningParts,
                part,
                GlobalConstants.CannotSignTheSameItemTwiceExceptionMessage,
                "part",
                "vehicle"
                );

            this.tunningParts.Add(part);
        }

        public TimeSpan Race(int trackLengthInMeters)
        {
            this.InRace = true;

            var topSpeedInMetersPerSecond = MetricUnitsConverter.GetMetersPerSecondFrom(this.TopSpeed);
            double timeToTopSpeedInSeconds = topSpeedInMetersPerSecond / this.Acceleration;
            var distanceTravelledWhileReachingTopSpeedInMeters = (this.Acceleration * Math.Pow(timeToTopSpeedInSeconds, 2));// / 2;
            if (trackLengthInMeters == distanceTravelledWhileReachingTopSpeedInMeters)
            {
                this.InRace = false;
                return TimeSpan.FromSeconds(timeToTopSpeedInSeconds);
            }
            else if (trackLengthInMeters > distanceTravelledWhileReachingTopSpeedInMeters)
            {
                var distanceToTheEndOfTrackAfterTopSpeedInMeters = trackLengthInMeters - distanceTravelledWhileReachingTopSpeedInMeters;
                double timeToTheEndOfTrackAfterTopSpeed = distanceToTheEndOfTrackAfterTopSpeedInMeters / topSpeedInMetersPerSecond;
                this.InRace = false;
                return TimeSpan.FromSeconds(timeToTopSpeedInSeconds + timeToTheEndOfTrackAfterTopSpeed);
            }
            else
            {
                var timeToFinish = Math.Sqrt((trackLengthInMeters) / this.Acceleration);// 2 *
                this.InRace = false;
                return TimeSpan.FromSeconds(timeToFinish);
            }

        }

        public bool RemoveTunning(ITunningPart part)
        {
            return this.tunningParts.Remove(part);
        }
    }
}
