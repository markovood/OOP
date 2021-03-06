﻿using FastAndFurious.ConsoleApplication.Models.Tunnings.Abstract;
using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Common.Enums;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Transmissions.Abstract
{
    public abstract class Transmission : TunningPart, ITransmission, ITunningPart, IAccelerateable, ITopSpeed, IWeightable, IValuable, IIdentifiable
    {
        private TransmissionType transmissionType;

        public Transmission(decimal price, int weight, int acceleration, int topSpeed, TunningGradeType gradeType, TransmissionType transmissionType) :
            base(price, weight, acceleration, topSpeed, gradeType)
        {
            this.transmissionType = transmissionType;
        }

        public TransmissionType TransmissionType
        {
            get
            {
                return this.transmissionType;
            }
        }
    }
}
