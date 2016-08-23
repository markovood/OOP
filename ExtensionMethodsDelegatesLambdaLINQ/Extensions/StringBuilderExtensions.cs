namespace MyExtensions
{
    using System;
    using System.Text;

    /// <summary>
    /// Extends the StringBuilder class methods, by providing functionality that is missing but is helpful
    /// </summary>
    public static class StringBuilderExtensions
    {
        /// <summary>
        /// The same functionality as the 'Substring' method in class String. Returns a new StringBuilder!!!
        /// </summary>
        /// <param name="strBldr">The StringBuilder from which a substring is going to be taken</param>
        /// <param name="index">The index at which collecting is going to start</param>
        /// <param name="length">The number of chars to be taken</param>
        /// <returns>Returns a new StringBuilder!!!</returns>
        public static StringBuilder Substring(this StringBuilder strBldr, int index, int length)
        {
            // bounds checking
            if (index < 0)
            {
                throw new ArgumentException("Index cannot be negative!!!");
            }

            if (index > strBldr.Length)
            {
                throw new ArgumentException("Index cannot be larger than length!!!");
            }

            if (length < 0)
            {
                throw new ArgumentException("Length cannot be negative!!!");
            }

            if (index > strBldr.Length - length)
            {
                throw new ArgumentException("Length parameter is out of range!!!");
            }

            // doesn't need to go through the loop
            if (index == 0 && length == strBldr.Length)
            {
                return strBldr;
            }

            var subStr = new StringBuilder();
            for (int i = index; i < index + length; i++)
            {
                subStr.Append(strBldr[i]);
            }

            return subStr;
        }
    }
}