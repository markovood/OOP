using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Models.Common;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Abstract
{
    public abstract class TunningPart : IdentifiedSubject, ITunningPart, IAccelerateable, ITopSpeed, IWeightable, IValuable
    {
        private int acceleration;
        private int topSpeed;
        private int weight;
        private decimal price;
        private TunningGradeType gradeType;


        protected TunningPart(decimal price, int weight, int acceleration, int topSpeed, TunningGradeType gradeType)
        {
            this.price = price;
            this.weight = weight;
            this.acceleration = acceleration;
            this.topSpeed = topSpeed;
            this.gradeType = gradeType;
        }

        /// <summary>
        /// Gets the acceleration bonus of the current object measured in meters per second squared m/s^2
        /// </summary>
        public int Acceleration
        {
            get
            {
                return this.acceleration;
            }
        }

        public TunningGradeType GradeType
        {
            get
            {
                return this.gradeType;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
        }

        /// <summary>
        /// Get the Top Speed bonus of the current object measured in km/h
        /// </summary>
        public int TopSpeed
        {
            get
            {
                return this.topSpeed;
            }
        }

        /// <summary>
        /// Get the weight of the current object measured in grams
        /// </summary>
        public int Weight
        {
            get
            {
                return this.weight;
            }
        }
    }
}
