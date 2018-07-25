using System;

namespace Logic.Task2
{
    public class IntPredicate : IPredicate<int>
    {
        private int _checkValue;

        /// <summary>
        /// Initialize StringPredicate object
        /// </summary>
        /// <param name="checkValue"> Value for checking </param>
        public IntPredicate(int checkValue)
        {
            _checkValue = checkValue;
        }

        /// <summary>
        /// Check the next: value is consist checkValue
        /// </summary>
        /// <param name="value"> Value for checking </param>
        /// <returns> If value has checkValue, it will be true, else - false </returns>
        public bool IsMatch(int value)
        {
            value = Math.Abs(value);

            int wholePart = value / 10,
                modulo = value % 10;

            bool result = false;

            do
            {
                if ((modulo == _checkValue) || (wholePart == _checkValue))
                {
                    result = true;
                }
                else
                {
                    if (wholePart != 0)
                    {
                        modulo = wholePart % 10;

                        wholePart /= 10;
                    }
                }
            }
            while ((!result) && (wholePart != 0));

            return result;
        }
    }
}
