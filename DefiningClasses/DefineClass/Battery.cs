namespace GSMClass
{
    using System;

    public enum BatteryType
    {
        Unknown,
        LiIon,
        LiPol,
        NiMH,
        NiCd
    }

    public class Battery
    {
        // fields
        private string model;
        private int hoursIdle;
        private int hoursTalk;
        private BatteryType batteryType;

        // constructors
        public Battery(int _hoursIdle, int _hoursTalk)
        {
            this.Model = null;
            this.HoursIdle = _hoursIdle;
            this.HoursTalk = _hoursTalk;
            this.BatteryType = BatteryType.Unknown;
        }

        public Battery(string _model, int _hoursIdle, int _hoursTalk)
        {
            this.Model = _model;
            this.HoursIdle = _hoursIdle;
            this.HoursTalk = _hoursTalk;
            this.BatteryType = BatteryType.Unknown;
        }

        public Battery(string _model, int _hoursIdle, int _hoursTalk, BatteryType _batteryType)
        {
            this.Model = _model;
            this.HoursIdle = _hoursIdle;
            this.HoursTalk = _hoursTalk;
            this.BatteryType = _batteryType;
        }

        // properties
        public string Model
        {
            get
            {
                return this.model;
            }

            set
            {
                this.model = value;
            }
        }

        public int HoursIdle
        {
            get
            {
                return this.hoursIdle;
            }

            set
            {
                if (value > 0)
                {
                    this.hoursIdle = value;
                }
                else
                {
                    throw new ArgumentException("hours idle cannot be zero");
                }
            }
        }

        public int HoursTalk
        {
            get
            {
                return this.hoursTalk;
            }

            set
            {
                if (value > 0)
                {
                    this.hoursTalk = value;
                }
                else
                {
                    throw new ArgumentException("hours talk cannot be zero");
                }
            }
        }

        public BatteryType BatteryType
        {
            get
            {
                return this.batteryType;
            }

            set
            {
                this.batteryType = value;
            }
        }

        // methods
        public override string ToString()
        {
            string summary = "*BATTERY CHARACTERISTICS*\r\nType: {0},\r\nModel: {1},\r\nHours idle: {2},\r\nHours talk: {3}\r\n\r\n";
            string description = string.Format(summary, this.BatteryType, this.Model, this.HoursIdle, this.HoursTalk);
            return description;
        }
    }
}