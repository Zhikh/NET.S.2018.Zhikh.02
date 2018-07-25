using System;
using System.Collections.Generic;

namespace Logic.Task2
{
    /// <summary>
    /// This class gives possibilities for extending work space of digit types.
    /// </summary>
    public static class DigitWorker
    {
        #region Public methods
        /// <summary>
        /// This method finds all numbers that contain checkValue from array of elements (for search it uses division).
        /// </summary>
        /// <param name="elements"> Elements for searching in </param>
        /// <param name="checkValue"> Value for searching elements in array </param>
        /// <param name="predicate"> Rule for checking </param>
        /// <returns> List of elements that contain check value </returns>
        /// <exception cref="ArgumentNullException"> If elements null </exception>
        public static T[] FilterDivision<T>(T checkValue, IPredicate<T> predicate, params T[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException("Argument elements can't benull!");
            }

            var result = new List<T>();

            foreach (var element in elements)
            {
                if (predicate.IsMatch(element))
                {
                    result.Add(element);
                }
            }

            return result.ToArray();
        }

        /// <summary>
        /// This method finds all numbers that contain checkValue from array of elements (for search it uses division).
        /// </summary>
        /// <param name="elements"> Elements for searching in </param>
        /// <param name="checkValue"> Value for searching elements in array </param>
        /// <param name="predicate"> Rule for checking </param>
        /// <returns> List of elements that contain check value </returns>
        /// <exception cref="ArgumentNullException"> If elements null </exception>
        public static T[] FilterDivision<T>(T checkValue, Predicate<T> predicate, params T[] elements)
        {
            return FilterDivision(checkValue, new Nested<T>(predicate), elements);
        }

        /// <summary>
        /// This method finds all numbers that contain checkValue from array of elements (for search it uses String.Contains)
        /// </summary>
        /// <param name="elements"> Elements for searching in </param>
        /// <param name="checkValue"> Value for searching elements in array </param>
        /// <returns> List of elements that contain check value </returns>
        public static T[] FilterString<T>(T checkValue, T[] elements)
        {
            string checkString = checkValue.ToString();

            var result = new List<T>();

            foreach (var element in elements)
            {
                if (element.ToString().Contains(checkString))
                {
                    result.Add(element);
                }
            }

            return result.ToArray();
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
