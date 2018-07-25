using System;

namespace Logic.Task2
{
    public class IntPredicate : IPredicate<int>
    {
        private int _checkValue;

        public IntPredicate(int checkValue)
        {
            _checkValue = checkValue;
        }

        /// <summary>
        /// This method checks if checkValue in value.
        /// </summary>
        /// <param name="value"> Number for checking </param>
        /// <param name="_checkValue"> Numeral </param>
        /// <returns> If value contain checkValue return true, else - false </returns>
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
