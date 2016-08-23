namespace MyTimer
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Creates a MyTimer object that can execute a delegate at a preset interval of time, for a preset duration
    /// </summary>
    public class MyTimer : Stopwatch
    {
        /// <summary>
        /// This is the watch that is responsible for the interval
        /// </summary>
        private readonly Stopwatch intervalWatch;

        /// <summary>
        /// This is the watch that is responsible for the duration
        /// </summary>
        private readonly Stopwatch durationWatch;

        /// <summary>
        /// Local variable that holds the interval of time in seconds
        /// </summary>
        private int interval;

        /// <summary>
        /// Local variable that holds the duration time in seconds
        /// </summary>
        private int duration;

        /// <summary>
        /// Initializes a new instance of the <see cref="MyTimer" /> class.
        /// </summary>
        /// <param name="interval">Represents the interval (in seconds) at which specified delegate will be invoked</param>
        /// <param name="duration">Represents the total time (in seconds) for which the delegate will be invoking</param>
        public MyTimer(int interval, int duration)
        {
            this.Interval = interval;
            this.Duration = duration;
            this.intervalWatch = new Stopwatch();
            this.durationWatch = new Stopwatch();
        }

        /// <summary>
        /// Gets or sets the time interval (in seconds) when the delegate will be invoked
        /// </summary>
        public int Interval
        {
            get
            {
                return this.interval;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Interval cannot be zero or less");
                }

                this.interval = value;
            }
        }

        /// <summary>
        /// Gets or sets the period of time that defines how long the delegate will be invoking
        /// </summary>
        public int Duration
        {
            get
            {
                return this.duration;
            }

            set
            {
                if (value <= this.Interval)
                {
                    throw new ArgumentException("Duration cannot be less than or equal to the interval");
                }

                this.duration = value;
            }
        }

        /// <summary>
        /// Invokes some delegate at preset interval for preset duration 
        /// </summary>
        /// <param name="action">The delegate to be invoked</param>
        public void Execute(Action action)
        {
            this.intervalWatch.Reset();
            this.durationWatch.Reset();
            this.intervalWatch.Start();
            this.durationWatch.Start();
            while (this.durationWatch.Elapsed.Seconds <= this.Duration)
            {
                if (this.intervalWatch.Elapsed.Seconds == this.Interval)
                {
                    action();
                    //// Console.WriteLine(this.durationWatch.Elapsed); // just for testing
                    this.intervalWatch.Restart();
                }
            }

            this.intervalWatch.Stop();
            this.durationWatch.Stop();
        }

        /// <summary>
        /// Invokes a delegate with one parameter at preset interval for preset duration 
        /// </summary>
        /// <typeparam name="T">The type of the passed parameter</typeparam>
        /// <param name="action">The delegate passed</param>
        /// <param name="arg1">The parameter of the passed delegate</param>
        public void Execute<T>(Action<T> action, T arg1)
        {
            this.intervalWatch.Reset();
            this.durationWatch.Reset();
            this.intervalWatch.Start();
            this.durationWatch.Start();
            while (this.durationWatch.Elapsed.Seconds <= this.Duration)
            {
                if (this.intervalWatch.Elapsed.Seconds == this.Interval)
                {
                    action(arg1);
                    //// Console.WriteLine(this.durationWatch.Elapsed); // just for testing
                    this.intervalWatch.Restart();
                }
            }

            this.intervalWatch.Stop();
            this.durationWatch.Stop();
        }
    }
}