using System.Collections.Generic;

namespace Logic.Task2
{
    /// <summary>
    /// This class gives possibilities for extending work space of digit types.
    /// </summary>
    public static class DigitWorker
    {
        /// <summary>
        /// This method inserts bits from two values in new value by indexes.
        /// </summary>
        /// <param name="elements"> Elements for searching in </param>
        /// <param name="checkValue"> Value for searching elements in array </param>
        /// <returns> List of elements that contain check value </returns>
        public static List<T> Filter<T>(T[] elements, T checkValue) where T : struct
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

            return result;
        }
    }
}
