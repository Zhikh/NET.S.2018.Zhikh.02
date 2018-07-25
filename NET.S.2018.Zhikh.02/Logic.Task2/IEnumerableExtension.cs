using System;
using System.Collections.Generic;

namespace Logic.Task2
{
    /// <summary>
    /// This class gives possibilities for extending work space of digit types.
    /// </summary>
    public static class IEnumerableExtension
    {
        #region Public methods
        /// <summary>
        /// This method finds all numbers that contain checkValue from array of elements (for search it uses division).
        /// </summary>
        /// <param name="elements"> Elements for searching in </param>
        /// <param name="predicate"> Rule for checking </param>
        /// <returns> List of elements that contain check value </returns>
        /// <exception cref="ArgumentNullException"> If elements null </exception>
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> elements, IPredicate<T> predicate)
        {
            if (elements == null)
            {
                throw new ArgumentNullException("Argument elements can't benull!");
            }

            foreach (var element in elements)
            {
                if (predicate.IsMatch(element))
                {
                    yield return element;
                }
            }
        }

        /// <summary>
        /// This method finds all numbers that contain checkValue from array of elements (for search it uses division).
        /// </summary>
        /// <param name="elements"> Elements for searching in </param>
        /// <param name="checkValue"> Value for searching elements in array </param>
        /// <param name="predicate"> Rule for checking </param>
        /// <returns> List of elements that contain check value </returns>
        /// <exception cref="ArgumentNullException"> If elements null </exception>
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> elements, Predicate<T> predicate)
        {
            return elements.Filter(new Nested<T>(predicate));
        }
        #endregion

        #region Private methods
        private class Nested<T> : IPredicate<T>
        {
            private Predicate<T> _callback;

            public Nested(Predicate<T> callback)
            {
                _callback = callback;
            }

            public bool IsMatch(T value)
            {
                return _callback(value);
            }
        }
        #endregion
    }
}
