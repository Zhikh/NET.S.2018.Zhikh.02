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
        /// <param name="contain"> Rule for checking </param>
        /// <returns> List of elements that contain check value </returns>
        /// <exception cref="ArgumentNullException"> If elements null </exception>
        public static T[] FilterDivision<T>(T checkValue, IContain<T> contain, params T[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException("Argument elements can't benull!");
            }

            var result = new List<T>();

            foreach (var element in elements)
            {
                if (contain.IsContain(element, checkValue))
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
        /// <param name="isContain"> Rule for checking </param>
        /// <returns> List of elements that contain check value </returns>
        /// <exception cref="ArgumentNullException"> If elements null </exception>
        public static T[] FilterDivision<T>(T checkValue, Func<T, T, bool> isContain, params T[] elements)
        {
            return FilterDivision(checkValue, new Nested<T>(isContain), elements);
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
        private class Nested<T> : IContain<T>
        {
            private Func<T, T, bool> _callback;

            public Nested(Func<T, T, bool> callback)
            {
                _callback = callback;
            }

            public bool IsContain(T element, T value)
            {
                return _callback(element, value);
            }
        }
        #endregion
    }
}
