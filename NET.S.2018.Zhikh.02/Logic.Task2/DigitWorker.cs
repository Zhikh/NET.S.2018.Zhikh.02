using System;
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
        /// <exception cref="ArgumentNullException"> If elements null </exception>
        public static int[] Filter(int checkValue, params int[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException("Argument elements can't benull!");
            }

            string checkString = checkValue.ToString();

            var result = new List<int>();

            foreach (var element in elements)
            {
                if (element.IsContain(checkValue))
                {
                    result.Add(element);
                }
            }

            return result.ToArray();
        }

        /// <summary>
        /// This method checks if checkValue in value.
        /// </summary>
        /// <param name="value"> Number for checking </param>
        /// <param name="checkValue"> Numeral </param>
        /// <returns> If value contain checkValue return true, else - false </returns>
        private static bool IsContain(this int value, int checkValue)
        {
            int wholePart = value / 10,
                modulo = value % 10;

            bool result = false;
            
            if ((modulo == checkValue) || (wholePart == checkValue))
            {
                result = true;
            }
            else
            {
                if (wholePart != 0)
                {
                    result = wholePart.IsContain(checkValue);
                }
            }

            return result;
            
        }
    }
}
