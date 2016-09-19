namespace CustomExeptions
{
    using System;

    public class InvalidRangeException<T> : ApplicationException
        where T : struct
    {
        private const string ERROR_MESSAGE = "THE VALUE IS NOT WITHIN THE PROPER RANGE...!";

        public InvalidRangeException(T minValue, T maxValue)
            : base(ERROR_MESSAGE)
        {
            this.MinValue = minValue;
            this.MaxValue = maxValue;
        }

        public InvalidRangeException(string message, T minValue, T maxValue)
            : base(message)
        {
            this.MinValue = minValue;
            this.MaxValue = maxValue;
        }

        public InvalidRangeException(string message, T minValue, T maxValue, Exception innerException)
            : base(message, innerException)
        {
            this.MinValue = minValue;
            this.MaxValue = maxValue;
        }

        public T MinValue { get; private set; }

        public T MaxValue { get; private set; }
    }
}
