namespace GSMClass
{
    using System;

    public class Call
    {
        // fields
        private readonly DateTime date; // making this fields read-only, once a call is created it will be unchangeable

        private readonly TimeSpan time; // making this fields read-only, once a call is created it will be unchangeable
        private string dialedNumber;
        private int duration;

        // constructors
        public Call(string dialedNumber)
        {
            this.DialedNumber = dialedNumber;
            this.date = DateTime.MinValue;  // first initialization
            this.time = TimeSpan.Zero;  // first initialization
            this.Duration = 0;
        }

        public Call(string dialedNumber, DateTime date, TimeSpan time)
        {
            this.DialedNumber = dialedNumber;
            this.date = date;   // first initialization
            this.time = time;   // first initialization
            this.Duration = 0;
        }

        public Call(string dialedNumber, DateTime date, TimeSpan time, int duration)
        {
            this.DialedNumber = dialedNumber;
            this.date = date;   // first initialization
            this.time = time;   // first initialization
            this.Duration = duration;
        }

        // properties
        public string DialedNumber
        {
            get
            {
                return this.dialedNumber;
            }

            set
            {
                if (value == null || value == string.Empty)
                {
                    throw new ArgumentException("dialed number cannot be empty");
                }
                else
                {
                    this.dialedNumber = value;
                }
            }
        }

        public DateTime Date
        {
            get
            {
                return this.date;
            }
        }

        public TimeSpan Time
        {
            get
            {
                return this.time;
            }
        }

        public int Duration
        {
            get
            {
                return this.duration;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("duration cannot be less than zero");
                }
                else
                {
                    this.duration = value;
                }
            }
        }

        // methods
        public override string ToString()
        {
            string summary = "*CURRENT CALL SUMMARY*\r\nDialed number: {0} ,\r\nDate: {1}/{2:D2}/{3} ,\r\nTime: {4} ,\r\nDuration: {5} seconds\r\n\r\n";
            string description = string.Format(summary, this.DialedNumber, this.Date.Day, this.Date.Month, this.Date.Year, this.Time, this.Duration);
            return description;
        }
    }
}