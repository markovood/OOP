namespace MyExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary> Provides some useful extension methods for IEnumerable </summary>
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Sums all elements in the current IEnumerable collection
        /// </summary>
        /// <typeparam name="T">The type of the collection</typeparam>
        /// <param name="collection">The current IEnumerable collection</param>
        /// <returns>The sum of all elements in the specified type T</returns>
        public static T MySum<T>(this IEnumerable<T> collection)
        {
            T sum = default(T);

            foreach (var element in collection)
            {
                sum += (dynamic)element;
            }

            return sum;
        }

        /// <summary>
        /// Multiplies all elements in the current IEnumerable collection. Collection elements' type is limited to 'struct'
        /// </summary>
        /// <typeparam name="T">The type of the collection</typeparam>
        /// <param name="collection">The current collection</param>
        /// <returns>The product after the multiplication of all elements</returns>
        public static T MyProduct<T>(this IEnumerable<T> collection) where T : struct
        {
            T product = (dynamic)1;

            foreach (var element in collection)
            {
                product *= (dynamic)element;
            }

            return product;
        }

        /// <summary>
        /// Finds the minimal element in the current IEnumerable collection. The elements' type must implement IComparable
        /// </summary>
        /// <typeparam name="T">The type of the collection</typeparam>
        /// <param name="collection">The current collection</param>
        /// <returns>The minimal element</returns>
        public static T MyMin<T>(this IEnumerable<T> collection) where T : IComparable<T>
        {
            T min = collection.First();

            foreach (var element in collection)
            {
                if (element.CompareTo(min) < 0)
                {
                    min = element;
                }
            }

            return min;
        }

        /// <summary>
        /// Finds the maximal element in the current IEnumerable collection. The elements' type must implement IComparable
        /// </summary>
        /// <typeparam name="T">The type of the collection</typeparam>
        /// <param name="collection">The current collection</param>
        /// <returns>The maximal element</returns>
        public static T MyMax<T>(this IEnumerable<T> collection) where T : IComparable<T>
        {
            T max = collection.First();

            foreach (var element in collection)
            {
                if (element.CompareTo(max) > 0)
                {
                    max = element;
                }
            }

            return max;
        }

        /// <summary>
        /// Calculates the average of all elements in the current IEnumerable collection. Collection elements' type is limited to 'struct'
        /// </summary>
        /// <typeparam name="T">The type of the collection</typeparam>
        /// <param name="collection">The current IEnumerable collection</param>
        /// <returns>The average of all elements in the specified type T</returns>
        public static T MyAverage<T>(this IEnumerable<T> collection) where T : struct
        {
            T sum = default(T);
            int counter = 0;

            foreach (var element in collection)
            {
                sum += (dynamic)element;
                counter++;
            }

            return (dynamic)sum / counter;
        }
    }
}